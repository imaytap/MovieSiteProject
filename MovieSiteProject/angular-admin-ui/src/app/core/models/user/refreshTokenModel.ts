import { Model } from '../model';

export interface RefreshTokenModel extends Model {
  userId: string;
  clientId: string;
  clientName: string;
  tokenValue: string;
  refreshTokenValue: string;
}
