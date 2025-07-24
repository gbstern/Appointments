import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Button } from "primeng/button";
import { ToastModule } from 'primeng/toast';
import { ConfirmDialog } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';


@Component({
  selector: 'app-appointment-booking',
  imports: [Button, ToastModule, ConfirmDialog],
  templateUrl: './appointment-booking.component.html',
  styleUrl: './appointment-booking.component.scss',
  providers: [ConfirmationService, MessageService]
})
export class AppointmentBookingComponent {

  constructor(private confirmationService: ConfirmationService, private messageService: MessageService) { }

  @Input() selectedDate: Date | null = null;
  @Input() selectedHour: string = '';
  @Input() canBook: boolean = false;
  @Input() statusMessage: string = '';

  @Output() book = new EventEmitter<void>();


  onBook() {
    this.confirmationService.confirm({
      header: 'רגע לפני זימון התור',
      message: `זימנת תור לתאריך ${this.formatDate(this.selectedDate)} בשעה ${this.selectedHour}`,
      accept: () => {
        this.messageService.add({ severity: 'info', summary: 'אישור', detail: 'התור נקבע בהצלחה!' });
        this.book.emit();
      },
    });
  }


  formatDate(date: Date | null): string {
    if (!date) return '';
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0'); // חודשים מתחילים מ-0
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
  }
}





