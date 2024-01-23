import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { JwtPayload, jwtDecode } from 'jwt-decode';
import { BehaviorSubject, map } from 'rxjs';

export const STORAGE_KEY = 'ACCESS_TOKEN'
export const API_URL = 'http://172.26.0.3:8080/api/v1'

export interface ResponseLoginProps {
  data: {
    accessToken: string,
    id: string,
  }
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private colaborator: BehaviorSubject<ResponseLoginProps | null | undefined>
    = new BehaviorSubject<ResponseLoginProps | null | undefined>(undefined)

  private http = inject(HttpClient)

  getColaborator() {
    const token = localStorage.getItem(STORAGE_KEY)

    if(token) {
      const decodedToken = jwtDecode<JwtPayload>(token)
      const res: ResponseLoginProps = {
        data : {
          accessToken: token,
          id: decodedToken.sub!
        }
      }
      this.colaborator.next(res)
    }
    this.colaborator.next(null)
  }

  signIn(username: string, password: string) {
    return this.http
      .post(`${API_URL}/login`, { username, password })
      .pipe(
        map((response: any) => {
          console.log('Api response :', response)
          localStorage.setItem(STORAGE_KEY, response.data.accessToken)

          const decoded = jwtDecode<JwtPayload>(response.data.accessToken);
            const result: ResponseLoginProps = {
              data: {
                accessToken: response.accessToken,
                id: decoded.sub!
              }
            };
            this.colaborator.next(result);
            return result;
        })
      )
  }
}
