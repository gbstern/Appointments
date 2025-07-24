import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AppointmentItemComponent } from '../appointment-item/appointment-item.component';
import { Appointment } from '../../../../classes/appointment';
import { Doctor } from '../../../../classes/doctor';
import { SpecialtyService } from '../../../../services/specialty.service';
import { Specialty } from '../../../../classes/specialty';

@Component({
  selector: 'app-appointment-list',
  standalone: true,
  imports: [AppointmentItemComponent],
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.scss']
})
export class AppointmentListComponent implements OnInit{

  constructor(public specialtyService: SpecialtyService) { }
  ngOnInit(): void {
    this.loadSpecialties();
  }

  specialties: Array<Specialty> = [];

  @Input() appointments: Appointment[] = [];
  @Input() doctors: Doctor[] = [];
  @Input() userRole: 'patient' | 'admin' = 'patient';
  @Input() viewType: 'cards' | 'table' = 'cards';

  @Output() cancel = new EventEmitter<Appointment>();
  @Output() reschedule = new EventEmitter<Appointment>();
  @Output() bookNew = new EventEmitter<Doctor>();

  getDoctor(id: string) {
    return this.doctors.find(d => d.id === id)!;
  }

  loadSpecialties() {
    this.specialtyService.getAll().subscribe(data => {
      this.specialties = data;
    })
  }

  getSpecialtyName(specialtyId: number): string {
    console.log(this.specialties);
    const specialty = this.specialties.find(s => s.id == specialtyId)
    console.log(specialty);
    return specialty ? specialty.specialty : 'Unknown specialty'
  }

  isFuture(appointment: Appointment): boolean {
    return new Date(appointment.date) >= new Date(new Date());
  }

  getActionPermissions(appointment: Appointment) {
    const isFuture = this.isFuture(appointment);
    return {
      canCancel: isFuture,
      canReschedule: isFuture,
      canBookNew: !isFuture
    };
  }

  trackById(index: number, item: Appointment) {
    return item.id;
  }
}