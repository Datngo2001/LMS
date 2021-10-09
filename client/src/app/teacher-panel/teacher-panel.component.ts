import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DashboardService } from '../_services/dashboard.service';

@Component({
  selector: 'app-teacher-panel',
  templateUrl: './teacher-panel.component.html',
  styleUrls: ['./teacher-panel.component.css']
})
export class TeacherPanelComponent implements OnInit {

  constructor(private dashService: DashboardService, private http: HttpClient, private route: ActivatedRoute) { }
  tid: number;
  myClass: any;
  ngOnInit(): void {
  }
  loadMyCourse() {
    this.tid = parseInt(this.route.snapshot.paramMap.get("id"))
    this.dashService.myCourse(this.tid).subscribe(course => {
      this.myClass = course;
    })
  }
  createLessons() {
    return 1
  }
}
