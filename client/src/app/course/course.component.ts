import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CourseImageModalComponent } from '../modals/course-image-modal/course-image-modal.component';
import { CreateLessonModalComponent } from '../modals/create-lesson-modal/create-lesson-modal.component';
import { UpdateCourseModalComponent } from '../modals/update-course-modal/update-course-modal.component';
import { Course } from '../_model/Course';
import { CreateLesson } from '../_model/CreateLesson';
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
  lastLessonOrder: number = 0
  updateModal?: BsModalRef
  imageModal?: BsModalRef
  lessonModal?: BsModalRef

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


      //calculate next lesson order
      if (this.course.lessons.length != 0) {
        this.lastLessonOrder = this.course.lessons[0].order
        for (let index = 1; index < this.course.lessons.length; index++) {
          if (this.lastLessonOrder < this.course.lessons[index].order) {
            this.lastLessonOrder = this.course.lessons[index].order
          }
        }
      }
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

  openLessonModal() {
    var createLesson: CreateLesson = {
      order: (this.lastLessonOrder + 1),
      name: "",
      courseId: this.cId
    }
    const config = {
      initialState: {
        model: createLesson
      }
    }
    this.lessonModal = this.modalService.show(CreateLessonModalComponent, config);
  }
}
