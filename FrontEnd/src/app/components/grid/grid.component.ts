import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { products } from './products';
import { HttpParams, HttpHeaders } from '@angular/common/http';
import { HttpService } from '../../services/http.service';
import { EmployeeIncome } from '../../domain/models/employee-income';
import { AuthorizationService } from '../../services/authorization.service';
import { GridDataResult, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Observable';
import { State } from '@progress/kendo-data-query';
import { EmployeeIncomeService } from '../../services/employee-income.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})

export class DataGrid {
  public view: Observable<GridDataResult>;

  public state: State = {
      skip: 0,
      take: 10,
  };

  constructor(public service: EmployeeIncomeService) {
      this.view = service;
      this.service.query(this.state);
  }

  public dataStateChange(state: DataStateChangeEvent): void {
      this.state = state;
      this.service.query(state);
  }
}
