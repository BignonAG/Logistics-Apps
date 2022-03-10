import { Component, OnInit } from '@angular/core';
import { RefundService } from '../../../service/refund.service';
import { Refund } from '../../../service/Model/refund';

@Component({
  selector: 'app-refund',
  templateUrl: './refund.component.html',
  styleUrls: ['./refund.component.scss']
})
export class RefundComponent implements OnInit {
  refunds: Refund[];
  successMessage: string;
  errorMessage: string;
  message: string;
  loading: boolean;
  constructor(private _refundService: RefundService) { }

  ngOnInit() {
    this.getRefunds();
  }

  getRefunds() {
    this.loading = true;
    return this._refundService.getRefunds().subscribe(
      result => {
        this.refunds = result;
        if (result.length == 0)
          this.message = "There is no data at this time...";
        this.loading = false;
      },
      error => {
        this.loading = false;
        console.log(error);
      }
    )
  }

  deleteRefund(id: number) {
    return this._refundService.delete(id).subscribe(
      result => {
        this.getRefunds();
        this.successMessage = "The item has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }

}
