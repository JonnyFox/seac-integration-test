import { Injectable, EventEmitter } from '@angular/core';
import { SeverityData } from '../components/gravity-selector/gravity-selector.component';

@Injectable()
export class GravitySelectorService {
	public elements: Array<SeverityData> = new Array<SeverityData>();
	public onChanged: EventEmitter<Array<SeverityData>> = new EventEmitter();

	public setData(filterData: SeverityData) {
		const element = this.elements.find(elem => elem.id === filterData.id);
		if (element != null) {
			this.elements.splice(this.elements.indexOf(element));
		}

		this.elements.push(filterData);
		this.onChanged.emit(this.elements);
	}

	constructor() { }
}
