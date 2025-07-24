import { Component, OnInit } from '@angular/core';
import { Appointment } from '../../../classes/appointment';
import { Doctor } from '../../../classes/doctor';
import { Patient } from '../../../classes/patient';
import { AppointmentService } from '../../../services/appointment.service';
import { DoctorService } from '../../../services/doctor.service';
import { PatientService } from '../../../services/patient.service';
import { TableModule } from "primeng/table";
import { DatePipe } from '@angular/common';
import { SpecialtyService } from '../../../services/specialty.service';
import { Specialty } from '../../../classes/specialty';
import { SortEvent } from 'primeng/api';


@Component({
  selector: 'app-show-all-appointments',
  imports: [TableModule, DatePipe],
  templateUrl: './show-all-appointments.component.html',
  styleUrl: './show-all-appointments.component.scss'
})
export class ShowAllAppointmentsComponent implements OnInit {

  appointments: Array<Appointment> = [];
  appointmentsByDoctor: Array<Appointment> = [];
  appointmentByPatient: Array<Appointment> = [];
  appointmentsById: Appointment;
  appointmentByDate: Array<Appointment> = [];
  doctors: Array<Doctor> = [];
  patients: Array<Patient> = [];
  specialties: Array<Specialty> = [];


  constructor(
    private appointmentService: AppointmentService,
    private doctorService: DoctorService,
    private patientService: PatientService,
    private specialtyService: SpecialtyService
  ) { }


  ngOnInit(): void {
    this.showAllAppointments();
    this.loadDoctors();
    this.loadPatients();
    this.loadSpecialties();
  }


  showAllAppointments() {
    this.appointmentService.getAll().subscribe(data => {
      this.appointments = data;
    });
  }

  showAppointmentsById(id: number) {
    this.appointmentService.getById(id).subscribe(data => {
      this.appointmentsById = data;
    })
  }

  showAppointmentsByDoctor(doctorId: string) {
    this.appointmentService.getByDoctor(doctorId).subscribe(data => {
      this.appointmentsByDoctor = data;
    })
  }

  showAppointmentsByPatient(patientId: string) {
    this.appointmentService.getByPatient(patientId).subscribe(data => {
      this.appointmentByPatient = data;
    })
  }


  showAppointmentsByDate(date: string) {
    const selectedDate = new Date(date);
    const formattedDate: string = selectedDate.toISOString().replace('Z', '');;
    this.appointmentService.getByDate(formattedDate).subscribe(data => {
      this.appointmentByDate = data;
    })
  }


  loadDoctors() {
    this.doctorService.getAll().subscribe(data => {
      this.doctors = data;
    });
  }

  loadPatients() {
    this.patientService.getAll().subscribe(data => {
      this.patients = data;
    });
  }

  loadSpecialties() {
    this.specialtyService.getAll().subscribe(data => {
      this.specialties = data;
    });
  }

  getPatientName(patientId: string): string {
    const patient = this.patients.find(p => p.id === patientId);
    return patient ? patient.firstName + " " + patient.lastName : 'Unknown Patient';
  }

  getDoctorName(doctorId: string): string {
    const doctor = this.doctors.find(d => d.id === doctorId);
    return doctor ? doctor.name : 'Unknown Doctor';
  }

  getSpecialtyName(doctorId: string): string {
    const doctor = this.doctors.find(d => d.id === doctorId);
    const specialty = this.specialties.find(s => s.id === doctor?.specialtyId);
    return specialty ? specialty.specialty : 'Unknown Specialty';
  }
}

