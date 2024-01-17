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
        username: ['', [Validators.required, Validators.min(3), Validators.max(20)]],
        password: ['', [Validators.required, Validators.min(4), Validators.max(40)]],
        passwordConfirmation: ['', [Validators.required, Validators.min(4), Validators.max(30)]],
      }),
      personalData: this.formBuilderService.group({
        firstName: ['', [Validators.required, Validators.min(3), Validators.max(30)]],
        lastName: ['', [Validators.required, Validators.min(3), Validators.max(40)]],
        phone: ['', [Validators.required, Validators.min(10), Validators.max(11)]],
        cpf: ['', [Validators.required, Validators.min(11), Validators.max(11)]],
      }),
      address: this.formBuilderService.group({
        postalCode: ['', [Validators.required, Validators.min(8), Validators.max(8)]],
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
