import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{ path: 'form', loadChildren: () => import('./register-form/address-form/address-form.module').then(m => m.AddressFormModule) }, { path: 'form', loadChildren: () => import('./register-form/personal-contact-form/personal-contact-form.module').then(m => m.PersonalContactFormModule) }, { path: 'form', loadChildren: () => import('./register-form/credentials-form/credentials-form.module').then(m => m.CredentialsFormModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
