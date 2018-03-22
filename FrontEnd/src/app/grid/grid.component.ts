import { Component, OnInit } from '@angular/core';
import { products } from './products';
import { BaseHttpService } from '../services/http.service'
import { EmployeeIncome } from '../domain/models/EmployeeIncome';
import { AuthorizationToken } from '../domain/models/AuthorizationToken';
import { HttpParams } from '@angular/common/http';
import { AuthorizationService } from '../services/authorization.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {
  public gridData: EmployeeIncome;

  constructor(private httpService: BaseHttpService,private authorizationService: AuthorizationService) { }

  ngOnInit() {
    this.getGridData();
  }

  private getGridData() {
    let params = new HttpParams();
    let body = new URLSearchParams();
    body.set('username','paperino');
    body.set('password','paperino');
    body.set('grant_type','password');
    body.set('client_id','ro.client');
    body.set('client_secret','secret');
    body.set('scope','api1');

    console.log(body.toString());
    this.authorizationService.sendPost<AuthorizationToken>("connect/token", body.toString(), params).subscribe(res => {
      let token = `${res.token_type} ${res.access_token}`;
      this.seedGrid(token);
    });
  }

  private seedGrid(token: string) {
    let params = new HttpParams()
    params.set('Authorization', token);
    console.log('AAA '+JSON.stringify(params));
    console.log('BBB '+ params.toString());
    this.httpService.sendGet<EmployeeIncome>("api/employeeIncome", params).subscribe(res => {
      this.gridData = res;
    });
  }

}
