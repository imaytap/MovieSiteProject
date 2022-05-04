import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardPageComponent } from 'src/app/admin/pages/dashboard-page/dashboard-page.component';
import { KeysPageComponent } from 'src/app/admin/pages/keys-page/keys-page.component';
import { LanguagesPageComponent } from 'src/app/admin/pages/languages-page/languages-page.component';
import { RolesPageComponent } from 'src/app/admin/pages/roles-page/roles-page.component';
import { TranslatesPageComponent } from 'src/app/admin/pages/translates-page/translates-page.component';
import { UsersPageComponent } from 'src/app/admin/pages/users-page/users-page.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardPageComponent,
    children: [
      { path: 'languages', component: LanguagesPageComponent },
      { path: 'translates', component: TranslatesPageComponent },
      { path: 'keys', component: KeysPageComponent },
      { path: 'roles', component: RolesPageComponent },
      { path: 'users', component: UsersPageComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
