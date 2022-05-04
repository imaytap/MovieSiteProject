import { Model } from '../core/models/model';

export interface ActorModel extends Model {
  xUserId: string;
  name: string;
  description: string;
  imagePath: string;
}
