import { Injectable } from '@angular/core';
import { AuthorizationService } from './authorization.service';
import { HttpService } from './http.service';
import { GridService } from './grid.service';
import { SeverityData } from '../components/gravity-selector/gravity-selector.component';

@Injectable()
export class EmployeeIncomeService extends GridService {
	public SeverityData: SeverityData;

	constructor(authorizationService: AuthorizationService, httpService: HttpService) {
		super('employeeIncome', authorizationService, httpService);
		this.SeverityData = null;
	}
}
