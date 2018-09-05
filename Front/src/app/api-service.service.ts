import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SimpleMessageModel } from './models/message-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  constructor(private http: HttpClient) { }

  postMessage(simpleMessage: SimpleMessageModel): Observable<SimpleMessageModel> {
    return this.http.post<SimpleMessageModel>('http://localhost:63465/api/message', JSON.stringify(simpleMessage), this.httpOptions);
  }

  getMessages(): Observable<SimpleMessageModel[]> {
    return this.http.get<SimpleMessageModel[]>('http://localhost:63465/api/message', this.httpOptions);
  }

  deleteMessage(id: number): Observable<SimpleMessageModel> {
    return this.http.delete<SimpleMessageModel>('http://localhost:63465/api/message/' + id);
  }


}
