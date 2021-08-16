import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CourseService } from '../shared/course.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styles: [
  ]
})
export class StudentComponent implements OnInit {

  constructor(public service: CourseService) { }

  ngOnInit(): void {
  }
  resetForm(form: NgForm) {
    if(form == null)
      form.resetForm();

  }
}
