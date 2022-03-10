import { Variant } from "./variant";

export class Option {
  id: number;
  name: string;
  variant: Variant;
  createdOn: Date;
  updatedOn: Date;
  optionValues: string[];
}
