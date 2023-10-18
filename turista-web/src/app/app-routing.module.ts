import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { DefaultComponent } from './layout/default.component';
import { AlojamientosComponent } from './pages/alojamientos/alojamientos.component';
import { ContactoComponent } from './pages/contacto/contacto.component';
import { FaqsComponent } from './pages/faqs/faqs.component';
import { NosotrosComponent } from './pages/nosotros/nosotros.component';
import { OfertasComponent } from './pages/ofertas/ofertas.component';
import { VehiculosComponent } from './pages/vehiculos/vehiculos.component';

const routes: Routes = [{
  path: '',
  component: DefaultComponent,
  children: [{
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  }, {
    path: 'home',
    component: HomeComponent
  }, {
    path: 'app-alojamientos',
    component: AlojamientosComponent
  },{
    path: 'app-vehiculos',
    component: VehiculosComponent
  },{
    path: 'app-ofertas',
    component: OfertasComponent
  },{
    path: 'app-nosotros',
    component: NosotrosComponent
  },{
    path: 'app-faqs',
    component: FaqsComponent
  },{
    path: 'app-contacto',
    component: ContactoComponent
  }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
