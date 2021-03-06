import { Component, OnInit } from '@angular/core';
import { products } from './products';
import { BaseHttpService } from '../services/base-http.service'
import { EmployeeIncome } from '../domain/models/EmployeeIncome';
import { AuthorizationToken } from '../domain/models/AuthorizationToken';
import { HttpParams, HttpHeaders } from '@angular/common/http';
import { AuthorizationService } from '../services/authorization.service';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {
  public gridData: EmployeeIncome[];

  constructor(private httpService: HttpService, private authorizationService: AuthorizationService) { }

  ngOnInit() {

  }

  private seedGrid(token: string) {

  }

}
