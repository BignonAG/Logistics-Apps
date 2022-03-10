import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Currency } from './Model/currency';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  get(): Observable<Currency> {
    return this._http.get<Currency>(this._url + 'api/currency', { headers: this.header });
  }

  getCurrencies(): Observable<Currency[]> {
    return this._http.get<Currency[]>(this._url + 'api/currencies', { headers: this.header });
  }
}
