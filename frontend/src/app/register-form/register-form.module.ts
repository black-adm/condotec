import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { RegisterFormRoutingModule } from './register-form-routing.module';
import { RegisterFormComponent } from './register-form.component';
import { StepperComponent } from '../components/stepper/stepper.component';
import { HeaderComponent } from '../components/header/header.component';

@NgModule({
  declarations: [
    RegisterFormComponent,
    HeaderComponent,
    StepperComponent,
  ],
  imports: [
    CommonModule,
    RegisterFormRoutingModule,
    ReactiveFormsModule,
  ]
})
export class RegisterFormModule { }
