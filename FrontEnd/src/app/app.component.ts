import { Component, SimpleChange } from '@angular/core';
import { MainPageService } from './services/main-page.service';
import { GravitySelectorComponent } from './components/gravity-selector/gravity-selector.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  constructor(private pageService: MainPageService) { }

  onChanged(filterData: GravitySelectorComponent) {
    console.log(filterData);
  }
}
