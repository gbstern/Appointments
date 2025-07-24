import { Component, OnInit } from '@angular/core';
import { Doctor } from '../../../classes/doctor';
import { DoctorService } from '../../../services/doctor.service';
import { TableModule, TableRowCollapseEvent, TableRowExpandEvent } from 'primeng/table';
import { DatePipe } from '@angular/common';
import { WorkingHoursService } from '../../../services/working-hours.service';
import { SpecialtyService } from '../../../services/specialty.service';
import { Specialty } from '../../../classes/specialty';
import { Button } from "primeng/button";

@Component({
  selector: 'app-show-all-doctors',
  imports: [TableModule, DatePipe, Button],
  templateUrl: './show-all-doctors.component.html',
  styleUrl: './show-all-doctors.component.scss'
})
export class ShowAllDoctorsComponent implements OnInit {


  doctors: Array<Doctor> = [];
  specialties: Array<Specialty> = [];
  expandedRows = {};


  constructor(
    private doctorService: DoctorService,
    private workingHoursService: WorkingHoursService,
    private specialtyService: SpecialtyService
  ) { }

  ngOnInit(): void {
    this.loadDoctors();
    this.loadSpecialties();
  }


  loadDoctors() {
    this.doctorService.getAll().subscribe(data => {
      this.doctors = data;
      data.forEach(d => {
        this.workingHoursService.getByDoctor(d.id).subscribe(whs => {
          const sorted = whs.sort((a, b) => a.day - b.day);
          d.workingHours = sorted;
        })
      });
    }
    );
  }

  loadSpecialties() {
    this.specialtyService.getAll().subscribe(data => {
      this.specialties = data;
    })
  }
  getSpecialtyName(specialtyId: number): string {
    console.log("all specialties: " + this.specialties);
    const specialty = this.specialties.find(s => s.id == specialtyId)
    return specialty ? specialty.specialty : 'Unknown specialty'
  }
  getDayName(dayNum: number): string {
    const days = ['ראשון', 'שני', 'שלישי', 'רביעי', 'חמישי', 'שישי', 'שבת'];
    return days[dayNum] ?? '';
  }


  onRowExpand(event: TableRowExpandEvent) {
  }

  onRowCollapse(event: TableRowCollapseEvent) {
  }


}
