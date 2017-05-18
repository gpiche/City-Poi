import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import {fakeAsync, tick} from '@angular/core/testing';

import { DashboardComponent } from './dashboard.component';
import {PointOfInterest} from '../Shared/PointOfInterest';
import {City} from '../Shared/City';

describe('DashboardComponent', () => {
  let dashBoardComp: DashboardComponent;
  let poi: PointOfInterest[];
  let cities: City[];

  beforeEach(async(() => {
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
    dashBoardComp = new DashboardComponent();
  }));

  describe('handleCity()', () => {
    it('should save city name in proprety name of dashboardcomp', fakeAsync(() => {
      dashBoardComp.handleCity(cities[1]);

      expect(dashBoardComp.name).toEqual(cities[1].name);

    }));
    it('should save city country in proprety country of dashboardcomp', fakeAsync(() => {
      dashBoardComp.handleCity(cities[1]);

      expect(dashBoardComp.country).toEqual(cities[1].country);

    }));
  });

  describe('changeMarkerColor()', () => {
    it('should save received poi in selectedPoi proprety', fakeAsync(() => {
      dashBoardComp.changeMarkerColor(poi[1]);

      expect(dashBoardComp.selectedPoi).toEqual(poi[1]);

    }));
  });

  describe('showInfoWindow()', () => {
    it('should save received poi in clickedPoi proprety', fakeAsync(() => {
      dashBoardComp.showInfoWindow(poi[1]);

      expect(dashBoardComp.clickedPoi).toEqual(poi[1]);

    }));
  });

});

