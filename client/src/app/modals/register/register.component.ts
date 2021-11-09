import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Student } from '../../_model/student';
import { AccountService } from '../../_services/account.service';
import { StudentService } from '../../_services/student.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  //Business variable
  model: any = {};
  student: any = {};
  constructor(public bsModalRef: BsModalRef, private accountService: AccountService, private toastr: ToastrService, private studentService: StudentService) { }

  ngOnInit(): void {

  }

  register() {
    this.accountService.register(this.model).subscribe(response => {
      this.createStudent();
      console.log(response);
      this.cancel();
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    })
  }
  createStudent() {
    this.studentService.createStudent(this.student).subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error);
    })
  }
  cancel() {
    this.bsModalRef.hide();
  }
}
