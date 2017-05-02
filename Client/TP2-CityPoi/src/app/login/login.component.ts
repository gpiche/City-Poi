import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from "../authentification/authentification.service";
import {Router} from "@angular/router";
import {NgForm} from "@angular/forms";


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

  onLoginClick(form: NgForm) {
    const credentials: Credentials = {
      username : form.value.username,
      password : form.value.password
    };
    this.authentificationService.login(credentials)
     .then(response => this.goToAdmin(),
           error => console.log(error));

  }

  goToAdmin() {
    this.router.navigate(['admin']);
  }

  goBack(){
    this.router.navigate(['']);
  }


  ngOnInit() {
  }

}
