import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddressFormRoutingModule } from './address-form-routing.module';
import { AddressFormComponent } from './address-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddressFormComponent
  ],
  imports: [
    CommonModule,
    AddressFormRoutingModule,
    ReactiveFormsModule
  ]
})
export class AddressFormModule { }
