import { Order } from "./order";
import { User } from "./user";
import { InvoiceLineItem } from "./invoice-line-item";
import { PayementTerm } from "./payement-term";

export class Invoice {
  id: number;
  createdOn: Date;
  updateOn: Date;
  isActive: boolean;
  referenceNumber: string;
  description: string;
  payementTerm: PayementTerm;
  order: Order;
  createdBy: User;
  invoiceLineItems: InvoiceLineItem[];
}
