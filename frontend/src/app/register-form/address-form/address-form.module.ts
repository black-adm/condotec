import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';

import { AddressFormRoutingModule } from './address-form-routing.module';
import { AddressFormComponent } from './address-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddressFormComponent
  ],
  imports: [
    CommonModule,
    NgxMaskDirective,
    NgxMaskPipe,
    AddressFormRoutingModule,
    ReactiveFormsModule
  ],
  providers: [provideNgxMask()]
})
export class AddressFormModule { }
