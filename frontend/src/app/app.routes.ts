import { Routes } from '@angular/router';
import { LoginComponent } from './components/user/profile&login/login/login.component';
import { MyAppointmentsComponent } from './components/user/appointments/my-appointments/my-appointments.component';
import { OurTeamComponent } from './components/user/information/our-team/our-team.component';
import { VisionComponent } from './components/user/information/vision/vision.component';
import { HomeComponent } from './components/user/information/home/home.component';
import { ShowAllPatientsComponent } from './components/manager/show-all-patients/show-all-patients.component';
import { AddAppointmentComponent } from './components/user/appointmentBooking/add-appointment/add-appointment.component';
import { ShowAllAppointmentsComponent } from './components/manager/show-all-appointments/show-all-appointments.component';
import { ManagerComponent } from './components/manager/manager/manager.component';
import { ShowAllDoctorsComponent } from './components/manager/show-all-doctors/show-all-doctors.component';
import { DoctorListComponent } from './components/user/doctors/doctor-list/doctor-list.component';
import { EditProfileComponent } from './components/user/profile&login/edit-profile/edit-profile.component';
import { RegisterComponent } from './components/user/profile&login/register/register.component';
import { ProfileComponent } from './components/user/profile&login/profile/profile.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'ourTeam', component: OurTeamComponent },
    { path: 'vision', component: VisionComponent },
    { path: 'allDoctors', component: DoctorListComponent },
    {
        path: 'manager', component: ManagerComponent, children: [
            { path: 'showAllPatients', component: ShowAllPatientsComponent },
            { path: 'showAllAppointments', component: ShowAllAppointmentsComponent },
            { path: 'ShowAllDoctors', component: ShowAllDoctorsComponent }

        ]
    },


    { path: 'profile', component: ProfileComponent },
    { path: 'profile/edit', component: EditProfileComponent },
    { path: 'myAppointments', component: MyAppointmentsComponent },
    { path: 'addAppointment', component: AddAppointmentComponent },



];
