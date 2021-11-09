import { Component, OnInit } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../_model/user';
import { AccountService } from '../_services/account.service';
import { RegisterComponent } from '../modals/register/register.component';
import { LoginComponent } from '../modals/login/login.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  //UI variable
  isCollapsed = true;
  loginModal?: BsModalRef;
  registerModal?: BsModalRef;

  //Business variable
  currentUser$: Observable<User>;

  constructor(private modalService: BsModalService, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    // observe the current user at user service
    this.currentUser$ = this.accountService.currentUser$;
  }

  openLoginModal() {
    this.loginModal = this.modalService.show(LoginComponent);
  }
  openRegisterModal() {
    this.registerModal = this.modalService.show(RegisterComponent);
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/");
  }
}

