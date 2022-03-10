import { Status } from "./status";
import { Address } from "./Address";
import { User } from "./user";
import { Currency } from "./currency";
import { Customer } from "./customer";
import { Warehouse } from "./warehouse";
import { Taxe } from "./taxe";
import { ShippingMethod } from "./shipping-method";
import { Shipment } from "./Shipping";
import { Variant } from "./variant";
import { Processing } from "./processing";
import { Invoice } from "./invoice";
import { Return } from "./return";
import { Refund } from "./refund";
import { OrderLineItem } from "./order-line-item";

export class Order {
  id: number;
  checked: boolean;
  disabled: boolean;
  createdOn: Date;
  //createdOnLocalTime: string;
  updatedOn: Date;
  //updateOnLocalTime: string;
  isActive: boolean;
  paidOnValue: string;
  paidOn: Date;
  cancelOnValue: string;
  cancelOn: Date;
  referenceNumber: string;
  payementStatus: Status;
  subtotalBeforeTax: number;
  qte: number;
  totalPrice: number;
  totalTax: number;
  discountType: string;
  dsicountValue: string;
  status: Status;
  fulfillmentStatus: Status;
  billingAddress: Address;
  shippingAddress: Address;
  taxe: Taxe;
  createdBy: User;
  currency: Currency;
  customer: Customer;
  warehouse: Warehouse;
  shippingMethod: ShippingMethod;
  shippings: Shipment[];
  invoices: Invoice[];
  processings: Processing[];
  returns: Return[];
  refunds: Refund[];
  orderLineItems: OrderLineItem[];
}