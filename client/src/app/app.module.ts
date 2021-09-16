import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { SharedModule } from './_modules/shared.module';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrrorComponent } from './errors/server-errror/server-errror.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptor/error.interceptor';
import { StudentComponent } from './student/student.component';
import { CourseComponent } from './Student/course/course.component';
import { CourseService } from './_services/course.service';
import { JwtInterceptor } from './_interceptor/jwt.interceptor';
import { CoursesTabComponent } from './student-dash-board/courses-tab/courses-tab.component';
import { DeadlinesTabComponent } from './student-dash-board/deadlines-tab/deadlines-tab.component'
import { NoticeTabComponent } from './student-dash-board/notice-tab/notice-tab.component';
import { StudentDashBoardComponent } from './student-dash-board/student-dash-board.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    HomeComponent,
    NotFoundComponent,
    ServerErrrorComponent,
    TestErrorsComponent,
    StudentComponent,
    CourseComponent,
    CoursesTabComponent,
    DeadlinesTabComponent,
    NoticeTabComponent,
    StudentDashBoardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    SharedModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    CourseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
