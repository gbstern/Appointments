import { Component } from '@angular/core';
import { Divider } from "primeng/divider";
import { Card } from "primeng/card";
import { Patient } from '../../../../classes/patient';
import { PatientService } from '../../../../services/patient.service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { DatePicker } from "primeng/datepicker";
import { Button } from "primeng/button";
import { Router } from '@angular/router';
import { Password } from "primeng/password";

@Component({
  selector: 'app-edit-profile',
  imports: [Divider, Card, FormsModule, InputTextModule, ReactiveFormsModule, DatePicker, Button, Password],
  templateUrl: './edit-profile.component.html',
  styleUrl: './edit-profile.component.scss'
})
export class EditProfileComponent {

  user: any | null;
  patient: Patient;
  imageUrl: string = '../../../../../assets/images/';
  editProfileForm: FormGroup;
  private readonly _currentYear = new Date().getFullYear();
  readonly minDate = new Date(this._currentYear - 120, 0, 1);
  readonly maxDate = new Date(new Date().setDate(new Date().getDate() - 1));


  constructor(
    private patientService: PatientService,
    private router: Router
  ) { }



  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('currentUser') || 'null');
    if (this.user) {
      this.loadPatient(this.user.userId);
      console.log(this.user.userId);
    }
  }


  initializeForm() {
    this.editProfileForm = new FormGroup({
      address: new FormControl(this.patient.address, Validators.required),
      phone: new FormControl(this.patient.phone, Validators.required),
      email: new FormControl(this.patient.email, Validators.required),
      birthDate: new FormControl(this.patient.birthDate ? new Date(this.patient.birthDate) : null, Validators.required),
      password: new FormControl(this.patient.password, Validators.required),
      passwordValidate: new FormControl(this.patient.password, Validators.required)
    });
  }

  formatDate(date: Date | string): string {
    if (!date) return '';
    if (date instanceof Date) {
      const day = String(date.getDate()).padStart(2, '0');
      const month = String(date.getMonth() + 1).padStart(2, '0');
      const year = date.getFullYear();
      return `${day}/${month}/${year}`;
    }
    return '';
  }


  loadPatient(id: string) {
    this.patientService.getById(id).subscribe(p => {
      this.patient = p;
      console.log(this.patient.lastName);
      this.initializeForm();
    });
  }


  edit() {
    const updatedPatient = new Patient(
      this.patient.id,
      this.patient.firstName,
      this.patient.lastName,
      this.editProfileForm.get('birthDate')?.value,
      this.patient.gender,
      this.editProfileForm.get('address')?.value,
      this.editProfileForm.get('phone')?.value,
      this.editProfileForm.get('email')?.value,
      this.editProfileForm.get('password')?.value,
      []
    )
    console.log(updatedPatient);
    this.patientService.updatePatient(updatedPatient, this.patient.id).subscribe(p => {
      this.patient = p;
      this.router.navigate(['/profile']);
    });
  }

}
