import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MAP WORKS!';
  positions = [];


  onMapReady(map) {
    console.log('map', map);
    console.log('markers', map.markers);  // to get all markers as an array
  }
  onIdle(event){
    console.log('map', event.target);
  }
  onMarkerInit(marker){
    console.log('marker', marker);
  }
  onMapClick(event){
    this.positions.push(event.latLng);
    event.target.panTo(event.latLng);
  }

}
