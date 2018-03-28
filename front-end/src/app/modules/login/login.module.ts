import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from '../../components/login/login.component';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(
      [
        { path: '', component: LoginComponent }
      ])
  ],
  declarations: [LoginComponent]
})
export class LoginModule { }
