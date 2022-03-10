import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Status } from '../../../service/Model/status';
import { Order } from '../../../service/Model/order';
import { User } from '../../../service/Model/user';
import { ReturnLineItem } from '../../../service/Model/return-line-item';
import { NbDialogService } from '@nebular/theme';
import { StatusService } from '../../../service/status.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../../service/user.service';
import { Return } from '../../../service/Model/return';
import { RefundLineItemDialogComponent } from '../../refund/refund-line-item-dialog/refund-line-item-dialog.component';
import { ReturnService } from '../../../service/return.service';
import { ReturnLineItemService } from '../../../service/return-line-item.service';

@Component({
  selector: 'app-return-create',
  templateUrl: './return-create.component.html',
  styleUrls: ['./return-create.component.scss']
})
export class ReturnCreateComponent implements OnInit {
  returnForm: FormGroup;
  loading = false;
  cardLoading = false;
  errorMessage: string;
  returnId: string;
  orderId: number;
  formTitle: string = "Create new order return";
  txtBtnSubmit: string = "Save";
  status: Status[] = [];
  selectedStatusId;
  selectedAgentId;
  referenceNumber: string;
  referenceNumberId: number;
  statusCategId = 22;
  checkedOrderItems: Order[] = [];
  totalPrice: number = 0;
  currencySymbol: string;
  orderLineItemSelectErrorMessage: string;
  returnLineItems: ReturnLineItem[] = [];
  agents: User[];

  constructor(private _fb: FormBuilder, private _returnService: ReturnService, private _dialogService: NbDialogService,
    private router: Router, private activatedRoute: ActivatedRoute, private _statusService: StatusService,
    private _userService: UserService, private _returnLineItemService: ReturnLineItemService) {
    // Create form group that the  html form and construct the json entity
    this.returnForm = this._fb.group({
      totalPrice: '',
      isActive: true,
      shippedOn: new Date(),
      receiveOn: new Date(),
      startDate: new Date(),
      endDate: new Date(),
      sendUpdate: true,
      trackNumber: '',
      trackUrl: '',
      shippingCharge: '',
      agent: this._fb.group({
        id: ['', [Validators.required]]
      }),
      status: this._fb.group({
        id: ['', [Validators.required]]
      })
    });
    this.returnId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
  }

  ngOnInit() {
    if (this.returnId != null && this.returnId != "") {
      this.formTitle = "Update return informations";
      this.txtBtnSubmit = "Update";
      this.cardLoading = true;
      this.getReturn();//Get supplier information to update and pre-fullfil the form
    }
    this.getStatus();
    this.getAgents();
  }

  upsert(_return: Return) {
    if (this.returnForm.valid) {
      //return.totalPrice = this.totalPrice;
      _return.returnLineItems = this.returnLineItems;
      _return.order = this.checkedOrderItems[0];
      this.loading = true;
      if (this.returnId != null && this.returnId != "") {
        var id: number = +this.returnId;
        _return.id = id;
        _return.referenceNumber = this.referenceNumber
        _return.referenceNumberId = this.referenceNumberId
        return this._returnService.update(_return).subscribe(
          result => {
            this.router.navigateByUrl("/app/returns")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );
      } else {
        return this._returnService.create(_return).subscribe(
          result => {
            this.router.navigateByUrl("/app/returns")
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

  getAgents() {
    this._userService.getUsers().subscribe(
      result => {
        this.agents = result
      }, error => {
        console.log(error)
      }
    )
  }

  getReturn() {
    return this._returnService.get(this.returnId).subscribe(
      result => {
        console.log(result);
        this.referenceNumber = result.referenceNumber;
        this.referenceNumberId = result.referenceNumberId;
        this.selectedAgentId = result.agent.id;
        this.selectedStatusId = result.status.id;
        this.orderId = result.order.id;
        this.returnForm.patchValue(result);
        this.cardLoading = false;
        this._returnLineItemService.getEntities(result.id).subscribe(
          items => {
            var order = new Order();
            order.id = result.order.id;
            order.checked = true;
            order.orderLineItems = [];
            for (let item of items) {
              item.orderLineItem.checked = true;
              order.orderLineItems.push(item.orderLineItem);
            }
            this.checkedOrderItems.push(order);
            this.createReturnLineItem();
            this.getTotalPrice();
          }
        )
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
    this._returnService.sendCheckedOrder(this.checkedOrderItems);
    this._dialogService.open(RefundLineItemDialogComponent, { closeOnBackdropClick: false })
      .onClose.subscribe(result => {
        if (result != null && result.length > 0) {
          this.checkedOrderItems = result;
          this.currencySymbol = this.checkedOrderItems[0].currency.currencySymbol;
          //this.createReturnLineItem();
        }
        this.createReturnLineItem();
        this.getTotalPrice();
      });
  }

  //return that second level input has error // e.g: selected option not valid
  formSecondGroupLevelHasError(controlName: string, secondLevelControlName: string, errorName: string) {
    return ((this.returnForm.controls[controlName]) as FormGroup).controls[secondLevelControlName].hasError(errorName);
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

  createReturnLineItem() {
    for (let order of this.checkedOrderItems.filter(x => x.checked == true)) {
      for (let item of order.orderLineItems.filter(x => x.checked == true)) {
        item.order = null
        var returnItem = new ReturnLineItem();
        //returnItem.quantity = item.quantity;
        returnItem.orderLineItem = item;
        this.returnLineItems.push(returnItem);
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
