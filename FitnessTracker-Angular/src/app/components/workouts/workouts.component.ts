import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbDate, NgbDateParserFormatter, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { WorkoutModel } from 'src/app/Models/workout.model';
import { WorkoutsService } from 'src/app/Services/workouts.service';
import { WorkoutDetailsModalComponent } from './workout-details-modal/workout-details-modal.component';
import {NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap';
import { ExerciseModel } from 'src/app/Models/exercise.model';
import { ExercisesService } from 'src/app/Services/exercices.service';

@Component({
  selector: 'app-workouts',
  animations: [
    trigger('flyInOut', [
      state('in', style({ opacity: 1 })),
      transition('void => *', [style({ opacity: 0 }), animate(1000)]),
      transition('* => void', [animate(300, style({ opacity: 0 }))]),
    ]),
  ],
  templateUrl: './workouts.component.html',
  styleUrls: ['./workouts.component.scss'],
})
export class WorkoutsComponent implements OnInit {

  startDate: NgbDateStruct;
  endDate: NgbDateStruct;

  date1: NgbDate = this.calendar.getToday();
  date2: NgbDate = this.calendar.getNext(this.calendar.getToday(), 'd', 1)

  workouts: WorkoutModel[] = [];
  exercises: ExerciseModel[] = [];
  showFilter = false;
  fadeOut = false;

  formModel = {
    Name: '',
    ExerciseId: '',
    StartDate: this.date1,
    EndDate: this.date2
  };
  error: string = null;
  isLoading: boolean = false;

  constructor(
    private workoutService: WorkoutsService,
    private modalService: NgbModal,
    private calendar: NgbCalendar,
    private ngbDateParserFormatter: NgbDateParserFormatter,
    private exerciseService: ExercisesService
  ) {}

  ngOnInit(): void {
    console.log(typeof(this.date1))
    console.log('formatted? ',this.ngbDateParserFormatter.format(this.date1))
    this.getWorkoutes();
    this.getExercises();
  }

  getExercises(){
    this.exerciseService.getAllExercises().subscribe((res: ExerciseModel[]) =>{
      console.log(res)
      this.exercises = res;
    })
  }

  OnCreateWorkout() {}

  onDetailsClicked(workout: WorkoutModel) {
    const modalRef = this.modalService.open(WorkoutDetailsModalComponent, {
      size: 'md',
      centered: true,
    });
    modalRef.componentInstance.my_modal_title = workout.name;
    modalRef.componentInstance.workout = workout;
  }

  getWorkoutes() {
    this.workoutService.getAllUserWorkouts().subscribe((res) => {
      console.log(res);
      this.workouts = res;
    });
  }

  OnShowFilter() {
    if (this.showFilter) {
      this.fadeOut = !this.fadeOut;
    }
    this.showFilter = !this.showFilter;
  }

  resetFilter(){
    this.resetForm();
    this.getWorkoutes();
  }

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }

    console.log(form)
    console.log(form.value.StartDate)
    console.log("date1", this.ngbDateParserFormatter.format(form.value.StartDate))

    form.value.StartDate = this.ngbDateParserFormatter.format(form.value.StartDate)
    form.value.EndDate = this.ngbDateParserFormatter.format(form.value.EndDate)


    this.error = null;

    let authObs: Observable<WorkoutModel[]>;

    this.isLoading = true;

    authObs = this.workoutService.getFilteredWorkouts(form.value);

    authObs.subscribe(
      (res: WorkoutModel[]) => {
        console.log(res);
        this.isLoading = false;
        this.workouts = [];
        this.workouts = res;
      },
      (err) => {
        console.log(err.error);
        this.error = err.error;
        this.isLoading = false;
      }
    );
    
    this.resetForm();
  }

  private resetForm(){
    console.log(this.formModel.StartDate)
      this.date1 = this.calendar.getToday(),
      this.date2 = this.calendar.getNext(this.calendar.getToday(), 'd', 1),
      this.formModel.ExerciseId = '',
      this.formModel.Name = '';
    console.log(this.formModel.StartDate)

  }
}
