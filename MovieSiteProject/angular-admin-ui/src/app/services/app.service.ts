import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { translates } from 'src/api';
import { SeoService } from '../core/services/seo.service';
import { TranslateService } from '../core/services/translate.service';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  constructor(
    private translateService: TranslateService,
    private seoService: SeoService,
    private toastrService: ToastrService
  ) {}

  setTranslates() {
    var lang = localStorage.getItem('lang');

    if (lang == null) {
      lang = navigator.language;
      localStorage.setItem('lang', lang);
    }

    this.seoService.updateLang(lang);

    this.translateService.getTranslatesWithLanguageCode(lang).subscribe(
      (response) => {
        translates.keys = response.data;
      },
      (responseError) => {
        lang = navigator.language;
        localStorage.setItem('lang', lang);

        this.seoService.updateLang(lang);
        this.translateService.getTranslatesWithLanguageCode(lang).subscribe(
          (response) => {
            translates.keys = response.data;
          },
          (responseError) => {}
        );
      }
    );
  }

  errorToast(message: string, title?: string) {
    this.toastrService.error(message, title != null ? title : '', {
      timeOut: 8000,
      closeButton: true,
      enableHtml: true,
      toastClass: 'alert alert-danger alert-with-icon',
      positionClass: 'toast-top-center',
    });
  }

  successToast(message: string, title?: string) {
    this.toastrService.success(message, title != null ? title : '', {
      timeOut: 8000,
      closeButton: true,
      enableHtml: true,
      toastClass: 'alert alert-success alert-with-icon',
      positionClass: 'toast-top-center',
    });
  }

  infoToast(message: string, title?: string) {
    this.toastrService.info(message, title != null ? title : '', {
      timeOut: 8000,
      closeButton: true,
      enableHtml: true,
      toastClass: 'alert alert-info alert-with-icon',
      positionClass: 'toast-top-center',
    });
  }

  warningToast(message: string, title?: string) {
    this.toastrService.warning(message, title != null ? title : '', {
      timeOut: 8000,
      closeButton: true,
      enableHtml: true,
      toastClass: 'alert alert-warning alert-with-icon',
      positionClass: 'toast-top-center',
    });
  }
}
