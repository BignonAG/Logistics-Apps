import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../service/order.service';
import { NbDialogRef } from '@nebular/theme';
import { Order } from '../../../service/Model/order';
import { OrderLineItem } from '../../../service/Model/order-line-item';
import { OrderLineItemService } from '../../../service/order-line-item.service';
import { RefundService } from '../../../service/refund.service';

@Component({
  selector: 'app-refund-line-item-dialog',
  templateUrl: './refund-line-item-dialog.component.html',
  styleUrls: ['./refund-line-item-dialog.component.scss']
})
export class RefundLineItemDialogComponent implements OnInit {
  orders: Order[];
  loading: boolean;
  pickupOrders: Order[];

  constructor(protected dialogRef: NbDialogRef<RefundLineItemDialogComponent>, private _orderService: OrderService,
    private _orderLineItemService:OrderLineItemService, private _refundService: RefundService) { }

  ngOnInit() {
    this.getOrders();
    this.pickupOrders = this._refundService.getCheckedOrder();
  }

  getOrders() {
    this.loading = true;
    return this._orderService.getOrders().subscribe(
      result => {
        this.orders = result;
        for (let order of result) {
          this._orderLineItemService.getOrderLineItems(order.id).subscribe(
            result => {
              order.orderLineItems = result;

              for (let item of order.orderLineItems) item.maxQuantity = item.quantity;

              if (this.pickupOrders != null && this.pickupOrders.length > 0) {
                for (let order of this.pickupOrders.filter(x => x.checked == true)) {
                  var orderChecked = this.orders.find(x => x.id == order.id);
                  orderChecked.checked = true;
                  for (let item of order.orderLineItems.filter(x => x.checked == true)) {
                    orderChecked.orderLineItems.find(x => x.id == item.id).checked = true;
                  }
                }
                for (let order of this.pickupOrders.filter(x => x.checked != true)) {
                  var orderUnchecked = this.orders.find(x => x.id == order.id);
                  orderUnchecked.disabled = true;
                  for (let item of order.orderLineItems.filter(x => x.checked != true)) {
                    orderUnchecked.orderLineItems.find(x => x.id == item.id).disabled = true;
                  }
                }
              }

            }, error => {
              console.log(error);
            }
          )
        }

        this.loading = false;
      },
      error => {
        this.loading = false;
        console.log(error);
      }
    )
  }

  submit() {
    this.dialogRef.close(this.orders);
  }

  close() {
    this.dialogRef.close();
  }

  lineItemChecked(_ev, item: OrderLineItem, order: Order) {
    var othersOrder = this.orders.filter(x => x != order);
    if (_ev.target.checked && item != null && order != null) {// if variant is checked 
      item.checked = true;// checked vaiant 
      order.checked = true;// checked variant product
      for (let order of othersOrder) {
        order.disabled = true;
        for (let item of order.orderLineItems) {
          item.disabled = true;
        }
      }
    }
    else {// if variant is unchecked 
      item.checked = false;// uncheck variant
      // chec if there is again unchecked after uncheck variant.
      //if not so unchecked vairant product too  
      var unCheckedOrderItemLine = order.orderLineItems.filter(x => x.checked == true);
      if (unCheckedOrderItemLine.length == 0) {
        order.checked = false;
      }
      for (let order of othersOrder) {
        order.disabled = false;
        for (let item of order.orderLineItems) {
          item.disabled = false;
        }
      }
    }
  }

  orderChecked(_ev, order: Order) {
    var othersOrder = this.orders.filter(x => x != order);
    if (_ev.target.checked && order != null) {// if order checkbox is checked
      order.checked = true; // set checkbox variable in model to true
      // checked all order item related to the product
      for (let item of order.orderLineItems) {
        item.checked = true;
      }
      for (let order of othersOrder) {
        order.disabled = true;
        for (let item of order.orderLineItems) {
          item.disabled = true;
        }
      }
    } else {// if order checkbox is not checked 
      order.checked = false; // set order checkbox to false
      // unchecked all order item line
      for (let item of order.orderLineItems) {
        item.checked = false;
      }
      for (let order of othersOrder) {
        order.disabled = false;
        for (let item of order.orderLineItems) {
          item.disabled = false;
        }
      }
    }

  }

  onQteChange(event, item) {
    var qte = event.target.value; // get
    for (let order of this.orders) {
      var line = order.orderLineItems.find(x => x.id == item.id)
      line.quantity = qte;
      line.totalPrice = line.variant.retailPrice * qte;
    }
  }

}
