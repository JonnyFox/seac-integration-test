import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeverityFilterComponent } from './severity-filter.component';

describe('SeverityFilterComponent', () => {
  let component: SeverityFilterComponent;
  let fixture: ComponentFixture<SeverityFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeverityFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeverityFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
