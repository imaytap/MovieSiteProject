import { Model } from '../model';

export interface TranslateModel extends Model {
  languageId: string;
  translateKeyId: string;
  value: string;
}
