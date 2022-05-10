import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  userFirstname = '';
  userLastname = '';
  userEmail = '';
  constructor() { }

  ngOnInit(): void {
    this.getUserInfo();
  }

  getUserInfo(){
    const userData: {
      email: string;
      name: string;
    } = JSON.parse(localStorage.getItem('userData'));

    this.userEmail = userData.email;

    const FirstAndLastname= userData.name.split(' ');

    this.userFirstname = FirstAndLastname[0];
    this.userLastname = FirstAndLastname[1];
  }

}
