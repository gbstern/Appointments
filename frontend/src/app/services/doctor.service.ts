import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Doctor, Gender } from '../classes/doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  URL = "http://localhost:5025/api/Doctor"

  constructor(private httpClient : HttpClient) { }


  private mapGenderText(doctors: Array<Doctor>): Doctor[] {
    return doctors.map(doctor => ({
      ...doctor,
      genderText: doctor.gender == Gender.Male ? 'male' : 'female'
    }));
  }


  getAll() : Observable<Array<Doctor>>
  {
    return this.httpClient.get<Array<Doctor>>(this.URL).pipe(
      map(this.mapGenderText)
    );
  }

  getById(id : string) : Observable<Doctor>
  {
    return this.httpClient.get<Doctor>(`${this.URL}/id/${id}`).pipe(
      map(doctor => ({
        ...doctor,
        genderText: doctor.gender === Gender.Male ? 'male' : 'female' // הוספת שדה חדש
      }))
    );
  }

  getByGender(gender : Gender) : Observable<Array<Doctor>>
  {
    return this.httpClient.get<Array<Doctor>>(`${this.URL}/gender/${gender}`).pipe(
      map(this.mapGenderText)
    );
  }

  getByLanguage(language : string) : Observable<Array<Doctor>>
  {
    return this.httpClient.get<Array<Doctor>>(`${this.URL}/language/${language}`).pipe(
      map(this.mapGenderText)
    );
  }

  getByName(name : string) : Observable<Doctor>
  {
    return this.httpClient.get<Doctor>(`${this.URL}/name/${name}`).pipe(
      map(doctor => ({
        ...doctor,
        genderText: doctor.gender === Gender.Male ? 'male' : 'female' // הוספת שדה חדש
      }))
    );
  }

  getBySpecialty(specialty : number) : Observable<Array<Doctor>>
  {
    return this.httpClient.get<Array<Doctor>>(`${this.URL}/specialty/${specialty}`).pipe(
      map(this.mapGenderText)
    );
  }

  addDoctor(doctor : Doctor) : Observable<any>
  {
    return this.httpClient.post(this.URL, doctor);
  }

  updateDoctor(doctor : Doctor, id : string) : Observable<any>
  {
    return this.httpClient.put(`${this.URL}/${id}`, doctor);
  }

  deleteDoctor(id : string) : Observable<any>
  {
    return this.httpClient.delete(`${this.URL}/${id}`);
  }
}
