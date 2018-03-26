import { Injectable, EventEmitter } from '@angular/core';
import { SeverityFilterData } from '../components/gravity-selector/gravity-selector.component';

@Injectable()
export class GravitySelectorService {
  public onChanged: EventEmitter<SeverityFilterData> = new EventEmitter(); //todo: list

  constructor() {
  }
}
