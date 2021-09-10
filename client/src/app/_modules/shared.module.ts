import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// ngx boostrap link: https://valor-software.com/ngx-bootstrap
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
// Toaster link: https://www.npmjs.com/package/ngx-toastr
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  exports: [
    BsDropdownModule,
    CollapseModule,
    ToastrModule
  ]
})
export class SharedModule { }
