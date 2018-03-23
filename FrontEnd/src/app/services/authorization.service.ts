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

  public getToken() : Promise<AuthorizationToken>{
    let params = new HttpParams();
    let body = new URLSearchParams();
    body.set('username', 'paperino');
    body.set('password', 'paperino');
    body.set('grant_type', 'password');
    body.set('client_id', 'ro.client');
    body.set('client_secret', 'secret');
    body.set('scope', 'api1');

    return this.Post<AuthorizationToken>("connect/token", body.toString(), params);
  }

  protected buildOptions(auth: boolean, queryParams: HttpParams): HttpOptions {
    return <HttpOptions>{
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded'),
      withCredentials: auth,
      params: queryParams
    };
  }
}
