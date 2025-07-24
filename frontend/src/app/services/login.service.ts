import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Login } from '../classes/login';
import { Patient } from '../classes/patient';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  URL = "http://localhost:5025/api/Login"

  currentUser: any;
  currentPatient: Patient;

  constructor(private httpClient: HttpClient) { }

  login(login: Login): Observable<any> {
    return this.httpClient.post(this.URL, login).pipe(
      tap((response: any) => {
        this.currentUser = { ...response };
        localStorage.setItem('currentUser', JSON.stringify(this.currentUser));
        localStorage.setItem('jwt', response.token);
      })

    );
  }

  logout(): void {
    this.currentUser = null;
    localStorage.removeItem('currentUser');
    localStorage.removeItem('jwt');
    console.log('User logged out');
  }

  isManager(): boolean {
    const userData = localStorage.getItem('currentUser');
    if (userData) {
      const user = JSON.parse(userData);
      return user.role == 'manager'
    }
    return false;
  }

  setPatient(patient: Patient) {
    this.currentUser = patient;
  }

  getCurrentUser() {
    if (this.currentUser && this.currentUser.id)
      return this.currentUser.id;
    const userData = localStorage.getItem('currentUser');
    if (userData) {
      const user = JSON.parse(userData);
      this.currentUser = user;
      console.log("current User from localStorage " + this.currentUser.userId);
      return this.currentUser;
    }
    return null;
  }
}
