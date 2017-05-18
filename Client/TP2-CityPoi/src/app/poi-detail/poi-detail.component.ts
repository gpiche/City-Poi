import {Component, EventEmitter, Input, OnChanges, OnInit, Output} from '@angular/core';
import {PointOfInterest} from '../Shared/PointOfInterest';

@Component({
  selector: 'app-poi-detail',
  templateUrl: './poi-detail.component.html',
  styleUrls: ['./poi-detail.component.css']
})
export class PoiDetailComponent implements OnInit {

  @Input()
  selectedPoi: PointOfInterest;

  constructor() { }

  ngOnInit() {
  }

}
