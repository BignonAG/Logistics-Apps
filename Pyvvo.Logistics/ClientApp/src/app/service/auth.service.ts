import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountLogin } from './Model/account-login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  _url: string;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
  }

  signUp(accountLogin: AccountLogin): Observable<AccountLogin> {

    return this._http.post<AccountLogin>(this._url + 'api/auth/sign-up', accountLogin);
  }

  signIn(accountLogin: AccountLogin): Observable<AccountLogin> {
    return this._http.post<AccountLogin>(this._url + 'api/auth/sign-in', accountLogin);
  }
}
