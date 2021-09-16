import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeadlinesTabComponent } from './deadlines-tab.component';

describe('DeadlinesTabComponent', () => {
  let component: DeadlinesTabComponent;
  let fixture: ComponentFixture<DeadlinesTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeadlinesTabComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeadlinesTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
