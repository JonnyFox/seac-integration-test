import { Component, Output, EventEmitter, } from '@angular/core';

@Component({
	selector: 'app-gravity-selector',
	templateUrl: './gravity-selector.component.html',
	styleUrls: ['./gravity-selector.component.scss']
})

export class GravitySelectorComponent {
	colors: Array<string> = ['#ffffff', '#ffffff', '#ffffff', '#ffffff'];
	values: Array<number> = [100, 1000, 2000, 5000];
	@Output() changed: EventEmitter<SeverityData> = new EventEmitter();

	private emitChangeEvent() {
		this.changed.emit(<SeverityData>{
			colors: this.colors,
			values: this.values
		});
	}
}

export class SeverityData {
	constructor(
		public colors: Array<string>,
		public values: Array<number>
	) { }
}
