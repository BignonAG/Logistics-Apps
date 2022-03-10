import { Status } from "./status";
import { User } from "./user";
import { Variant } from "./variant";
import { ProductCategory } from "./ProductCategory";
import { Image } from "./image";
import { Taxe } from "./taxe";
import { Option } from './option'

export class Product {
  id: number;
  createdOn: Date;
  updateOn: Date;
  publushedOn: Date;
  isActive: boolean;
  hasMultipleVariant: boolean;
  unit: string;
  referenceNumber: string;
  name: string;
  description: string;
  tags: string;
  checked: boolean;
  status: Status;
  productCategory: ProductCategory;
  createdBy: User;
  image: Image;
  taxe: Taxe;
  variant: Variant;
  options: Option[];
  variants: Variant[];
}
