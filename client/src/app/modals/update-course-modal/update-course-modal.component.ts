import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { UpdateCourse } from 'src/app/_model/UpdateCourse';
import { CourseService } from 'src/app/_services/course.service';

@Component({
  selector: 'app-update-course-modal',
  templateUrl: './update-course-modal.component.html',
  styleUrls: ['./update-course-modal.component.css']
})
export class UpdateCourseModalComponent implements OnInit {

  cId: string;
  model: UpdateCourse;

  constructor(public bsModalRef: BsModalRef, private courseService: CourseService,
    private toast: ToastrService) { }

  ngOnInit(): void {
  }

  update() {
    this.courseService.UpdateCrouse(this.cId, this.model).subscribe(() => {
      this.toast.success("Course Updated")
      this.bsModalRef.hide()
    })
  }

  cancel() {
    this.bsModalRef.hide()
  }

}
