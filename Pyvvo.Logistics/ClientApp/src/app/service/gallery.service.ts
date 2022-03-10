import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Image } from './Model/image';

@Injectable({
  providedIn: 'root'
})
export class GalleryService {
  _url: string;
  private header: HttpHeaders;

  constructor(@Inject('BASE_URL') url: string, private _http: HttpClient) {
    this._url = url;
    this.header = new HttpHeaders(
      {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      });
  }

  create(formData: FormData) {
    return this._http.post(this._url + 'api/blob', formData, { headers: this.header });
  }

  delete(filename: string) {
    return this._http.delete(this._url + 'api/blob/' + filename, { headers: this.header });
  }

  get(filename: string) {
    return this._http.get(this._url + 'api/blob/' + filename, { headers: this.header });
  }

  getBlobs() {
    return this._http.get(this._url + 'api/blobs', { headers: this.header });
  }

  getMedias(): Observable<Image[]> {
    return this._http.get<Image[]>(this._url + 'api/medias', { headers: this.header });
  }

}
