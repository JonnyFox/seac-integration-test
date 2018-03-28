import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { AuthorizationService } from './authorization.service';
import { HttpService } from './http.service';
import { State, toODataString } from '@progress/kendo-data-query';
import { OdataResponse } from '../domain/core/odata-response';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class GridService extends BehaviorSubject<GridDataResult> {
	public isLoading = true;
	private data: GridDataResult;
	constructor(protected tableName: string, private authorizationService: AuthorizationService, private httpService: HttpService) {
		super(null);
	}

	public query(state: State): void {
		const dataResult = this.fetch(this.tableName, state);
		dataResult.subscribe(data => {
			this.data = data;
			super.next(this.data);
		});
	}

	public queryAll(state: State): Observable<GridDataResult> {
		return this.fetch(this.tableName, state);
	}

	public localRefresh() {
		super.next(this.data);
	}

	protected fetch(tableName: string, state: State): Observable<GridDataResult> {
		const queryStr = `${toODataString(state)}&$count=true`;
		this.isLoading = true;

		return this.authorizationService.getToken()
			.finally(() => this.isLoading = false)
			.switchMap(token => Observable.of(this.authorizationService.getHeaders(token)))
			.switchMap(headers => this.httpService.Get<OdataResponse>(`api/${tableName}?${queryStr}`, null, headers))
			.map((res) => <GridDataResult>{ data: res.items, total: res.count });
	}
}
