import { Component, OnInit, OnChanges, SimpleChanges, ViewEncapsulation, Input } from '@angular/core';
import { HttpParams, HttpHeaders } from '@angular/common/http';
import { HttpService } from '../../services/http.service';
import { EmployeeIncome } from '../../domain/models/employee-income';
import { AuthorizationService } from '../../services/authorization.service';
import { GridDataResult, DataStateChangeEvent, RowClassArgs } from '@progress/kendo-angular-grid';
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
  private severityFilterData: SeverityFilterData = null;

  public state: State = {
    skip: 0,
    take: 10,
  };

  constructor(public service: EmployeeIncomeService, private gravitySelectorService: GravitySelectorService) {
    this.view = service;
    this.service.query(this.state);
    this.gravitySelectorService.onChanged.subscribe(res => this.onSeverityDataCahanged(res));
  }

  public onSeverityDataCahanged(data: SeverityFilterData) {
    this.severityFilterData = data;
    this.service.localRefresh();
  }

  public dataStateChange(state: DataStateChangeEvent): void {
    this.state = state;
    this.service.query(state);
  }

  public rowCallback = (context: RowClassArgs) => {
    if (this.severityFilterData == null || this.severityFilterData.selectedItem == null) {
      return;
    }

    let income = context.dataItem.income;
    if (income < this.severityFilterData.maxValue && income > this.severityFilterData.minValue) { // todo: list
      return {
        gravity1: this.severityFilterData.selectedItem.class == 'gravity1',
        gravity2: this.severityFilterData.selectedItem.class == 'gravity2',
        gravity3: this.severityFilterData.selectedItem.class == 'gravity3',
        gravity4: this.severityFilterData.selectedItem.class == 'gravity4'
      };
    }
  }
}
