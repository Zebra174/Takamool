import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DerasatComponent } from './derasat.component';

describe('DerasatComponent', () => {
  let component: DerasatComponent;
  let fixture: ComponentFixture<DerasatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DerasatComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DerasatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
