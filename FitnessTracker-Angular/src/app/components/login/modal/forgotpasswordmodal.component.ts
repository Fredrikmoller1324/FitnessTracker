import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { AuthResponseData, AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'forgotpassword-modal',
  templateUrl: './forgotpasswordmodal.html',
  styleUrls: ['./forgotpasswordmodal.scss'],
})
export class ForgotPasswordModal implements OnInit {
  @Input() my_modal_title;
  @Input() content;

  formModel = {
    UserName: '',
  };

  successSent = false;
  isLoading = false;
  error: string = null;

  constructor(
    private authService: AuthService,
    public activeModal: NgbActiveModal
  ) {}

  ngOnInit(): void {}

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }
    this.error = null;

    let authObs: Observable<object>;

    this.isLoading = true;

    authObs = this.authService.forgotPassword(form.value);

    authObs.subscribe(
      (res) => {
        this.isLoading = false;
        this.error = null;
        this.successSent = true;
      },
      (err) => {
        console.log(err.error);
        this.error = err.error;
        this.isLoading = false;
        this.successSent = false;
        console.log('successent', this.successSent);
        console.log('errordisplay', this.error);
      }
    );

    form.reset();
  }
}
