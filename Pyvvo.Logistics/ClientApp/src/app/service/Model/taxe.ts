import { User } from "./user";
import { TaxeLineItem } from "./taxe-line-item";

export class Taxe {
  id: number;
  createdOn: Date;
  createdOnLocalTime: string;
  updatedOn: Date;
  updateOnLocalTime: string;
  isActive: boolean;
  rate: number;
  createdBy: User;
  taxLineItems: TaxeLineItem [];
}
