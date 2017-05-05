/**
 * Created by Remikya Hellal on 2017-05-05.
 */
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';

import {City} from '../Shared/City';
import {PointOfInterest} from '../Shared/PointOfInterest';

@Injectable()
export class AdminService {

  constructor(private http: Http) {
  }

  getCities(): Observable<City[]> {
    return this.http
      .get(`http://localhost:50467/api/cities}`)
      .map(response => response.json().data as City[]);
  }
}
