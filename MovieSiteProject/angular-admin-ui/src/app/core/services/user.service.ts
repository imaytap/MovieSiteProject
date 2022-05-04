import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../models/deleteModel';
import { OperationClaimModel } from '../models/operation-claim/operationClaimModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { UserOperationClaimDetailsModel } from '../models/user-operation-claim/userOperationClaimDetailsModel';
import { UserModel } from '../models/user/userModel';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpClient: HttpClient) {}
  add(addModel: UserModel): Observable<SingleResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/add';

    return this.httpClient.post<SingleResponseModel<UserModel>>(
      newPath,
      addModel
    );
  }

  getByEmail(email: string): Observable<SingleResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/getbyemail?email=' + email;

    return this.httpClient.get<SingleResponseModel<UserModel>>(newPath);
  }

  getByStatus(status: boolean): Observable<ListResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/getbystatus?status=' + status;

    return this.httpClient.get<ListResponseModel<UserModel>>(newPath);
  }

  getById(id: string): Observable<SingleResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/getbyid?id=' + id;

    return this.httpClient.get<SingleResponseModel<UserModel>>(newPath);
  }

  getAll(): Observable<ListResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/getall';

    return this.httpClient.get<ListResponseModel<UserModel>>(newPath);
  }

  update(user: UserModel): Observable<SingleResponseModel<UserModel>> {
    let newPath = apiUrl + 'users/update';

    return this.httpClient.post<SingleResponseModel<UserModel>>(newPath, user);
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'users/delete';

    return this.httpClient.post<ResponseModel>(newPath, deleteModel);
  }

  getUserClaims(
    userId: string
  ): Observable<ListResponseModel<UserOperationClaimDetailsModel>> {
    let newPath = apiUrl + 'users/getuserclaims?userId=' + userId;

    return this.httpClient.get<ListResponseModel<UserOperationClaimDetailsModel>>(newPath);
  }

  getOtherClaims(
    userId: string
  ): Observable<ListResponseModel<OperationClaimModel>> {
    let newPath = apiUrl + 'users/getotherclaims?userId=' + userId;

    return this.httpClient.get<ListResponseModel<OperationClaimModel>>(newPath);
  }
}
