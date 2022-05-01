import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import {HttpClientModule} from '@angular/common/http';
import { AuthComponent } from './auth/auth.component';
import { HomeComponent } from './components/home/home.component'
import { LoadingSpinnerComponent } from './Shared/loading-spinner/loading-spinner.component';
import { HeaderComponent } from './components/header/header.component';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ForgotPasswordModal } from './components/login/modal/forgotpasswordmodal.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AuthComponent,
    HomeComponent,
    LoadingSpinnerComponent,
    HeaderComponent,
    ForgotPasswordModal

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule
  ],
  providers: [NgbActiveModal],
  bootstrap: [AppComponent]
})
export class AppModule { }
