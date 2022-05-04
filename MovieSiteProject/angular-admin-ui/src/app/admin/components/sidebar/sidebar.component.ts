import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
  {
    path: '/admin/languages',
    title: 'Diller',
    icon: 'design_app',
    class: '',
  },
  {
    path: '/admin/translates',
    title: 'Çeviriler',
    icon: 'objects_planet',
    class: '',
  },
  {
    path: '/admin/keys',
    title: 'Keyler',
    icon: 'objects_key-25',
    class: '',
  },
  {
    path: '/admin/roles',
    title: 'Roller',
    icon: 'gestures_tap-01',
    class: '',
  },
  {
    path: '/admin/users',
    title: 'Kullanıcılar',
    icon: 'users_circle-08',
    class: '',
  },
  {
    path: '/',
    title: 'Siteyi Görüntüle',
    icon: 'objects_spaceship',
    class: 'active active-pro',
  },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() {}

  ngOnInit() {
    this.menuItems = ROUTES.filter((menuItem) => menuItem);
  }
  isMobileMenu() {
    if (window.innerWidth > 991) {
      return false;
    }
    return true;
  }
}
