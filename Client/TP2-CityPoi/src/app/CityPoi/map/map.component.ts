import {Component, EventEmitter, Input, OnChanges, OnInit, Output} from '@angular/core';
import {City} from '../../Shared/City';
import LatLng = google.maps.LatLng;
import Geocoder = google.maps.Geocoder;
import {PointOfInterest} from "../../Shared/PointOfInterest";
import InfoWindow = google.maps.InfoWindow;


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
  @Input()
    clickedPoi: PointOfInterest;
  map;
  coordinate: LatLng[] = [];
  redMarker = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png';
  blueMarker = 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png';


  onMapReady(map){
    console.log('map', map);
    this.map = map;
  }

  ngOnInit() {

  }

  ngOnChanges(change){
    this.changeMarkerColor(this.selectedPoi);
    if(this.clickedPoi !== null && typeof this.clickedPoi !== 'undefined') {
      this.infoWindow(this.clickedPoi);
    }
  }

  infoWindow(poi: PointOfInterest){

    var contentString = '<div id="content">' +
      '<div id="siteNotice">' +
        '<div' +
      '</div>' + '<img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDvxGceA1mrFKBFrr9vboIlQxgrwK3QOgn01omSp9MaC_Oixdd" alt="some_text" style="width:100px;height:100px;">' +
      '<h3 >' + poi.name + '</h3>' +
      '</div>' +
      '<div id="bodyContent">' +
      poi.descritption +
      '</div>' +
        '<button class="bg-primary">Voir les détails</button>' +
      '</div>';
    const infoWindow = new InfoWindow()
    const position = new LatLng(parseFloat(poi.latitude), parseFloat(poi.longitude));
    infoWindow.setPosition(position);
    infoWindow.setContent(contentString);
    infoWindow.open(this.map);
    this.clickedPoi = null;
  }

  changeMarkerColor(poi: PointOfInterest){
    this.selectedPoi = poi;
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
}
