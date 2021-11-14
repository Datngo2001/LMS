import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CourseImageModalComponent } from '../modals/course-image-modal/course-image-modal.component';
import { UpdateCourseModalComponent } from '../modals/update-course-modal/update-course-modal.component';
import { Course } from '../_model/Course';
import { UpdateCourse } from '../_model/UpdateCourse';
import { CourseService } from '../_services/course.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  cId: string
  course: Course
  updateModal?: BsModalRef
  imageModal?: BsModalRef

  constructor(private courseService: CourseService, private route: ActivatedRoute, private modalService: BsModalService) {
    this.cId = this.route.snapshot.paramMap.get('id')
  }

  ngOnInit(): void {
    this.getContent(this.cId)
  }

  getContent(cId: string) {
    this.courseService.GetContent(cId).subscribe(content => {
      this.course = content
      this.course.lessons?.sort((a, b) => a.order - b.order)
    })
  }

  openUpdateModal() {
    var updateCourse: UpdateCourse = {
      name: this.course.name,
      description: this.course.description
    }
    const config = {
      initialState: {
        cId: this.cId,
        model: updateCourse
      }
    }
    this.updateModal = this.modalService.show(UpdateCourseModalComponent, config);
  }

  openImageModal() {
    this.imageModal = this.modalService.show(CourseImageModalComponent);
  }
}
