import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StatusCategory } from './Model/StatusCategory';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatusCategoryService {
  _url: string;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
  }

  create(statusCategory: StatusCategory) : Observable<StatusCategory> {
    return this._http.post<StatusCategory>(this._url + 'api/status/category', statusCategory);
  }

  update(statusCategory: StatusCategory): Observable<StatusCategory> {
    return this._http.put<StatusCategory>(this._url + 'api/status/category/', statusCategory);
  }

  delete(id: number){
    return this._http.delete(this._url + 'api/status/category/'+id);
  }
}
