import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { RefundLineItem } from './Model/refund-line-item';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RefundLineItemService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getEntities(refundId): Observable<RefundLineItem[]> {
    return this._http.get<RefundLineItem[]>(this._url + 'api/refund/' + refundId + '/refund-line-items', { headers: this.header });
  }
}
