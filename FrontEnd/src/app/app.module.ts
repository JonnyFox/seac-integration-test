import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http'
import { AuthorizationService } from './services/authorization.service';
import { HttpService } from './services/http.service';
import { EmployeeIncomeService } from './services/employee-income.service';
import { EmployeeIncomeBindingDirective } from './directives/employee-income-binding.directive';
import { GridModule } from '@progress/kendo-angular-grid';
import { GridComponent } from './components/grid/grid.component';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { SeverityFilterComponent } from './components/severity-filter/severity-filter.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

@NgModule({
  declarations: [
    AppComponent,
    GridComponent,
    EmployeeIncomeBindingDirective,
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
