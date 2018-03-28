import { Component, OnInit, OnChanges, SimpleChanges, ViewEncapsulation, Input } from '@angular/core';
import { HttpParams, HttpHeaders } from '@angular/common/http';
import { HttpService } from '../../services/http.service';
import { EmployeeIncome } from '../../domain/models/employee-income';
import { AuthorizationService } from '../../services/authorization.service';
import { GridDataResult, DataStateChangeEvent, RowClassArgs, PageChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Observable';
import { State } from '@progress/kendo-data-query';
import { EmployeeIncomeService } from '../../services/employee-income-grid.service';
import { SelectedClassInfo, SeverityFilterData } from '../gravity-selector/gravity-selector.component';

@Component({
  selector: 'app-grid-details',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './grid-details.component.html',
  styleUrls: ['./grid-details.component.scss']
})

export class GridDetailsComponent {
  public view: Observable<GridDataResult>;
  private severityFilterDataList: Array<SeverityFilterData> = null;

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

  public onSeverityDataCahanged(data: Array<SeverityFilterData>) {
    this.severityFilterDataList = data;
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
    if (this.severityFilterDataList == null) {
      return;
    }

    for (const element of this.severityFilterDataList) {

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
    }
  }
}
