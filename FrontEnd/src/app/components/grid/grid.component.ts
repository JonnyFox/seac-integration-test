import { Component, OnInit } from '@angular/core';
import { products } from './products';
import { HttpParams, HttpHeaders } from '@angular/common/http';
import { HttpService } from '../../services/http.service';
import { EmployeeIncome } from '../../domain/models/employee-income';
import { AuthorizationService } from '../../services/authorization.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {
  public gridData: EmployeeIncome[];

  constructor() { }

  ngOnInit() {  }
}
