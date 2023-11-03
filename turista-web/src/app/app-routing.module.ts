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
import { AuthGuard } from './auth/auth-guard.service';

const routes: Routes = [
  {
    path: '',
    component: DefaultComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },
      {
        path: 'home',
        component: HomeComponent
      },
      {
        path: 'alojamientos',
        component: AlojamientosComponent
      },
      {
        path: 'contacto',
        component: ContactoComponent
      },
      {
        path: 'faqs',
        component: FaqsComponent
      },
      {
        path: 'nosotros',
        component: NosotrosComponent
      },
      {
        path: 'ofertas',
        component: OfertasComponent
      },
      {
        path: 'vehiculos',
        component: VehiculosComponent
      }
    ]
  }, {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule),
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
