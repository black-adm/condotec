import { Component, OnInit, inject } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { RegisterFormComponent } from '../register-form.component';

export interface PersonalProps {
  firstName: string,
  lastName: string,
  cpf: string,
  phone: string
}

@Component({
  selector: 'app-personal-data-form',
  templateUrl: './personal-data-form.component.html',
})
export class PersonalDataFormComponent implements OnInit {
  form!: FormGroup

  title = 'Dados de pessoa fisíca'

  private registerForm = inject(RegisterFormComponent)

  ngOnInit() {
    this.form = this.registerForm.getPersonalData()
    console.log('Form Values:', this.form.value);
  }
}
