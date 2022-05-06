import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from './user.model';

export interface AuthResponseData {
  access_token: string;
  name: string;
  email: string;
  expiresIn: string;
  userId: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  constructor(
    private http: HttpClient,
    private fb: FormBuilder,
    private router: Router
  ) {}

  user = new BehaviorSubject<User>(null);
  private tokenExpirationTimer: any;

  readonly BaseURL = 'https://localhost:7146/api';

  signup(formData: any) {
    console.log('in signup');
    return this.http.post<AuthResponseData>(this.BaseURL + '/Auth/Register', formData)
    .pipe(
      tap((res) => {
        this.handleAuthentication(
          res.name,
          res.email,
          res.userId,
          res.access_token,
          +res.expiresIn
        );
      })
    );
  }

  login(formData: any) {
    return this.http
      .post<AuthResponseData>(this.BaseURL + '/Auth/Login', formData, {})
      .pipe(
        tap((res) => {
          this.handleAuthentication(
            res.name,
            res.email,
            res.userId,
            res.access_token,
            +res.expiresIn
          );
        })
      );
  }

  forgotPassword(formData: any){
    return this.http.post(this.BaseURL + `/Auth/ForgotPassword/${formData.UserName}`,{})
  }

  changePassword(formData: any){
    return this.http.post(this.BaseURL + '/Auth/ChangePassword', formData,{responseType:'text'})
  }

  autoLogin() {
    const userData: {
      email: string;
      id: string;
      name: string;
      _token: string;
      _tokenExperiationDate: string;
    } = JSON.parse(localStorage.getItem('userData'));
    if (!userData) {
      return;
    }
    const loadedUser = new User(
      userData.id,
      userData.email,
      userData.name,
      userData._token,
      new Date(userData._tokenExperiationDate)
    );

    if (loadedUser) {
      this.user.next(loadedUser);
      const expirationDuration =
        new Date(userData._tokenExperiationDate).getTime() -
        new Date().getTime();
      this.autoLogout(expirationDuration);
    }
  }

  logout() {
    this.user.next(null);
    this.router.navigate(['/login']);
    localStorage.removeItem('userData');
  }

  autoLogout(expirationDuration: number) {
    this.tokenExpirationTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration);
  }

  private handleAuthentication(
    name: string,
    email: string,
    userId: string,
    token: string,
    expiresIn: number
  ) {
    console.log('expiresIn', expiresIn);
    const expirationDate = new Date(new Date().getTime() + expiresIn * 1000);
    const user = new User(userId, email, name, token, expirationDate);
    this.user.next(user);
    // multiply by 1000 to convert s to ms
    this.autoLogout(expiresIn * 1000);
    localStorage.setItem('userData', JSON.stringify(user));
  }
}
