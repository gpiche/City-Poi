import {Component, OnChanges, OnInit} from '@angular/core';

import { Http } from '@angular/http';
import {AuthenticationService} from '../authentification/authentification.service';
import {Router} from '@angular/router';
import {City} from '../Shared/City';
import {PointOfInterest} from '../Shared/PointOfInterest';
import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import {CitySearchService} from '../CityPoi/city-search/city-search.service';
import {ModalService} from '../Shared/modal.service';
import {ToastrService} from '../Shared/toastr.service';
import {AdminService} from './admin.service';
import {ViewContainerRef} from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  providers: [CitySearchService, ModalService, AdminService, ToastrService]
})

export class AdminComponent implements OnInit, OnChanges {

  cities: Observable<City[]>;
  poi: Observable<PointOfInterest[]>;
  selectedCity: City;
  selectedPoi: PointOfInterest;

  constructor(private authentificationService: AuthenticationService,
              private router: Router,
              private citySearchService: CitySearchService,
              private adminService: AdminService,
              private modalService: ModalService,
              private toastrService: ToastrService,
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
    const timer = Observable.timer(10, 10);
    timer.subscribe(t => {
      this.ngOnChanges(t);
    });
  }

  ngOnChanges(change){}

  onSelectCity(city: City): void {
  this.selectedCity = city;
  }

  onSelectPoi(poi: PointOfInterest): void {
    this.selectedPoi = poi;
  }


  getPoiForACity(id: number) {
    this.poi = this.citySearchService.getPoiForACity(id);
  }
// La page ne recharge pas après la supression
  openModal(message: string) {
    this.modalService.confirm(message, ' Supprimer ')
      .then(() => {
        this.delete(this.selectedCity.key, this.selectedPoi.id)
        this.toastrService.success('Success');
        if (this.selectedCity === this.selectedCity) { this.selectedCity = null; }
      })
      .catch(() => this.toastrService.error('Canceled'));
  }

  delete(cityId: number, poiId: number){
  this.adminService.delete(cityId, poiId, this.selectedPoi);
  }
}




