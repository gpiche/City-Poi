import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from "../authentification/authentification.service";
import {Router} from "@angular/router";


interface Credentials {
  username: string;
  password: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent implements OnInit {

  constructor(
    private authentificationService: AuthenticationService,
    private router: Router,) {
  }

  onLoginClick() {
    const credentials: Credentials = {
      username : "Mickey",
      password : "qwerty"
    };

    // devrait retourner une promise ou un observable pour mieux gérer l'affichage.
    this.authentificationService.login(credentials)
      .then(response => this.goToMap());

  }



  onLogoutClick() {
    this.authentificationService.logout();
    this.goBack();
  }

  goToMap(){
    this.router.navigate(['map']);
  }

  goBack(){
    this.router.navigate(['']);
  }


  ngOnInit() {
  }

}
