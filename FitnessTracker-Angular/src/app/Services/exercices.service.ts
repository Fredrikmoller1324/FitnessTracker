import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ExerciseModel } from "../Models/exercise.model";

@Injectable({ providedIn: 'root' })
export class ExercisesService{
    
    readonly BaseURL = 'https://localhost:7146/api';

    constructor(private http: HttpClient){}

    
    getAllExercises(){
        return this.http.get<ExerciseModel[]>(this.BaseURL + '/Exercise/GetAllExercises');
    }
  
}