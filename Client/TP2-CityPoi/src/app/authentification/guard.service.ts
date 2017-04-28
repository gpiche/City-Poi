/**
 * Created by Guillaume on 2017-04-28.
 */

import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CanActivate } from '@angular/router';
import { AuthenticationService } from './authentification.service';

@Injectable()
export class AuthenticationGuard implements CanActivate {

  constructor(private authService: AuthenticationService, private router: Router) {}

  //Voir app-routing.module pour le CanActivate
  canActivate() {
    if(this.authService.loggedIn()) {
      return true;
    }
    else {
      this.router.navigateByUrl('/unauthorized');
      return false;
    }
  }
}
