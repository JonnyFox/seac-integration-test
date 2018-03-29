import { Component, ViewEncapsulation, Input } from '@angular/core';
import { EmployeeIncome } from '../../domain/models/employee-income';
import { GridDataResult, DataStateChangeEvent, RowClassArgs, PageChangeEvent } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Observable';
import { State } from '@progress/kendo-data-query';
import { EmployeeIncomeService } from '../../services/employee-income-grid.service';
import { SeverityData } from '../gravity-selector/gravity-selector.component';

@Component({
	selector: 'app-grid-details',
	encapsulation: ViewEncapsulation.None,
	templateUrl: './grid-details.component.html',
	styleUrls: ['./grid-details.component.scss']
})

export class GridDetailsComponent {
	public view: Observable<GridDataResult>;
	private SeverityDataList: Array<SeverityData> = null;

	public state: State = {
		skip: 0,
		take: 10,
	};

	public readonly pageable = {
		pageSizes: [10, 20, 50]
	};

	@Input() public employee: EmployeeIncome;

	constructor(public service: EmployeeIncomeService) {
		this.view = service;
		this.service.query(this.state);
		this.allData = this.allData.bind(this);
	}

	public allData = (): Observable<any> => {
		return this.service.queryAll(this.state);
	}

	public onSeverityDataCahanged(data: Array<SeverityData>) {
		this.SeverityDataList = data;
		this.service.localRefresh();
	}

	public dataStateChange(state: DataStateChangeEvent): void {
		this.state = state;
		this.service.query(state);
	}

	public pageChange(event: PageChangeEvent): void {
		this.state.skip = event.skip;
		this.service.localRefresh();
	}

	public rowCallback = (context: RowClassArgs) => {
		if (this.SeverityDataList == null) {
			return;
		}/*

		for (const element of this.SeverityDataList) {

			if (element == null || element.selectedClassInfo == null) {
				return;
			}

			const income = context.dataItem.income;
			if (income < element.maxValue && income > element.minValue) {
				const colorClass = element.selectedClassInfo.class;
				return {
					gravity1: colorClass === 'gravity1',
					gravity2: colorClass === 'gravity2',
					gravity3: colorClass === 'gravity3',
					gravity4: colorClass === 'gravity4'
				};
			}
		}*/
	}
}
