import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../service/order.service';
import { ActivatedRoute } from '@angular/router';
import { Order } from '../../../service/Model/order';
import { OrderLineItem } from '../../../service/Model/order-line-item';
import { OrderLineItemService } from '../../../service/order-line-item.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {
  orderGrandTotal: number = 0;
  totalTax: number = 0;
  shippingCharge: number = 0;
  total: number = 0;
  orderId: string;
  order: Order;
  orderLineItems: OrderLineItem[];
  emptyOrder :Order;

  constructor(private _orderService: OrderService, private _orderLineItemService: OrderLineItemService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.orderId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
    if (this.orderId != null && this.orderId != "")
      this.getOrder();
  }

  getOrder() {
    return this._orderService.get(this.orderId).subscribe(
      result => {
        console.log(result);
        this.order = result;
        this.getOrderLineItems();
        this.totalTax = result.totalPrice - result.subtotalBeforeTax;
        this.totalTax = +Number(this.totalTax).toFixed(2);
        for (let item of result.orderLineItems) {
          this.orderGrandTotal = this.orderGrandTotal + item.totalPrice;
        }
        this.orderGrandTotal = +Number(this.orderGrandTotal).toFixed(2);
        this.total = this.orderGrandTotal + this.shippingCharge + this.totalTax;
      },
      error => {
        console.log(error);
      }
    );
  }

  getOrderLineItems() {
    return this._orderLineItemService.getOrderLineItems(this.orderId).subscribe(
      result => {
        this.orderLineItems = result;

      },
      error => {
        console.log(error);
      }
    );
  }

}
