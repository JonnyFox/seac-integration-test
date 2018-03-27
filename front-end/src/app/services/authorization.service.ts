import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthorizationToken } from '../domain/models/authorization-token';
import { HttpService, HttpOptions } from './http.service';

@Injectable()
export class AuthorizationService extends HttpService {

  constructor(protected http: HttpClient) {
    super(http);
  }

  public getToken() : Observable<AuthorizationToken> {
    const params = new HttpParams();
    const body = new URLSearchParams();
    body.set('username', 'username');
    body.set('password', 'password');
    body.set('grant_type', 'password');
    body.set('client_id', 'ro.client');
    body.set('client_secret', 'secret');

    return this.Post<AuthorizationToken>('connect/token', body.toString(), params);
  }

  public getHeaders(token : AuthorizationToken) : HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    headers = headers.set('Authorization', `${token.token_type} ${token.access_token}`);
    return headers;
  }

  protected buildOptions(auth: boolean, queryParams: HttpParams): HttpOptions {
    return <HttpOptions>{
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded'),
      withCredentials: auth,
      params: queryParams
    };
  }
}
