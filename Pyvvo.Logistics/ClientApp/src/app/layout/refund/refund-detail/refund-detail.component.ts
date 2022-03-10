import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RefundService } from '../../../service/refund.service';
import { Refund } from '../../../service/Model/refund';
import { RefundLineItemService } from '../../../service/refund-line-item.service';

@Component({
  selector: 'app-refund-detail',
  templateUrl: './refund-detail.component.html',
  styleUrls: ['./refund-detail.component.scss']
})
export class RefundDetailComponent implements OnInit {
  refundId: string;
  refund: Refund;
  grandTotal: number = 0;
  totalTax: number = 0;
  total: number = 0;
  shippingCharge: number = 0;

  constructor(private activatedRoute: ActivatedRoute, private _refundService: RefundService,
     private _refundLineItemService: RefundLineItemService) { }

  ngOnInit() {
    this.refundId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
    this.getRefund();
   
  }

  getRefund() {
    return this._refundService.get(this.refundId).subscribe(
      result => {
        console.log(result);
        this.refund = result;
        this.total = result.totalPrice + this.totalTax + this.shippingCharge;
        this._refundLineItemService.getEntities(result.id).subscribe(
          refundItems => {
        this.refund.refundLineItems = refundItems;
          }
        )
      },
      error => {
        console.log(error);
      }
    );
  }

}
