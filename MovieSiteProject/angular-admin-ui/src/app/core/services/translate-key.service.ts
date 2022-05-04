import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../models/deleteModel';
import { ListResponseModel } from '../models/response/listResponseModel';
import { ResponseModel } from '../models/response/responseModel';
import { SingleResponseModel } from '../models/response/singleResponseModel';
import { TranslateKeyModel } from '../models/translate-key/translateKeyModel';

@Injectable({
  providedIn: 'root',
})
export class TranslateKeyService {
  constructor(private httpClient: HttpClient) {}

  add(
    addModel: TranslateKeyModel
  ): Observable<SingleResponseModel<TranslateKeyModel>> {
    let newPath = apiUrl + 'translatekeys/add';
    return this.httpClient.post<SingleResponseModel<TranslateKeyModel>>(
      newPath,
      addModel
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    let newPath = apiUrl + 'translatekeys/delete';
    return this.httpClient.post<ResponseModel>(newPath, deleteModel);
  }

  update(
    updateModel: TranslateKeyModel
  ): Observable<SingleResponseModel<TranslateKeyModel>> {
    let newPath = apiUrl + 'translatekeys/update';
    return this.httpClient.post<SingleResponseModel<TranslateKeyModel>>(
      newPath,
      updateModel
    );
  }

  getById(id: string): Observable<SingleResponseModel<TranslateKeyModel>> {
    let newPath = apiUrl + 'translatekeys/getbyid?id=' + id;
    return this.httpClient.get<SingleResponseModel<TranslateKeyModel>>(newPath);
  }

  getAll(): Observable<ListResponseModel<TranslateKeyModel>> {
    let newPath = apiUrl + 'translatekeys/getall';
    return this.httpClient.get<ListResponseModel<TranslateKeyModel>>(newPath);
  }

  getByKey(key: string): Observable<SingleResponseModel<TranslateKeyModel>> {
    let newPath = apiUrl + 'translatekeys/getbykey?key=' + key;
    return this.httpClient.get<SingleResponseModel<TranslateKeyModel>>(newPath);
  }
}
