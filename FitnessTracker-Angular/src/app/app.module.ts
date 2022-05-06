import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { HomeComponent } from './components/home/home.component'
import { LoadingSpinnerComponent } from './Shared/components/loading-spinner/loading-spinner.component';
import { HeaderComponent } from './components/header/header.component';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ForgotPasswordModal } from './components/login/modal/forgotpasswordmodal.component';
import { ProfileComponent } from './components/profile/profile.component';
import { BaseCardComponent } from './Shared/components/base-card/base-card.component';
import { ChangePasswordComponent } from './components/profile/change-password/change-password.component';
import { AuthInterceptorService } from './auth/auth-interceptor.service';
import { ExerciseLibraryComponent } from './components/exercise-library/exercise-library.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    LoadingSpinnerComponent,
    HeaderComponent,
    ForgotPasswordModal,
    ProfileComponent,
    BaseCardComponent,
    ChangePasswordComponent,
    ExerciseLibraryComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule
  ],
  providers: [
    NgbActiveModal,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
