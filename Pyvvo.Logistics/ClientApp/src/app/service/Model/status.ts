import { StatusCategory } from "./StatusCategory";

export class Status {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  isActive: boolean;
  name: string;
  description: string;
  statusCategory: StatusCategory;
}
