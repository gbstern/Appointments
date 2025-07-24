import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../../../services/login.service';
import { Login } from '../../../../classes/login';
import { PatientService } from '../../../../services/patient.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputMaskModule } from 'primeng/inputmask';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, InputTextModule, FloatLabelModule, InputMaskModule, PasswordModule, ButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(public loginService: LoginService, public patientService: PatientService, private router: Router) { }

  userName: string = "";


  loginForm: FormGroup = new FormGroup({
    idNumber: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  })

  login(): void {
    const newLogin: Login = new Login(this.loginForm.get('idNumber')?.value, this.loginForm.get('password')?.value);
    this.loginService.login(newLogin).subscribe(response => {
      this.loginService.setPatient(response);
      this.getUserName(this.loginForm.get('idNumber')?.value);
      if (this.loginService.isManager())
        this.router.navigate(['/manager']);
      else
        this.router.navigate(['/myAppointments']);
    });
  }

  logout(): void {
    this.loginService.logout();
  }

  getUserName(userId: string): void {
    this.patientService.getById(userId).subscribe(p => {
      this.userName = p.firstName + " " + p.lastName;
    });
  }

}