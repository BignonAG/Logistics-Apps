import { User } from "./user";

export class MeasurementUnit {
  id: number;
  createdOn: Date;
  createdOnLocalTime: string;
  updatedOn: Date;
  updateOnLocalTime: string;
  name: string;
  isActive: boolean;
  format: string;
  precision: number;
  code: string;
  createdBy: User;
}
