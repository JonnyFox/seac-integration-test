import { Component, OnInit } from '@angular/core';
import { products } from './products';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }


  public gridData: any[] = products;

}
