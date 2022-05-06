import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss'],
})
export class ChangePasswordComponent implements OnInit {
  formModel = {
    currentPassword: '',
    newPassword: '',
    confirmNewPassword: '',
  };

  successSent:boolean = false;
  successMessage: string = '';
  isLoading: boolean = false;
  error: string = null;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {}

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }
    this.error = null;

    let authObs: Observable<string>;

    this.isLoading = true;

    authObs = this.authService.changePassword(form.value);

    authObs.subscribe(
      (res) => {
        console.log(res);
        this.successMessage = res;
        this.isLoading = false;
        this.error = null;
        this.successSent = true;
      },
      (err) => {
        console.log(err.error);
        this.error = err.error;
        this.isLoading = false;
        this.successSent = false;
      }
    );

    form.reset();
  }
}
