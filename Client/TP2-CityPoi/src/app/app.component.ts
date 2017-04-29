import { Component } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import {Router} from '@angular/router';
import {AuthenticationService} from './authentification/authentification.service';

interface Credentials {
  username: string,
  password: string
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

   cities = 'Failed';


  constructor(private http: Http) {}

    getCities() {
    const url = 'http://localhost:50467/api/cities';

    this.http.get(url)
      .subscribe(
        data => this.cities = 'Succes',
        error => console.log(error)
      );
  }



}


