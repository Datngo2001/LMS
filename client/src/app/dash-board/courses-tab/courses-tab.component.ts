import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateCourseModalComponent } from 'src/app/modals/create-course-modal/create-course-modal.component';
import { CourseCard } from 'src/app/_model/CourseCard';

@Component({
  selector: 'app-courses-tab',
  templateUrl: './courses-tab.component.html',
  styleUrls: ['./courses-tab.component.css']
})
export class CoursesTabComponent implements OnInit {
  @Input() cards: CourseCard[];
  createModal?: BsModalRef;

  constructor(private modalService: BsModalService) { }

  ngOnInit(): void {
  }
  openCreateModal() {
    this.createModal = this.modalService.show(CreateCourseModalComponent);
  }
}
