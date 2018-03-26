import { Component, OnInit, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { EmployeeIncomeService } from '../../services/employee-income-grid.service';
import { GravitySelectorService } from '../../services/gravity-selector.service';

@Component({
  selector: 'app-gravity-selector',
  templateUrl: './gravity-selector.component.html',
  styleUrls: ['./gravity-selector.component.scss']
})

export class GravitySelectorComponent {

  public minValue: number = 100;
  public maxValue: number = 1000;
  public selectedItem: selectedItem = null;
  public listItems: Array<selectedItem> = [
    { text: "Trascurabile", value: 1, class: 'gravity1' },
    { text: "Lieve", value: 2, class: 'gravity2' },
    { text: "Consistente", value: 3, class: 'gravity3' },
    { text: "Grave", value: 4, class: 'gravity4' }
  ];

  constructor(private gridService: EmployeeIncomeService, private service: GravitySelectorService) { }

  public MinValueChanged(changes: number): void {
    this.minValue = changes;
    this.emitChangeEvent();
  }
  public MaxValueChanged(changes: number): void {
    this.maxValue = changes;
    this.emitChangeEvent();
  }
  public SeverityValueChanged(changes: selectedItem): void {
    this.selectedItem = changes;
    this.emitChangeEvent();
  }

  private emitChangeEvent() {
      this.service.onChanged.emit(<SeverityFilterData>{
        minValue: this.minValue,
        maxValue: this.maxValue,
        selectedItem: this.selectedItem
      });
  }
}

export class SeverityFilterData {
  readonly minValue: number;
  readonly maxValue: number;
  readonly selectedItem: selectedItem;
}

export class selectedItem {
  readonly text: string;
  readonly value: number;
  readonly class: string;
}
