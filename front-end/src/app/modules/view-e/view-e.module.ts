import { ViewEComponent } from '../../components/view-e/view-e.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(
      [
        { path: '', component: ViewEComponent }
      ])
  ],
  declarations: [ViewEComponent]
})
export class ViewEModule { }
