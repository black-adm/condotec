import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
})
export class LoginFormComponent {

  private formBuilderService = inject(FormBuilder)

  protected form = this.formBuilderService.group({
    email: ['', Validators.required,Validators.email],
    password: ['', Validators.required, Validators.min(4)]
  })
}
