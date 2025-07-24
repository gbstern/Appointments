import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentHourPickerComponent } from './appointment-hour-picker.component';

describe('AppointmentHourPickerComponent', () => {
  let component: AppointmentHourPickerComponent;
  let fixture: ComponentFixture<AppointmentHourPickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentHourPickerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentHourPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
