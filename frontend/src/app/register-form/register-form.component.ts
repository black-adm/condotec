import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss']
})
export class RegisterFormComponent implements OnInit {
  form: FormGroup

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.form = this.formBuilder.group({
      personalData: this.formBuilder.group({
        firstName: '',
        lastName: '',
        cpf: '',
      }),
      address: this.formBuilder.group({
        postalCode: '',
        streetAddress: '',
        complement: '' || null,
        city: '',
        uf: '',
      }),
      personalContact: this.formBuilder.group({
        email: '',
        phone: '',
      }),
      credentials: this.formBuilder.group({
        username: '',
        password: '',
        passwordConfirmation: '',
      })
    })
  }

  getPersonalData(): FormGroup {
    return this.form.get('personalData') as FormGroup
  }

  getAddress(): FormGroup {
    return this.form.get('address') as FormGroup
  }

  getPersonalContact(): FormGroup {
    return this.form.get('personalContact') as FormGroup
  }
  getCredentials(): FormGroup {
    return this.form.get('credentials') as FormGroup
  }
}
