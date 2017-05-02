import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from '../authentification/authentification.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(
    private authentificationService: AuthenticationService,
    private router: Router)
  {}

  onLogoutClick() {
    this.authentificationService.logout();
    this.goBack();
  }

  goBack() {
    this.router.navigate(['']);
}

  ngOnInit() {
  }

}
