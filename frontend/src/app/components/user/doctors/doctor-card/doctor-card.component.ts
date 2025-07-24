import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DataViewModule } from 'primeng/dataview';
import { CommonModule } from '@angular/common';
import { Card } from 'primeng/card';
import { Button } from 'primeng/button';
import { Divider } from 'primeng/divider';
import { Doctor } from '../../../../classes/doctor';




@Component({
  selector: 'app-doctor-card',
  imports: [DataViewModule, CommonModule, Card, Button, Divider],
  templateUrl: './doctor-card.component.html',
  styleUrl: './doctor-card.component.scss'
})
export class DoctorCardComponent {
  @Input() doctor!: Doctor;
  @Input() specialtyName: string = '';
  @Input() getDayName!: (dayNum: number) => string;

  @Output() bookAppointment = new EventEmitter<string>();

  onBook() {
    this.bookAppointment.emit(this.doctor.id);
  }

}
