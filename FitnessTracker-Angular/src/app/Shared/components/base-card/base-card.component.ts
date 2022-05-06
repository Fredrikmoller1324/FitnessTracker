import {
  Component,
  Input,
  OnInit,
} from '@angular/core';


@Component({
  selector: 'app-base-card',
  templateUrl: './base-card.component.html',
  styleUrls: ['./base-card.component.scss'],
})
export class BaseCardComponent implements OnInit {
  @Input() title: string;

  constructor() {}
  ngOnInit(): void {
    
  }
  
}
