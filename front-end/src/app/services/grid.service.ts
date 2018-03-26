import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthorizationService } from './authorization.service';
import { HttpService, HttpOptions } from './http.service';
import { State, toODataString } from '@progress/kendo-data-query';
import { OdataResponse } from '../domain/core/odata-response';

@Injectable()
export class GridService extends BehaviorSubject<GridDataResult> {
    public isLoading = true;
    private data: GridDataResult;
    constructor(private http: HttpClient, protected tableName: string, private authorizationService: AuthorizationService, private httpService: HttpService) {
        super(null);
    }

    public async query(state: State): Promise<void> {
        this.data = await this.fetch(this.tableName, state);
        super.next(this.data);
    }

    public localRefresh() {
        super.next(this.data);
    }

    protected async fetch(tableName: string, state: State): Promise<GridDataResult> {
        const queryStr = `${toODataString(state)}&$count=true`;
        this.isLoading = true;

        const token = await this.authorizationService.getToken();

        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', `${token.token_type} ${token.access_token}`);

        const options = <HttpOptions>{
            headers: headers,
            withCredentials: true,
            params: null
        };

        const response = await this.httpService
            .Get<OdataResponse>(`api/${tableName}?${queryStr}`, null, headers);

        const gridData = <GridDataResult>{
            data: response.items,
            total: response.count
        };

        this.isLoading = false;
        return Promise.resolve(gridData);
    }
}
