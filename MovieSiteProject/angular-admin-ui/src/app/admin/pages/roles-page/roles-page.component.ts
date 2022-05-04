import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OperationClaimModel } from 'src/app/core/models/operation-claim/operationClaimModel';
import { OperationClaimService } from 'src/app/core/services/operation-claim.service';
import { AppService } from 'src/app/services/app.service';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-roles-page',
  templateUrl: './roles-page.component.html',
  styleUrls: ['./roles-page.component.css'],
})
export class RolesPageComponent implements OnInit {
  operationClaimAddForm: FormGroup;
  operationClaimUpdateForm: FormGroup;

  operationClaims: OperationClaimModel[];
  selectedOperationClaim: OperationClaimModel;

  constructor(
    private formBuilder: FormBuilder,
    private operationClaimService: OperationClaimService,
    private appService: AppService,
    private validationService: ValidationService
  ) {}

  ngOnInit(): void {
    this.getAllOperationClaims();
    this.createOperationClaimAddForm();
    this.createOperationClaimUpdateForm();
  }

  createOperationClaimAddForm() {
    this.operationClaimAddForm = this.formBuilder.group({
      name: ['', Validators.required],
    });
  }

  createOperationClaimUpdateForm() {
    this.operationClaimUpdateForm = this.formBuilder.group({
      id: [this.selectedOperationClaim?.id, Validators.required],
      name: [this.selectedOperationClaim?.name, Validators.required],
      createdDate: [
        this.selectedOperationClaim?.createdDate,
        Validators.required,
      ],
    });
  }

  getAllOperationClaims() {
    this.operationClaimService.getAll().subscribe({
      next: (response) => {
        this.operationClaims = response.data;
      },
    });
  }

  selectOperationClaim(operationClaim: OperationClaimModel) {
    window.scrollTo(0, 0);
    this.selectedOperationClaim = operationClaim;
    this.createOperationClaimUpdateForm();
  }

  deleteSelectedOperationClaim() {
    if (this.selectedOperationClaim != null) {
      this.operationClaimService.delete(this.selectedOperationClaim).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Rol <b>' +
              this.selectedOperationClaim.name +
              '</b> başarıyla silindi.'
          );

          this.selectedOperationClaim = null;
          this.getAllOperationClaims();
          this.operationClaimUpdateForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  addOperationClaim() {
    if (this.operationClaimAddForm.valid) {
      this.operationClaimService
        .add(this.operationClaimAddForm.value)
        .subscribe({
          next: (response) => {
            this.appService.successToast(
              '<span class="now-ui-icons ui-1_bell-53"></span> Rol <b>' +
                response.data.name +
                '</b> başarıyla eklendi.'
            );

            this.getAllOperationClaims();
            this.operationClaimAddForm.reset();
          },
          error: (responseError) => {
            this.validationService.showErrors(responseError);
          },
        });
    }
  }

  updateOperationClaim() {
    if (this.operationClaimUpdateForm.valid) {
      this.operationClaimService
        .update(this.operationClaimUpdateForm.value)
        .subscribe({
          next: (response) => {
            this.appService.successToast(
              '<span class="now-ui-icons ui-1_bell-53"></span> Rol <b>' +
                response.data.name +
                '</b> başarıyla güncellendi.'
            );

            this.getAllOperationClaims();
          },
          error: (responseError) => {
            this.validationService.showErrors(responseError);
          },
        });
    }
  }
}
