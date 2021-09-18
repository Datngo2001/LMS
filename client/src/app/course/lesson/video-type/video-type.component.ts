import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-video-type',
  templateUrl: './video-type.component.html',
  styleUrls: ['./video-type.component.css']
})
export class VideoTypeComponent implements OnInit {

  @Input() content

  constructor() { }

  ngOnInit(): void {
  }

}
