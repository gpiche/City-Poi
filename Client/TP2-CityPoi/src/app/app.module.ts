import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NguiMapModule} from '@ngui/map';
import { MapComponent } from './CityPoi/map/map.component';
import { CitySearchComponent } from './CityPoi/city-search/city-search.component';
import { PointOfInterestsComponent } from './CityPoi/point-of-interests/point-of-interests.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import {AppRoutingModule} from './app-routing.module';
import {AuthenticationService} from './authentification/authentification.service';
import {AuthenticationGuard} from './authentification/guard.service';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MapComponent,
    CitySearchComponent,
    PointOfInterestsComponent,
    UnauthorizedComponent,
    AdminComponent,
    DashboardComponent,

  ],
  imports: [
    NguiMapModule.forRoot({apiUrl: 'https://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyD5W8EzEuPsvvitGICxg0NvQ8TUHdNp4To'}),
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthenticationService,
    AuthenticationGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
