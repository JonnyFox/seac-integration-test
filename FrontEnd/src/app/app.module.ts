import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http'
import { AuthorizationService } from './services/authorization.service';
import { HttpService } from './services/http.service';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DataGrid } from './components/grid/grid.component';
import { MainPageService } from './services/main-page.service';
import { EmployeeIncomeService } from './services/employee-income-grid.service';
import { GravitySelectorComponent } from './components/gravity-selector/gravity-selector.component';
import { GravitySelectorService } from './services/gravity-selector.service';

@NgModule({
  declarations: [
    AppComponent,
    DataGrid,
    GravitySelectorComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    GridModule,
    HttpClientModule,
    InputsModule,
    DropDownsModule
  ],
  providers: [AuthorizationService, HttpService, EmployeeIncomeService, MainPageService, GravitySelectorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
