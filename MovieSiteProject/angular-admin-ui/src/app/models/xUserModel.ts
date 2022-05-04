import { UserModel } from '../core/models/user/userModel';

export interface XUserModel extends UserModel {
  nick: string;
}
