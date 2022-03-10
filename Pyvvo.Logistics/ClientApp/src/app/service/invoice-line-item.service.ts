import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InvoiceLineItem } from './Model/invoice-line-item';

@Injectable({
  providedIn: 'root'
})
export class InvoiceLineItemService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getEntities(invoiceId): Observable<InvoiceLineItem[]> {
    return this._http.get<InvoiceLineItem[]>(
      this._url + 'api/invoice/' + invoiceId + '/invoice-line-items', { headers: this.header }
    );
  }


}
