import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterFormComponent } from './register-form.component';

const routes: Routes = [
  {
    path: 'cadastro',
    redirectTo: 'dados-pessoais',
    pathMatch: 'full'
  },
  {
    path: 'cadastro',
    component: RegisterFormComponent,
    children: [
      {
        path: 'dados-pessoais',
        loadChildren: () =>
          import('./personal-data-form/personal-data-form.module').then(
            (module) => module.PersonalDataFormModule
          )
      },
      {
        path: 'dados-endereço',
        loadChildren: () =>
          import('./address-form/address-form.module').then(
            (module) => module.AddressFormModule
          )
      },
      {
        path: 'dados-contato',
        loadChildren: () =>
          import('./personal-contact-form/personal-contact-form.module').then(
            (module) => module.PersonalContactFormModule
          )
      },
      {
        path: 'credenciais-login',
        loadChildren: () =>
          import('./credentials-form/credentials-form.module').then(
            (module) => module.CredentialsFormModule
          )
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegisterFormRoutingModule { }
