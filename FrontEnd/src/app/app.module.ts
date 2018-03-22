import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GridModule } from '@progress/kendo-angular-grid';
import { AppComponent } from './app.component';
import { GridComponent } from './grid/grid.component';
import { BaseHttpService } from './services/http.service'
import { HttpClientModule } from '@angular/common/http'
import { AuthorizationService } from './services/authorization.service';

@NgModule({
  declarations: [
    AppComponent,
    GridComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    GridModule,
    HttpClientModule
  ],
  providers: [BaseHttpService, AuthorizationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
