import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Avatar } from 'primeng/avatar';
import { Card } from 'primeng/card';
import { DividerModule } from 'primeng/divider';
import { Appointment } from '../../../../classes/appointment';
import { Doctor } from '../../../../classes/doctor';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-appointment-item',
  standalone: true,
  imports: [Card, DividerModule, DatePipe],
  templateUrl: './appointment-item.component.html',
  styleUrls: ['./appointment-item.component.scss']
})
export class AppointmentItemComponent {
  @Input() appointment!: Appointment;
  @Input() doctor!: Doctor;
  @Input() canCancel = false;
  @Input() canReschedule = false;
  @Input() canBookNew = false;
  @Input() specialtyName: string = '';


  @Output() cancel = new EventEmitter<Appointment>();
  @Output() reschedule = new EventEmitter<Appointment>();
  @Output() bookNew = new EventEmitter<Doctor>();

  onCancel() {
    this.cancel.emit(this.appointment);
  }
  onReschedule() {
    this.reschedule.emit(this.appointment);
  }
  onBookNew() {
    this.bookNew.emit(this.doctor);
  }
}