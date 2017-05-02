/**
 * Created by Guillaume on 2017-04-28.
 */
import {MapComponent} from './CityPoi/map/map.component';
import {AuthenticationGuard} from './authentification/guard.service';
import {RouterModule, Routes} from '@angular/router';
import {UnauthorizedComponent} from './unauthorized/unauthorized.component';
import {NgModule} from '@angular/core';
import {LoginComponent} from './login/login.component';
import {AdminComponent} from './admin/admin.component';

export const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: '', component: MapComponent},
  {path: 'admin', component: AdminComponent, canActivate: [AuthenticationGuard] },
  { path: 'unauthorized', component: UnauthorizedComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
