import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../../../services/appointment.service';
import { LoginService } from '../../../../services/login.service';
import { ActivatedRoute } from '@angular/router';
import { Appointment } from '../../../../classes/appointment';
import { WorkingHoursService } from '../../../../services/working-hours.service';
import { WorkingHours } from '../../../../classes/working-hours';
import { AppointmentBookingComponent } from '../appointment-booking/appointment-booking.component';
import { AppointmentHourPickerComponent } from '../appointment-hour-picker/appointment-hour-picker.component';
import { AppointmentDatePickerComponent } from '../appointment-date-picker/appointment-date-picker.component';
import { Card } from "primeng/card";
import { DoctorService } from '../../../../services/doctor.service';
import { WorkingHoursComponent } from "../working-hours/working-hours.component";



@Component({
  selector: 'app-add-appointment',
  imports: [AppointmentBookingComponent, AppointmentHourPickerComponent, AppointmentDatePickerComponent, Card, WorkingHoursComponent],
  templateUrl: './add-appointment.component.html',
  styleUrl: './add-appointment.component.scss'
})


export class AddAppointmentComponent implements OnInit {

  // קונסטרקטור
  constructor(
    private appointmentService: AppointmentService,
    public loginService: LoginService,
    private workingHoursService: WorkingHoursService,
    private doctorService: DoctorService,
    private route: ActivatedRoute
  ) { }


  doctorId: string;
  doctorName: string;
  userId: string | null;
  date: Date | null = null;
  minDate: Date;
  maxDate: Date;
  disabledDates: Date[] = [];
  workingDays: number[] = [];
  workingHours: WorkingHours[] = [];
  availableHours: Array<string> = [];
  selectedHour: string = '';


  ngOnInit(): void {
    this.initDateRange();
    this.loadDoctorData();
  }

  private initDateRange(): void {
    const today = new Date();
    this.minDate = new Date(today);
    this.minDate.setDate(today.getDate() + 1);
    this.maxDate = new Date(today);
    this.maxDate.setFullYear(today.getFullYear() + 2);
  }

  private loadDoctorData(): void {
    this.route.queryParams.subscribe(params => {
      this.doctorId = params['doctorId'];
      this.userId = this.loginService.getCurrentUser().userId;
      this.workingHoursService.getByDoctor(this.doctorId).subscribe(workingHours => {
        this.workingHours = workingHours.sort((a, b) => a.day - b.day);
        this.workingDays = workingHours.map(wh => wh.day);
        this.populateDisabledDates();
      });
    });
    this.doctorService.getById(this.doctorId).subscribe(doctor => { this.doctorName = doctor.name });
  }

  getDayName(dayNum: number): string {
    const days = ['ראשון', 'שני', 'שלישי', 'רביעי', 'חמישי', 'שישי', 'שבת'];
    return days[dayNum] ?? '';
  }

  populateDisabledDates(): void {
    this.disabledDates = [];
    const start = new Date(this.minDate);
    const end = new Date(this.maxDate);
    for (let d = new Date(start); d <= end; d.setDate(d.getDate() + 1)) {
      if (!this.workingDays.includes(d.getDay())) {
        this.disabledDates.push(new Date(d));
      }
    }
  }

  onDateSelected(selectedDate: Date): void {
    this.date = selectedDate;
    this.selectedHour = '';
    if (selectedDate) {
      this.getAvailableHoursThisDoctor(selectedDate);
    } else {
      this.availableHours = [];
    }
  }

  getAvailableHoursThisDoctor(date: Date): void {
    this.availableHours = [];
    const dateString = date.toISOString().substring(0, 10);
    this.workingHoursService.getAvaiableHours(this.doctorId, dateString)
      .subscribe(hours => this.availableHours = hours ?? []);
  }

  onHourSelected(hour: string): void {
    this.selectedHour = hour;
  }

  onBookAppointment(): void {
    if (!this.userId || !this.date || !this.selectedHour) {
      return;
    }
    const appointment = new Appointment(
      0,
      new Date(this.date),
      this.convertToTimeSpan(this.selectedHour),
      this.doctorId,
      this.userId
    );
    this.appointmentService.addAppointment(appointment).subscribe({
      next: () => {
      },
      error: () => {
        alert("שגיאה בקביעת התור, אנא נסה שנית מאוחר יותר.")
      }
    });
  }

  private convertToTimeSpan(hour: string): string {
    const [h, m] = hour.split(':').map(Number);
    return `${h.toString().padStart(2, '0')}:${m.toString().padStart(2, '0')}:00`;
  }
}


