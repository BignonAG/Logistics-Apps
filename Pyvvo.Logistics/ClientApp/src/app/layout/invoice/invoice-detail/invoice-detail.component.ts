import { Component, OnInit } from '@angular/core';
import { Invoice } from '../../../service/Model/invoice';
import { ActivatedRoute, Router } from '@angular/router';
import { InvoiceService } from '../../../service/invoice.service';
import { InvoiceLineItemService } from '../../../service/invoice-line-item.service';
import { InvoiceLineItem } from '../../../service/Model/invoice-line-item';

@Component({
  selector: 'app-invoice-detail',
  templateUrl: './invoice-detail.component.html',
  styleUrls: ['./invoice-detail.component.scss']
})
export class InvoiceDetailComponent implements OnInit {
  orderId: string;
  invoice: Invoice;
  emptyInvoice : Invoice;

  constructor(private activatedRoute: ActivatedRoute, private _invoiceService: InvoiceService,
    private _invoiceLineItemService: InvoiceLineItemService, private router: Router) { }

  ngOnInit() {
    //this.invoiceId = this.activatedRoute.snapshot.params["id"];// Get the supplier id param from url
    this.orderId = this.activatedRoute.snapshot.params["orderId"];// Get the supplier id param from url
    if (this.orderId != null && this.orderId != "")
      this.getInvoice();
  }

  getInvoice() {
    return this._invoiceService.get(this.orderId).subscribe(
      result => {
        console.log(result);
        this.invoice = result;
        this._invoiceLineItemService.getEntities(result.id).subscribe(
          invoiceItems => {
            this.invoice.invoiceLineItems = invoiceItems;
          }
        )
      },
      error => {
        console.log(error);
      }
    );
  }

  delete(id: number) {
    return this._invoiceService.delete(id).subscribe(
      result => {
        this.router.navigateByUrl('/app/invoices');
      },
      error => {
        console.log(error);
      }
    )
  }

  //createInvoice() {
  //  return this._invoiceService.create(this.orderId).subscribe(
  //    result => {
  //      this.router.navigateByUrl('/app/invoice/'+this.invoiceId);
  //    }
  //  )
  //}

}
