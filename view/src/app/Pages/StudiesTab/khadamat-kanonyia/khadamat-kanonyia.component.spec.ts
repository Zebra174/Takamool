import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KhadamatKanonyiaComponent } from './khadamat-kanonyia.component';

describe('KhadamatKanonyiaComponent', () => {
  let component: KhadamatKanonyiaComponent;
  let fixture: ComponentFixture<KhadamatKanonyiaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KhadamatKanonyiaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KhadamatKanonyiaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
