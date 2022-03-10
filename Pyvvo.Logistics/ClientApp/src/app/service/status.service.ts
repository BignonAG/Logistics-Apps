import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Status } from './Model/status';


@Injectable({
  providedIn: 'root'
})
export class StatusService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  getStatus(categoryId): Observable<Status[]> {
    return this._http.get<Status[]>(this._url + 'api/status-category/' + categoryId+'/status', { headers: this.header });
  }
}
