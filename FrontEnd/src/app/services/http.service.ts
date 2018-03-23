import { Injectable } from '@angular/core';
import { BaseHttpService, HttpOptions } from './base-http.service';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HttpService extends BaseHttpService {

  public constructor(protected http: HttpClient) {
    super(http);
  }

  public Get<T>(url: string, queryParams: HttpParams = null, headers: HttpHeaders = null, auth = true): Observable<T> {
    return this.http.get<T>(this.buildUrl(url), <{}>this.buildOptions(auth, queryParams, headers));
  }

  public Post<T>(url: string, data: any, queryParams: HttpParams = null, headers: HttpHeaders = null, auth = true): Observable<T> {
    return this.http.post<T>(this.buildUrl(url), data, <{}>this.buildOptions(auth, queryParams, headers));
  }

  public Delete(url: string, queryParams: HttpParams = null, headers: HttpHeaders = null, auth = true): Observable<void> {
    return this.http.delete<void>(this.buildUrl(url), <{}>this.buildOptions(auth, queryParams, headers));
  }

  public Put<T>(url: string, data: any, queryParams: HttpParams = null, headers: HttpHeaders = null, auth = true): Observable<T> {
    return this.http.put<T>(this.buildUrl(url), data, <{}>this.buildOptions(auth, queryParams, headers));
  }

  protected buildOptions(auth: boolean, queryParams: HttpParams, headers: HttpHeaders = null): HttpOptions {
    headers = headers.set('Content-Type', 'application/json');
    return <HttpOptions>{
      headers: headers,
      withCredentials: auth,
      params: queryParams
    };
  }

}
