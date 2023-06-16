import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditConsultingComponent } from './edit-consulting.component';

describe('EditConsultingComponent', () => {
  let component: EditConsultingComponent;
  let fixture: ComponentFixture<EditConsultingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditConsultingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditConsultingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
