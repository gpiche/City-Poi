import {Component, Input, OnInit} from '@angular/core';
import {PointOfInterest} from '../../Shared/PointOfInterest';
import {Observable} from "rxjs";

@Component({
  selector: 'app-point-of-interests',
  templateUrl: './point-of-interests.component.html',
  styleUrls: ['./point-of-interests.component.css']
})
export class PointOfInterestsComponent implements OnInit {

  @Input()
  pointOfInterests: Observable<PointOfInterest[]>;

  constructor() { }

  ngOnInit() {
  }

}
