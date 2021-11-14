import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseCard } from 'src/app/_model/CourseCard';

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
