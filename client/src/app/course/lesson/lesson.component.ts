import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.css']
})
export class LessonComponent implements OnInit {

  isOpen = false
  @Input() lesson: any; 

  constructor() { }

  ngOnInit(): void {
  }

}
