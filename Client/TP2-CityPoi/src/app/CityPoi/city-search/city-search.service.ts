/**
 * Created by Guillaume on 2017-05-01.
 */
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { CitySearchComponent } from './city-search.component';
import {City} from '../../Shared/City';

@Injectable()
export class CitySearchService {
  constructor(private http: Http) {}
  search(term: string): Observable<City[]> {
    return this.http
      .get(`app/cities/?name=${term}`)
      .map(response => response.json().data as City[]);
  }
}
