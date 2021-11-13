import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseCard } from '../_model/CourseCard';
import { CourseService } from '../_services/course.service';
import { DashboardService } from '../_services/dashboard.service';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent implements OnInit {
  courseCards: Partial<CourseCard[]>;

  constructor(private courseService: CourseService) { }

  ngOnInit(): void {
    this.loadCourseCard();
  }

  loadCourseCard() {
    this.courseService.CourseCard().subscribe(cards => {
      this.courseCards = cards;
      console.log(this.courseCards)
    })
  }
}
