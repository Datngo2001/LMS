import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { UpdateLesson } from 'src/app/_model/UpdateLesson';
import { LessonService } from 'src/app/_services/lesson.service';

@Component({
  selector: 'app-update-lesson-modal',
  templateUrl: './update-lesson-modal.component.html',
  styleUrls: ['./update-lesson-modal.component.css']
})
export class UpdateLessonModalComponent implements OnInit {
  lId: string;
  model: UpdateLesson;

  constructor(public bsModalRef: BsModalRef, private lessonService: LessonService,
    private toast: ToastrService) { }

  ngOnInit(): void {
  }

  update() {
    this.lessonService.UpdateLesson(this.model).subscribe(() => {
      this.toast.success("Lesson Updated")
      this.bsModalRef.hide()
    })
  }

  cancel() {
    this.bsModalRef.hide()
  }

}
