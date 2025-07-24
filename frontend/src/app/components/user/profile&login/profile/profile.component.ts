import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CardModule } from 'primeng/card';
import { Patient } from '../../../../classes/patient';
import { PatientService } from '../../../../services/patient.service';
import { Divider } from 'primeng/divider';
import { DatePipe } from '@angular/common';
import { Button } from "primeng/button";


@Component({
  selector: 'app-profile',
  imports: [CardModule, Divider, DatePipe, Button],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent implements OnInit {
  user: any | null;
  patient: Patient;
  imageUrl: string = '../../../../../assets/images/'

  constructor(
    private router: Router,
    private patientService: PatientService
  ) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('currentUser') || 'null');
    if (this.user) {
      this.loadPatient(this.user.userId);
      console.log(this.user.userId);

    }
  }

  loadPatient(id: string) {
    this.patientService.getById(id).subscribe(p => {
      this.patient = p;
      console.log(this.patient.lastName);

    });
  }

  editProfile() {
    this.router.navigate(['/profile/edit']);
  }
}