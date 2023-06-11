import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLegalServicesComponent } from './add-legal-services.component';

describe('AddLegalServicesComponent', () => {
  let component: AddLegalServicesComponent;
  let fixture: ComponentFixture<AddLegalServicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLegalServicesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddLegalServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
