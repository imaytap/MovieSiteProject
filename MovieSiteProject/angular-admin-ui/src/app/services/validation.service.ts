import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';
import { AppService } from './app.service';

@Injectable({
  providedIn: 'root',
})

/// If response has error returns true
export class ValidationService {
  returnValue: boolean;

  constructor(
    private toastrService: ToastrService,
    private appService: AppService
  ) {}

  showErrors(responseError: any) {
    if (responseError.error != null) {
      if (responseError.error.data != null) {
        switch (responseError.error.data.exceptionType) {
          case +ExceptionType.TransactionException:
            this.appService.errorToast(
              responseError.error.data.transactionError,
              responseError.error.message
            );

            this.returnValue = true;
            return true;

          case +ExceptionType.AuthorizationDeniedException:
            this.appService.errorToast(
              responseError.error.data.securityError,
              responseError.error.message
            );

            this.returnValue = true;
            return true;

          case +ExceptionType.ValidationException:
            responseError.error.data.validationErrors.forEach((error: any) => {
              this.appService.errorToast(error, responseError.error.message);
            });

            this.returnValue = true;
            return true;

          default:
            this.appService.errorToast(responseError.error.data?.errorMessage);

            this.returnValue = true;
            return true;
        }
      } else if (responseError.error.message != null) {
        this.appService.errorToast(responseError.error.message);
        this.returnValue = true;
      } else {
        this.appService.errorToast('Bir Şeyler Ters Gitti', 'Beklenmedik Hata');
        console.log(responseError);

        this.returnValue = true;
      }

      return this.returnValue;
    }

    return false;
  }
}

export enum ExceptionType {
  TransactionException,
  AuthorizationDeniedException,
  LoginRequiredException,
  ValidationException,
  SystemException,
}
