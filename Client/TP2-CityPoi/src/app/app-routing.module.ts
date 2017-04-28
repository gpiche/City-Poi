/**
 * Created by Guillaume on 2017-04-28.
 */
import {MapComponent} from './CityPoi/map/map.component';
import {AuthenticationGuard} from './authentification/guard.service';
import {RouterModule, Routes} from '@angular/router';
import {UnauthorizedComponent} from './unauthorized/unauthorized.component';
import {NgModule} from '@angular/core';

export const routes: Routes = [
  { path: 'map', component: MapComponent, canActivate: [AuthenticationGuard] },
  { path: 'unauthorized', component: UnauthorizedComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
