import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../../services/login.service';
import { ButtonModule } from 'primeng/button';
import { AvatarModule } from 'primeng/avatar';
import { MenuModule } from 'primeng/menu';
import { MenubarModule } from 'primeng/menubar';
import { NavComponent } from '../nav/nav.component';
import { MenuItem } from 'primeng/api';
import { NgIf } from '@angular/common';
import { Subscription } from 'rxjs';
import { PatientService } from '../../../services/patient.service';

@Component({
  selector: 'app-header',
  imports: [ButtonModule, AvatarModule, MenuModule, MenubarModule, NavComponent, NgIf],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit, OnDestroy {
  profileMenuItems: MenuItem[] = [];
  subscriptions: Subscription[] = [];
  UserName: string = '';

  constructor(public loginService: LoginService, private router: Router, private patientService: PatientService) { }

  ngOnInit() {
    this.setProfileMenu();
    this.UserName = this.loginService.getCurrentUser().name;
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
    this.UserName = ""
  }

  get isLoggedIn(): boolean {
    return !!this.loginService.currentUser;
  }

  setProfileMenu() {
    if (this.isLoggedIn) {
      this.profileMenuItems = [
        { label: 'הפרופיל שלי', icon: 'pi pi-user', command: () => this.router.navigate(['/profile']) },
        { separator: true },
        {
          label: 'התנתק', icon: 'pi pi-sign-out', command: () => {
            this.loginService.logout();
            this.router.navigate(['/']);
            this.setProfileMenu();
          }
        }
      ];
    } else {
      this.profileMenuItems = [
        { label: 'התחברות', icon: 'pi pi-sign-in', command: () => this.router.navigate(['/login']) },
        { label: 'הרשמה', icon: 'pi pi-user-plus', command: () => this.router.navigate(['/register']) }
      ];
    }
  }

  onProfileMenuShow() {
    this.setProfileMenu();
  }
}