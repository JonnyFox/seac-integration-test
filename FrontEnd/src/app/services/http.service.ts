import { Injectable } from '@angular/core';
import {
	HttpRequest,
	HttpHandler,
	HttpEvent,
	HttpInterceptor,
	HttpErrorResponse,
	HttpResponse,
	HttpClient,
	HttpHeaders,
	HttpParams
} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
//import { SettingsService } from '.';
import { environment } from '../../environments/environment';
import { ObservableInput } from 'rxjs/Observable';

@Injectable()
export class BaseHttpService {

	private readonly baseUrl = environment.baseUrl;

	public constructor(protected http: HttpClient) { }

	public sendGet<T>(url: string, queryParams: HttpParams = null, auth = true): Observable<T> {
		return this.http.get<T>(this.buildUrl(url), <{}>this.buildOptions(auth, queryParams));
	}

	public sendPost<T>(url: string, data: any, queryParams: HttpParams = null, auth = true): Observable<T> {
		return this.http.post<T>(this.buildUrl(url), data, <{}>this.buildOptions(auth, queryParams));
	}

	public sendDelete(url: string, queryParams: HttpParams = null, auth = true): Observable<void> {
		return this.http.delete<void>(this.buildUrl(url), <{}>this.buildOptions(auth, queryParams));
	}

	public sendPut<T>(url: string, data: any, queryParams: HttpParams = null, auth = true): Observable<T> {
		return this.http.put<T>(this.buildUrl(url), data, <{}>this.buildOptions(auth, queryParams));
	}

	public sendGetForDownload(url: string, queryParams: HttpParams = null, auth = true): Observable<Blob> { // forse va ritornato un any. Blob è un test
		let options = this.buildOptions(auth, queryParams);
		options.responseType = 'blob';
		return this.http.get<Blob>(this.buildUrl(url), <{}>options);
	}

	protected buildOptions(auth: boolean, queryParams: HttpParams): HttpOptions {
		return <HttpOptions>{
			headers: new HttpHeaders().set('Content-Type', 'application/json'),
			withCredentials: auth,
			params: queryParams
		};
	}

	private buildUrl(url: string, useAsRelative = true): string {
		if (useAsRelative) {
			return `${this.baseUrl}${url}`;
		}
		return url;
	}

}

export interface HttpOptions {
	headers?: HttpHeaders | { [header: string]: string | string[]; };
	observe?: 'body';
	params?: HttpParams | { [param: string]: string | string[]; };
	reportProgress?: boolean;
	responseType?: string;
	withCredentials?: boolean;
}
