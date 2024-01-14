import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { RegisterFormComponent } from '../register-form.component';

@Component({
  selector: 'app-credentials-form',
  templateUrl: './credentials-form.component.html',
})
export class CredentialsFormComponent implements OnInit {
  form!: FormGroup

  constructor(private registerForm: RegisterFormComponent) {}

  ngOnInit() {
    this.form = this.registerForm.getCredentials()
  }
}
