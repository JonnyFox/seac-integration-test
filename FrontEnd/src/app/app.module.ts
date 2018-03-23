import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http'
import { AuthorizationService } from './services/authorization.service';
import { HttpService } from './services/http.service';
import { EmployeeIncomeService } from './services/employee-income.service';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { SeverityFilterComponent } from './components/severity-filter/severity-filter.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DataGrid } from './components/grid/grid.component';

@NgModule({
  declarations: [
    AppComponent,
    DataGrid,
    SeverityFilterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    GridModule,
    HttpClientModule,
    InputsModule,
    DropDownsModule
  ],
  providers: [AuthorizationService, HttpService, EmployeeIncomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
