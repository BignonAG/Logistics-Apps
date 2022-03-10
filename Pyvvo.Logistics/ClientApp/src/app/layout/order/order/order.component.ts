import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../service/order.service';
import { Order } from '../../../service/Model/order';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  successMessage: string;
  message: string;
  errorMessage: string;
  loading = true;
  orders: Order[];
  

  constructor(private _orderService: OrderService) { }

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    this.loading = true;
    return this._orderService.getOrders().subscribe(
      result => {
        this.orders = result;
        //console.log(result);
        if (result.length == 0)
          this.message = "There is no data at this time...";
        this.loading = false;
      }, error => {
        console.log(error);
        this.loading = false;
        this.errorMessage = "An error occured! Please try again...";
      }
    )
  }

  deleteOrder(id: number) {
    return this._orderService.delete(id).subscribe(
      result => {
        this.getOrders();
        this.successMessage = "The order has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }
}
