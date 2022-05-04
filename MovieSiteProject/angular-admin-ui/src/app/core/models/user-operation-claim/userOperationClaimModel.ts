import { Model } from '../model';

export interface UserOperationClaimModel extends Model {
  userId: string;
  operationClaimId: string;
}
