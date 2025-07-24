import { Component, OnInit } from '@angular/core';
import { Appointment } from '../../../../classes/appointment';
import { AppointmentService } from '../../../../services/appointment.service';
import { Doctor } from '../../../../classes/doctor';
import { DoctorService } from '../../../../services/doctor.service';
import { AppointmentListComponent } from '../appointment-list/appointment-list.component';
import { PatientService } from '../../../../services/patient.service';
import { Patient } from '../../../../classes/patient';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-appointments',
  imports: [AppointmentListComponent],
  templateUrl: './my-appointments.component.html',
  styleUrl: './my-appointments.component.scss'
})

export class MyAppointmentsComponent implements OnInit {

  upcomingAppointments: Appointment[] = [];
  pastAppointments: Appointment[] = [];
  doctors: Doctor[] = [];
  user: any;
  patient: Patient;
  loading = true;
  error = '';

  constructor(
    private appointmentService: AppointmentService,
    private doctorService: DoctorService,
    private patientService: PatientService,
    private router: Router
  ) { }


  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('currentUser') || 'null');
    if (this.user) {
      this.loadPatient(this.user.userId);
    }
    this.loadDoctors();
  }


  loadPatient(id: string) {
    this.patientService.getById(id).subscribe(p => {
      this.patient = p;
      this.loadAppointments(this.patient.id);
      if (!this.patient) {
        this.handleNoUser();
      }
    });
  }


  private handleNoUser(): void {
    this.error = 'לא נמצאה כניסת משתמש';
    this.loading = false;
  }

  private loadDoctors(): void {
    this.doctorService.getAll().subscribe(docs => this.doctors = docs);
  }

  private loadAppointments(userId: string): void {
    this.appointmentService.getByPatient(userId).subscribe({
      next: appointments => this.processAppointments(appointments),
      error: () => this.handleAppointmentsError()
    });
  }

  private processAppointments(appointments: Appointment[]): void {
    const now = new Date();
    this.upcomingAppointments = appointments
      .filter(a => new Date(a.date) >= now)
      .sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime());
    this.pastAppointments = appointments
      .filter(a => new Date(a.date) < now)
      .sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());
    this.loading = false;
  }

  private handleAppointmentsError(): void {
    this.error = 'שגיאה בטעינת התורים';
    this.loading = false;
  }


  onCancel(appointment: Appointment) {
    this.appointmentService.deleteAppointment(appointment.id).subscribe({
      next: () => {
        alert(`התור בוטל בהצלחה: ${appointment.id}`);
        this.loadAppointments(this.patient.id);
      }
    });
  }

  onReschedule(appointment: Appointment) {
    this.appointmentService.deleteAppointment(appointment.id).subscribe({
      next: () => {
        this.loadAppointments(this.patient.id);
      }
    });
    this.doctorService.getById(appointment.doctorId).subscribe({
      next: (doctor: Doctor) => {
        this.onBookNew(doctor);
      }
    });
  }
  onBookNew(doctor: Doctor) {
    this.router.navigate(['addAppointment'], { queryParams: { doctorId: doctor.id, userId: this.patient.id } });
  }

}
