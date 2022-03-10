import { User } from "./user";
import { MeasurementUnit } from "./measurement-unit";

export class Parameter {
  id: number;
  createdOn: Date;
  createdOnLocalTime: string;
  updatedOn: Date;
  updateOnLocalTime: string;
  name: string;
  isActive: boolean;
  length: number;
  width: number;
  height: number;
  weight: number;
  weightUnit: MeasurementUnit;
  dimensionUnit: MeasurementUnit;
  createdBy: User;
}
