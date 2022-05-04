import { Model } from '../core/models/model';

export interface MovieCategoryModel extends Model {
  movieId: string;
  categoryId: string;
}
