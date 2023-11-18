import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { OfertasComponent } from '../pages/ofertas/ofertas.component';
import { AlojamientosComponent } from '../pages/alojamientos/alojamientos.component';
import { VehiculosComponent } from '../pages/vehiculos/vehiculos.component';
import { NosotrosComponent } from '../pages/nosotros/nosotros.component';
import { FaqsComponent } from '../pages/faqs/faqs.component';
import { ContactoComponent } from '../pages/contacto/contacto.component';
import { DefaultComponent } from './default.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from '../pages/home/home.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { HeaderComponent } from '../shared/components/header/header.component';
import { FooterComponent } from '../shared/components/footer/footer.component';
import { DialogSetearClaveComponent } from '../auth/components/dialog-setear-clave.component';
import { DialogRegistroUsuarioComponent } from '../auth/components/dialog-registro-usuario.component';
import { DialogSetearClaveOlvidadaComponent } from '../auth/components/dialog-setear-clave-olvidada.component';
import { DialogOlvidoUsuarioComponent } from '../auth/components/dialog-olvido-usuario.component';
import { DialogOlvidoClaveComponent } from '../auth/components/dialog-olvido-clave.component';
import { AuthComponent } from '../auth/auth.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    OfertasComponent,
    AlojamientosComponent,
    VehiculosComponent,
    NosotrosComponent,
    FaqsComponent,
    ContactoComponent,
    DefaultComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,   
    DialogSetearClaveComponent,   
    DialogRegistroUsuarioComponent,
    DialogSetearClaveOlvidadaComponent,
    DialogOlvidoUsuarioComponent,
    DialogOlvidoClaveComponent,
    
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule 
    
  ],
})
export class DefaultModule { }
