import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginService } from './services/login.service';
import { NavComponent } from "./components/user/nav/nav.component";
import { HeaderComponent } from './components/user/header/header.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  title = 'Appointments';

  constructor(private loginService : LoginService){}
  ngOnInit(): void {
    
  }
}
