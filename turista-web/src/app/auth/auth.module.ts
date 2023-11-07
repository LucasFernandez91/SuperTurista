import { NgModule } from '@angular/core';
import { AuthComponent } from './auth.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthRoutingModule, routedComponents } from './auth-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatButtonModule } from '@angular/material/button';
import { MatSliderModule } from '@angular/material/slider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { DefaultModule } from '../layout/default.module';
import { LoginComponent } from './login/login.component';

const components = [
    AuthComponent,
  ];
  
  @NgModule({
    imports: [
      AuthRoutingModule,
      HttpClientModule,
      FormsModule,
      CommonModule,
      MatCardModule,
      MatSelectModule,
      MatButtonModule,
      MatSliderModule,
      DefaultModule,
      MatCheckboxModule,
      MatGridListModule,
      MatInputModule,
      MatIconModule,
      MatFormFieldModule,
      MatExpansionModule,
      ReactiveFormsModule
    ],
    declarations: [
      ...routedComponents,
    ],
    exports: [
      LoginComponent,
    ],
  })
export class AuthModule { }