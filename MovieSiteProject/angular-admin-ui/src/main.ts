import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import {
  setApiUrl,
  setBaseUrl,
  setBaseUrlForImage,
  setClientName,
} from './api';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  setApiUrl('/api/');
  setBaseUrl('/');
  setBaseUrlForImage('');
  setClientName('Angular-Admin');

  enableProdMode();

  if (window) {
    window.console.log = function () {};
  }
}

platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch((err) => console.error(err));
