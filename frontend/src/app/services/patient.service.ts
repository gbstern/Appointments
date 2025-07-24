import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Patient } from '../classes/patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  URL = "http://localhost:5025/api/Patient"

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Array<Patient>> {
    return this.httpClient.get<Array<Patient>>(this.URL);
  }

  getById(id: string): Observable<Patient> {
    return this.httpClient.get<Patient>(`${this.URL}/id/${id}`);
  }

  addPatient(patient: Patient): Observable<any> {
    console.log(`patient ${patient.firstName} ${patient.lastName} ${patient.birthDate}`);
    console.log("URL" + this.URL);
    console.log("request" + this.httpClient.post(this.URL, patient));

    return this.httpClient.post(this.URL, patient);
  }

  updatePatient(patient: Patient, id: string): Observable<any> {
    return this.httpClient.put(`${this.URL}/${id}`, patient);
  }

  deletePatient(id: string): Observable<any> {
    return this.httpClient.delete(`${this.URL}/${id}`);
  }
}
