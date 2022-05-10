import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ExerciseCategoryModel, ExerciseModel } from '../Models/exercise.model';

@Injectable({ providedIn: 'root' })
export class ExercisesService {
  readonly BaseURL = 'https://localhost:7146/api';

  constructor(private http: HttpClient) {}

  getAllExercises() {
    return this.http.get<ExerciseModel[]>(
      this.BaseURL + '/Exercise/GetAllExercises'
    );
  }

  createExercise(formData: any) {
    console.log(formData);
    return this.http.post(this.BaseURL + `/Exercise/CreateExercise`, formData, {
      responseType: 'text',
    });
  }

  getAllExerciseCategories(){
    return this.http.get<ExerciseCategoryModel[]>(this.BaseURL + `/Exercise/GetExerciseCategories`)
  }

  getExerciseByName(exerciseName:string){
    return this.http.get<ExerciseModel>(this.BaseURL + `/Exercise/GetExerciseByName?exerciseName=${exerciseName}`)
  }
}
