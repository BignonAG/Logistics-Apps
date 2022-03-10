import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderLineItem } from './Model/order-line-item';


@Injectable({
  providedIn: 'root'
})
export class OrderLineItemService {

  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getOrderLineItems(orderId): Observable<OrderLineItem[]> {
    return this._http.get<OrderLineItem[]>(this._url + 'api/order/'+orderId+'/order-line-items', { headers: this.header });
  }
}
