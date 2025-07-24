import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ManagerNavigationComponent } from "../manager-navigation/manager-navigation.component";
import { DrawerModule } from 'primeng/drawer';


@Component({
  selector: 'app-manager',
  imports: [RouterOutlet, DrawerModule, ManagerNavigationComponent],
  templateUrl: './manager.component.html',
  styleUrl: './manager.component.scss'
})
export class ManagerComponent {

}
