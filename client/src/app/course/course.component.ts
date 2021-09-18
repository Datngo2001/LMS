import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  courseName = 'Calculus 1'
  lessons = ['lesson 1', 'lesson 2', 'lesson 3', 'lesson 4']

  constructor() { }

  ngOnInit(): void {
  }

}
