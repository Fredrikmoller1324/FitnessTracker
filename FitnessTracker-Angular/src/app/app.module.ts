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
import { CreateExerciseModalComponent } from './components/exercise-library/create-exercise-modal/create-exercise-modal.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { WorkoutsComponent } from './components/workouts/workouts.component';
import { WorkoutDetailsModalComponent } from './components/workouts/workout-details-modal/workout-details-modal.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CreateWorkoutModalComponent } from './components/workouts/create-workout-modal/create-workout-modal.component';


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
    ExerciseLibraryComponent,
    CreateExerciseModalComponent,
    WorkoutsComponent,
    WorkoutDetailsModalComponent,
    CreateWorkoutModalComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule,
    NgMultiSelectDropDownModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    NgbActiveModal,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
