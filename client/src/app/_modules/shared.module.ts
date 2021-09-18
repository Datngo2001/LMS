import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// ngx boostrap link: https://valor-software.com/ngx-bootstrap
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AlertModule } from 'ngx-bootstrap/alert';
import { AccordionModule } from 'ngx-bootstrap/accordion';
// Toaster link: https://www.npmjs.com/package/ngx-toastr
import { ToastrModule } from 'ngx-toastr';
// Infinite Scroll: https://www.npmjs.com/package/ngx-infinite-scroll
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
//FileUploadModule: https://www.npmjs.com/package/@iplab/ngx-file-upload
import { FileUploadModule } from '@iplab/ngx-file-upload';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    TabsModule.forRoot(),
    AlertModule.forRoot(),
    AccordionModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    InfiniteScrollModule,
    FileUploadModule
  ],
  exports: [
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    AlertModule,
    AccordionModule,
    ToastrModule,
    InfiniteScrollModule,
    FileUploadModule
  ]
})
export class SharedModule { }
