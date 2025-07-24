import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Specialty } from '../classes/specialty';

@Injectable({
  providedIn: 'root'
})
export class SpecialtyService {

  URL = "http://localhost:5025/api/Specialty"

  constructor(private httpClient : HttpClient) { }

  getAll() : Observable<Array<Specialty>>
  {
    return this.httpClient.get<Array<Specialty>>(this.URL);
  }

  getById(id : number) : Observable<Specialty>
  {
    return this.httpClient.get<Specialty>(`${this.URL}/id/${id}`);
  }

  getByName(name : string) : Observable<Specialty>
  {
    return this.httpClient.get<Specialty>(`${this.URL}/name/${name}`);
  }

  addSpecialty(specialty : Specialty) : Observable<any>
  {
    return this.httpClient.post(this.URL, specialty);
  }

  updateSpecialty(specialty : Specialty, id : number) : Observable<any>
  {
    return this.httpClient.put(`${this.URL}/${id}`, specialty);
  }

  deleteSpecialty(id : number) : Observable<any>
  {
    return this.httpClient.delete(`${this.URL}/${id}`)
  }
}
