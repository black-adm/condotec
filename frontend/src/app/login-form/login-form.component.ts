import { Component, inject } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner'
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
})
export class LoginFormComponent {
  showPassword = false
  showPasswordIcon = false

  private spinner = inject(NgxSpinnerService)
  private formBuilderService =  inject(FormBuilder)
  private authService =  inject(AuthService)
  private router =  inject(Router)

  protected form = this.formBuilderService.group({
    username: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)],],
    password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(40)],]
  });

  error = ''

  toggleShowPassword() {
    this.showPassword = !this.showPassword
    if (this.showPassword) this.showPasswordIcon = true
    else this.showPasswordIcon = !this.showPasswordIcon;
  }

  onSubmit() {
    const username = this.form.get('username')?.value;
    const password = this.form.get('password')?.value;

    if (username && password) {
      this.spinner.show()

      this.authService.signIn(username, password).subscribe(
        () => {
          this.router.navigateByUrl('/dashboard');
        }
      );

      this.spinner.hide()
    }
    (error: string) => {
      console.log(error);
      this.error = 'Erro ao realizar login!';
    }
  }
}
