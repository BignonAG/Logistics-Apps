import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Order } from './Model/order';
import { Return } from './Model/return';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReturnService {

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

  create(_return: Return): Observable<Return> {
    return this._http.post<Return>(this._url + 'api/returns', _return, { headers: this.header });
  }

  update(_return: Return): Observable<Return> {
    return this._http.put<Return>(this._url + 'api/returns', _return, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/returns/' + id, { headers: this.header });
  }

  get(id: string): Observable<Return> {
    return this._http.get<Return>(this._url + 'api/returns/' + id, { headers: this.header });
  }

  getReturns(): Observable<Return[]> {
    return this._http.get<Return[]>(this._url + 'api/returns', { headers: this.header });
  }

  sendCheckedOrder(checkedOrders: Order[]) {
    return this.checkedOrders = checkedOrders;
  }

  getCheckedOrder() {
    return this.checkedOrders
  }
}
