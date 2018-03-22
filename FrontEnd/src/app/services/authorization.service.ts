import { Injectable } from '@angular/core';
import { BaseHttpService, HttpOptions } from './base-http.service';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AuthorizationService extends BaseHttpService {

  constructor(protected http: HttpClient) {
    super(http);
  }

  protected buildOptions(auth: boolean, queryParams: HttpParams): HttpOptions {
    return <HttpOptions>{
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded'),
      withCredentials: auth,
      params: queryParams
    };
  }
}
