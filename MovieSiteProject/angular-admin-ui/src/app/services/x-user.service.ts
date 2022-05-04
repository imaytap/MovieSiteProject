import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { XUserModel } from '../models/xUserModel';

@Injectable({
  providedIn: 'root',
})
export class XUserService {
  constructor(private httpClient: HttpClient) {}
  add(entity: XUserModel): Observable<SingleResponseModel<XUserModel>> {
    return this.httpClient.post<SingleResponseModel<XUserModel>>(
      apiUrl + 'xusers/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'xusers/delete',
      deleteModel
    );
  }

  update(entity: XUserModel): Observable<SingleResponseModel<XUserModel>> {
    return this.httpClient.post<SingleResponseModel<XUserModel>>(
      apiUrl + 'xusers/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<XUserModel>> {
    return this.httpClient.get<SingleResponseModel<XUserModel>>(
      apiUrl + 'xusers/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<XUserModel>> {
    return this.httpClient.get<ListResponseModel<XUserModel>>(
      apiUrl + 'xusers/getall'
    );
  }
}
