import { Component, OnInit, EventEmitter, OnChanges, SimpleChanges, Input, ViewContainerRef } from '@angular/core';
import { EmployeeIncomeService } from '../../services/employee-income-grid.service';
import { GravitySelectorService } from '../../services/gravity-selector.service';
import { ColorPickerService, Cmyk } from 'ngx-color-picker';

@Component({
    selector: 'app-gravity-selector',
    templateUrl: './gravity-selector.component.html',
    styleUrls: ['./gravity-selector.component.scss']
})

export class GravitySelectorComponent implements OnInit {

    public selectedItem: SelectedClassInfo = null;
    @Input() minValue: number = null;
    @Input() maxValue: number = null;

    color = '#ffffff';

    constructor(private gridService: EmployeeIncomeService, private service: GravitySelectorService, public vcRef: ViewContainerRef, private cpService: ColorPickerService) { }

    public cmykColor: Cmyk = new Cmyk(0, 0, 0, 0);
    public onChangeColor(color: string): Cmyk {
      const hsva = this.cpService.stringToHsva(color);

      const rgba = this.cpService.hsvaToRgba(hsva);

      return this.cpService.rgbaToCmyk(rgba);
    }

    ngOnInit(): void {
           // throw new Error(`selectorId not set as input for component ${GravitySelectorComponent.name}`);
    }

    public minValueChanged(changes: number): void {
        this.minValue = changes;
        this.emitChangeEvent();
    }

    public maxValueChanged(changes: number): void {
        this.maxValue = changes;
        this.emitChangeEvent();
    }

    public severityValueChanged(changes: SelectedClassInfo): void {
        this.selectedItem = changes;
        this.emitChangeEvent();
    }

    private emitChangeEvent() {
        this.service.setData(<SeverityFilterData>{
            //id: this.selectorId,
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
    readonly selectedClassInfo: SelectedClassInfo;
}

export class SelectedClassInfo {
    readonly text: string;
    readonly value: number;
    readonly class: string;
}
