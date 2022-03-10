import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ShippingMethod } from './Model/shipping-method';

@Injectable({
  providedIn: 'root'
})
export class ShippingMethodService {

  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getShippingMethod(): Observable<ShippingMethod[]> {
    return this._http.get<ShippingMethod[]>(this._url + 'api/shipping-methods', { headers: this.header });
  }
}
