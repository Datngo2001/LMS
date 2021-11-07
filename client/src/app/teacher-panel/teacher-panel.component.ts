import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { DashboardService } from '../_services/dashboard.service';
import { CourseDetailComponent } from './course-detail/course-detail.component';

@Component({
  selector: 'app-teacher-panel',
  templateUrl: './teacher-panel.component.html',
  styleUrls: ['./teacher-panel.component.css']
})
export class TeacherPanelComponent implements OnInit {
  constructor(private dashService: DashboardService, private http: HttpClient, private route: ActivatedRoute, public detail: CourseDetailComponent) { }
  tid: number;
  myClass: any;
  classDetail: any;
  ngOnInit(): void {
    this.loadMyClass();
  }
  loadMyClass() {
    //this.tid = parseInt(this.route.snapshot.paramMap.get("id"))
    this.dashService.myClass().subscribe(classes => {
      this.myClass = classes;

    })
  }

  createLessons() {
    return 1;
  }

}
