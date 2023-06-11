import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MetaFilesComponent } from './meta-files.component';

describe('MetaFilesComponent', () => {
  let component: MetaFilesComponent;
  let fixture: ComponentFixture<MetaFilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MetaFilesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MetaFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
