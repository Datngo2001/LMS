import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from '../_model/Course';
import { CourseService } from '../_services/course.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  cId: string
  course: Partial<Course>

  constructor(private courseService: CourseService, private route: ActivatedRoute) {
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
}
