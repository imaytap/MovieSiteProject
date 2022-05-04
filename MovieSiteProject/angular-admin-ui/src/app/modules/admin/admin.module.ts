import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboardPageComponent } from '../../admin/pages/dashboard-page/dashboard-page.component';
import { LanguagesPageComponent } from '../../admin/pages/languages-page/languages-page.component';
import { RolesPageComponent } from '../../admin/pages/roles-page/roles-page.component';
import { UsersPageComponent } from '../../admin/pages/users-page/users-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SidebarComponent } from 'src/app/admin/components/sidebar/sidebar.component';
import { NavbarComponent } from 'src/app/admin/components/navbar/navbar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslatesPageComponent } from '../../admin/pages/translates-page/translates-page.component';
import { KeysPageComponent } from '../../admin/pages/keys-page/keys-page.component';

@NgModule({
  declarations: [
    DashboardPageComponent,
    LanguagesPageComponent,
    RolesPageComponent,
    UsersPageComponent,
    SidebarComponent,
    NavbarComponent,
    TranslatesPageComponent,
    KeysPageComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
})
export class AdminModule {}
