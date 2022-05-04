import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { TagModel } from '../models/tagModel';

@Injectable({
  providedIn: 'root',
})
export class TagService {
  constructor(private httpClient: HttpClient) {}

  add(entity: TagModel): Observable<SingleResponseModel<TagModel>> {
    return this.httpClient.post<SingleResponseModel<TagModel>>(
      apiUrl + 'tags/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'tags/delete',
      deleteModel
    );
  }

  update(entity: TagModel): Observable<SingleResponseModel<TagModel>> {
    return this.httpClient.post<SingleResponseModel<TagModel>>(
      apiUrl + 'tags/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<TagModel>> {
    return this.httpClient.get<SingleResponseModel<TagModel>>(
      apiUrl + 'tags/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<TagModel>> {
    return this.httpClient.get<ListResponseModel<TagModel>>(
      apiUrl + 'tags/getall'
    );
  }
}
