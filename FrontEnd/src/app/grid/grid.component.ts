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
    this.getGridData();
  }

  private getGridData() {
    let params = new HttpParams();
    let body = new URLSearchParams();
    body.set('username', 'paperino');
    body.set('password', 'paperino');
    body.set('grant_type', 'password');
    body.set('client_id', 'ro.client');
    body.set('client_secret', 'secret');
    body.set('scope', 'api1');

    console.log(body.toString());
    this.authorizationService.sendPost<AuthorizationToken>("connect/token", body.toString(), params).subscribe(res => {
      let token = `${res.token_type} ${res.access_token}`;
      this.seedGrid(token);
    });
  }

  private seedGrid(token: string) {
    let headers = new HttpHeaders()
    headers = headers.set('Authorization', token);
    console.log('AAA ' + JSON.stringify(headers));
    console.log('BBB ' + headers.toString());
    this.httpService.Get<any>("api/employeeIncome", null, headers).subscribe(res => {
      console.log(res);
      this.gridData = res.items;
    });
  }

}
