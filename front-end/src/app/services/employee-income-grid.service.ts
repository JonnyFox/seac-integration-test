import { Injectable } from '@angular/core';
import { AuthorizationService } from './authorization.service';
import { HttpService } from './http.service';
import { GridService } from './grid.service';
import { SeverityFilterData } from '../components/gravity-selector/gravity-selector.component';

@Injectable()
export class EmployeeIncomeService extends GridService {
	public severityFilterData: SeverityFilterData;

	constructor(authorizationService: AuthorizationService, httpService: HttpService) {
		super('employeeIncome', authorizationService, httpService);
		this.severityFilterData = null;
	}
}
