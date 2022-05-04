import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { MovieActorModel } from '../models/movieActorModel';

@Injectable({
  providedIn: 'root',
})
export class MovieActorService {
  constructor(private httpClient: HttpClient) {}

  add(
    entity: MovieActorModel
  ): Observable<SingleResponseModel<MovieActorModel>> {
    return this.httpClient.post<SingleResponseModel<MovieActorModel>>(
      apiUrl + 'movieactors/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'movieactors/delete',
      deleteModel
    );
  }

  update(
    entity: MovieActorModel
  ): Observable<SingleResponseModel<MovieActorModel>> {
    return this.httpClient.post<SingleResponseModel<MovieActorModel>>(
      apiUrl + 'movieactors/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<MovieActorModel>> {
    return this.httpClient.get<SingleResponseModel<MovieActorModel>>(
      apiUrl + 'movieactors/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<MovieActorModel>> {
    return this.httpClient.get<ListResponseModel<MovieActorModel>>(
      apiUrl + 'movieactors/getall'
    );
  }
}
