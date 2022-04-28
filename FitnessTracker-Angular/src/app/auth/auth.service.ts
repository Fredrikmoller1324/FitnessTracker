import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthService {
  constructor(
    private http: HttpClient,
    private fb: FormBuilder,
    private router: Router
  ) {}

  token = new BehaviorSubject<string>(null);
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
    return this.http.post(this.BaseURL + '/Auth/Login', formData, {
      responseType: 'text',
    })
    .pipe(
      tap(res=>{
        this.token.next(res);
      })
    )
  }

  logout() {
    this.router.navigate(['/login']);
    localStorage.removeItem('token');
  }
}
