import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Appointment } from '../classes/appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  URL = "http://localhost:5025/api/Appointment"

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Array<Appointment>> {
    const token = localStorage.getItem('jwt');
    if (token) {
      const headers = new HttpHeaders({
        Authorization: `Bearer${token}`
      })
      return this.httpClient.get<Array<Appointment>>(this.URL, { headers });
    }
    return this.httpClient.get<Array<Appointment>>(this.URL);
  }

  getById(id: number): Observable<Appointment> {
    return this.httpClient.get<Appointment>(`${this.URL}/id/${id}`);
  }

  getByPatient(patientId: string): Observable<Array<Appointment>> {
    return this.httpClient.get<Array<Appointment>>(`${this.URL}/patient/${patientId}`);
  }

  getByDoctor(doctorId: string): Observable<Array<Appointment>> {
    return this.httpClient.get<Array<Appointment>>(`${this.URL}/doctor/${doctorId}`);
  }

  getByDate(date: string): Observable<Array<Appointment>> {
    return this.httpClient.get<Array<Appointment>>(`${this.URL}/date/${date}`);
  }

  addAppointment(appointment: Appointment): Observable<any> {
    return this.httpClient.post(this.URL, appointment);
  }

  updateAppointment(appointment: Appointment, id: number): Observable<any> {
    return this.httpClient.put(`${this.URL}/${id}`, appointment);
  }

  deleteAppointment(id: number): Observable<any> {
    return this.httpClient.delete(`${this.URL}/${id}`);
  }
}
