import { Injectable, Inject } from '@angular/core';
import { Variant } from './Model/variant';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VariantService {

  _url: string;
  private header: HttpHeaders;
  checkedVariants: Variant[];

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      }
    );
  }

  update(variant: Variant): Observable<Variant> {
    return this._http.put<Variant>(this._url + 'api/variant', variant, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/variant/' + id, { headers: this.header });
  }

  get(id: string): Observable<Variant> {
    return this._http.get<Variant>(this._url + 'api/variant/' + id, { headers: this.header });
  }

}
