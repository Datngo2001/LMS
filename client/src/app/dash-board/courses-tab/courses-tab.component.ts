import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/_model/Course';
import { DashboardService } from 'src/app/_services/dashboard.service';

@Component({
  selector: 'app-courses-tab',
  templateUrl: './courses-tab.component.html',
  styleUrls: ['./courses-tab.component.css']
})
export class CoursesTabComponent implements OnInit {
  id: number;
  courses: Partial<Course[]>;

  constructor(private dashService: DashboardService, private http: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMyCourse();
  }
  loadMyCourse() {
    this.dashService.CourseCard().subscribe(courses => {
      this.courses = courses;
      console.log(this.courses)
    })
  }
}
