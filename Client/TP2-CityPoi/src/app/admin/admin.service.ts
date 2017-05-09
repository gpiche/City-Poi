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

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }

  delete(cityId: number, poiId: number): Promise<void> {
    const url = `http://localhost:50467/api/cities/${cityId}/pointsOfInterest/${poiId}`;
    return this.http.delete(url)
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }
}
