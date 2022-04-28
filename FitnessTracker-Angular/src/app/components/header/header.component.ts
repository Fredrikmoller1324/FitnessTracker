import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit{
  isAuthenticated = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.token.subscribe(token=>{
      console.log(token);
      console.log('in header')
      if(token){
        this.isAuthenticated = true;
      } console.log(this.isAuthenticated)
    })
  }
  onLogout() {
    this.authService.logout();
  }

}
