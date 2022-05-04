import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LanguageModel } from 'src/app/core/models/language/languageModel';
import { LanguageService } from 'src/app/core/services/language.service';
import { AppService } from 'src/app/services/app.service';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-languages-page',
  templateUrl: './languages-page.component.html',
  styleUrls: ['./languages-page.component.css'],
})
export class LanguagesPageComponent implements OnInit {
  languageAddForm: FormGroup;
  languageUpdateForm: FormGroup;
  languages: LanguageModel[];
  selectedLanguage: LanguageModel;

  constructor(
    private formBuilder: FormBuilder,
    private languageService: LanguageService,
    private appService: AppService,
    private validationService: ValidationService
  ) {}

  ngOnInit(): void {
    this.getAllLanguages();
    this.createLanguageAddForm();
    this.createLanguageUpdateForm();
  }

  createLanguageAddForm() {
    this.languageAddForm = this.formBuilder.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
    });
  }

  createLanguageUpdateForm() {
    this.languageUpdateForm = this.formBuilder.group({
      id: [this.selectedLanguage?.id, Validators.required],
      name: [this.selectedLanguage?.name, Validators.required],
      code: [this.selectedLanguage?.code, Validators.required],
      createdDate: [this.selectedLanguage?.createdDate, Validators.required],
    });
  }

  getAllLanguages() {
    this.languageService.getAll().subscribe({
      next: (response) => {
        this.languages = response.data;
      },
    });
  }

  selectLanguage(language: LanguageModel) {
    window.scrollTo(0, 0);
    this.selectedLanguage = language;
    this.createLanguageUpdateForm();
  }

  deleteSelectedLanguage() {
    if (this.selectedLanguage != null) {
      this.languageService.delete(this.selectedLanguage).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Dil <b>' +
              this.selectedLanguage.name +
              '</b> başarıyla silindi.'
          );

          this.selectedLanguage = null;
          this.getAllLanguages();
          this.languageUpdateForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  addLanguage() {
    if (this.languageAddForm.valid) {
      this.languageService.add(this.languageAddForm.value).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Dil <b>' +
              response.data.name +
              '</b> başarıyla eklendi.'
          );

          this.getAllLanguages();
          this.languageAddForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  updateLanguage() {
    if (this.languageUpdateForm.valid) {
      this.languageService.update(this.languageUpdateForm.value).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Dil <b>' +
              response.data.name +
              '</b> başarıyla güncellendi.'
          );

          this.getAllLanguages();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }
}
