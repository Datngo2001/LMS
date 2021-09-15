import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'courses-tab',
  templateUrl: './courses-tab.component.html',
  styleUrls: ['./courses-tab.component.css']
})
export class CoursesTabComponent implements OnInit {

  courses = [1, 2, 3, 4]

  constructor() { }

  ngOnInit(): void {

  }

}
