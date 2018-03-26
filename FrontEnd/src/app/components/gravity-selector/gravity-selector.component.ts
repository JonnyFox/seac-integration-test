import { Component, OnInit, EventEmitter, OnChanges, SimpleChanges, Input } from '@angular/core';
import { EmployeeIncomeService } from '../../services/employee-income-grid.service';
import { GravitySelectorService } from '../../services/gravity-selector.service';

@Component({
  selector: 'app-gravity-selector',
  templateUrl: './gravity-selector.component.html',
  styleUrls: ['./gravity-selector.component.scss']
})

export class GravitySelectorComponent implements OnInit {
  public selectedItem: selectedClassInfo = null;
  public listItems: Array<selectedClassInfo> = [
    { text: "Trascurabile", value: 1, class: 'gravity1' },
    { text: "Lieve", value: 2, class: 'gravity2' },
    { text: "Consistente", value: 3, class: 'gravity3' },
    { text: "Grave", value: 4, class: 'gravity4' }
  ];

  @Input() selectorId: number = null;
  @Input() minValue: number = null;
  @Input() maxValue: number = null;

  constructor(private gridService: EmployeeIncomeService, private service: GravitySelectorService) { }

  ngOnInit(): void {
    if (this.selectorId == null) {
      throw new Error(`selectorId not set as input for component ${GravitySelectorComponent.name}`);
    }
  }

  public MinValueChanged(changes: number): void {
    this.minValue = changes;
    this.emitChangeEvent();
  }
  public MaxValueChanged(changes: number): void {
    this.maxValue = changes;
    this.emitChangeEvent();
  }
  public SeverityValueChanged(changes: selectedClassInfo): void {
    console.log("dioporco")
    this.selectedItem = changes;
    this.emitChangeEvent();
  }

  private emitChangeEvent() {
    this.service.setData(<SeverityFilterData>{
      id: this.selectorId,
      minValue: this.minValue,
      maxValue: this.maxValue,
      selectedClassInfo: this.selectedItem
    });
  }
}

export class SeverityFilterData {
  readonly id: number;
  readonly minValue: number;
  readonly maxValue: number;
  readonly selectedClassInfo: selectedClassInfo;
}

export class selectedClassInfo {
  readonly text: string;
  readonly value: number;
  readonly class: string;
}
