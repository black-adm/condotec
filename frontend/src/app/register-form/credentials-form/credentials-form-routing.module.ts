import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CredentialsFormComponent } from './credentials-form.component';

const routes: Routes = [{ path: '', component: CredentialsFormComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CredentialsFormRoutingModule { }
