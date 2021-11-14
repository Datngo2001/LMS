import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Lesson } from 'src/app/_model/Lesson';
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
  safeURL: any

  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.createEmbedUrl();
  }

  createEmbedUrl() {
    if (this.lesson.videoPublicId.length == 0) return
    var videoUrl = "https://player.cloudinary.com/embed/?public_id="
      + this.lesson.videoPublicId + "&cloud_name=" + this.cloudName
      + "&player%5Bfluid%5D=true&player%5Bcontrols%5D=true&player%5Bcolors%5D%5Baccent%5D=%23ffffff&player%5Bshow_jump_controls%5D=true&player%5Bfloating_when_not_visible%5D=right&player%5Bhide_context_menu%5D=true&source%5Bsource_types%5D%5B0%5D=mp4";
    this.safeURL = this.sanitizer.bypassSecurityTrustResourceUrl(videoUrl);
  }
}
