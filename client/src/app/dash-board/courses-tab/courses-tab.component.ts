import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseCard } from 'src/app/_model/CourseCard';
import { DashboardService } from 'src/app/_services/dashboard.service';

@Component({
  selector: 'app-courses-tab',
  templateUrl: './courses-tab.component.html',
  styleUrls: ['./courses-tab.component.css']
})
export class CoursesTabComponent implements OnInit {
  @Input() cards: CourseCard[];

  constructor() { }

  ngOnInit(): void {
  }
}
