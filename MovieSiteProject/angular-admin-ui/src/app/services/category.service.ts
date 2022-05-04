import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api';
import { DeleteModel } from '../core/models/deleteModel';
import { ListResponseModel } from '../core/models/response/listResponseModel';
import { ResponseModel } from '../core/models/response/responseModel';
import { SingleResponseModel } from '../core/models/response/singleResponseModel';
import { CategoryModel } from '../models/categoryModel';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private httpClient: HttpClient) {}

  add(entity: CategoryModel): Observable<SingleResponseModel<CategoryModel>> {
    return this.httpClient.post<SingleResponseModel<CategoryModel>>(
      apiUrl + 'categories/add',
      entity
    );
  }

  delete(deleteModel: DeleteModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      apiUrl + 'categories/delete',
      deleteModel
    );
  }

  update(
    entity: CategoryModel
  ): Observable<SingleResponseModel<CategoryModel>> {
    return this.httpClient.post<SingleResponseModel<CategoryModel>>(
      apiUrl + 'categories/update',
      entity
    );
  }

  getById(id: string): Observable<SingleResponseModel<CategoryModel>> {
    return this.httpClient.get<SingleResponseModel<CategoryModel>>(
      apiUrl + 'categories/getbyid?id=' + id
    );
  }

  getAll(): Observable<ListResponseModel<CategoryModel>> {
    return this.httpClient.get<ListResponseModel<CategoryModel>>(
      apiUrl + 'categories/getall'
    );
  }
}
