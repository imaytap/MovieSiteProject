import { Model } from '../core/models/model';

export interface MovieTagModel extends Model {
  movieId: string;
  tagId: string;
}
