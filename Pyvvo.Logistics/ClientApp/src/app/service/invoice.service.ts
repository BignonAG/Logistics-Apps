import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invoice } from './Model/invoice';
import { Order } from './Model/order';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  create(orderId): Observable<Invoice> {
    var order = new Order();
    order.id = orderId;
    return this._http.post<Invoice>(this._url + 'api/invoice', order, { headers: this.header });
  }

  update(invoice: Invoice): Observable<Invoice> {
    return this._http.put<Invoice>(this._url + 'api/invoice', invoice, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/invoice/' + id, { headers: this.header });
  }

  get(id: string): Observable<Invoice> {
    return this._http.get<Invoice>(this._url + 'api/order/'+id+'/invoice', { headers: this.header });
  }

  getInvoices(): Observable<Invoice[]> {
    return this._http.get<Invoice[]>(this._url + 'api/invoices', { headers: this.header });
  }
}
