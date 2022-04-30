import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from './user.model';

export interface AuthResponseData {
  access_token: string;
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

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group(
      {
        Password: ['', [Validators.required, Validators.minLength(4)]],
        ConfirmPassword: ['', Validators.required],
      },
      { validator: this.comparePasswords }
    ),
  });

  comparePasswords(fb: FormGroup) {
    let confirmPasswordControl = fb.get('ConfirmPassword');
    if (
      confirmPasswordControl?.errors == null ||
      'passwordMismatch' in confirmPasswordControl?.errors
    ) {
      if (fb.get('Password')?.value != confirmPasswordControl?.value)
        confirmPasswordControl?.setErrors({ passwordMismatch: true });
      else confirmPasswordControl?.setErrors(null);
    }
  }

  signup() {
    var body = {
      UserName: this.formModel.value.UserName,
      FirstName: this.formModel.value.FirstName,
      LastName: this.formModel.value.LastName,
      Password: this.formModel.value.Passwords.Password,
    };
    return this.http.post(this.BaseURL + '/Auth/Register', body);
  }

  login(formData: any) {
    return this.http
      .post<AuthResponseData>(this.BaseURL + '/Auth/Login', formData, {})
      .pipe(
        tap((res) => {
          console.log('RETURNEDFROMDB', res);
          this.handleAuthentication(
            res.email,
            res.userId,
            res.access_token,
            +res.expiresIn
          );
        })
      );
  }

  autoLogin() {
    const userData: {
      email: string;
      id: string;
      _token: string;
      _tokenExperiationDate: string;
    } = JSON.parse(localStorage.getItem('userData'));
    console.log('userdata', userData);
    if (!userData) {
      return;
    }
    console.log(
      'expirationdate before loadedUsercheck',
      userData._tokenExperiationDate
    );
    const loadedUser = new User(
      userData.id,
      userData.email,
      userData._token,
      new Date(userData._tokenExperiationDate)
    );
    

    if (loadedUser) {
      console.log(
        'expirationdate in loadedUser',
        userData._tokenExperiationDate
      );
      this.user.next(loadedUser);
      const expirationDuration =
        new Date(userData._tokenExperiationDate).getTime() -
        new Date().getTime();
      this.autoLogout(expirationDuration);
    }
  }

  logout() {
    console.log('calling logout');
    this.user.next(null);
    this.router.navigate(['/login']);
    localStorage.removeItem('userData');
  }

  autoLogout(expirationDuration: number) {
    console.log(this.tokenExpirationTimer)
    this.tokenExpirationTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration);
  }

  private handleAuthentication(
    email: string,
    userId: string,
    token: string,
    expiresIn: number
  ) {
    console.log('expiresIn', expiresIn);
    const expirationDate = new Date(new Date().getTime() + expiresIn * 1000);
    const user = new User(userId, email, token, expirationDate);
    this.user.next(user);
    this.autoLogout(expiresIn * 1000);
    console.log('In handle authentication: ', JSON.stringify(user));
    localStorage.setItem('userData', JSON.stringify(user));
  }
}
