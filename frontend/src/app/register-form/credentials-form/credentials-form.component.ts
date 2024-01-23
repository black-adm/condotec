import { Component, OnInit, inject } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { RegisterFormComponent } from '../register-form.component';
import { RegisterService, RegisterDataProps } from 'src/app/services/register.service';
import { StepperService } from 'src/app/services/stepper.service';

@Component({
  selector: 'app-credentials-form',
  templateUrl: './credentials-form.component.html',
})
export class CredentialsFormComponent implements OnInit {
  form!: FormGroup
  error = ''
  showPassword = false
  showPasswordIcon = false

  private registerForm = inject(RegisterFormComponent)
  private registerService = inject(RegisterService)
  private router = inject(Router)
  private stepperService = inject(StepperService)

  ngOnInit() {
    this.form = this.registerForm.getCredentials()
    this.stepperService.setCurrentStep(1);
  }

  toggleShowPassword() {
    this.showPassword = !this.showPassword
    if (this.showPassword) this.showPasswordIcon = true
    else this.showPasswordIcon = !this.showPasswordIcon;
  }

  onSubmit() {
    const register: RegisterDataProps = this.form.getRawValue();

    this.registerService.signUp(register).subscribe({
      next: (response) => {
        console.log('Token de acesso:', response.data.accessToken);
        this.router.navigateByUrl('../dados-pessoais');
      },
      error: (error) => {
        console.error('Erro durante o cadastro:', error);
        this.error = 'Erro ao realizar cadastro de usuário!';
      }
    });
  }

}
