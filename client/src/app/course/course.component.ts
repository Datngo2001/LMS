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

  gid: string;
  name: string;
  course: Partial<Course>

  constructor(private courseService: CourseService, private route: ActivatedRoute) {
    this.name = this.route.snapshot.paramMap.get('name');
    this.gid = this.route.snapshot.paramMap.get('gid');
  }

  ngOnInit(): void {
  }
}
