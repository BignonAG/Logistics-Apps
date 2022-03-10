import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Refund } from './Model/refund';
import { Order } from './Model/order';

@Injectable({
  providedIn: 'root'
})
export class RefundService {
  _url: string;
  private header: HttpHeaders;
  checkedOrders: Order[];

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  create(refund: Refund): Observable<Refund> {
    return this._http.post<Refund>(this._url + 'api/refund', refund, { headers: this.header });
  }

  update(refund: Refund): Observable<Refund> {
    return this._http.put<Refund>(this._url + 'api/refund', refund, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/refund/' + id, { headers: this.header });
  }

  get(id: string): Observable<Refund> {
    return this._http.get<Refund>(this._url + 'api/refund/' + id, { headers: this.header });
  }

  getRefunds(): Observable<Refund[]> {
    return this._http.get<Refund[]>(this._url + 'api/refunds', { headers: this.header });
  }
  ;
  sendCheckedOrder(checkedOrders: Order[]) {
    return this.checkedOrders = checkedOrders;
  }

  getCheckedOrder() {
    return this.checkedOrders
  }
}
