import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { RegisterFormComponent } from '../register-form.component';

@Component({
  selector: 'app-personal-data-form',
  templateUrl: './personal-data-form.component.html',
  styleUrls: ['./personal-data-form.component.scss']
})
export class PersonalDataFormComponent implements OnInit {
  form!: FormGroup

  constructor(private registerForm: RegisterFormComponent) {}

  ngOnInit() {
    this.form = this.registerForm.getPersonalData()
  }
}
