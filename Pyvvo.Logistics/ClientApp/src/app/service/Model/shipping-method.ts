import { User } from "./user";
import { Status } from "./status";
import { Currency } from "./currency";
import { Parameter } from "./parameter";
import { CarrierService } from "./carrier-service";

export class ShippingMethod {
  id: number;
  createdOn: Date;
  createdOnLocalTime: string;
  updatedOn: Date;
  updateOnLocalTime: string;
  name: string;
  rate: number;
  status: Status;
  minParameter: Parameter;
  maxParameter: Parameter;
  currency: Currency;
  carrierService: CarrierService;
  isActive: boolean;
  createdBy: User;
}
