import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Status } from '../../../service/Model/status';
import { CustomerService } from '../../../service/customer.service';
import { StatusService } from '../../../service/status.service';
import { Customer } from '../../../service/Model/customer';
import { TaxeService } from '../../../service/taxe.service';
import { Taxe } from '../../../service/Model/taxe';
import { WarehouseService } from '../../../service/warehouse.service';
import { Warehouse } from '../../../service/Model/warehouse';
import { CurrencyService } from '../../../service/currency.service';
import { Currency } from '../../../service/Model/currency';
import { ShippingMethodService } from '../../../service/shipping-method.service';
import { ShippingMethod } from '../../../service/Model/shipping-method';
import { OrderLineItem } from '../../../service/Model/order-line-item';
import { NbDialogService } from '@nebular/theme';
import { OrderLineItemDialogComponent } from '../order-line-item-dialog/order-line-item-dialog.component';
import { Product } from '../../../service/Model/product';
import { Order } from '../../../service/Model/order';
import { OrderService } from '../../../service/order.service';
import { Router, ActivatedRoute } from '@angular/router';
import { OrderLineItemService } from '../../../service/order-line-item.service';
import { ProductService } from '../../../service/product.service';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.scss']
})
export class OrderCreateComponent implements OnInit {
  orderForm: FormGroup;
  loading = false;
  cardLoading = false;
  errorMessage: string;
  orderId: string;
  updateShippingAddressId: number;
  updateBillingAddressId: number;
  formTitle: string = "Add new order";
  txtBtnSubmit: string = "Save";
  sameAddressChecked: boolean;
  subtotalBeforeTax: number = 0;
  totalPrice: number = 0;
  totalTax: number = 0;
  taxeRate: number = 0;

  statusCategId = 19;
  selectedStatusId;
  status: Status[] = [];

  selectedFulFillmentStatusId;
  fulFillmentStatus: Status[] = [];

  selectedPaiementStatusId;
  paiementStatus: Status[] = [];

  customers: Customer[];
  selectedCustomerId: number;

  taxes: Taxe[];
  selectedTaxeId;

  currencies: Currency[];
  selectCurrencyId;

  warehouses: Warehouse[];
  selectedWarehouseId;

  shippingMethods: ShippingMethod[];
  selectIdShippingMId;

  orderLineItems: OrderLineItem[] = [];
  selectedProducts: Product[] = [];
  orderLineItemSelectErrorMessage: string;

  constructor(private _fb: FormBuilder, private _customerService: CustomerService, private _statusService: StatusService,
    private _taxeService: TaxeService, private _warehouseService: WarehouseService, private _currencyService: CurrencyService,
    private _shippingMethodService: ShippingMethodService, private _dialogService: NbDialogService, private _orderService: OrderService,
    private router: Router, private activatedRoute: ActivatedRoute, private _orderLineItemService: OrderLineItemService,
    private _productService: ProductService) {

    // Build order form group
    this.orderForm = this._fb.group({
      customer: this._fb.group({
        id: ['', Validators.required]
      }),
      paidOnValue: new Date(),
      cancelOnValue: new Date(),
      //referenceNumber: [''],
      subtotalBeforeTax: ['0'],
      totalPrice: ['0'],
      totalTax: ['0'],
      discountType: [''],
      dsicountValue: ['0'],
      qte: ['1'],
      isActive: true,
      payementStatus: this._fb.group({
        id: ['', [Validators.required]]
      }),
      status: this._fb.group({
        id: ['', [Validators.required]]
      }),
      fulfillmentStatus: this._fb.group({
        id: ['', [Validators.required]]
      }),
      taxe: this._fb.group({
        id: ['', [Validators.required]]
      }),
      currency: this._fb.group({
        id: ['', [Validators.required]]
      }),
      warehouse: this._fb.group({
        id: ['', [Validators.required]]
      }),
      shippingMethod: this._fb.group({
        id: ['', [Validators.required]]
      }),
      shippingAddress: this._fb.group({
        address1: ['', [Validators.required]],
        address2: '',
        province: '',
        zip: ['', [Validators.required]],
        country: ['', [Validators.required]],
      }),
      billingAddress: this._fb.group({
        address1: [''],
        address2: [''],
        province: [''],
        zip: [''],
        country: [''],
      }),
    });
    this.selectedTaxeId = 0;
    this.selectIdShippingMId = 0;
  }

  ngOnInit() {
    this.getCustomers(); // Get customer for select list option
    this.getOrderProductVariant(); // Product order variants
    this.getPaiementStatus(); // get paiement status
    this.getFulFillementStatus(); // Get fulfillment status options
    this.getStatus();// Get status options =
    this.getTaxes();// Get taxe form selection option
    this.getWarehouses();// get warehouse
    this.getCurrencies();
    this.getShippingMethod();
    this.sameAddressChecked = false;
    this.orderId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
    if (this.orderId != null && this.orderId != "") {
      this.formTitle = "Update order";
      this.txtBtnSubmit = "Update";
      this.cardLoading = true;
      this.sameAddressChecked = false;// allow user to udpdate the 2 addresses
      this.getOrder();//Get supplier information to update and pre-fullfil the form
    }
  }

  setCustomDataBeforeSave(order: Order) {
    this.loading = true; // enable button loading
    if (this.sameAddressChecked) // Check if toogle is checked 
      order.billingAddress = order.shippingAddress;
    order.orderLineItems = this.orderLineItems;
    order.subtotalBeforeTax = this.subtotalBeforeTax;
    order.totalPrice = this.totalPrice;
    order.totalTax = this.totalTax;
    if (order.paidOnValue != null && order.paidOnValue != "") {
      var paidOn = new Date(this.orderForm.controls['paidOnValue'].value);
      order.paidOn = new Date();
      order.paidOn.setDate(paidOn.getDate());
    }
    if (order.cancelOnValue != null && order.cancelOnValue != "") {
      var cancelOn = new Date(this.orderForm.controls['cancelOnValue'].value);
      order.cancelOn = new Date();
      order.cancelOn.setDate(cancelOn.getDate());
    }
  }

  upsert(order: Order) {
    if (this.orderLineItems.length > 0 && this.orderForm.valid) {
      this.setCustomDataBeforeSave(order);
      if (this.orderId != null && this.orderId != "") {
        var id: number = + this.orderId;
        order.id = id;
        if (this.updateShippingAddressId != 0) order.shippingAddress.id = this.updateShippingAddressId;
        if (this.updateBillingAddressId != 0) order.billingAddress.id = this.updateBillingAddressId;
        return this._orderService.update(order).subscribe(
          result => {
            this.router.navigateByUrl("/app/orders")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );

      } else {

        return this._orderService.create(order).subscribe(
          result => {
            this.router.navigateByUrl("/app/orders")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );

      }
    }
    else if (this.orderLineItems.length == 1) {
      this.orderLineItemSelectErrorMessage = "Please add at least one product item!";
    }
    else {
      this.errorMessage = "Something wrong! Please check your informations and retry...";
    }
  }

  //return that input has error 
  formHasError(controlName: string, errorName:string) {
    return this.orderForm.controls[controlName].hasError(errorName);
  }

  // Get selected order to update 
  getOrder() {
    return this._orderService.get(this.orderId).subscribe(
      result => {
        this.updateShippingAddressId = result.shippingAddress.id;
        this.updateBillingAddressId = result.billingAddress.id;
        this.selectedStatusId = result.status.id;
        this.selectedCustomerId = result.customer.id;
        this.selectedFulFillmentStatusId = result.fulfillmentStatus.id;
        this.selectedPaiementStatusId = result.payementStatus.id;
        this.selectCurrencyId = result.currency.id;
        this.selectedTaxeId = result.taxe.id;
        this.taxeRate = result.taxe.rate;
        this.selectedWarehouseId = result.warehouse.id;
        this.selectIdShippingMId = result.shippingMethod.id;
        
        //this.subtotalBeforeTax = result.subtotalBeforeTax;
        //this.totalPrice = result.totalPrice;
        
        this.orderLineItems = result.orderLineItems;

        this.orderForm.patchValue(result);
        this.orderForm.controls['paidOnValue'].setValue(result.paidOn);
        this.orderForm.controls['cancelOnValue'].setValue(result.cancelOn);
        if (this.orderLineItems != null && this.orderLineItems.length > 0) {
          return this.getCheckedProducts();
        }
      },
      error => {
        console.log(error);
        this.cardLoading = false;
      }
    );
  }

  getCheckedProducts() {
    return this._orderLineItemService.getOrderLineItems(this.orderId).subscribe(
      result => {
        var product = new Product();
        product.checked = true;
        product.variants = [];
        for (let item of result) {
          item.variant.checked = true;
          item.variant.qte = item.quantity;
          product.variants.push(item.variant);
        }
        this.selectedProducts = [product];
        this.createdOrderLineItem();
        this.cardLoading = false;
        
      }, error => {
        this.cardLoading = false;
        console.log(error);
      }
    )
  }


  //create order line item list
  createdOrderLineItem() {
    this.orderLineItems = [];
    if (this.selectedProducts != null && this.selectedProducts.length > 0) { // check if products are added in the form
      for (let product of this.selectedProducts.filter(x => x.checked == true)) {
        for (let variant of product.variants.filter(x => x.checked == true)) {
          var qte = 1;// quantity
          if (this.orderId != null && this.orderId != "") qte = variant.qte;
          variant.totalPrice = variant.retailPrice * qte; // set initial total price
          variant.qte = qte;
          // create order line item 
          var lineItem = new OrderLineItem();
          lineItem.variant = variant;
          lineItem.quantity = qte;
          lineItem.totalPrice = variant.totalPrice;
          this.orderLineItems.push(lineItem); // add to order line item list
        }
      }
      this.calculatePrices();
      if (this.orderLineItems.length > 0)
        this.orderLineItemSelectErrorMessage = null;
    }
    if (this.orderLineItems.length == 0) {
      this.subtotalBeforeTax = 0;
      this.totalPrice = 0;
      this.totalTax = 0;
    }
  }

  calculatePrices() {
    this.subtotalBeforeTax = 0;
    this.subtotalBeforeTax = 0;
    if (this.selectedProducts.length > 0) { // check if products are added in the form
      for (let product of this.selectedProducts.filter(x => x.checked == true)) {
        for (let variant of product.variants.filter(x => x.checked == true)) {
          this.subtotalBeforeTax = this.subtotalBeforeTax + variant.totalPrice;
        }
      }
      if (this.taxeRate > 0) {
        this.totalPrice = this.subtotalBeforeTax + (this.subtotalBeforeTax * this.taxeRate);
        var totalPriceString = this.totalPrice.toFixed(2);
        this.totalPrice = Number(totalPriceString);
        this.totalTax = this.totalPrice - this.subtotalBeforeTax;
        var totalTaxString = this.totalTax.toFixed(2);
        this.totalTax = Number(totalTaxString); 
      }
      else {
        this.totalPrice = this.subtotalBeforeTax;
        this.totalTax = 0;

      }
    }
  }

  //return that second level input has error // e.g: selected option not valid
  formSecondGroupLevelHasError(controlName: string, secondLevelControlName: string, errorName: string) {
    return ((this.orderForm.controls[controlName]) as FormGroup).controls[secondLevelControlName].hasError(errorName);
  }

  // On taxe selected
  onTaxeChange(_ev, rate) {
    this.taxeRate = rate;
    this.calculatePrices();
  }
  
  // Open product variant listing dialog
  openDialog() {
    this._productService.sendCheckedProduct(this.selectedProducts);
    this._dialogService.open(OrderLineItemDialogComponent, { closeOnBackdropClick: false })
      .onClose.subscribe(result => {
        if (result != null && result.length > 0) {
          this.selectedProducts = result;
        }
        this.createdOrderLineItem();
      });
  }

  
  // calculate the total price for variant on input quantity value change 
  onQteChange(event, variant) {
    var qte = event.target.value; // get
    var line = this.orderLineItems.find(x => x.variant.id == variant.id)
    line.quantity = qte;
    variant.qte = qte;
    line.totalPrice = line.variant.retailPrice * qte;
    variant.totalPrice = line.totalPrice;
    this.calculatePrices();
  }

  // remove added product 
  removeVariant(variant) {
    if (this.selectedProducts.length > 0) {
      for (let product of this.selectedProducts.filter(x => x.checked == true)) {
        if (product.variants.find(x => x.id == variant.id) != null) 
          product.variants.splice(product.variants.indexOf(variant), 1);
        if (product.variants.length == 0) 
          this.selectedProducts.splice(this.selectedProducts.indexOf(product), 1);// remove the product from the table 
      }
      var line = this.orderLineItems.find(x => x.variant.id == variant.id);
      this.orderLineItems.splice(this.orderLineItems.indexOf(line), 1);
      this.calculatePrices();
    }
  }

  // Get customer for select option
  getCustomers() {
    return this._customerService.getCustomers().subscribe(
      result => {
        this.customers = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  // Get order product item
  getOrderProductVariant() {
    return null;
  }

  //Get paiement status 
  getPaiementStatus() {
    return this._statusService.getStatus(20).subscribe(
      result => {
        this.paiementStatus = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  // Get order status
  getStatus() {
    return this._statusService.getStatus(this.statusCategId).subscribe(
      result => {
        this.status = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  // Get order fulfillment status
  getFulFillementStatus() {
    return this._statusService.getStatus(21).subscribe(
      result => {
        this.fulFillmentStatus = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  // Get taxe slection options 
  getTaxes() {
    return this._taxeService.getTaxes().subscribe(
      result => {
        this.taxes = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  // Get selection option curencies
  getCurrencies() {
    return this._currencyService.getCurrencies().subscribe(
      result => {
        this.currencies = result;
      },
      error => {
        console.log(error);
      }
    )
  }

  // Get Warehouse list 
  getWarehouses() {
    this._warehouseService.getEntities().subscribe(
      result => {
        this.warehouses = result;
      },
      error => console.log(error)
    )
  }

  // Get Shipping method
  getShippingMethod() {
    this._shippingMethodService.getShippingMethod().subscribe(
      result => {
        this.shippingMethods = result;
      },
      error => console.log(error)
    )
  }

}
