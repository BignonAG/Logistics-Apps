import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductCategory } from './Model/ProductCategory';

@Injectable({
  providedIn: 'root'
})
export class ProductCategoryService {
  companyId = localStorage.getItem("companyId");
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getCategories(): Observable<ProductCategory[]> {
    return this._http.get<ProductCategory[]>(this._url + 'api/company/'+this.companyId+'/product-categories', { headers: this.header });
  }
}
