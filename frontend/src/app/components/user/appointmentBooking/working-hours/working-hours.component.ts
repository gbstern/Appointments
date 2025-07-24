import { Component, Input } from '@angular/core';
import { WorkingHours } from '../../../../classes/working-hours';

@Component({
  selector: 'app-working-hours',
  imports: [],
  templateUrl: './working-hours.component.html',
  styleUrl: './working-hours.component.scss'
})
export class WorkingHoursComponent {
  @Input() workingHours: WorkingHours[] = [];
  @Input() getDayName!: (dayNum: number) => string;
}
