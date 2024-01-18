import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask'

import { PersonalDataFormRoutingModule } from './personal-data-form-routing.module';
import { PersonalDataFormComponent } from './personal-data-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PersonalDataFormComponent
  ],
  imports: [
    CommonModule,
    NgxMaskDirective,
    NgxMaskPipe,
    PersonalDataFormRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [provideNgxMask()]
})
export class PersonalDataFormModule { }
