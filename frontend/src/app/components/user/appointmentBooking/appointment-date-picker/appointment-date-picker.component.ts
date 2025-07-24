import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DatePicker } from 'primeng/datepicker';

@Component({
  selector: 'app-appointment-date-picker',
  imports: [DatePicker, FormsModule],
  templateUrl: './appointment-date-picker.component.html',
  styleUrl: './appointment-date-picker.component.scss'
})
export class AppointmentDatePickerComponent {
  @Input() date: Date | null = null;
  @Input() minDate: Date | null = null;
  @Input() maxDate: Date | null = null;
  @Input() disabledDates: Date[] = [];
  @Output() dateSelected = new EventEmitter<Date>();

  onDateSelect(event: Date) {
    this.dateSelected.emit(event);
  }
}