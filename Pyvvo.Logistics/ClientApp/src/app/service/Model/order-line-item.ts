import { Order } from "./order";
import { Status } from "./status";
import { Variant } from "./variant";
import { InvoiceLineItem } from "./invoice-line-item";
import { RefundLineItem } from "./refund-line-item";
import { ReturnLineItem } from "./return-line-item";
import { ProcessingLineItem } from "./processing-line-item";
import { ShipmentLineItem } from "./shipment-line-item";

export class OrderLineItem {
  id: number;
  checked: boolean;
  disabled: boolean;
  createdOn: Date;
  updateOn: Date;
  lineNumber: number;
  name: string;
  isOutOfStock: boolean;
  quantity: number;
  maxQuantity: number;
  totalPrice: number;
  order: Order;
  fulFillmentStatus: Status;
  variant: Variant;
  invoiceLineItems: InvoiceLineItem[];
  refundLineItems: RefundLineItem[];
  shippmentLineItem: ShipmentLineItem[];
  processionLineItem: ProcessingLineItem[];
  returnLineItems: ReturnLineItem[];
}
