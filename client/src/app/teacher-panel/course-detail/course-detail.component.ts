import { Component, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Group } from 'src/app/_model/CourseComp/Group';
import { DashboardService } from 'src/app/_services/dashboard.service';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: ['./course-detail.component.css']
})

@Injectable({
  providedIn: 'root'
})
export class CourseDetailComponent implements OnInit {
  classDetail: any;
  check = false;
  constructor(private dashService: DashboardService, private route: ActivatedRoute) { }

  ngOnInit(): void {

  }
  open() {
    this.check = true;
  }
  cancel() {
    this.check = false;
  }
  loadDetailClass(id: number) {
    this.dashService.classDetail(id).subscribe(data => {
      this.classDetail = data;
      console.log(this.classDetail);
    })
  }

}
