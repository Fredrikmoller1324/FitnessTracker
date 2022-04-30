import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy{
  isAuthenticated = false;
  private userSub: Subscription;

  constructor(private authService: AuthService) { }


  ngOnInit(): void {
    this.userSub = this.authService.user.subscribe(user=>{
      console.log('in header')
      this.isAuthenticated = !!user;
      console.log(this.isAuthenticated)
    })
  }
  onLogout() {
    this.authService.logout();
  }

  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }

}
