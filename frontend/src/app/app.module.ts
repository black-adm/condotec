import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormModule } from './login-form/login-form.module';
import { RegisterFormModule } from './register-form/register-form.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginFormModule,
    RegisterFormModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
