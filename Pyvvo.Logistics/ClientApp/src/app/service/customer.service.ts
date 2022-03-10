import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from './Model/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  create(customer: Customer): Observable<Customer> {
    return this._http.post<Customer>(this._url + 'api/customer', customer, { headers: this.header });
  }

  update(customer: Customer): Observable<Customer> {
    return this._http.put<Customer>(this._url + 'api/customer', customer, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/customer/' + id, { headers: this.header });
  }

  get(id: string): Observable<Customer> {
    return this._http.get<Customer>(this._url + 'api/customer/' + id, { headers: this.header });
  }

  getUserCustomers(): Observable<Customer[]> {
    return this._http.get<Customer[]>(this._url + 'api/user/customers', { headers: this.header });
  }

  getCustomers(): Observable<Customer[]> {
    return this._http.get<Customer[]>(this._url + 'api/customers', { headers: this.header });
  }
}
