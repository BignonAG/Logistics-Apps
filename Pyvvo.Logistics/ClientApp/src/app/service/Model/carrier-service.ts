import { Address } from "./Address";
import { Contact } from "./contact";
import { User } from "./user";
import { ShippingMethod } from "./shipping-method";

export class CarrierService {
  id: number;
  createdOn: Date;
  createdOnLocalTime: string;
  updatedOn: Date;
  updateOnLocalTime: string;
  isActive: boolean;
  name: string;
  address: Address;
  contact: Contact;
  createdBy: User;
  shippingMethods: ShippingMethod[];
}
