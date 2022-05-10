import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { WorkoutModel } from 'src/app/Models/workout.model';
import { WorkoutsService } from 'src/app/Services/workouts.service';
import { WorkoutDetailsModalComponent } from './workout-details-modal/workout-details-modal.component';

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
  workouts: WorkoutModel[] = [];
  showFilter = false;
  fadeOut = false;

  formModel = {
    Name: '',
    Exercise: '',
    Date: '',
  };
  error: string = null;
  isLoading: boolean = false;

  constructor(
    private workoutService: WorkoutsService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getWorkoutes();
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

  resetFilter(form:NgForm){
    form.reset();
    this.getWorkoutes();
  }

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }

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

    form.reset();
  }
}
