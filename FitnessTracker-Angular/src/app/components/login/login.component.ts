import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
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
  };

  constructor(private service: AuthService, private router: Router) {}

  ngOnInit(): void {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/home');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: string) => {
        localStorage.setItem('token', res);
        this.router.navigateByUrl('/home');
      },
      (err) => {
        console.log(err.error);
      }
    );
  }
}
