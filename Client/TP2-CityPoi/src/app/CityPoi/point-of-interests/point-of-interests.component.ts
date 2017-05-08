import {Component, Input, OnChanges, OnInit} from '@angular/core';
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

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges() {

  }


  }

