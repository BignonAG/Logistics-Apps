import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ReturnLineItem } from './Model/return-line-item';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReturnLineItemService {

  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getEntities(returnId): Observable<ReturnLineItem[]> {
    return this._http.get<ReturnLineItem[]>(this._url + 'api/return/' + returnId + '/return-line-items', { headers: this.header });
  }
}
