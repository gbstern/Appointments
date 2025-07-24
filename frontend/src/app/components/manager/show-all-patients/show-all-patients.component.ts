import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../../services/patient.service';
import { Patient } from '../../../classes/patient';
import { TableModule } from 'primeng/table';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-show-all-patients',
  imports: [TableModule, DatePipe],
  templateUrl: './show-all-patients.component.html',
  styleUrl: './show-all-patients.component.scss'
})
export class ShowAllPatientsComponent implements OnInit {

  patients: Array<Patient> = [];

  constructor(private patientsService: PatientService) { }
  
  ngOnInit(): void {
    this.patientsService.getAll().subscribe(data => this.patients = data);
  }

}
