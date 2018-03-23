import { Directive, OnInit, OnDestroy } from '@angular/core';
import { DataBindingDirective, GridComponent } from '@progress/kendo-angular-grid';
import { Subscription } from 'rxjs/Subscription';
import { EmployeeIncomeService } from '../services/employee-income.service';

@Directive({
    selector: '[EmployeeIncomeBinding]'
})
export class EmployeeIncomeBindingDirective extends DataBindingDirective implements OnInit, OnDestroy {
    private serviceSubscription: Subscription;

    constructor(private products: EmployeeIncomeService, grid: GridComponent) {
        super(grid);
    }

    public ngOnInit(): void {
        this.serviceSubscription = this.products.subscribe((result) => {
            this.grid.data = result;
            this.notifyDataChange();
        });

        super.ngOnInit();

        this.rebind();
    }

    public ngOnDestroy(): void {
        if (this.serviceSubscription) {
            this.serviceSubscription.unsubscribe();
        }

        super.ngOnDestroy();
    }

    public rebind(): void {
        this.products.query(this.state);
    }
}
