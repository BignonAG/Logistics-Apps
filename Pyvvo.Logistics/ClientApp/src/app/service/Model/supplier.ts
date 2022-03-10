import { Note } from "./Note";
import { Address } from "./Address";
import { Contact } from "./contact";
import { User } from "./user";

export class Supplier {
  id: number;
  createdOn: Date;
  createdOnLocalTime: string;
  updatedOn: Date;
  isActive: boolean;
  notes: Note[];
  //variants: Variant[];
  address: Address;
  contact: Contact;
  refUser: User;
  createdBy: User;

}
