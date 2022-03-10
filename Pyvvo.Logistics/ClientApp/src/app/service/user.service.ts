import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './Model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

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

  create(user: User): Observable<User> {
    return this._http.post<User>(this._url + 'api/user', user, { headers: this.header });
  }

  update(user: User): Observable<User> {
    return this._http.put<User>(this._url + 'api/user', user, { headers: this.header });
  }

  delete(id: number) {
    return this._http.delete(this._url + 'api/user/' + id, { headers: this.header });
  }

  get(id: string): Observable<User> {
    return this._http.get<User>(this._url + 'api/user/' + id, { headers: this.header });
  }

  getUsers(): Observable<User[]> {
    return this._http.get<User[]>(this._url + 'api/users', { headers: this.header });
  }
}
