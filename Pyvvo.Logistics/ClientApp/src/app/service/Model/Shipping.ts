import { Note } from "./Note";
import { ShippingMethod } from "./shipping-method";
import { Order } from "./order";
import { Status } from "./status";
import { User } from "./user";

export class Shipment {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  shippedOn: Date;
  deliveredOn: Date;
  startDate: Date;
  endDate: Date;
  isActive: boolean;
  sendUpdate: string;
  referenceNumber: string;
  trackNumber: string;
  trackUrl: string;
  notes: Note[];
  //shipmentLineItems: ShipmentLineItem[];
  shippingMethod: ShippingMethod[];
  order: Order;
  status: Status;
  agent: User;
  createdBy: User;
}
