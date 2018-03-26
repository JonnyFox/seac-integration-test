import { Component, OnInit, OnChanges, SimpleChanges, ViewEncapsulation, Input } from '@angular/core';
import { HttpParams, HttpHeaders } from '@angular/common/http';
import { HttpService } from '../../services/http.service';
import { EmployeeIncome } from '../../domain/models/employee-income';
import { AuthorizationService } from '../../services/authorization.service';
import { GridDataResult, DataStateChangeEvent, RowClassArgs, PageChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Observable';
import { State } from '@progress/kendo-data-query';
import { EmployeeIncomeService } from '../../services/employee-income-grid.service';
import { selectedItem, SeverityFilterData } from '../gravity-selector/gravity-selector.component';
import { GravitySelectorService } from '../../services/gravity-selector.service';

@Component({
  selector: 'app-grid',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})

export class DataGrid {
  public view: Observable<GridDataResult>;
  private severityFilterDataList: Array<SeverityFilterData> = null;

  public state: State = {
    skip: 0,
    take: 10,
  };

  constructor(public service: EmployeeIncomeService, private gravitySelectorService: GravitySelectorService) {
    this.view = service;
    this.service.query(this.state);
    this.gravitySelectorService.onChanged.subscribe(res => this.onSeverityDataCahanged(res));
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

    for (let element of this.severityFilterDataList) {

      if (element == null || element.selectedItem == null) {
        return;
      }

      let income = context.dataItem.income;
      if (income < element.maxValue && income > element.minValue) { // todo: list
        let colorClass = element.selectedItem.class;
        return {
          gravity1: colorClass == 'gravity1',
          gravity2: colorClass == 'gravity2',
          gravity3: colorClass == 'gravity3',
          gravity4: colorClass == 'gravity4'
        };
      }
    });
  }
}
