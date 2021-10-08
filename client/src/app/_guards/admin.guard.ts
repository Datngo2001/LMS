import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private accountSevice: AccountService, private toastr: ToastrService) { }

  canActivate(): Observable<boolean> {
    return this.accountSevice.currentUser$.pipe(
      map(user => {
        if (user.roles.includes('Admin') || user.roles.includes('Teacher')) {
          return true;
        }
        this.toastr.error('You shall not pass');
      })
    )
  }

}
