import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkingHours } from '../classes/working-hours';

@Injectable({
  providedIn: 'root'
})
export class WorkingHoursService {

  URL = "http://localhost:5025/api/WorkingHours"

  constructor(private httpClient: HttpClient) { }

  getAll() : Observable<Array<WorkingHours>>{
    return this.httpClient.get<Array<WorkingHours>>(this.URL);
  }

  getByDoctor(doctorId : string) : Observable<Array<WorkingHours>>{
    return this.httpClient.get<Array<WorkingHours>>(`${this.URL}/${doctorId}`);
  }

  getByDay(doctorId : string, day : string) : Observable<WorkingHours>{
    return this.httpClient.get<WorkingHours>(`${this.URL}/id/${doctorId}/day/${day}`);
  }

  getAvaiableHours(doctorId : string , date: string) : Observable<Array<string>>{
    return this.httpClient.get<Array<string>>(`${this.URL}/id/${doctorId}/date/${date}`);
  }

  addWorkingHours(workingHours : WorkingHours) : Observable<any>{
    return this.httpClient.post(this.URL, workingHours);
  }

  updateWorkingHours(workingHours : WorkingHours, id : number) : Observable<any>{
    return this.httpClient.put(`${this.URL}/${id}`, workingHours);
  }

  deleteWorkingHours(id : number) : Observable<any>{
    return this.httpClient.delete(`${this.URL}/${id}`);
  }

}
