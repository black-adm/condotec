import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CredentialsFormRoutingModule } from './credentials-form-routing.module';
import { CredentialsFormComponent } from './credentials-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CredentialsFormComponent
  ],
  imports: [
    CommonModule,
    CredentialsFormRoutingModule,
    ReactiveFormsModule
  ]
})
export class CredentialsFormModule { }
