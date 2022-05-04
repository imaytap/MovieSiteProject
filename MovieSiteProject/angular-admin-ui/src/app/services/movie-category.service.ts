import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { MovieCategoryModel } from '../models/movieCategoryModel';

@Injectable({
  providedIn: 'root',
})
export class MovieCategoryService {
  constructor(private httpClient: HttpClient) {}
  add(
    entity: MovieCategoryModel
  ): Observable<SingleResponseModel<MovieCategoryModel>> {
    return this.httpClient.post<SingleResponseModel<MovieCategoryModel>>(
      apiUrl + 'moviecategories/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'moviecategories/delete',
      deleteModel
    );
  }

  update(
    entity: MovieCategoryModel
  ): Observable<SingleResponseModel<MovieCategoryModel>> {
    return this.httpClient.post<SingleResponseModel<MovieCategoryModel>>(
      apiUrl + 'moviecategories/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<MovieCategoryModel>> {
    return this.httpClient.get<SingleResponseModel<MovieCategoryModel>>(
      apiUrl + 'moviecategories/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<MovieCategoryModel>> {
    return this.httpClient.get<ListResponseModel<MovieCategoryModel>>(
      apiUrl + 'moviecategories/getall'
    );
  }
}
