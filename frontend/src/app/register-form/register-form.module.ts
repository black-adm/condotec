import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { RegisterFormRoutingModule } from './register-form-routing.module';
import { RegisterFormComponent } from './register-form.component';
import { StepperComponent } from '../components/stepper/stepper.component';

@NgModule({
  declarations: [
    RegisterFormComponent,
    StepperComponent,
  ],
  imports: [
    CommonModule,
    RegisterFormRoutingModule,
    ReactiveFormsModule,
  ]
})
export class RegisterFormModule { }
