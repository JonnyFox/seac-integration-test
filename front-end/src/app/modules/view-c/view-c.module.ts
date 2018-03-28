import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewCComponent } from '../../components/view-c/view-c.component';
import { RouterModule } from '@angular/router';
import { DataGridComponent } from '../../components/grid/grid.component';
import { GravitySelectorComponent } from '../../components/gravity-selector/gravity-selector.component';
import { EmployeeIncomeService } from '../../services/employee-income-grid.service';
import { GravitySelectorService } from '../../services/gravity-selector.service';
import { ColorPickerModule } from 'ngx-color-picker';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

@NgModule({
  imports: [
    GridModule,
    ExcelModule,
    PDFModule,
    InputsModule,
    DropDownsModule,
    CommonModule,
    ColorPickerModule,
    RouterModule.forChild(
      [
        { path: '', component: ViewCComponent }
      ])
  ],
  declarations: [
    ViewCComponent,        
    DataGridComponent,
    GravitySelectorComponent,
  ],
  providers: [
    EmployeeIncomeService,
    GravitySelectorService
  ]
})
export class ViewCModule { }
