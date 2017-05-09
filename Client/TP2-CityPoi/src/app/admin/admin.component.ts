import { Component, OnInit } from '@angular/core';

import { Http } from '@angular/http';
import {AuthenticationService} from '../authentification/authentification.service';
import {Router} from '@angular/router';
import {City} from '../Shared/City';
import {PointOfInterest} from '../Shared/PointOfInterest';
import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import {CitySearchService} from '../CityPoi/city-search/city-search.service';
import {ModalService} from '../Shared/modal.service';
import {ViewContainerRef} from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  providers: [CitySearchService, ModalService]
})

export class AdminComponent implements OnInit {

  cities: Observable<City[]>;
  poi: Observable<PointOfInterest[]>;
  resultModalWindow: boolean = false;

  constructor(private authentificationService: AuthenticationService,
              private router: Router,
              private citySearchService: CitySearchService,
              private modalService: ModalService,
              private viewContainerRef: ViewContainerRef)
  {modalService.setOverlayToViewContainer(viewContainerRef);}


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

  getPoiForACity(id: number) {
    this.poi = this.citySearchService.getPoiForACity(id);
  }

  openModal(message: string) {
    this.modalService.confirm(message, ' Supprimer ')
      .then(result => this.resultModalWindow = result as boolean)
      .catch(result => this.resultModalWindow = false);
  }
}




