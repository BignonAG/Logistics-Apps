import { Status } from "./status";
import { Order } from "./order";
import { User } from "./user";
import { ProcessingLineItem } from "./processing-line-item";
import { Note } from "./Note";

export class Processing {
  id: number;
  referenceNumber: string;
  referenceNumberId: number;
  createdOn: Date;
  updatedOn: Date;
  startDate: Date;
  endDate: Date;
  isActive: boolean;
  sendUpdate: boolean;
  status: Status;
  order: Order;
  createdBy: User;
  processingLineItems: ProcessingLineItem[];
  notes: Note[];
  agent: User;
}
