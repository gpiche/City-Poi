import { Component, OnInit } from '@angular/core';

import { Http } from '@angular/http';
import {AuthenticationService} from '../authentification/authentification.service';
import {Router} from '@angular/router';
import {City} from '../Shared/City';
import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import {CitySearchService} from '../CityPoi/city-search/city-search.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  providers: [CitySearchService]
})

export class AdminComponent implements OnInit {

  cities: Observable<City[]>;
  constructor(private authentificationService: AuthenticationService,
              private router: Router,
              private citySearchService: CitySearchService)
  {}
  onLogoutClick() {
    this.authentificationService.logout();
    this.goBack();
  }

  goBack() {
    this.router.navigate(['']);
}

  ngOnInit() {
    this.cities = this.citySearchService.getCities();
  }

}
