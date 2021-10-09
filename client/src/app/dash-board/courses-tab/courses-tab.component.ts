import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DashboardService } from 'src/app/_services/dashboard.service';
import { DashBoardComponent } from '../dash-board.component';

@Component({
  selector: 'app-courses-tab',
  templateUrl: './courses-tab.component.html',
  styleUrls: ['./courses-tab.component.css']
})
export class CoursesTabComponent implements OnInit {
  id: number;
  myCourse: any;


  constructor(private dashService: DashboardService, private http: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMyCourse();
  }
  loadMyCourse() {
    this.id = parseInt(this.route.snapshot.paramMap.get("id"))
    this.dashService.myCourse(1).subscribe(course => {
      this.myCourse = course;
    })
  }
  onScroll(): void {
    console.log("Scrolled")
  }
}
