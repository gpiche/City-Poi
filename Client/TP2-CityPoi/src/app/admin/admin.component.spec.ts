import { AdminComponent } from './admin.component';
import {MockActivatedRoute} from "../Testing/MockActivatedRoute";
import {MockViewContainerRef} from "../Testing/MockViewContainerRef";
import {CitySearchService} from '../CityPoi/city-search/city-search.service';
import {ModalService} from '../Shared/modal.service';
import {ToastrService} from '../Shared/toastr.service';
import {AdminService} from './admin.service';
import {fakeAsync, tick} from "@angular/core/testing";
import {PointOfInterest} from '../Shared/PointOfInterest';
import {City} from '../Shared/City';
import { Headers, Http } from '@angular/http';
import {RequestOptions, Request, RequestMethod} from '@angular/http';
import { NguiMapModule} from '@ngui/map';
import {Body} from "@angular/http/src/body";

// Tests admin.component.ts
describe('AdminComponent', () => {
  let adminComponent: AdminComponent;
  let mockAuthentificationService;
  let mockActivatedRoute;
  let mockAdminService;
  let mockCitySearchService;
  let mockModalService;
  let mockToastrService;
  let mockViewContainerRef;
  let poi: PointOfInterest[];
  let cities: City[];

  beforeEach(() => {
    mockAuthentificationService = jasmine.createSpyObj('AuthentificationService', ['login', 'logout']);
    mockActivatedRoute = new MockActivatedRoute();
    mockAdminService = jasmine.createSpyObj('AdminService', ['onLogoutClick', 'onSelectCity', 'onSelectPoi', 'delete']);
    mockCitySearchService = jasmine.createSpyObj('CitySearchService', ['getCities', 'getPoiForACity'])
    mockModalService = jasmine.createSpyObj('ModalService', ['confirm', 'setOverlayToViewContainer']);
    mockToastrService = jasmine.createSpyObj('ToastrService', ['success', 'info', 'warning', 'error']);
    mockViewContainerRef = new MockViewContainerRef();
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
    adminComponent = new AdminComponent(
      mockAuthentificationService,
      mockActivatedRoute,
      mockCitySearchService,
      mockAdminService,
      mockModalService,
      mockToastrService,
      mockViewContainerRef
    );
  });

  describe('ngOnInit()', () => {
    it('should set selectedCity to cities[1]', fakeAsync(() => {
      //Arrange
      mockModalService.confirm.and.returnValue(Promise.resolve());
      mockAdminService.delete.and.returnValue(Promise.resolve());
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));

      //Action
      adminComponent.ngOnInit()
      tick();
      //Assert
      expect(adminComponent.cities).toEqual(cities);

    }));
  });

  describe('onSelectCity()', () => {
    it('should set selectedCity to cities[1]', fakeAsync(() => {
      //Arrange
      mockModalService.confirm.and.returnValue(Promise.resolve());
      mockAdminService.delete.and.returnValue(Promise.resolve());
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));

      //Action
      adminComponent.onSelectCity(cities[1]);
      tick();
      //Assert
      expect(adminComponent.selectedCity).toEqual(cities[1]);

    }));
  });

  describe('onSelectPoi()', () => {
    it('should set selectedPoi to poi[1]', fakeAsync(() => {
      //Arrange
      mockModalService.confirm.and.returnValue(Promise.resolve());
      mockAdminService.delete.and.returnValue(Promise.resolve());
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));

      //Action
      adminComponent.onSelectPoi(poi[1]);
      tick();
      //Assert
      expect(adminComponent.selectedPoi).toEqual(poi[1]);

    }));
  });

  describe('onLogoutClick()', () => {
    it('should set selectedPoi to poi[1]', fakeAsync(() => {
      //Arrange
      mockModalService.confirm.and.returnValue(Promise.resolve());
      mockAdminService.delete.and.returnValue(Promise.resolve());
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));

      //Action
      adminComponent.onLogoutClick();
      tick();
      //Assert
      expect(mockAuthentificationService.onLogoutClick).toHaveBeenCalled();

    }));
  });

  describe('openModal() ', () => {
    it('should delete city on confirmation', fakeAsync(() => {
      //Arrange
      mockModalService.confirm.and.returnValue(Promise.resolve());
      mockAdminService.delete.and.returnValue(Promise.resolve());
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));
      const messageModal = 'Voulez-vous supprimer ce point?';
      adminComponent.onSelectCity(cities[1]);
      adminComponent.onSelectPoi(poi[1]);
      let poiii = new PointOfInterest();

      //Action
      adminComponent.openModal(messageModal);

      tick();
      //Assert
      expect(mockAdminService.delete).toHaveBeenCalled();

    }));
  });

  describe('getPoiForACity() ', () => {
    it('should set poi when click on a poi', fakeAsync(() => {
      //Arrange
      mockModalService.confirm.and.returnValue(Promise.resolve());
      mockAdminService.delete.and.returnValue(Promise.resolve());
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));

      //Action
      adminComponent.getPoiForACity(cities[1].key);

      tick();
      //Assert
      expect(mockCitySearchService.getPoiForACity).toHaveBeenCalledWith(cities[1].key);

    }));
  });
  describe('delete() ', () => {
    it('should set poi when click on a poi', fakeAsync(() => {
      //Arrange
      mockModalService.confirm.and.returnValue(Promise.resolve());
      mockAdminService.delete.and.returnValue(Promise.resolve());
      mockCitySearchService.getCities.and.returnValue(Promise.resolve(cities));

      //Action
      adminComponent.delete(cities[1].key, poi[1].id);

      tick();
      //Assert
      expect(mockCitySearchService.delete).toHaveBeenCalled();

    }));
  });

});

describe('AdminService', () => {
  let adminService: AdminService;
  let mockHttp;


  beforeEach(() => {

    mockHttp = jasmine.createSpyObj('Http', ['delete']);
    adminService = new AdminService(
      mockHttp
    );
  });

  describe('delete()', () => {
    it('should call http.delete()', fakeAsync(() => {
      // Arrange
      const fakeHeader = new Headers({'Content-Type': 'application/json'});
      let fakePoi = {id: 1, name: 'any', latitude: 'any', longitude: 'any', descritption: 'any', fullDescription: 'any',
          logo: 'any', picture: 'any'}
      const fakeCityId = 1;
      // Action
      adminService.delete(fakeCityId, fakePoi.id, fakePoi);
      tick();
      // Assert
      expect(mockHttp.then).toEqual(Promise.resolve());

    }));
  });

});







