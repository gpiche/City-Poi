import {ActivatedRoute, ActivatedRouteSnapshot, UrlSegment, Params, Data, Route, ParamMap, } from '@angular/router';
import {Observable} from 'rxjs';
import {Type} from '@angular/core';

export class MockActivatedRoute implements ActivatedRoute {
  url: Observable<UrlSegment[]>;
  params: Observable<Params>;
  queryParams: Observable<Params>;
  fragment: Observable<string>;
  data: Observable<Data>;
  outlet: string;
  component: Type<any>|string;
  snapshot: ActivatedRouteSnapshot;
  routeConfig: Route;
  root: ActivatedRoute;
  parent: ActivatedRoute;
  firstChild: ActivatedRoute;
  children: ActivatedRoute[];
  pathFromRoot: ActivatedRoute[];
  paramMap: Observable<ParamMap>;
  queryParamMap: Observable<ParamMap>;


};
