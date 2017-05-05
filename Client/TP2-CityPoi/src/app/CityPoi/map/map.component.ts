import {Component, Input, OnInit} from '@angular/core';
import {City} from '../../Shared/City';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  title = 'MAP WORKS!';
  @Input()
  positions = [];
  @Input()
    name: string;
  @Input()
    country: string;
  redMarker = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png';
  blueMarker = 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png';


  ngOnInit() {

  }

  onMarkerInit(event){
    let map = event.map;
    if (this.name != null && this.country != null) {
      map.setCenter(this.positions[0]);
    }
  }

  onSelect(event) {
    event.target.setIcon(this.blueMarker);
  }

  unSelect(event) {
    event.target.setIcon(this.redMarker);
  }



}
