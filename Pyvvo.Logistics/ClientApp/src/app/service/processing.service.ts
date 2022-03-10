import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Processing } from './Model/processing';
import { Order } from './Model/order';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProcessingService {
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

  create(processing: Processing): Observable<Processing> {
    return this._http.post<Processing>(this._url + 'api/processing', processing, { headers: this.header });
  }

  update(processing: Processing): Observable<Processing> {
    return this._http.put<Processing>(this._url + 'api/processing', processing, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/processing/' + id, { headers: this.header });
  }

  get(id: string): Observable<Processing> {
    return this._http.get<Processing>(this._url + 'api/processing/' + id, { headers: this.header });
  }

  getProcessings(): Observable<Processing[]> {
    return this._http.get<Processing[]>(this._url + 'api/processings', { headers: this.header });
  }
  
  sendCheckedOrder(checkedOrders: Order[]) {
    return this.checkedOrders = checkedOrders;
  }

  getCheckedOrder() {
    return this.checkedOrders
  }
}
