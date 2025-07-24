import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ButtonModule } from 'primeng/button';



@Component({
  selector: 'app-appointment-hour-picker',
  imports: [ButtonModule],
  templateUrl: './appointment-hour-picker.component.html',
  styleUrl: './appointment-hour-picker.component.scss'
})
export class AppointmentHourPickerComponent {
  @Input() availableHours: string[] = [];
  @Input() selectedHour: string = '';
  @Output() hourSelected = new EventEmitter<string>();

  selectHour(hour: string) {
    this.hourSelected.emit(hour);
  }
}
