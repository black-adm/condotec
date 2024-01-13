import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonalDataFormComponent } from './personal-data-form.component';

const routes: Routes = [{ path: '', component: PersonalDataFormComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonalDataFormRoutingModule { }
