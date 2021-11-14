import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// Ngx boostrap: https://valor-software.com/ngx-bootstrap
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AlertModule } from 'ngx-bootstrap/alert';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { ModalModule } from 'ngx-bootstrap/modal';
// Toaster: https://www.npmjs.com/package/ngx-toastr
import { ToastrModule } from 'ngx-toastr';

import { FileUploadModule } from 'ng2-file-upload';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    TabsModule.forRoot(),
    AlertModule.forRoot(),
    AccordionModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    FileUploadModule
  ],
  exports: [
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    AlertModule,
    AccordionModule,
    ModalModule,
    ToastrModule,
    FileUploadModule
  ]
})
export class SharedModule { }
