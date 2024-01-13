import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddressFormRoutingModule } from './address-form-routing.module';
import { AddressFormComponent } from './address-form.component';


@NgModule({
  declarations: [
    AddressFormComponent
  ],
  imports: [
    CommonModule,
    AddressFormRoutingModule
  ]
})
export class AddressFormModule { }
