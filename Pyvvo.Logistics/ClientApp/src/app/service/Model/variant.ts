import { Status } from "./status";
import { Parameter } from "./parameter";
import { Taxe } from "./taxe";
import { Image } from "./image";
import { Supplier } from "./supplier";
import { Option } from "./Option";
import { Product } from "./product";
import { LinkedVariant } from "./linked-variant";
import { StockLevel } from "./stock-level";

export class Variant {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  referenceNumber: string;
  avgSupplyTime: number;
  lineNumber: number;
  type: string;
  isActive: boolean;
  isTaxable: boolean;
  weight: boolean;
  moq: number;
  initialStockLevel: number;
  initialStockCost: number;
  retailPrice: number;
  specialPrice: number;
  sku: number;
  supplierCode: number;
  ean: string;
  upc: string;
  isbn: string;
  hsCode: string;
  name: string;
  checked: boolean;//Not mapped to .net 
  qte: number;//Not mapped to .net 
  totalPrice: number;//Not mapped to .net 
  status: Status;
  options: Option[];
  parameter: Parameter;
  product: Product;
  taxe: Taxe;
  image: Image;
  supplier: Supplier;
  purchaseOrderLineItems: LinkedVariant[];
  stockLevel: StockLevel[];
}
