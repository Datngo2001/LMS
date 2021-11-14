import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { CreateCourse } from 'src/app/_model/CreateCourse';
import { CourseService } from 'src/app/_services/course.service';

@Component({
  selector: 'app-create-course-modal',
  templateUrl: './create-course-modal.component.html',
  styleUrls: ['./create-course-modal.component.css']
})
export class CreateCourseModalComponent implements OnInit {

  model: CreateCourse = { name: "", description: "" };

  constructor(public bsModalRef: BsModalRef, private courseService: CourseService,
    private toast: ToastrService) { }

  ngOnInit(): void {
  }

  create() {
    this.courseService.CreateCrouse(this.model).subscribe(() => {
      this.toast.success("Course Created")
      this.bsModalRef.hide()
    })
  }

  cancel() {
    this.bsModalRef.hide()
  }
}
