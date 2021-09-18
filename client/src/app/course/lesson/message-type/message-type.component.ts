import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-message-type',
  templateUrl: './message-type.component.html',
  styleUrls: ['./message-type.component.css']
})
export class MessageTypeComponent implements OnInit {

  @Input() content

  constructor() { }

  ngOnInit(): void {
  }

}
