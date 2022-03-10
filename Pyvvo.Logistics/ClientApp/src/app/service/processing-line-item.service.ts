import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProcessingLineItem } from './Model/processing-line-item';

@Injectable({
  providedIn: 'root'
})
export class ProcessingLineItemService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getEntities(returnId): Observable<ProcessingLineItem[]> {
    return this._http.get<ProcessingLineItem[]>(this._url + 'api/processing/' + returnId + '/processing-line-items', { headers: this.header });
  }
}
