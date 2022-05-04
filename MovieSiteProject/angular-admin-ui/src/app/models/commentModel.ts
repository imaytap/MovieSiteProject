import { Model } from '../core/models/model';

export interface CommentModel extends Model {
  xUserId: string;
  movieId: string;
  description: string;
}
