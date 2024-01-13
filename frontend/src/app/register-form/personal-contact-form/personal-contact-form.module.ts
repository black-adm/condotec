import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonalContactFormRoutingModule } from './personal-contact-form-routing.module';
import { PersonalContactFormComponent } from './personal-contact-form.component';


@NgModule({
  declarations: [
    PersonalContactFormComponent
  ],
  imports: [
    CommonModule,
    PersonalContactFormRoutingModule
  ]
})
export class PersonalContactFormModule { }
