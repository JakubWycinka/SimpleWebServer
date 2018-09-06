import { environment } from './../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SimpleMessageModel } from './models/message-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  urlBase: string;
  httpOptions: {headers: HttpHeaders};

  constructor(private http: HttpClient) {
    this.urlBase = environment.apiUrlBase;
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };
  }

  postMessage(simpleMessage: SimpleMessageModel): Observable<SimpleMessageModel> {
    return this.http.post<SimpleMessageModel>(this.urlBase + '/message', JSON.stringify(simpleMessage), this.httpOptions);
  }

  getMessages(): Observable<SimpleMessageModel[]> {
    return this.http.get<SimpleMessageModel[]>(this.urlBase + '/message', this.httpOptions);
  }

  deleteMessage(id: number): Observable<SimpleMessageModel> {
    return this.http.delete<SimpleMessageModel>(this.urlBase + '/message/' + id);
  }
}
