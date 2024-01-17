import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';

import { API_URL, STORAGE_KEY, SignInData } from './auth.service';
import { JwtPayload, jwtDecode } from 'jwt-decode';

export interface SignUpData {
  email: string;
  username: string;
  password: string;
  passwordConfirmation: string;
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private colaborator: BehaviorSubject<SignInData | null | undefined> =
    new BehaviorSubject<SignInData | null | undefined>(undefined);

  private http = inject(HttpClient)

  signUp(register: SignUpData): Observable<SignInData> {
    return this.http.post(`${API_URL}/signUp`, register)
      .pipe(
        map((response: any) => {
          console.log('API response :', response)
          localStorage.setItem(STORAGE_KEY, response.data.accessToken)

          const decoded = jwtDecode<JwtPayload>(response.data.accessToken);
          const result: SignInData = {
            data: {
              accessToken: response.data.accessToken,
              id: decoded.sub!,
            },
          }
          this.colaborator.next(result)
          return result
        })
      )
  }
}
