import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './auth.component';
import { AuthRoutingModule, routedComponents } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { ConfirmUserComponent } from './confirm-user.component';
import { DefaultModule } from '../layout/default.module';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [  
    ...routedComponents,
    
  ],
  imports: [  
    CommonModule,
    AuthRoutingModule,
    DefaultModule,
    SharedModule,
    FormsModule, 
  ], 
  exports: [
    LoginComponent,
    ConfirmUserComponent,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    DefaultModule,
  ],
})
export class AuthModule { }
