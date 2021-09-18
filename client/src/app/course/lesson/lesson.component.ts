import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.css']
})
export class LessonComponent implements OnInit {

  isOpen = false

  contents = [
    {
      type: 'video',
      title: 'Video lecture',
      describe: 'Video week 1',
      link: 'https://www.youtube.com/watch?v=CqLepeyHKMc'
    },
    {
      type: 'file',
      title: 'Video lecture',
      describe: 'Video week 1',
      link: 'https://docs.google.com/document/d/1uD6MGjfdvJse5mroPypssdXhZ4htS1JbD49SU5CZfho/edit?usp=sharing'
    },
    {
      type: 'message',
      title: 'Remember to do assignment',
      concent: 'That is midterm assignment',
    },
    {
      type: 'assignment',
      title: 'Midterm',
      describe: 'Video week 1',
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
