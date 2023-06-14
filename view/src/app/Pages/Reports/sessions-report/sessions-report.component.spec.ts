import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionsReportComponent } from './sessions-report.component';

describe('SessionsReportComponent', () => {
  let component: SessionsReportComponent;
  let fixture: ComponentFixture<SessionsReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SessionsReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SessionsReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
