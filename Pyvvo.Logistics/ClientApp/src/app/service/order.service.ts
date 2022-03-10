import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from './Model/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  create(order: Order): Observable<Order> {
    return this._http.post<Order>(this._url + 'api/order', order, { headers: this.header });
  }

  update(order: Order): Observable<Order> {
    return this._http.put<Order>(this._url + 'api/order', order, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/order/' + id, { headers: this.header });
  }

  get(id: string): Observable<Order> {
    return this._http.get<Order>(this._url + 'api/order/' + id, { headers: this.header });
  }

  getOrders(): Observable<Order[]> {
    return this._http.get<Order[]>(this._url + 'api/orders', { headers: this.header });
  }
}
