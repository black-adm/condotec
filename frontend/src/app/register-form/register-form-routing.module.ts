import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterFormComponent } from './register-form.component';

const routes: Routes = [
  {
    path: 'cadastrar',
    redirectTo: 'cadastrar/credenciais',
    pathMatch: 'full'
  },
  {
    path: 'cadastrar',
    component: RegisterFormComponent,
    children: [
      {
        path: 'credenciais',
        loadChildren: () =>
          import('./credentials-form/credentials-form.module').then(
            (module) => module.CredentialsFormModule
          ),
        title: 'Condotec | Criar credenciais'
      },
      {
        path: 'dados-pessoais',
        loadChildren: () =>
          import('./personal-data-form/personal-data-form.module').then(
            (module) => module.PersonalDataFormModule
          ),
        title: 'Condotec | Dados pessoa fisíca'
      },
      {
        path: 'dados-pessoais/endereco',
        loadChildren: () =>
          import('./address-form/address-form.module').then(
            (module) => module.AddressFormModule
          ),
          title: 'Condotec | Dados de endereço'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegisterFormRoutingModule { }
