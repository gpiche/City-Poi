/**
 * Created by Guillaume on 2017-05-01.
 */
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import {City} from '../../Shared/City';
import {PointOfInterest} from '../../Shared/PointOfInterest';

@Injectable()
export class CitySearchService {

  constructor(private http: Http) {
  }

  search(term: string): Observable<City[]> {
    return this.http.get(`http://localhost:50467/api/cities?name=${term}`)
        .map(res => res.json() as City[]) // <--------- Map the json I had forgot
  }

  getPoiForACity(id: number): Observable<PointOfInterest[]>{
    return this.http.get(`http://localhost:50467/api/cities/${id}/pointsOfInterest`)
      .map(res => res.json() as PointOfInterest[]);
}
}
