import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {City} from '../../Shared/City';
import LatLng = google.maps.LatLng;
import Geocoder = google.maps.Geocoder;

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
  @Output()
  hiddenMarker: EventEmitter<LatLng[]> = new EventEmitter<LatLng[]>();
  coordinate: LatLng[] = [];
  redMarker = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png';
  blueMarker = 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png';


  ngOnInit() {

  }

  onMarkerInit(event){
    let map = event.map;
    let geocoder =  new Geocoder();
    let adress = this.name + ',' + this.country;
    geocoder.geocode( { 'address': adress }, function(results, status) {
      if (status === google.maps.GeocoderStatus.OK) {
        let position = new LatLng(results[0].geometry.location.lat(), results[0].geometry.location.lng());
        map.panTo(position);
      }
    });
  }

  checkBounds(event){
    const map = event.target;
    const markers = map.markers;
    const mapBounds = map.getBounds();

    for (const marker of markers){
      const  markerPosition = marker.getPosition();
      if (!mapBounds.contains(markerPosition)) {
          this.coordinate.push(markerPosition);
      }
    }
    this.hiddenMarker.emit(this.coordinate);
    this.coordinate = [];
  }

  onSelect(event) {
    event.target.setIcon(this.blueMarker);
  }

  unSelect(event) {
    event.target.setIcon(this.redMarker);
  }



}
