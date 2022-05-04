import { Model } from '../core/models/model';

export interface MovieActorModel extends Model {
  movieId: string;
  actorId: string;
}
