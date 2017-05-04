import { Component, OnInit } from '@angular/core';
import {MapComponent} from "../CityPoi/map/map.component";
import {CitySearchComponent} from "../CityPoi/city-search/city-search.component";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
map : MapComponent

  constructor() { }

  ngOnInit() {

  }

}
