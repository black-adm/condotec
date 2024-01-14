import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { RegisterFormComponent } from '../register-form.component';

@Component({
  selector: 'app-address-form',
  templateUrl: './address-form.component.html',
})
export class AddressFormComponent implements OnInit {
  form!: FormGroup

  constructor(private registerForm: RegisterFormComponent) {}

  ngOnInit() {
    this.form = this.registerForm.getAddress()
  }
}
