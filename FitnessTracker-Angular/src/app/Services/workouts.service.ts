import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { WorkoutModel } from '../Models/workout.model';

@Injectable({ providedIn: 'root' })
export class WorkoutsService {
  readonly BaseURL = 'https://localhost:7146/api';

  constructor(private http: HttpClient) {}

  getAllUserWorkouts(){
      return this.http.get<WorkoutModel[]>(this.BaseURL + `/UserWorkout/GetAllUserWorkouts`);
  }

  getFilteredWorkouts(form:any){
    return this.http.get<WorkoutModel[]>(this.BaseURL + `/UserWorkout/GetAllUserWorkoutsByName?userWorkoutName=${form.Name}`);
  }
}