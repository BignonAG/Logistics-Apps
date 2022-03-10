import { Component, OnInit } from '@angular/core';
import { Invoice } from '../../../service/Model/invoice';
import { InvoiceService } from '../../../service/invoice.service';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.scss']
})
export class InvoiceComponent implements OnInit {
  invoices: Invoice[];
  successMessage: string;
  errorMessage: string;
  message: string;
  loading: boolean;
  constructor(private _invoiceService: InvoiceService) { }

  ngOnInit() {
    this.getInvoices();
  }

  getInvoices() {
    this.loading = true;
    return this._invoiceService.getInvoices().subscribe(
      result => {
        this.invoices = result;
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

  delete(id: number) {
    return this._invoiceService.delete(id).subscribe(
      result => {
        this.getInvoices();
        this.successMessage = "The item has been succefully deleted! ";
      },
      error => {
        console.log(error);
        this.errorMessage = "Something wrong! Please retry...";
      }
    )
  }

}
