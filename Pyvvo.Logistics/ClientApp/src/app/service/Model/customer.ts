import { Status } from "./status";
import { Address } from "./Address";
import { User } from "./user";
import { Contact } from "./contact";
import { Note } from "./Note";
import { Currency } from "./currency";
import { Order } from "./order";

export class Customer {
  id: number;
  createdOn: Date;
  updateOn: Date;
  isActive: boolean;
  status: Status;
  billingAddress: Address;
  shippingAddress: Address;
  createdBy: User;
  currency: Currency;
  contact: Contact;
  orders: Order;
  notes: Note[];
}
