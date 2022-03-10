import { Status } from "./status";
import { Order } from "./order";
import { User } from "./user";
import { RefundLineItem } from "./refund-line-item";

export class Refund {
  id: number;
  referenceNumber: string;
  totalPrice: number;
  createdOn: Date;
  updateOn: Date;
  refundedOn: Date;
  isActive: boolean;
  status: Status;
  order: Order;
  refundLineItems: RefundLineItem[];
  createdBy: User;
}
