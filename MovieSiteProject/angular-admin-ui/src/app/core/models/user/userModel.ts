import { Model } from '../model';

export interface UserModel extends Model {
  email: string;
  status: boolean;
}
