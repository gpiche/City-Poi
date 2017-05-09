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
import {AdminService} from './admin.service';
import {ViewContainerRef} from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  providers: [CitySearchService, ModalService, AdminService]
})

export class AdminComponent implements OnInit {

  cities: Observable<City[]>;
  poi: Observable<PointOfInterest[]>;
  resultModalWindow: boolean = false;
  selectedCity: City;
  selectedPoi: PointOfInterest;

  constructor(private authentificationService: AuthenticationService,
              private router: Router,
              private citySearchService: CitySearchService,
              private adminService: AdminService,
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

  onSelectCity(city: City): void {
  this.selectedCity = city;
  }

  onSelectPoi(poi: PointOfInterest): void {
    this.selectedPoi = poi;
  }


  getPoiForACity(id: number) {
    this.poi = this.citySearchService.getPoiForACity(id);
  }

  openModal(message: string) {
    this.modalService.confirm(message, ' Supprimer ')
      /*.then(this.delete(this.selectedCity.key, this.selectedPoi.id))*/
      .then(result => this.delete(this.selectedCity.key, this.selectedPoi.id))
      .catch(result => this.resultModalWindow = false);
  }

  delete(cityId: number, poiId: number){
  this.adminService.delete(cityId, poiId, this.selectedPoi);
  }
}




