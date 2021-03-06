import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { toODataString } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { map } from 'rxjs/operators/map';
import { AuthorizationService } from './authorization.service';
import { HttpService } from './http.service';

export abstract class ODataService extends BehaviorSubject<GridDataResult> {
  private BASE_URL = 'https://localhost:8080/api/';

  constructor(private http: HttpClient, protected tableName: string, private authorizationService: AuthorizationService, private httpService: HttpService) {
    super(null);
  }

  public async query(state: any): Promise<void> {
    let x = await this.fetch(this.tableName, state)
    super.next(x);
  }

  protected async fetch(tableName: string, state: any): Promise<GridDataResult> {
    const queryStr = `${toODataString(state)}&$count=true`;

    let token = await this.authorizationService.getToken();

    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    headers = headers.set('Authorization', `${token.token_type} ${token.access_token}`);
    let options = <HttpOptions>{
      headers: headers,
      withCredentials: true,
      params: null
    };

    return this.httpService.Get<any>(`api/${tableName}?${queryStr}`, null, headers).pipe(
      map(response => (<GridDataResult>{
        data: response['items'],
        total: parseInt(response['@odata.count'], 10)
      }))
    ).toPromise();
  }
}

@Injectable()
export class EmployeeIncomeService extends ODataService {
  constructor(http: HttpClient, authorizationService: AuthorizationService, httpService: HttpService) {
    super(http, 'employeeIncome', authorizationService, httpService);
  }

  queryAll(st?: any): Promise<GridDataResult> {
    const state = Object.assign({}, st);
    delete state.skip;
    delete state.take;

    return this.fetch(this.tableName, state);
  }
}

interface HttpOptions {
  headers?: HttpHeaders | { [header: string]: string | string[]; };
  observe?: 'body';
  params?: HttpParams | { [param: string]: string | string[]; };
  reportProgress?: boolean;
  responseType?: string;
  withCredentials?: boolean;
}
