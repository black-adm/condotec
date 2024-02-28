import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';

import { JwtPayload, jwtDecode } from 'jwt-decode';
import { API_URL, AuthenticationProps, STORAGE_KEY } from './auth.service';

export interface RegisterDataProps {
  email: string;
  username: string;
  password: string;
  passwordConfirmation: string;
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private colaborator: BehaviorSubject<AuthenticationProps | null | undefined> =
    new BehaviorSubject<AuthenticationProps | null | undefined>(undefined);

  private http = inject(HttpClient)

  signUp(register: RegisterDataProps): Observable<AuthenticationProps> {
    return this.http.post(`${API_URL}/signUp`, register)
      .pipe(
        map((response: any) => {
          try {
            console.log('API response :', response)
            localStorage.setItem(STORAGE_KEY, response.data.accessToken)

            const decoded = jwtDecode<JwtPayload>(response.data.accessToken);
            const result: AuthenticationProps = {
              data: {
                accessToken: response.data.accessToken,
                id: decoded.sub!,
              },
            }
            this.colaborator.next(result)
            return result
          } catch (error) {
            throw new Error('Erro ao registrar usuário!')
          }
        })
      )
  }
}
