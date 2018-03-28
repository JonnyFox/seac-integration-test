import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewEComponent } from './view-e.component';

describe('ViewEComponent', () => {
  let component: ViewEComponent;
  let fixture: ComponentFixture<ViewEComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewEComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewEComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
