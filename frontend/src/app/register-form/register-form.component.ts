import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
})
export class RegisterFormComponent {

    private formBuilderService = inject(FormBuilder)

    protected form = this.formBuilderService.group({
      credentials: this.formBuilderService.group({
        email: ['', [Validators.required,Validators.email]],
        username: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
        password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(40)]],
        passwordConfirmation: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(30)]],
      }),
      personalData: this.formBuilderService.group({
        firstName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
        lastName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
        phone: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(11)]],
        cpf: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      }),
      address: this.formBuilderService.group({
        postalCode: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(8)]],
        streetAddress: '',
        complement: '' || null,
        city: '',
        uf: '',
      })
    })

  getCredentials(): FormGroup {
    return this.form.get('credentials') as FormGroup
  }

  getPersonalData(): FormGroup {
    return this.form.get('personalData') as FormGroup
  }

  getAddress(): FormGroup {
    return this.form.get('address') as FormGroup
  }
}
