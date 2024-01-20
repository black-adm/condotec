import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'login',
     loadChildren: () => import('./login-form/login-form.module')
      .then(module => module.LoginFormModule),
    title: 'Condotec | Fazer login'
 }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
