import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-deadlines-tab',
  templateUrl: './deadlines-tab.component.html',
  styleUrls: ['./deadlines-tab.component.css']
})
export class DeadlinesTabComponent implements OnInit {

  deadlines = [
    {
      type: 'Quiz',
      course: 'Calculus 1',
      header: 'Bai quiz giua ki',
      describe: 'Lam chieu lan'
    },
    {
      type: 'Assignment',
      course: 'Calculus 2',
      header: 'Bai quiz giua ki',
      describe: 'Lam chieu lan'
    },
    {
      type: 'Pregentation',
      course: 'Calculus 3',
      header: 'Bai quiz giua ki',
      describe: 'Lam chieu lan'
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
