import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { CommentModel } from '../models/commentModel';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  constructor(private httpClient: HttpClient) {}
  add(entity: CommentModel): Observable<SingleResponseModel<CommentModel>> {
    return this.httpClient.post<SingleResponseModel<CommentModel>>(
      apiUrl + 'comments/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'comments/delete',
      deleteModel
    );
  }

  update(entity: CommentModel): Observable<SingleResponseModel<CommentModel>> {
    return this.httpClient.post<SingleResponseModel<CommentModel>>(
      apiUrl + 'comments/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<CommentModel>> {
    return this.httpClient.get<SingleResponseModel<CommentModel>>(
      apiUrl + 'comments/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<CommentModel>> {
    return this.httpClient.get<ListResponseModel<CommentModel>>(
      apiUrl + 'comments/getall'
    );
  }
}
