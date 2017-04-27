import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PointOfInterestsComponent } from './point-of-interests.component';

describe('PointOfInterestsComponent', () => {
  let component: PointOfInterestsComponent;
  let fixture: ComponentFixture<PointOfInterestsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PointOfInterestsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PointOfInterestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
