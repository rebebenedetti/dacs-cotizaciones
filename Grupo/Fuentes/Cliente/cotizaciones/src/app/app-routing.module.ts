import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { InicioSesionGuard } from './guards/inicio-sesion.guard';
import { NoInicioSesionGuard } from './guards/no-inicio-sesion.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'inicio',
    pathMatch: 'full'
  },
  {
    path: 'paginas',
    loadChildren: () => import('./paginas/paginas.module').then(m => m.PaginasPageModule),
    canActivate: [InicioSesionGuard]
  },
  {
    path: 'consultar',
    loadChildren: () => import('./paginas/consultar/consultar.module').then(m => m.ConsultarPageModule),
    canActivate: [InicioSesionGuard]
  },
  {
    path: 'historico',
    loadChildren: () => import('./paginas/historico/historico.module').then(m => m.HistoricoPageModule),
    canActivate: [InicioSesionGuard]
  },
  {
    path: 'alerta',
    loadChildren: () => import('./paginas/alerta/alerta.module').then(m => m.AlertaPageModule),
    canActivate: [InicioSesionGuard]
  },
  {
    path: 'inicio',
    loadChildren: () => import('./inicio/inicio.module').then(m => m.InicioPageModule),
    canActivate: [NoInicioSesionGuard]
  }
];


@NgModule({
  imports: [
    RouterModule.forRoot(routes,
      { preloadingStrategy: PreloadAllModules }
    )
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
