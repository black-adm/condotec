import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
})
export class RegisterFormComponent implements OnInit {
  form!: FormGroup

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.form = this.formBuilder.group({
      credentials: this.formBuilder.group({
        email: '',
        username: '',
        password: '',
        passwordConfirmation: '',
      }),
      personalData: this.formBuilder.group({
        firstName: '',
        lastName: '',
        phone: '',
        cpf: '',
      }),
      address: this.formBuilder.group({
        postalCode: '',
        streetAddress: '',
        complement: '' || null,
        city: '',
        uf: '',
      })
    })
  }

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
