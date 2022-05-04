import { Component, OnInit } from '@angular/core';
import { translates } from 'src/api';
import { AuthService } from './core/services/auth.service';
import { SeoService } from './core/services/seo.service';
import { AppService } from './services/app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Admin Dashboard';
  translateKeys: any;

  constructor(
    private appService: AppService,
    private authService: AuthService,
    private seoService: SeoService
  ) {}

  ngOnInit(): void {
    this.seoService.updateTitle(this.title);

    if (this.translateKeys == null) {
      this.appService.setTranslates();
      this.translateKeys = translates;
    }

    this.authService.setRefreshTokenEvents(
      () => {
        console.log('Failed');
      },
      (token) => {
        console.log('Succeed' + token.expiration);
      }
    );
  }
}
