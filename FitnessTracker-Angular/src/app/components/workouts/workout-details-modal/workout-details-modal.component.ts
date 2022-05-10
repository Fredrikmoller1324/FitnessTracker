import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-workout-details-modal',
  templateUrl: './workout-details-modal.component.html',
  styleUrls: ['./workout-details-modal.component.scss']
})
export class WorkoutDetailsModalComponent implements OnInit {
  @Input() workout;
  @Input() my_modal_title;
  isLoading = false;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    
  }

}
