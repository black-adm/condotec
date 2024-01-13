import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonalDataFormRoutingModule } from './personal-data-form-routing.module';
import { PersonalDataFormComponent } from './personal-data-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PersonalDataFormComponent
  ],
  imports: [
    CommonModule,
    PersonalDataFormRoutingModule,
    ReactiveFormsModule,
  ]
})
export class PersonalDataFormModule { }
