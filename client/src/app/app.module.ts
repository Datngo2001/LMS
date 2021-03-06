import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrrorComponent } from './errors/server-errror/server-errror.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptor/error.interceptor';
import { JwtInterceptor } from './_interceptor/jwt.interceptor';
import { CoursesTabComponent } from './dash-board/courses-tab/courses-tab.component';
import { NoticeTabComponent } from './dash-board/notice-tab/notice-tab.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { CourseComponent } from './course/course.component';
import { LessonComponent } from './course/lesson/lesson.component';
import { OverviewComponent } from './course/overview/overview.component';
import { ProfileComponent } from './profile/profile.component';
import { TeacherPanelComponent } from './teacher-panel/teacher-panel.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directive/has-role.directive';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { RolesModalComponent } from './modals/roles-modal/roles-modal.component';
import { LoginComponent } from './modals/login/login.component';
import { ConfirmDialogComponent } from './modals/confirm-dialog/confirm-dialog.component';
import { SharedModule } from './_modules/shared.module';
import { RegisterComponent } from './modals/register/register.component';
import { IframeAutoHeightDirective } from './_directive/iframe-auto-heigh.directive';
import { CreateCourseModalComponent } from './modals/create-course-modal/create-course-modal.component';
import { UpdateCourseModalComponent } from './modals/update-course-modal/update-course-modal.component';
import { CourseImageModalComponent } from './modals/course-image-modal/course-image-modal.component';
import { CreateLessonModalComponent } from './modals/create-lesson-modal/create-lesson-modal.component';
import { UpdateLessonModalComponent } from './modals/update-lesson-modal/update-lesson-modal.component';
import { LessonVideoModalComponent } from './modals/lesson-video-modal/lesson-video-modal.component';
import { LoadingInterceptor } from './_interceptor/loading.interceptor';
import { AboutUsComponent } from './about-us/about-us.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    NotFoundComponent,
    ServerErrrorComponent,
    TestErrorsComponent,
    CoursesTabComponent,
    NoticeTabComponent,
    DashBoardComponent,
    CourseComponent,
    LessonComponent,
    OverviewComponent,
    LoginComponent,
    ProfileComponent,
    TeacherPanelComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserManagementComponent,
    RolesModalComponent,
    ConfirmDialogComponent,
    RegisterComponent,
    IframeAutoHeightDirective,
    CreateCourseModalComponent,
    UpdateCourseModalComponent,
    CourseImageModalComponent,
    CreateLessonModalComponent,
    UpdateLessonModalComponent,
    LessonVideoModalComponent,
    AboutUsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
