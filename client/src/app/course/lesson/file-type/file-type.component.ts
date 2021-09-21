import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-file-type',
  templateUrl: './file-type.component.html',
  styleUrls: ['./file-type.component.css']
})
export class FileTypeComponent implements OnInit {

  @Input() content

  constructor() { }

  ngOnInit(): void {
  }

}