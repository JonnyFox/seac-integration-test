import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-severity-filter',
  templateUrl: './severity-filter.component.html',
  styleUrls: ['./severity-filter.component.scss']
})
export class SeverityFilterComponent {
  public minValue: number = 100;
  public maxValue: number = 1000;
  public listItems: Array<string> = ["Trascurabile", "Lieve", "Consistente", "Grave"];

}
