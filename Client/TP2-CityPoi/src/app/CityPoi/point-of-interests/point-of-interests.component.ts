import {Component, EventEmitter, Input, OnChanges, OnInit, Output} from '@angular/core';
import {PointOfInterest} from '../../Shared/PointOfInterest';
import {Observable} from "rxjs";
import LatLng = google.maps.LatLng;


@Component({
  selector: 'app-point-of-interests',
  templateUrl: './point-of-interests.component.html',
  styleUrls: ['./point-of-interests.component.css']
})

export class PointOfInterestsComponent implements OnInit, OnChanges {
  @Input()
  pointOfInterests: Observable<PointOfInterest[]>;
  @Output()
  selectedPoiEmitter: EventEmitter<PointOfInterest> = new EventEmitter<PointOfInterest>()
  @Output()
  infoWindow: EventEmitter<PointOfInterest> = new EventEmitter<PointOfInterest>();

  constructor() {
  }

  ngOnInit() {
    const timer = Observable.timer(10, 10);
    timer.subscribe(t => {
      this.ngOnChanges(t);
    });

  }

  ngOnChanges(change) {}

  changeMarkerColor(poi: PointOfInterest) {
    this.selectedPoiEmitter.emit(poi);
  }

  showInfoWindow(poi: PointOfInterest){
    this.infoWindow.emit(poi);
  }



}

