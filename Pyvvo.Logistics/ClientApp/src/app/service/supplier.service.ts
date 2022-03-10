import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Supplier } from './Model/supplier';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
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
   
  create(supplier: Supplier): Observable<Supplier> {
    return this._http.post<Supplier>(this._url + 'api/supplier', supplier, { headers: this.header });
  }

  update(supplier: Supplier): Observable<Supplier> {
    return this._http.put<Supplier>(this._url + 'api/supplier', supplier, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/supplier/' + id, { headers: this.header });
  }

  get(id: string): Observable<Supplier> {
    return this._http.get<Supplier>(this._url + 'api/supplier/' + id, { headers: this.header });
  }

  getSuppliers(): Observable<Supplier[]> {
    return this._http.get<Supplier[]>(this._url + 'api/suppliers', { headers: this.header });
  }
}
