/**
 * Created by Guillaume on 2017-05-01.
 */
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import {City} from '../../Shared/City';

@Injectable()
export class CitySearchService {

  constructor(private http: Http) {
  }

  search(term: string): Promise<City[]> {
    return new Promise((resolve, reject) => {
      this.http.get(`http://localhost:50467/api/cities?name=${term}`)
        .map(res => res.json() as City[]) // <--------- Map the json I had forgot
        .subscribe((results: City[]) => {
          resolve(results);
        }, (errorResponse: Response) => {
          reject(errorResponse);
        });
    });

  }
}
