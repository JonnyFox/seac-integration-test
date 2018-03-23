import { Component, OnInit, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-severity-filter',
  templateUrl: './severity-filter.component.html',
  styleUrls: ['./severity-filter.component.scss']
})
export class SeverityFilterComponent {
  @Output() onChanged: EventEmitter<SeverityFilterData> = new EventEmitter();

  public minValue: number = 100;
  public maxValue: number = 1000;
  public selectedItem: string;
  public listItems: Array<{ text: string, value: number, class: string }> = [
    { text: "Trascurabile", value: 1, class: 'gravity0' },
    { text: "Lieve", value: 2, class: 'gravity1' },
    { text: "Consistente", value: 3, class: 'gravity2' },
    { text: "Grave", value: 3, class: 'gravity3' }
  ];

  public MinValueChanged(changes: number): void {
    this.minValue = changes;
    this.emitChangeEvent();
  }
  public MaxValueChanged(changes: number): void {
    this.maxValue = changes;
    this.emitChangeEvent();
  }
  public SeverityValueChanged(changes: string): void {
    this.selectedItem = changes;
    this.emitChangeEvent();
  }

  private emitChangeEvent() {
    this.onChanged.emit({
      minValue: this.minValue,
      maxValue: this.maxValue,
      selectedItem: this.selectedItem
    });
  }
}

export class SeverityFilterData {
  readonly minValue: number;
  readonly maxValue: number;
  readonly selectedItem: string;
}
