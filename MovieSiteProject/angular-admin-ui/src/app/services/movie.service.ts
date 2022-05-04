import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { MovieModel } from '../models/movieModel';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  constructor(private httpClient: HttpClient) {}

  // FromForm will be added
  add(entity: MovieModel): Observable<SingleResponseModel<MovieModel>> {
    return this.httpClient.post<SingleResponseModel<MovieModel>>(
      apiUrl + 'movies/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'movies/delete',
      deleteModel
    );
  }

  update(entity: MovieModel): Observable<SingleResponseModel<MovieModel>> {
    return this.httpClient.post<SingleResponseModel<MovieModel>>(
      apiUrl + 'movies/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<MovieModel>> {
    return this.httpClient.get<SingleResponseModel<MovieModel>>(
      apiUrl + 'movies/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<MovieModel>> {
    return this.httpClient.get<ListResponseModel<MovieModel>>(
      apiUrl + 'movies/getall'
    );
  }
}
