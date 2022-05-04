import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginDisableGuard } from './core/guards/login-disable.guard';
import { LoginGuard } from './core/guards/login.guard';
import { AdminGuard } from './core/guards/admin.guard';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'admin',
    // loadChildren: () =>
    //   import('./modules/home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  { path: '**', redirectTo: 'admin' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
