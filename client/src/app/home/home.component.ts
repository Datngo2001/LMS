import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { RegisterComponent } from '../modals/register/register.component';
import { CourseCard } from '../_model/CourseCard';
import { User } from '../_model/user';
import { AccountService } from '../_services/account.service';
import { CourseService } from '../_services/course.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //UI variable
  registerMode = false;
  registerModal?: BsModalRef;

  //Business variable
  currentUser$: Observable<User>;
  enrolleCards: Partial<CourseCard[]>;

  constructor(private modalService: BsModalService, private accountService: AccountService, private courseService: CourseService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.loadCourseCard();
  }

  openRegisterModal() {
    this.registerModal = this.modalService.show(RegisterComponent);
  }

  loadCourseCard() {
    this.courseService.CourseEnrolleCard().subscribe(cards => {
      this.enrolleCards = cards;
      console.log(this.enrolleCards)
    })
  }
}
