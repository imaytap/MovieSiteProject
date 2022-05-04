import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateKeyModel } from 'src/app/core/models/translate-key/translateKeyModel';
import { TranslateKeyService } from 'src/app/core/services/translate-key.service';
import { AppService } from 'src/app/services/app.service';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-keys-page',
  templateUrl: './keys-page.component.html',
  styleUrls: ['./keys-page.component.css'],
})
export class KeysPageComponent implements OnInit {
  keyAddForm: FormGroup;
  keyUpdateForm: FormGroup;
  keys: TranslateKeyModel[];
  selectedKey: TranslateKeyModel;

  constructor(
    private translateKeyService: TranslateKeyService,
    private formBuilder: FormBuilder,
    private appService: AppService,
    private validationService: ValidationService
  ) {}

  ngOnInit(): void {
    this.getAllKeys();
    this.createKeyAddForm();
    this.createKeyUpdateForm();
  }

  createKeyAddForm() {
    this.keyAddForm = this.formBuilder.group({
      key: ['', Validators.required],
    });
  }

  createKeyUpdateForm() {
    this.keyUpdateForm = this.formBuilder.group({
      id: [this.selectedKey?.id, Validators.required],
      key: [this.selectedKey?.key, Validators.required],
      createdDate: [this.selectedKey?.createdDate, Validators.required],
    });
  }

  getAllKeys() {
    this.translateKeyService.getAll().subscribe({
      next: (response) => {
        this.keys = response.data;
      },
    });
  }

  selectKey(key: TranslateKeyModel) {
    window.scrollTo(0, 0);
    this.selectedKey = key;
    this.createKeyUpdateForm();
  }

  deleteSelectedKey() {
    if (this.selectedKey != null) {
      this.translateKeyService.delete(this.selectedKey).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Key <b>' +
              this.selectedKey.key +
              '</b> başarıyla silindi.'
          );

          this.selectedKey = null;
          this.getAllKeys();
          this.keyUpdateForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  addKey() {
    if (this.keyAddForm.valid) {
      this.translateKeyService.add(this.keyAddForm.value).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Key <b>' +
              response.data.key +
              '</b> başarıyla eklendi.'
          );

          this.getAllKeys();
          this.keyAddForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  updateKey() {
    if (this.keyUpdateForm.valid) {
      this.translateKeyService.update(this.keyUpdateForm.value).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Key <b>' +
              response.data.key +
              '</b> başarıyla güncellendi.'
          );

          this.getAllKeys();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }
}
