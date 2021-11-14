import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { LessonVideoModalComponent } from 'src/app/modals/lesson-video-modal/lesson-video-modal.component';
import { UpdateLessonModalComponent } from 'src/app/modals/update-lesson-modal/update-lesson-modal.component';
import { Lesson } from 'src/app/_model/Lesson';
import { UpdateLesson } from 'src/app/_model/UpdateLesson';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.css']
})
export class LessonComponent implements OnInit {

  isOpen = false
  @Input() lesson: Lesson;
  cloudName = environment.cloudName;
  safeURL: any;
  updateModal?: BsModalRef;
  videoModal?: BsModalRef;

  constructor(private sanitizer: DomSanitizer, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.createEmbedUrl();
  }

  createEmbedUrl() {
    if (this.lesson.videoPublicId == null) return
    var videoUrl = "https://player.cloudinary.com/embed/?public_id="
      + this.lesson.videoPublicId + "&cloud_name=" + this.cloudName
      + "&player%5Bfluid%5D=true&player%5Bcontrols%5D=true&player%5Bcolors%5D%5Baccent%5D=%23ffffff&player%5Bshow_jump_controls%5D=true&player%5Bfloating_when_not_visible%5D=right&player%5Bhide_context_menu%5D=true&source%5Bsource_types%5D%5B0%5D=mp4";
    this.safeURL = this.sanitizer.bypassSecurityTrustResourceUrl(videoUrl);
  }

  openUpdateModal() {
    var updateLesson: UpdateLesson = {
      id: this.lesson.id,
      order: this.lesson.order,
      name: this.lesson.name,
      courseId: this.lesson.courseId
    }
    const config = {
      initialState: {
        model: updateLesson
      }
    }
    this.updateModal = this.modalService.show(UpdateLessonModalComponent, config);
  }

  openVideoModal() {
    this.videoModal = this.modalService.show(LessonVideoModalComponent);
  }
}
