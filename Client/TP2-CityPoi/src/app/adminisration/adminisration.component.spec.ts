import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminisrationComponent } from './adminisration.component';

describe('AdminisrationComponent', () => {
  let component: AdminisrationComponent;
  let fixture: ComponentFixture<AdminisrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminisrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminisrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
