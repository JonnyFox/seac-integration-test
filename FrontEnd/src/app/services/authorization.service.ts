import { Injectable } from '@angular/core';
import { BaseHttpService, HttpOptions } from './base-http.service';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { AuthorizationToken } from '../domain/models/AuthorizationToken';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthorizationService extends BaseHttpService {

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

    return this.sendPost<AuthorizationToken>("connect/token", body.toString(), params).toPromise();
  }

  protected buildOptions(auth: boolean, queryParams: HttpParams): HttpOptions {
    return <HttpOptions>{
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded'),
      withCredentials: auth,
      params: queryParams
    };
  }
}
