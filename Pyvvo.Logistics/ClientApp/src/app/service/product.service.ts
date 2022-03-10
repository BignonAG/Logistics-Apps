import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './Model/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  _url: string;
  private header: HttpHeaders;
  checkedProducts: Product[];

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      }
    );
  }

  create(product: Product): Observable<Product> {
    return this._http.post<Product>(this._url + 'api/product', product, { headers: this.header });
  }

  update(product: Product): Observable<Product> {
    return this._http.put<Product>(this._url + 'api/product', product, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/product/' + id, { headers: this.header });
  }

  get(id: string): Observable<Product> {
    return this._http.get<Product>(this._url + 'api/product/' + id, { headers: this.header });
  }

  getAllByCompany(): Observable<Product[]> {
    return this._http.get<Product[]>(this._url + 'api/products', { headers: this.header });
  }

  sendCheckedProduct(products: Product[]) {
    this.checkedProducts = products;
  }

  getCheckedProduct(): Product[] {
    return this.checkedProducts;
  }
}
