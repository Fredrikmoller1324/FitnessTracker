import { Component, OnInit } from '@angular/core';
import { ExerciseModel } from 'src/app/Models/exercise.model';
import { ExercisesService } from 'src/app/Services/exercices.service';

@Component({
  selector: 'app-exercise-library',
  templateUrl: './exercise-library.component.html',
  styleUrls: ['./exercise-library.component.scss']
})
export class ExerciseLibraryComponent implements OnInit {

  constructor(private exerciseService: ExercisesService) { }

  exercises: ExerciseModel[] = [];

  ngOnInit(): void {
    this.onGetExercices();
  }

  onGetExercices(){
    this.exerciseService.getAllExercises().subscribe((exercises)=>{
      console.log('in onGetExercises() before', this.exercises)
      
      this.exercises = exercises;
      console.log('in onGetExercises() after', this.exercises)
    });
  }
  

}
