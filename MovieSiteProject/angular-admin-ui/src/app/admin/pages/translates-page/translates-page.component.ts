import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LanguageModel } from 'src/app/core/models/language/languageModel';
import { TranslateKeyModel } from 'src/app/core/models/translate-key/translateKeyModel';
import { TranslateDetailsModel } from 'src/app/core/models/translate/translateDetailsModel';
import { TranslateModel } from 'src/app/core/models/translate/translateModel';
import { LanguageService } from 'src/app/core/services/language.service';
import { TranslateKeyService } from 'src/app/core/services/translate-key.service';
import { TranslateService } from 'src/app/core/services/translate.service';
import { AppService } from 'src/app/services/app.service';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-translates-page',
  templateUrl: './translates-page.component.html',
  styleUrls: ['./translates-page.component.css'],
})
export class TranslatesPageComponent implements OnInit {
  translateAddForm: FormGroup;
  translateUpdateForm: FormGroup;
  translateKeys: TranslateKeyModel[];
  languages: LanguageModel[];
  translates: TranslateDetailsModel[];
  selectedTranslate: TranslateModel;

  constructor(
    private translateService: TranslateService,
    private translateKeyService: TranslateKeyService,
    private languageService: LanguageService,
    private formBuilder: FormBuilder,
    private appService: AppService,
    private validationService: ValidationService
  ) {}

  ngOnInit(): void {
    this.getAllLanguages();
    this.getAllTranslateKeys();
    this.getAllTranslatesDetails();
    this.createTranslateAddForm();
    this.createTranslateUpdateForm();
  }

  createTranslateAddForm() {
    this.translateAddForm = this.formBuilder.group({
      languageId: ['', Validators.required],
      translateKeyId: ['', Validators.required],
      value: ['', Validators.required],
    });
  }

  createTranslateUpdateForm() {
    this.translateUpdateForm = this.formBuilder.group({
      id: [this.selectedTranslate?.id, Validators.required],
      languageId: [this.selectedTranslate?.languageId, Validators.required],
      translateKeyId: [
        this.selectedTranslate?.translateKeyId,
        Validators.required,
      ],
      value: [this.selectedTranslate?.value, Validators.required],
      createdDate: [this.selectedTranslate?.createdDate, Validators.required],
    });
  }

  getAllLanguages() {
    this.languageService.getAll().subscribe({
      next: (response) => {
        this.languages = response.data;
      },
    });
  }

  getAllTranslateKeys() {
    this.translateKeyService.getAll().subscribe({
      next: (response) => {
        this.translateKeys = response.data;
      },
    });
  }

  getAllTranslatesDetails() {
    this.translateService.getAllTranslatesDetails().subscribe({
      next: (response) => {
        this.translates = response.data;
      },
    });
  }

  selectTranslate(translate: TranslateModel) {
    window.scrollTo(0, 0);
    this.selectedTranslate = translate;
    this.createTranslateUpdateForm();
  }

  deleteSelectedTranslate() {
    if (this.selectedTranslate != null) {
      this.translateService.delete(this.selectedTranslate).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Çeviri <b>' +
              this.selectedTranslate.value +
              '</b> başarıyla silindi.'
          );

          this.selectedTranslate = null;
          this.getAllTranslatesDetails();
          this.translateUpdateForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  addTranslate() {
    if (this.translateAddForm.valid) {
      this.translateService.add(this.translateAddForm.value).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Çeviri <b>' +
              response.data.value +
              '</b> başarıyla eklendi.'
          );

          this.getAllTranslatesDetails();
          this.translateAddForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  updateTranslate() {
    if (this.translateUpdateForm.valid) {
      this.translateService.update(this.translateUpdateForm.value).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Çeviri <b>' +
              response.data.value +
              '</b> başarıyla güncellendi.'
          );

          this.getAllTranslatesDetails();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }
}
