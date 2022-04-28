import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './user.model';
import { catchError, tap } from 'rxjs/operators';
import { throwError, BehaviorSubject } from 'rxjs';
import jwtDecode from 'jwt-decode';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

export interface AuthResponseData {
  token: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {

  constructor(private http: HttpClient, private fb: FormBuilder) {}
    readonly BaseURL ='https://localhost:7146/api'

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  comparePasswords(fb: FormGroup) {
    let confirmPasswordControl = fb.get('ConfirmPassword');
    if (confirmPasswordControl?.errors == null || 'passwordMismatch' in confirmPasswordControl?.errors) {
      if (fb.get('Password')?.value != confirmPasswordControl?.value)
        confirmPasswordControl?.setErrors({ passwordMismatch: true });
      else
        confirmPasswordControl?.setErrors(null);
    }
  }

  signup() {
    var body = {
      UserName: this.formModel.value.UserName,
      FirstName: this.formModel.value.FirstName,
      LastName: this.formModel.value.LastName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURL + '/Auth/Register', body);
  }

  login(formData: any) {
    return this.http.post(this.BaseURL + '/Auth/Login', formData,{responseType:'text'})
  }





}
