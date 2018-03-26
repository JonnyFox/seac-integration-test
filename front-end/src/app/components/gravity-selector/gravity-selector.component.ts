import { Component, OnInit, EventEmitter, OnChanges, SimpleChanges, Input } from '@angular/core';
import { EmployeeIncomeService } from '../../services/employee-income-grid.service';
import { GravitySelectorService } from '../../services/gravity-selector.service';

@Component({
    selector: 'app-gravity-selector',
    templateUrl: './gravity-selector.component.html'
})

export class GravitySelectorComponent implements OnInit {

    public selectedItem: SelectedClassInfo = null;
    public listItems: Array<SelectedClassInfo> = [
        { text: 'Trascurabile', value: 1, class: 'gravity1' },
        { text: 'Lieve', value: 2, class: 'gravity2' },
        { text: 'Consistente', value: 3, class: 'gravity3' },
        { text: 'Grave', value: 4, class: 'gravity4' }
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
    readonly selectedClassInfo: SelectedClassInfo;
}

export class SelectedClassInfo {
    readonly text: string;
    readonly value: number;
    readonly class: string;
}
