import { Status } from "./status";
import { Order } from "./order";
import { User } from "./user";
import { Note } from "./Note";
import { ReturnLineItem } from "./return-line-item";

export class Return {
  id: number;
  referenceNumber: string;
  referenceNumberId: number;
  shippedOn: Date;
  receiveOn: Date;
  createdOn: Date;
  updatedOn: Date;
  startDate: Date;
  endDate: Date;
  isActive: boolean;
  sendUpdate: boolean;
  trackNumber: string;
  trackUrl: string;
  shippingCharge: string;
  status: Status;
  order: Order;
  createdBy: User;
  returnLineItems: ReturnLineItem[];
  notes: Note[];
  agent: User;
}
