import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Warehouse } from './Model/warehouse';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {

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

    create(warehouse: Warehouse): Observable<Warehouse> {
        return this._http.post<Warehouse>(this._url + 'api/warehouse', warehouse, {headers :this.header});
    }

    update(warehouse: Warehouse): Observable<Warehouse> {
        return this._http.put<Warehouse>(this._url + 'api/warehouse', warehouse, { headers: this.header });
    }

    delete(id: number) {
        return this._http.delete(this._url + 'api/warehouse/' + id, { headers: this.header });
    }

    get(id: string): Observable<Warehouse> {
        return this._http.get<Warehouse>(this._url + 'api/warehouse/' + id, { headers: this.header });
    }

    getUserEntities(): Observable<Warehouse[]> {
        return this._http.get<Warehouse[]>(this._url + 'api/user/warehouses', { headers: this.header });
    }

    getEntities(): Observable<Warehouse[]> {
      return this._http.get<Warehouse[]>(this._url + 'api/warehouses', { headers: this.header });
    }
}
