import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentDatePickerComponent } from './appointment-date-picker.component';

describe('AppointmentDatePickerComponent', () => {
  let component: AppointmentDatePickerComponent;
  let fixture: ComponentFixture<AppointmentDatePickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentDatePickerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentDatePickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
