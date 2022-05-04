import { Model } from '../core/models/model';

export interface CategoryModel extends Model {
  xUserId: string;
  name: string;
  description: string;
}
