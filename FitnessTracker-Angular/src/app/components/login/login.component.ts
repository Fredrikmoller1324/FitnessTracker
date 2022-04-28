import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { Observable } from 'rxjs/internal/Observable';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  formModel = {
    UserName: '',
    Password: '',
    FirstName: '',
    LastName: '',
  };

  isLoginMode = true;
  isLoading = false;
  error: string = null;

  constructor(private service: AuthService, private router: Router) {}

  onSwitchMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  ngOnInit(): void {
    // if (localStorage.getItem('token') != null)
    //   this.router.navigateByUrl('/home');
  }

  OnForgotPassword() {
    console.log('hej');
  }

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }
    this.error = null;

    let authObs: Observable<string>;

    this.isLoading = true;

    if (this.isLoginMode) {
      authObs = this.service.login(form.value);
    } else {
      console.log('register?');
      // authObs = this.service.register(form.value).subscribe(
      //   (res: string) =>{
      //     localStorage.setItem('token',res);
      //     this.router.navigateByUrl('/home')
      //   }
      // )
    }

    authObs.subscribe(
      (res: string) => {
        localStorage.setItem('token', res);
        this.isLoading = false;
        this.router.navigateByUrl('/home');
      },
      (err) => {
        console.log(err.error);
        this.error = err.error;
        this.isLoading = false;
      }
    );

    form.reset();
  }
}
