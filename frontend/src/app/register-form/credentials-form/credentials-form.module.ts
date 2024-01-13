import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CredentialsFormRoutingModule } from './credentials-form-routing.module';
import { CredentialsFormComponent } from './credentials-form.component';


@NgModule({
  declarations: [
    CredentialsFormComponent
  ],
  imports: [
    CommonModule,
    CredentialsFormRoutingModule
  ]
})
export class CredentialsFormModule { }
