import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OperationClaimModel } from 'src/app/core/models/operation-claim/operationClaimModel';
import { UserOperationClaimDetailsModel } from 'src/app/core/models/user-operation-claim/userOperationClaimDetailsModel';
import { UserModel } from 'src/app/core/models/user/userModel';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserOperationClaimService } from 'src/app/core/services/user-operation-claim.service';
import { UserService } from 'src/app/core/services/user.service';
import { AppService } from 'src/app/services/app.service';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-users-page',
  templateUrl: './users-page.component.html',
  styleUrls: ['./users-page.component.css'],
})
export class UsersPageComponent implements OnInit {
  userAddForm: FormGroup;
  userUpdateForm: FormGroup;
  userPasswordChangeForm: FormGroup;
  userOperationClaimAddForm: FormGroup;
  userOperationClaimDeleteForm: FormGroup;
  users: UserModel[];
  operationClaims: OperationClaimModel[];
  userOperationClaims: UserOperationClaimDetailsModel[];
  selectedUser: UserModel;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
    private appService: AppService,
    private validationService: ValidationService,
    private userOperationClaimService: UserOperationClaimService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.getAllUsers();
    this.createUserAddForm();
    this.createUserUpdateForm();
    this.createUserPasswordChangeForm();
    this.createUserOperationClaimAddForm();
    this.createUserOperationClaimDeleteForm();
  }

  createUserAddForm() {
    this.userAddForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      status: ['', Validators.required],
    });
  }

  createUserUpdateForm() {
    this.userUpdateForm = this.formBuilder.group({
      id: [this.selectedUser?.id, Validators.required],
      email: [this.selectedUser?.email, Validators.required],
      status: [this.selectedUser?.status, Validators.required],
    });
  }

  createUserPasswordChangeForm() {
    this.userPasswordChangeForm = this.formBuilder.group({
      id: [this.selectedUser?.id, Validators.required],
      newPassword: ['', Validators.required],
    });
  }

  createUserOperationClaimAddForm() {
    this.userOperationClaimAddForm = this.formBuilder.group({
      userId: [this.selectedUser?.id, Validators.required],
      operationClaimId: ['', Validators.required],
    });
  }

  createUserOperationClaimDeleteForm() {
    this.userOperationClaimDeleteForm = this.formBuilder.group({
      id: ['', Validators.required],
    });
  }

  getAllUsers() {
    this.userService.getAll().subscribe({
      next: (response) => {
        this.users = response.data;
      },
    });
  }

  getOtherOperationClaims() {
    this.userService.getOtherClaims(this.selectedUser?.id).subscribe({
      next: (response) => {
        this.operationClaims = response.data;
        this.createUserOperationClaimAddForm();
      },
    });
  }

  getUserOperationClaims() {
    this.userService.getUserClaims(this.selectedUser?.id).subscribe({
      next: (response) => {
        this.userOperationClaims = response.data;
        this.createUserOperationClaimDeleteForm();
      },
    });
  }

  addUser() {
    if (this.userAddForm.valid) {
      if (this.userAddForm.value.status == 'true') {
        this.userAddForm.value.status = true;
      }
      if (this.userAddForm.value.status == 'false') {
        this.userAddForm.value.status = false;
      }
      this.authService.registerForAdmin(this.userAddForm.value).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Kullanıcı <b>' +
              this.userAddForm.value.email +
              '</b> başarıyla eklendi.'
          );

          this.getAllUsers();
          this.userAddForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  clearUserAddForm() {
    this.userAddForm.reset();
  }

  selectUser(user: UserModel) {
    window.scrollTo(0, 0);
    this.selectedUser = user;
    this.getOtherOperationClaims();
    this.getUserOperationClaims();
    this.createUserUpdateForm();
    this.createUserPasswordChangeForm();
  }

  deleteSelectedUser() {
    if (this.selectedUser != null) {
      this.userService.delete(this.selectedUser).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Kullanıcı <b>' +
              this.selectedUser.email +
              '</b> başarıyla silindi.'
          );

          this.selectedUser = null;
          this.getAllUsers();
          this.userUpdateForm.reset();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  updateUser() {
    if (this.userUpdateForm.valid) {
      if (this.userUpdateForm.value.status == 'true') {
        this.userUpdateForm.value.status = true;
      }
      if (this.userUpdateForm.value.status == 'false') {
        this.userUpdateForm.value.status = false;
      }

      this.authService.updateUser(this.userUpdateForm.value).subscribe({
        next: (response) => {
          this.appService.successToast(
            '<span class="now-ui-icons ui-1_bell-53"></span> Kullanıcı <b>' +
              this.selectedUser.email +
              '</b> başarıyla güncellendi.'
          );

          this.getAllUsers();
        },
        error: (responseError) => {
          this.validationService.showErrors(responseError);
        },
      });
    }
  }

  changePassword() {
    if (this.userPasswordChangeForm.valid) {
      this.authService
        .changePassword(this.userPasswordChangeForm.value)
        .subscribe({
          next: (response) => {
            this.appService.successToast(
              '<span class="now-ui-icons ui-1_bell-53"></span> <b> Şifre </b> başarıyla değiştirildi.'
            );
          },
          error: (responseError) => {
            this.validationService.showErrors(responseError);
          },
        });
    }
  }

  addUserOperationClaim() {
    if (this.userOperationClaimAddForm.valid && this.selectedUser != null) {
      this.userOperationClaimService
        .add(this.userOperationClaimAddForm.value)
        .subscribe({
          next: (response) => {
            this.appService.successToast(
              '<span class="now-ui-icons ui-1_bell-53"></span> <b>Kullanıcıya Rol</b> başarıyla verildi.'
            );

            this.getUserOperationClaims();
            this.getOtherOperationClaims();
            this.userOperationClaimAddForm.reset();
          },
          error: (responseError) => {
            this.validationService.showErrors(responseError);
          },
        });
    }
  }

  deleteUserOperationClaim() {
    if (this.userOperationClaimDeleteForm.valid && this.selectedUser != null) {
      this.userOperationClaimService
        .delete(this.userOperationClaimDeleteForm.value)
        .subscribe({
          next: () => {
            this.appService.successToast(
              '<span class="now-ui-icons ui-1_bell-53"></span> <b>Kullanıcıdan Rol</b> başarıyla silindi.'
            );

            this.getUserOperationClaims();
            this.getOtherOperationClaims();
            this.userOperationClaimDeleteForm.reset();
          },
          error: (responseError) => {
            this.validationService.showErrors(responseError);
          },
        });
    }
  }
}
