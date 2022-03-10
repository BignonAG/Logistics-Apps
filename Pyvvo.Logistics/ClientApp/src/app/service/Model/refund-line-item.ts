import { Status } from "./status";
import { Refund } from "./refund";
import { OrderLineItem } from "./order-line-item";

export class RefundLineItem {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  lineNumber: number;
  quantity: number;
  status: Status;
  refund: Refund;
  orderLineItem: OrderLineItem;
}
