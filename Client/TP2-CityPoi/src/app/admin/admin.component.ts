import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import {AuthenticationService} from '../authentification/authentification.service';
import {Router} from '@angular/router';
import {City} from '../Shared/City';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private http: Http,
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
    return this.http
      .get(`http://localhost:50467/api/cities}`)
      .map(response => response.json().data as City[]);

  }

}
