import { Invoice } from "./invoice";
import { OrderLineItem } from "./order-line-item";

export class InvoiceLineItem {
  id: number;
  createdon: Date;
  updatedon: Date;
  lineNumber: number;
  invoice: Invoice;
  orderLineItem: OrderLineItem;
}
