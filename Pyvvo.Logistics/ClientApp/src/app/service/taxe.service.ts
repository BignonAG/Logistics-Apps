import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Taxe } from './Model/taxe';

@Injectable({
  providedIn: 'root'
})
export class TaxeService {

  userId: string;
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
    this.userId = localStorage.getItem("userId");
  }

  getTaxes(): Observable<Taxe[]> {
    return this._http.get<Taxe[]>(this._url + 'api/taxes', { headers: this.header });
  }
}
