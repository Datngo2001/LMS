import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// ngx boostrap link: https://valor-software.com/ngx-bootstrap
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AlertModule } from 'ngx-bootstrap/alert';
// Toaster link: https://www.npmjs.com/package/ngx-toastr
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    TabsModule.forRoot(),
    AlertModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  exports: [
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    AlertModule,
    ToastrModule
  ]
})
export class SharedModule { }
