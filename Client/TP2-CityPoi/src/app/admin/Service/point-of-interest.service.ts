import {Http} from "@angular/http";
import {PointOfInterest} from "../../Shared/PointOfInterest";
import {Injectable} from "@angular/core";
/**
 * Created by Guillaume on 2017-05-08.
 */
@Injectable()
export class PointOfInterestService {

  constructor(private http: Http) {}

  getPoiForACity(id: number): PointOfInterest[] {
    let poiList: PointOfInterest[] = [];
   this.http.get(`http://localhost:50467/api/cities/${id}/pointsOfInterest`)
   return poiList;
  }

}
