import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Parameter } from './Model/parameter';

@Injectable({
  providedIn: 'root'
})
export class ParameterService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getEntities(): Observable<Parameter[]> {
    return this._http.get<Parameter[]>(this._url + 'api/parameters', { headers: this.header });
  }
}
