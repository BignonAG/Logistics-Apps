import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Status } from '../../../service/Model/status';
import { Order } from '../../../service/Model/order';
import { ProcessingLineItem } from '../../../service/Model/processing-line-item';
import { ProcessingService } from '../../../service/processing.service';
import { NbDialogService } from '@nebular/theme';
import { Router, ActivatedRoute } from '@angular/router';
import { StatusService } from '../../../service/status.service';
import { Processing } from '../../../service/Model/processing';
import { RefundLineItemDialogComponent } from '../../refund/refund-line-item-dialog/refund-line-item-dialog.component';
import { UserService } from 'src/app/service/user.service';
import { User } from 'src/app/service/Model/user';
import { ProcessingLineItemService } from '../../../service/processing-line-item.service';

@Component({
  selector: 'app-processing-create',
  templateUrl: './processing-create.component.html',
  styleUrls: ['./processing-create.component.scss']
})
export class ProcessingCreateComponent implements OnInit {
  processingForm: FormGroup;
  loading = false;
  cardLoading = false;
  errorMessage: string;
  processingId: string;
  orderId: number;
  formTitle: string = "Create new order processing";
  txtBtnSubmit: string = "Save";
  status: Status[] = [];
  selectedStatusId;
  statusCategId = 22;
  checkedOrderItems: Order[] = [];
  totalPrice: number = 0;
  currencySymbol: string;
  orderLineItemSelectErrorMessage: string;
  processingLineItems: ProcessingLineItem[] = [];
  agents: User[];
  selectedAgentId;
  referenceNumber: string;
  referenceNumberId: number;

  constructor(private _fb: FormBuilder, private _processingService: ProcessingService, private _dialogService: NbDialogService,
    private router: Router, private activatedRoute: ActivatedRoute, private _statusService: StatusService,
    private _userService: UserService, private _processingLineItemService: ProcessingLineItemService) {
    // Create form group that the  html form and construct the json entity
    this.processingForm = this._fb.group({
      totalPrice: '',
      isActive: true,
      agent: this._fb.group({
        id: ['', [Validators.required]]
      }),
      status: this._fb.group({
        id: ['', [Validators.required]]
      })
    });
    this.processingId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
  }

  ngOnInit() {
    if (this.processingId != null && this.processingId != "") {
      this.formTitle = "Update processing informations";
      this.txtBtnSubmit = "Update";
      this.cardLoading = true;
      this.getProcessing();//Get supplier information to update and pre-fullfil the form
    }
    this.getStatus();
    this.getAgents();
  }

  upsert(processing: Processing) {
    if (this.processingForm.valid) {
      //processing.totalPrice = this.totalPrice;
      processing.processingLineItems = this.processingLineItems;
      processing.order = this.checkedOrderItems[0];
      this.loading = true;
      if (this.processingId != null && this.processingId != "") {
        var id: number = +this.processingId;
        processing.id = id;
        processing.referenceNumber = this.referenceNumber
        processing.referenceNumberId = this.referenceNumberId
        return this._processingService.update(processing).subscribe(
          result => {
            this.router.navigateByUrl("/app/processings")
          },
          error => {
            console.log(error);
            this.errorMessage = "Something wrong! Please check your informations and retry...";
            this.loading = false;
          }
        );
      } else {
        return this._processingService.create(processing).subscribe(
          result => {
            this.router.navigateByUrl("/app/processings")
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

  getAgents(){
    this._userService.getUsers().subscribe(
      result => {
        this.agents = result
      },error => {
        console.log(error)
      }
    )
  }

  getProcessing() {
    return this._processingService.get(this.processingId).subscribe(
      result => {
        this.referenceNumber = result.referenceNumber;
        this.referenceNumberId = result.referenceNumberId;
        this.selectedAgentId = result.agent.id;
        this.selectedStatusId = result.status.id;
        this.orderId = result.order.id;
        this.processingForm.patchValue(result);
        this._processingLineItemService.getEntities(result.id).subscribe(
          items => {
            console.log(items)
            var order = new Order();
            order.id = result.order.id;
            order.checked = true;
            order.orderLineItems = [];
            for (let item of items) {
              item.orderLineItem.checked = true;
              order.orderLineItems.push(item.orderLineItem);
            }
            this.checkedOrderItems.push(order);
            this.createProcessingLineItem();
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
    this._processingService.sendCheckedOrder(this.checkedOrderItems);
    this._dialogService.open(RefundLineItemDialogComponent, { closeOnBackdropClick: false })
      .onClose.subscribe(result => {
        if (result != null && result.length > 0) {
          this.checkedOrderItems = result;
          this.currencySymbol = this.checkedOrderItems[0].currency.currencySymbol;
          //this.createProcessingLineItem();
        }
        this.createProcessingLineItem();
        this.getTotalPrice();
      });
  }

  //return that second level input has error // e.g: selected option not valid
  formSecondGroupLevelHasError(controlName: string, secondLevelControlName: string, errorName: string) {
    return ((this.processingForm.controls[controlName]) as FormGroup).controls[secondLevelControlName].hasError(errorName);
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

  createProcessingLineItem() {
    for (let order of this.checkedOrderItems.filter(x => x.checked == true)) {
      for (let item of order.orderLineItems.filter(x => x.checked == true)) {
        item.order = null;
        var processingItem = new ProcessingLineItem();
        //processingItem.quantity = item.quantity;
        processingItem.orderLineItem = item;
        this.processingLineItems.push(processingItem);
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
