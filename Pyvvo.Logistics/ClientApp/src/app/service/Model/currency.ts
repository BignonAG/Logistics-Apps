import { Status } from "./status";
import { User } from "./user";

export class Currency {
  id: number;
  name: string;
  createdOn: Date;
  updateOn: Date;
  status: Status;
  precision: number;
  format: string;
  currencySymbol: string;
  exchangeRate: number;
  createdBy: User;
}
