import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AuthorizationService } from './authorization.service';
import { HttpService } from './http.service';
import { GridService } from './grid.service';
import { SeverityFilterData } from '../components/gravity-selector/gravity-selector.component';

@Injectable()
export class EmployeeIncomeService extends GridService {
    public severityFilterData: SeverityFilterData;

    constructor(http: HttpClient, authorizationService: AuthorizationService, httpService: HttpService) {
        super(http, 'employeeIncome', authorizationService, httpService);
        this.severityFilterData = null;
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
