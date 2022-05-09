import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Observable } from 'rxjs/internal/Observable';
import { ExerciseCategoryModel } from 'src/app/Models/exercise.model';
import { ExercisesService } from 'src/app/Services/exercices.service';

@Component({
  selector: 'app-create-exercise-modal',
  templateUrl: './create-exercise-modal.component.html',
  styleUrls: ['./create-exercise-modal.component.scss'],
})
export class CreateExerciseModalComponent implements OnInit {
  @Input() my_modal_title;

  formModel = {
    Name: '',
    ExerciseCategories: Array<ExerciseCategoryModel>()
  };

  successSent = false;
  isLoading = false;
  error: string = null;

  dropdownlist: Array<object> = [];
  dropdownSettings:IDropdownSettings={ 
    idField: 'id',
    textField: 'name',
  };

  constructor(
    public activeModal: NgbActiveModal,
    private exerciseService: ExercisesService,
  ) {}

  ngOnInit(): void {

    this.exerciseService.getAllExerciseCategories().subscribe((res:ExerciseCategoryModel[])=>{
      console.log(res);
      let dropdownlisttemp: Array<object> = [];

      res.forEach(exerciseCategory =>{
        dropdownlisttemp.push({ id: exerciseCategory.id.toString(), name: exerciseCategory.name })
      })
      this.dropdownlist = dropdownlisttemp;
    })
  }

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }

    console.log(form);

    this.error = null;

    let authObs: Observable<string>;

    this.isLoading = true;

    authObs = this.exerciseService.createExercise(form.value);

    authObs.subscribe(
      (res) => {
        this.isLoading = false;
        this.error = null;
        this.successSent = true;
      },
      (err) => {
        console.log(err.error);
        this.error = err.error;
        this.isLoading = false;
        this.successSent = false;
        console.log('successent', this.successSent);
        console.log('errordisplay', this.error);
      }
    );

    form.reset();
  }
}
