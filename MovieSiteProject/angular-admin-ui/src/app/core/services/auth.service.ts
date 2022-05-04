import { TokenService } from './token.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl, clientName } from 'src/api';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { LoginModel } from '../models/user/loginModel';
import { RegisterModel } from '../models/user/registerModel';
import { TokenModel } from '../models/user/tokenModel';
import { StorageService } from './storage.service';
import { UserChangePasswordModel } from '../models/user/userChangePasswordModel';
import { UserUpdateModel } from '../models/user/userUpdateModel';
import { RegisterForAdminModel } from '../models/user/registerForAdminModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _refreshTokenFailedEvent: () => any;
  private _refreshTokenSucceedEvent: (token: TokenModel) => any;

  constructor(
    private httpClient: HttpClient,
    private localStorageService: StorageService,
    private tokenService: TokenService
  ) {}

  login(user: LoginModel): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/login';

    return this.httpClient.post<SingleResponseModel<TokenModel>>(newPath, user);
  }

  register(user: RegisterModel): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/register';

    return this.httpClient.post<SingleResponseModel<TokenModel>>(newPath, user);
  }

  registerForAdmin(
    user: RegisterForAdminModel
  ): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/registerforadmin';

    return this.httpClient.post<SingleResponseModel<TokenModel>>(newPath, user);
  }

  changePassword(
    user: UserChangePasswordModel
  ): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/changepassword';

    return this.httpClient.post<SingleResponseModel<TokenModel>>(newPath, user);
  }

  updateUser(
    user: UserUpdateModel
  ): Observable<SingleResponseModel<TokenModel>> {
    let newPath = apiUrl + 'auth/updateuser';

    return this.httpClient.post<SingleResponseModel<TokenModel>>(newPath, user);
  }

  logout() {
    if (this.isAuthenticated()) {
      this.tokenService.removeToken();
      this.tokenService.removeRefreshToken();
      return true;
    }

    return false;
  }

  isAuthenticated(): boolean {
    if (this.localStorageService.controlItem('token')) {
      return true;
    }

    return false;
  }

  onRefreshTokenFailed() {
    if (this._refreshTokenFailedEvent != null) this._refreshTokenFailedEvent();
  }

  onRefreshTokenSucceed(token: TokenModel) {
    if (this._refreshTokenSucceedEvent != null)
      this._refreshTokenSucceedEvent(token);
  }

  setRefreshTokenEvents(
    refreshTokenFailedEvent: () => any,
    refreshTokenSucceedEvent: (token: TokenModel) => any
  ): void {
    this._refreshTokenFailedEvent = refreshTokenFailedEvent;
    this._refreshTokenSucceedEvent = refreshTokenSucceedEvent;
  }
}
