import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { MovieTagModel } from '../models/movieTagModel';

@Injectable({
  providedIn: 'root',
})
export class MovieTagService {
  constructor(private httpClient: HttpClient) {}
  add(entity: MovieTagModel): Observable<SingleResponseModel<MovieTagModel>> {
    return this.httpClient.post<SingleResponseModel<MovieTagModel>>(
      apiUrl + 'movietags/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'movietags/delete',
      deleteModel
    );
  }

  update(
    entity: MovieTagModel
  ): Observable<SingleResponseModel<MovieTagModel>> {
    return this.httpClient.post<SingleResponseModel<MovieTagModel>>(
      apiUrl + 'movietags/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<MovieTagModel>> {
    return this.httpClient.get<SingleResponseModel<MovieTagModel>>(
      apiUrl + 'movietags/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<MovieTagModel>> {
    return this.httpClient.get<ListResponseModel<MovieTagModel>>(
      apiUrl + 'movietags/getall'
    );
  }
}
