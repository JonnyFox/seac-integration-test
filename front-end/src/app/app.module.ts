import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthorizationService } from './services/authorization.service';
import { HttpService } from './services/http.service';
import { RouterModule } from '@angular/router';
import { ViewCModule } from './modules/view-c/view-c.module';

@NgModule({
	declarations: [
		AppComponent,
	],
	imports: [
		BrowserModule,
		BrowserAnimationsModule,
		HttpClientModule,
		ViewCModule,
		RouterModule.forRoot(
			[
				// { path: '', redirectTo: 'view-c', pathMatch: 'full' },
				// { path: 'test', component: DataGridComponent },
				{ path: 'view-c', loadChildren: 'app/modules/view-c/view-c.module#ViewCModule' }/*,
            { path: 'view-e', loadChildren: "app/modules/view-e/view-e.module#ViewEModule"},
            { path: 'login', loadChildren: "app/modules/login/login.module#LoginModule"},
            { path: 'home', loadChildren: "app/modules/home/home.module#HomeModule"},
            { path: 'not-found', loadChildren: "app/modules/not-found/not-found.module#NotFoundModule"},
            { path: '**', redirectTo: 'view-c', pathMatch: 'full' },*/
			]
		)
	],
	providers: [
		AuthorizationService,
		HttpService,
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
