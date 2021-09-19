import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { RegisterComponent } from '../register/register.component';
import { User } from '../_model/user';
import { AccountService } from '../_services/account.service';

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

  constructor(private modalService: BsModalService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

  openRegisterModal() {
    this.registerModal = this.modalService.show(RegisterComponent);
  }
}
