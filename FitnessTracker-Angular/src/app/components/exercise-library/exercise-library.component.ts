import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ExerciseModel } from 'src/app/Models/exercise.model';
import { ExercisesService } from 'src/app/Services/exercices.service';
import { CreateExerciseModalComponent } from './create-exercise-modal/create-exercise-modal.component';

@Component({
  selector: 'app-exercise-library',
  templateUrl: './exercise-library.component.html',
  styleUrls: ['./exercise-library.component.scss'],
})
export class ExerciseLibraryComponent implements OnInit {
  modalOptions: NgbModalOptions;

  constructor(
    private exerciseService: ExercisesService,
    private modalService: NgbModal
  ) {
    this.modalOptions = {
      backdrop: 'static',
      backdropClass: 'customBackdrop',
    };
  }

  exercises: ExerciseModel[] = [];

  ngOnInit(): void {
    this.onGetExercices();
  }

  onGetExercices() {
    this.exerciseService.getAllExercises().subscribe((exercises) => {
      console.log('in onGetExercises() before', this.exercises);

      this.exercises = exercises;
      console.log('in onGetExercises() after', this.exercises);
    });
  }

  OnCreateExercise() {
    const modalRef = this.modalService.open(CreateExerciseModalComponent, {
      size: 'md',
      centered: true,
    });
    modalRef.componentInstance.my_modal_title = 'Create new exercise';
  }
}
