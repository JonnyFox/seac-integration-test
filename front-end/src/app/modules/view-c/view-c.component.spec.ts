import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCComponent } from './view-c.component';

describe('ViewCComponent', () => {
  let component: ViewCComponent;
  let fixture: ComponentFixture<ViewCComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewCComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewCComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
