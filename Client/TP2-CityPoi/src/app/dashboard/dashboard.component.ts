import {Component, Input, OnInit} from '@angular/core';
import {PointOfInterest} from '../Shared/PointOfInterest';
import {Observable} from "rxjs";
import {City} from '../Shared/City';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
pointOfInterest: Observable<PointOfInterest[]>;

position = [];
  constructor() { }

  handlePointOfInterest(pointOfInterest: Observable<PointOfInterest[]>) {
    this.pointOfInterest = pointOfInterest;
    this.initialisePosition();
  }


  initialisePosition(){
    this.position = [];
   this.pointOfInterest
     .subscribe((data) => {
     for (const poi of data){
       this.position.push([poi.latitude, poi.longitude]);
     }
     });
  }

  ngOnInit() {

  }

}
