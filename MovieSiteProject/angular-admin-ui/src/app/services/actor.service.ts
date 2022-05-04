import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { ActorModel } from '../models/actorModel';

@Injectable({
  providedIn: 'root',
})
export class ActorService {
  constructor(private httpClient: HttpClient) {}

  add(entity: ActorModel): Observable<SingleResponseModel<ActorModel>> {
    return this.httpClient.post<SingleResponseModel<ActorModel>>(
      apiUrl + 'actors/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'actors/delete',
      deleteModel
    );
  }

  update(entity: ActorModel): Observable<SingleResponseModel<ActorModel>> {
    return this.httpClient.post<SingleResponseModel<ActorModel>>(
      apiUrl + 'actors/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<ActorModel>> {
    return this.httpClient.get<SingleResponseModel<ActorModel>>(
      apiUrl + 'actors/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<ActorModel>> {
    return this.httpClient.get<ListResponseModel<ActorModel>>(
      apiUrl + 'actors/getall'
    );
  }
}
