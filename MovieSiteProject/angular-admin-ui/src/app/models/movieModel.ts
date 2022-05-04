import { Model } from '../core/models/model';

export interface MovieModel extends Model {
  xUserId: string;
  name: string;
  description: string;
  slug: string;
  videoPath: string;
  imagePath: string;
}
