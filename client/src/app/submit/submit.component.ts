import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-submit',
  templateUrl: './submit.component.html',
  styleUrls: ['./submit.component.css']
})
export class SubmitComponent implements OnInit {

  public uploadedFiles: Array<File> = [];

  constructor() { }

  ngOnInit(): void {
  }

}
