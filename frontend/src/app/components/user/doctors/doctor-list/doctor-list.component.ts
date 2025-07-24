import { Component, OnInit } from '@angular/core';
import { Doctor, Gender } from '../../../../classes/doctor';
import { Specialty } from '../../../../classes/specialty';
import { DoctorService } from '../../../../services/doctor.service';
import { LoginService } from '../../../../services/login.service';
import { Router } from '@angular/router';
import { SpecialtyService } from '../../../../services/specialty.service';
import { WorkingHoursService } from '../../../../services/working-hours.service';
import { DoctorCardComponent } from '../doctor-card/doctor-card.component';
import { FormsModule } from '@angular/forms';
import { DataViewModule } from 'primeng/dataview';
import { MultiSelectModule } from 'primeng/multiselect';
import { FloatLabel } from 'primeng/floatlabel';
import { InputText } from 'primeng/inputtext';
import { Button } from 'primeng/button';



interface genderProps {
  name: string,
  eGender: string
}


@Component({
  selector: 'app-doctor-list',
  imports: [DoctorCardComponent, FormsModule, DataViewModule, MultiSelectModule, InputText, Button],
  templateUrl: './doctor-list.component.html',
  styleUrl: './doctor-list.component.scss'
})



export class DoctorListComponent implements OnInit {

  doctors: Array<Doctor> = [];
  selectedGender: string = '';
  selectedLanguage: string = '';
  selectedSpecialty: number[] = []
  selectedName: string = '';
  filteredDoctors: Array<Doctor> = [];
  specialties: Array<Specialty> = [];
  gender: Array<genderProps> = [{ name: 'זכר', eGender: 'Male' }, { name: 'נקבה', eGender: 'Female' }]

  constructor(
    public doctorService: DoctorService,
    public loginService: LoginService,
    private router: Router,
    public specialtyService: SpecialtyService,
    public workingHoursService: WorkingHoursService
  ) { }

  ngOnInit(): void {
    this.showAll();
  }

  showAll() {
    this.doctorService.getAll().subscribe((data: Doctor[]) => {
      this.doctors = data;
      this.filteredDoctors = data;
      this.loadSpecialties();
      data.forEach(d => {
        this.workingHoursService.getByDoctor(d.id).subscribe(whs => {
          const sorted = whs.sort((a, b) => a.day - b.day);
          d.workingHours = sorted;
        })
      });
    })
  }

  filterDoctors() {
    let filteredDoctors = this.doctors;
    if (this.selectedGender) {
      const gender = this.selectedGender == 'Male' ? Gender.Male : Gender.Female;
      filteredDoctors = filteredDoctors.filter(doctor => doctor.gender == gender);
    }
    if (this.selectedLanguage) {
      filteredDoctors = filteredDoctors.filter(doctor => doctor.languages.includes(this.selectedLanguage));
    }
    if (this.selectedName) {
      filteredDoctors = filteredDoctors.filter(doctor => doctor.name.includes(this.selectedName));
    }
    if (this.selectedSpecialty && this.selectedSpecialty.length > 0) {
      filteredDoctors = filteredDoctors.filter(doctor => this.selectedSpecialty.includes(doctor.specialtyId));
    }
    this.filteredDoctors = filteredDoctors;
    this.loadSpecialties();
  }

  resetFilters() {
    this.selectedGender = '';
    this.selectedLanguage = '';
    this.selectedSpecialty = [];
    this.selectedName = '';
    this.filteredDoctors = this.doctors;
  }

  addAppoinmnent(doctorId: string) {
    if (!this.loginService.currentUser)
      alert("you must log in to be able to book an appointment")
    else
      this.router.navigate(['addAppointment'], { queryParams: { doctorId: doctorId, userId: this.loginService.currentUser.id } });
  }

  loadSpecialties() {
    this.specialtyService.getAll().subscribe(data => {
      this.specialties = data;
    })
  }
  getSpecialtyName(specialtyId: number): string {
    const specialty = this.specialties.find(s => s.id == specialtyId)
    return specialty ? specialty.specialty : 'Unknown specialty'
  }
  getDayName(dayNum: number): string {
    const days = ['ראשון', 'שני', 'שלישי', 'רביעי', 'חמישי', 'שישי', 'שבת'];
    return days[dayNum] ?? '';
  }

}
