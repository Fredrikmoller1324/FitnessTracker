import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { AuthResponseData, AuthService } from 'src/app/auth/auth.service';
import { ForgotPasswordModal } from 'src/app/components/login/modal/forgotpasswordmodal.component';
import {
  NgbModal,
  ModalDismissReasons,
  NgbModalOptions,
} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  modalOptions: NgbModalOptions;

  formModel = {
    UserName: '',
    Password: '',
    FirstName: '',
    LastName: '',
  };

  isLoginMode = true;
  isLoading = false;
  error: string = null;

  constructor(
    private modalService: NgbModal,
    private authService: AuthService,
    private router: Router
  ) {
    this.modalOptions = {
      backdrop: 'static',
      backdropClass: 'customBackdrop',
    };
  }

  onSwitchMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  ngOnInit(): void {
    // if (localStorage.getItem('token') != null)
    //   this.router.navigateByUrl('/home');
  }

  OnForgotPassword() {
    const modalRef = this.modalService.open(ForgotPasswordModal, { size: 'md',centered:true });
    modalRef.componentInstance.my_modal_title = 'Forgot password';
    modalRef.componentInstance.content = 'Enter you email:'; 
  }

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }
    this.error = null;

    let authObs: Observable<AuthResponseData>;

    this.isLoading = true;

    if (this.isLoginMode) {
      authObs = this.authService.login(form.value);
    } else {
      authObs = this.authService.signup(form.value);
    }

    authObs.subscribe(
      (res: AuthResponseData) => {
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
