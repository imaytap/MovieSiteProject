import { Model } from '../core/models/model';

export interface TagModel extends Model {
  xUserId: string;
  name: string;
}
