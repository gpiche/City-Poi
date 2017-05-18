import {MockActivatedRoute} from '../../Testing/MockActivatedRoute';
import {CitySearchService} from './city-search.service';
import {fakeAsync, tick} from '@angular/core/testing';
import {PointOfInterest} from '../../Shared/PointOfInterest';
import {City} from '../../Shared/City';
import {CitySearchComponent} from './city-search.component';
import 'rxjs/add/observable/of';
import { Observable } from 'rxjs/Observable';
import {Subject} from "rxjs";

describe('CitySearchService', () => {
  let citySearchComponent: CitySearchComponent;
  let mockActivatedRoute;
  let mockCitySearchService;
  let poi: PointOfInterest[];
  let cities: City[];

  beforeEach(() => {
    mockActivatedRoute = new MockActivatedRoute();
    mockCitySearchService = jasmine.createSpyObj('CitySearchService', ['getCities', 'getPoiForACity']);

    poi = [
      {id: 1, name: 'any', latitude: 'any', longitude: 'any', descritption: 'any', fullDescription: 'any', logo: 'any', picture: 'any'},
      {id: 2, name: 'any', latitude: 'any', longitude: 'any', descritption: 'any', fullDescription: 'any', logo: 'any', picture: 'any'},
      {id: 3, name: 'any', latitude: 'any', longitude: 'any', descritption: 'any', fullDescription: 'any', logo: 'any', picture: 'any'},
    ];
    cities = [
      {key: 11, name: 'Paris', country: 'France', description: 'description', pointOfInterest: poi},
      {key: 12, name: 'NewYork', country: 'States', description: 'description', pointOfInterest: poi},
      {key: 13, name: 'Quebec', country: 'Canada', description: 'description', pointOfInterest: poi},
    ];
    citySearchComponent = new CitySearchComponent(
      mockCitySearchService,
      mockActivatedRoute

    );
  });
  describe('search()', () => {
    it('search should set selectedCity to null', fakeAsync(() => {
      // Arrange
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));
      const termSearch = 'a term';
      // Action
      citySearchComponent.search(termSearch);
      tick();
      // Assert
      expect(citySearchComponent.selectedCity).toEqual(null);

    }));
  });


  describe('ngOnInit()', () => {
    it('should call search()on citySearchService', fakeAsync(() => {
      // Arrange
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));
      let mocksearchTermsSubject = jasmine.createSpyObj('Subject', ['next', 'asObservable']);
      //Je n'ai pas réussi à tester avec le mock de searchTerms..

      // Action
      citySearchComponent.ngOnInit();
      tick();
      // Assert
      expect(mockCitySearchService.search).toHaveBeenCalledWith(mocksearchTermsSubject.name);

    }));
  });

  describe('getPoiForACity() ', () => {
    it('should set selectedCity to cities[1]', fakeAsync(() => {
      // Arrange
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));
      // Action
      citySearchComponent.getPoiForACity(cities[1]);
      tick();
      // Assert
      expect(citySearchComponent.selectedCity).toEqual(cities[1]);

    }));
  });

  describe('getPoiForACity() ', () => {
    it('getPoiForCity of citySearchService Should be called', fakeAsync(() => {
      // Arrange
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));
      // Action
      citySearchComponent.getPoiForACity(cities[1]);
      tick();
      // Assert
      expect(mockCitySearchService.getPoiForACity).toHaveBeenCalledWith(cities[1].key);

    }));
  });

});
