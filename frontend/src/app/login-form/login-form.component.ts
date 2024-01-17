import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService, Colaborator } from '../services/auth.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
})
export class LoginFormComponent {

  private formBuilderService =  inject(FormBuilder)
  private authService =  inject(AuthService)
  private router =  inject(Router)

  protected form = this.formBuilderService.group({
    username: [
      '', [Validators.required, Validators.minLength(3), Validators.maxLength(20)],
    ],
    password: [
      '', [Validators.required, Validators.minLength(4), Validators.maxLength(40)],
    ]
  });
  error = ''

  onSubmit() {
    const username = this.form.get('username')?.value;
    const password = this.form.get('password')?.value;

    if (username && password) {
      this.authService.signIn(username, password).subscribe(
        () => {
          this.router.navigateByUrl('/dashboard');
        }
      );
    }
    (error: string) => {
      console.log(error);
      this.error = 'Erro ao realizar login!';
    }
  }
}
