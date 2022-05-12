import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Observable } from 'rxjs';
import { ExerciseCategoryModel, ExerciseModel } from 'src/app/Models/exercise.model';
import { WorkoutExercise } from 'src/app/Models/workout.model';
import { ExercisesService } from 'src/app/Services/exercices.service';

@Component({
  selector: 'app-create-workout-modal',
  templateUrl: './create-workout-modal.component.html',
  styleUrls: ['./create-workout-modal.component.scss']
})
export class CreateWorkoutModalComponent implements OnInit {

  @Input() my_modal_title;

  exercises;


  workoutForm = this.fb.group({
    name: new FormControl('',Validators.required),
    timeTaken: new FormControl(0,Validators.required),
    workoutExercises: this.fb.array([
      this.fb.group({
        exercise: ['', Validators.required],
        reps: [0, Validators.required],
        sets: [0, Validators.required],
        weight: [0, Validators.required],

      })
    ])
  })

  get workoutExercises() {
    return this.workoutForm.get('workoutExercises') as FormArray;
  }

  addWorkoutExercise() {

    const workoutExerciseForm = this.fb.group({
      exercise: ['', Validators.required],
      reps: [0, Validators.required],
      sets: [0, Validators.required],
      weight: [0, Validators.required],

    })

    this.workoutExercises.push(workoutExerciseForm);
  }

  successSent = false;
  isLoading = false;
  error: string = null;



  constructor(
    public activeModal: NgbActiveModal,
    private exerciseService: ExercisesService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.getExercices();
  }



  getExercices(){
    this.exerciseService.getAllExercises().subscribe((res:ExerciseModel[])=>{
      console.log(res);
      this.exercises = res;
    })
  }

  onSubmit() {
    console.log(this.workoutForm.value);

    this.error = null;

    //let authObs: Observable<string>;

    //this.isLoading = true;

    // authObs = this.exerciseService.createExercise(form.value);

    // authObs.subscribe(
    //   (res) => {
    //     this.isLoading = false;
    //     this.error = null;
    //     this.successSent = true;
    //   },
    //   (err) => {
    //     console.log(err.error);
    //     this.error = err.error;
    //     this.isLoading = false;
    //     this.successSent = false;
    //     console.log('successent', this.successSent);
    //     console.log('errordisplay', this.error);
    //   }
    // );

    // form.reset();
  }

}
