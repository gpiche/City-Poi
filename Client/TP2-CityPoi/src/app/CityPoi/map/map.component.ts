import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  title = 'MAP WORKS!';
  positions = [];

  constructor() { }

  ngOnInit() {
  }
  showRandomMarkers() {
    let randomLat: number, randomLng: number;
    this.positions = [];
    for (let i = 0 ; i < 9; i++) {
      randomLat = Math.random() * 0.0099 + 43.7250;
      randomLng = Math.random() * 0.0099 + -79.7699;
      this.positions.push([randomLat, randomLng]);
    }
  }
  addMarker() {
    let randomLat = Math.random() * 0.0099 + 43.7250;
    let randomLng = Math.random() * 0.0099 + -79.7699;
    this.positions.push([randomLat, randomLng]);
  }
}
