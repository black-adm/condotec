import { Component, OnInit, inject } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { RegisterFormComponent } from '../register-form.component';
import { RegisterService, SignUpData } from 'src/app/services/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-credentials-form',
  templateUrl: './credentials-form.component.html',
})
export class CredentialsFormComponent implements OnInit {
  form!: FormGroup
  error = ''

  private registerForm = inject(RegisterFormComponent)
  private registerService = inject(RegisterService)
  private router = inject(Router)

  ngOnInit() {
    this.form = this.registerForm.getCredentials()
  }

  onSubmit() {
    const register: SignUpData = this.form.getRawValue()

    this.registerService.signUp(register).subscribe({
      next: () => {
        this.router.navigateByUrl('../dados-pessoais')
      },
      error: (e) => {
        console.log(e)
        this.error = 'Erro ao realizar cadastro de usuário!'
      }
    })
  }
}
