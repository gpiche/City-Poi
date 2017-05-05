import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  title = 'MAP WORKS!';
  @Input()
  positions = [];
  redMarker = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png';
  blueMarker = 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png';


  ngOnInit() {

  }

  onSelect(event) {
    event.target.setIcon(this.blueMarker);
  }

  unSelect(event) {
    event.target.setIcon(this.redMarker);
  }



}
