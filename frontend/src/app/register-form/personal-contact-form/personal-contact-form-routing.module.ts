import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonalContactFormComponent } from './personal-contact-form.component';

const routes: Routes = [{ path: '', component: PersonalContactFormComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonalContactFormRoutingModule { }
