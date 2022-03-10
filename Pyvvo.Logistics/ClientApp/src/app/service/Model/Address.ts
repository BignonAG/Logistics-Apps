import { User } from "./user";

export class Address {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  isActive: boolean;
  address1: string;
  address2: string;
  province: string;
  zip: string;
  country: string;
  createdBy: User;
}
