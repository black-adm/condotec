import { Component, OnInit, inject } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { RegisterFormComponent } from '../register-form.component';

@Component({
  selector: 'app-personal-data-form',
  templateUrl: './personal-data-form.component.html',
})
export class PersonalDataFormComponent implements OnInit {
  form!: FormGroup

  private registerForm = inject(RegisterFormComponent)

  ngOnInit() {
    this.form = this.registerForm.getPersonalData()
  }
}
