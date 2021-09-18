import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-assignment-type',
  templateUrl: './assignment-type.component.html',
  styleUrls: ['./assignment-type.component.css']
})
export class AssignmentTypeComponent implements OnInit {

  @Input() content

  constructor() { }

  ngOnInit(): void {
  }

}
