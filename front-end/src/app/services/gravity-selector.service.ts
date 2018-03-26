import { Injectable, EventEmitter } from '@angular/core';
import { SeverityFilterData } from '../components/gravity-selector/gravity-selector.component';

@Injectable()
export class GravitySelectorService {
  public elements: Array<SeverityFilterData> = new Array<SeverityFilterData>();
  public onChanged: EventEmitter<Array<SeverityFilterData>> = new EventEmitter();

  public setData(filterData: SeverityFilterData) {
    const element = this.elements.find(elem => elem.id === filterData.id);
    if (element != null) {
      this.elements.splice(this.elements.indexOf(element));
    }

    this.elements.push(filterData);
    this.onChanged.emit(this.elements);
  }

  constructor() {  }
}
