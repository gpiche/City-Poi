import {Component, Input, OnInit} from '@angular/core';
import {PointOfInterest} from '../Shared/PointOfInterest';
import {Observable} from "rxjs";
import {City} from '../Shared/City';
import LatLng = google.maps.LatLng;


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
pointOfInterest: Observable<PointOfInterest[]>;
listOfPoi: PointOfInterest[] = [];
name: string;
country: string;
selectedPoi: PointOfInterest;
clickedPoi: PointOfInterest;

  constructor() { }

  handlePointOfInterest(pointOfInterest: Observable<PointOfInterest[]>) {
    this.pointOfInterest = pointOfInterest;
    this.initialisePosition();
  }

  handleCity(city: City) {
    this.name = city.name;
    this.country = city.country;
  }

  handleHiddenMarkers(positions: LatLng[]) {

      const newList = [];
      for (const coord of positions){
        for (const poi of this.listOfPoi){
          if ( parseFloat(poi.latitude) === coord.lat() && parseFloat(poi.longitude) === coord.lng()) {
                newList.push(poi);
          }
        }
       }
        this.pointOfInterest = this.pointOfInterest
          .map(data => data = newList);
      }




  changeMarkerColor(poi: PointOfInterest){
    this.selectedPoi = poi;
  }

  showInfoWindow(poi: PointOfInterest){
    this.clickedPoi = poi;
  }


  initialisePosition(){
    this.listOfPoi = [];
   this.pointOfInterest
     .subscribe((data) => {
     for (const poi of data){
       this.listOfPoi.push(poi);
     }
     });
  }

  ngOnInit() {

  }

}
