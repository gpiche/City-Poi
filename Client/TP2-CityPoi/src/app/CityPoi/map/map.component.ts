import {Component, EventEmitter, Input, OnChanges, OnInit, Output} from '@angular/core';
import {City} from '../../Shared/City';
import LatLng = google.maps.LatLng;
import Geocoder = google.maps.Geocoder;
import {PointOfInterest} from "../../Shared/PointOfInterest";
import {Observable} from "rxjs";
import {isUndefined} from "util";

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit, OnChanges {
  @Input()
  positions: PointOfInterest[];
  @Input()
    name: string;
  @Input()
    country: string;
  @Input()
  selectedPoi: PointOfInterest;
  @Output()
  hiddenMarker: EventEmitter<LatLng[]> = new EventEmitter<LatLng[]>();
  map;
  coordinate: LatLng[] = [];
  redMarker = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png';
  blueMarker = 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png';


  onMapReady(map){
    console.log('map', map);
    this.map = map;
  }

  ngOnInit() {
    const timer = Observable.timer(10, 10);
    timer.subscribe(t => {
      this.ngOnChanges(t);
    });
  }

  ngOnChanges(change){
    this.changeMarkerColor(this.selectedPoi);
  }


  changeMarkerColor(poi: PointOfInterest){
    this.selectedPoi = poi;
    console.log(this.selectedPoi);
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
      if (mapBounds.contains(markerPosition)) {
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
