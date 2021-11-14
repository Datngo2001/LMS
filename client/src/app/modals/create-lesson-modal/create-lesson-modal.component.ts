import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { CreateLesson } from 'src/app/_model/CreateLesson';
import { LessonService } from 'src/app/_services/lesson.service';

@Component({
  selector: 'app-create-lesson-modal',
  templateUrl: './create-lesson-modal.component.html',
  styleUrls: ['./create-lesson-modal.component.css']
})
export class CreateLessonModalComponent implements OnInit {

  model: CreateLesson = { order: 0, name: "", courseId: "" };

  constructor(public bsModalRef: BsModalRef, private lessonService: LessonService,
    private toast: ToastrService) { }

  ngOnInit(): void {
  }

  create() {
    this.lessonService.CreateLesson(this.model).subscribe(() => {
      this.toast.success("Lesson Created")
      this.bsModalRef.hide()
    })
  }

  cancel() {
    this.bsModalRef.hide()
  }
}
