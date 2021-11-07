import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseCard } from 'src/app/_model/DashBoardComp/CourseCard';
import { DashboardService } from 'src/app/_services/dashboard.service';
import { DashBoardComponent } from '../dash-board.component';

@Component({
  selector: 'app-courses-tab',
  templateUrl: './courses-tab.component.html',
  styleUrls: ['./courses-tab.component.css']
})
export class CoursesTabComponent implements OnInit {
  id: number;
  cards: Partial<CourseCard[]>;

  constructor(private dashService: DashboardService, private http: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMyCourse();
  }
  loadMyCourse() {
    this.dashService.CourseCard().subscribe(courseCards => {
      this.cards = courseCards;
      console.log(courseCards)
    })
  }
}
