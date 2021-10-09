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
    this.loadMyClass();
  }
  loadMyClass() {
    this.tid = parseInt(this.route.snapshot.paramMap.get("id"))
    this.dashService.myClass(1).subscribe(classes => {
      this.myClass = classes;
    })
  }
  loadDetaiClass() {
    console.log("oke");
  }
  createLessons() {
    return 1;
  }
}
