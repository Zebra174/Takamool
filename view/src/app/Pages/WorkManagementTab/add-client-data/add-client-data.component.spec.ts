import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddClientDataComponent } from './add-client-data.component';

describe('AddClientDataComponent', () => {
  let component: AddClientDataComponent;
  let fixture: ComponentFixture<AddClientDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddClientDataComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddClientDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
