import { Warehouse } from "./warehouse";
import { Status } from "./status";
import { Contact } from "./contact";
import { Company } from "./Company";
import { Role } from "./role";

export class User {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  isActive: boolean;
  status: Status;
  createdBy: User;
  location: Warehouse;
  contact: Contact;
  company: Company;
  role: Role;
}
