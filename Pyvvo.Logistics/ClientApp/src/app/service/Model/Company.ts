import { User } from "./user";
import { Status } from "./status";
import { Contact } from "./contact";

export class Company {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  isActive: boolean;
  users: User[];
  //currency: Currency;
  status: Status;
  contact: Contact;
  //tenant: Tenant;
  //measurementUnit: MeasurementUnit:
}
