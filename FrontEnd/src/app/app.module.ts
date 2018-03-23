import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GridModule } from '@progress/kendo-angular-grid';
import { AppComponent } from './app.component';
import { GridComponent } from './grid/grid.component';
import { BaseHttpService } from './services/base-http.service'
import { HttpClientModule } from '@angular/common/http'
import { AuthorizationService } from './services/authorization.service';
import { HttpService } from './services/http.service';
import { EmployeeIncomeService } from './services/employee-income.service';
import { EmployeeIncomeBindingDirective } from './directives/employee-income-binding.directive';

@NgModule({
  declarations: [
    AppComponent,
    GridComponent,
    EmployeeIncomeBindingDirective
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    GridModule,
    HttpClientModule
  ],
  providers: [BaseHttpService, AuthorizationService, HttpService, EmployeeIncomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
