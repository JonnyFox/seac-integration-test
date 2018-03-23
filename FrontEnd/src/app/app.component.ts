import { Component, SimpleChange } from '@angular/core';
import { MainPageService } from './services/main-page.service';
import { SeverityFilterData } from './components/severity-filter/severity-filter.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  constructor(private pageService: MainPageService) { }

  onChanged(filterData: SeverityFilterData) {
    console.log(filterData);
  }
}
