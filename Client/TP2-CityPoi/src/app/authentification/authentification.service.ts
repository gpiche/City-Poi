/**
 * Created by Guillaume on 2017-04-28.
 */

import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from '@angular/http';

import 'rxjs/add/operator/map';
import {tokenNotExpired} from 'angular2-jwt';

@Injectable()
export class AuthenticationService {

  constructor(private http: Http) {
  }

  login(credentials) {
    // Devrait retourner une promise ou un observable pour mieux gérer l'affichage.
    // Devrait être en HTTPS !
    const url = 'http://localhost:50467/api/token';
    const headers = new Headers({'Content-Type': 'application/x-www-form-urlencoded'});
    const options = new RequestOptions({headers: headers});

    const urlSearchParams = new URLSearchParams();
    urlSearchParams.append('username', credentials.username);
    urlSearchParams.append('password', credentials.password);
    const body = urlSearchParams.toString();

    this.http.post(url, body, options)
      .map(res => res.json())
      .subscribe(
        data => localStorage.setItem('token', data.access_token),
        error => console.log(error)
      );
  }

  loggedIn() {
    return tokenNotExpired();
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  getToken(): string {
    const token = localStorage.getItem('token');
    return token ;
  }

}

