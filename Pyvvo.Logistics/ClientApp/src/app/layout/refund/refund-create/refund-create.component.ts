import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Status } from '../../../service/Model/status';
import { RefundService } from '../../../service/refund.service';
import { Router, ActivatedRoute } from '@angular/router';
import { StatusService } from '../../../service/status.service';
import { Refund } from '../../../service/Model/refund';
import { Order } from '../../../service/Model/order';
import { NbDialogService } from '@nebular/theme';   
import { RefundLineItemDialogComponent } from '../refund-line-item-dialog/refund-line-item-dialog.component';
import { RefundLineItem } from '../../../service/Model/refund-line-item';
import { RefundLineItemService } from '../../../service/refund-line-item.service';

@Component({
  selector: 'app-refund-create',
  templateUrl: './refund-create.component.html',
  styleUrls: ['./refund-create.component.scss']
})
export class RefundCreateComponent implements OnInit {
  refundForm: FormGroup;
  loading = false;
  cardLoading = false;
  errorMessage: string;
  refundId: string;
  orderId: number;
  formTitle: string = "Create new order refund";
  txtBtnSubmit: string = "Save";
  status: Status[] = [];
  selectedStatusId;
  statusCategId = 22;
  checkedOrderItems: Order[]= [];
  totalPrice: number = 0;
  currencySymbol: string;
  orderLineItemSelectErrorMessage: string;
  refundLineItems: RefundLineItem[] = [];

  constructor(private _fb: FormBuilder, private _refundService: RefundService, private _dialogService: NbDialogService,
    private router: Router, private activatedRoute: ActivatedRoute, private _statusService: StatusService,
    private _refundLineItemService: RefundLineItemService) {
    // Create form group that the  html form and construct the json entity
    this.refundForm = this._fb.group({
      totalPrice:'',
      isActive: true,
      status: this._fb.group({
        id: ['', [Validators.required]]
      })
    });
    this.refundId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
  }

  ngOnInit() {
    if (this.refundId != null && this.refundId != "") {
      this.formTitle = "Update refund informations";
      this.txtBtnSubmit = "Update";
      this.cardLoading = true;
      this.getRefund();//Get supplier information to update and pre-fullfil the form
    }
    this.getStatus();
  }

  upsert(refund: Refund) {
    if (this.refundForm.valid) {
      console.log(refund);
      refund.totalPrice = this.totalPrice;
      refund.refundLineItems = this.refundLineItems;
      console.log(refund);
      this.loading = true;
      if (this.refundId != null && this.refundId != "") {
        var id: number = +this.refundId;
        refund.id = id;
        return this._refundService.update(refund).subscribe(
          result => {
            this.router.navigateByUrl("/app/refunds")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );
      } else {
        return this._refundService.create(refund).subscribe(
          result => {
            this.router.navigateByUrl("/app/refunds")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );
      }
    }
  }

  getRefund() {
    return this._refundService.get(this.refundId).subscribe(
      result => {
        this.selectedStatusId = result.status.id;
        this.orderId = result.order.id;
        this.refundForm.patchValue(result);
        this._refundLineItemService.getEntities(result.id).subscribe(
          refundItems => {
            var order = new Order();
            order.id = result.order.id;
            order.checked = true;
            order.orderLineItems = [];
            for (let item of refundItems) {
              item.orderLineItem.checked = true;
              order.orderLineItems.push(item.orderLineItem);
            }
            this.checkedOrderItems.push(order);
            this.createRefundLineItem();
            this.getTotalPrice();
          }
        )
        this.cardLoading = false;
      },
      error => {
        console.log(error);
        this.cardLoading = false;
      }
    );
  }

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

  // Open product variant listing dialog
  openDialog() {
    this._refundService.sendCheckedOrder(this.checkedOrderItems);
    this._dialogService.open(RefundLineItemDialogComponent, { closeOnBackdropClick: false })
      .onClose.subscribe(result => {
        if (result != null && result.length > 0) {
          this.checkedOrderItems = result;
          this.currencySymbol = this.checkedOrderItems[0].currency.currencySymbol;
          //this.createRefundLineItem();
        }
        this.createRefundLineItem();
        this.getTotalPrice();
      });
  }

  //return that second level input has error // e.g: selected option not valid
  formSecondGroupLevelHasError(controlName: string, secondLevelControlName: string, errorName: string) {
    return ((this.refundForm.controls[controlName]) as FormGroup).controls[secondLevelControlName].hasError(errorName);
  }


  // remove added product 
  remove(item) {
    if (this.checkedOrderItems.length > 0) {
      for (let order of this.checkedOrderItems.filter(x => x.checked == true)) {
        var line = order.orderLineItems.find(x => x.id == item.id);
        if (line != null) {
          order.orderLineItems.splice(order.orderLineItems.indexOf(item), 1);
          this.totalPrice = this.totalPrice - line.totalPrice;
        }
        if (order.orderLineItems.length == 0)
          this.checkedOrderItems.splice(this.checkedOrderItems.indexOf(order), 1);// remove the product from the table 
      }
    }
  }

  createRefundLineItem() {
    for (let order of this.checkedOrderItems.filter(x => x.checked == true)) {
      for (let item of order.orderLineItems.filter(x => x.checked == true)) {
        item.order.orderLineItems = null;
        var refundItem = new RefundLineItem();
        refundItem.quantity = item.quantity;
        refundItem.orderLineItem = item;
        this.refundLineItems.push(refundItem);
        this.totalPrice = this.totalPrice + item.totalPrice;
      }
    }
  }

  getTotalPrice() {
    this.totalPrice = 0;
    for (let order of this.checkedOrderItems.filter(x => x.checked == true)) {
      for (let item of order.orderLineItems.filter(x => x.checked == true)) {
        this.totalPrice = this.totalPrice + item.totalPrice;
      }
    }
  }
  
}
