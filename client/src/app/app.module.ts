import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RegisterComponent } from './modals/register/register.component';
import { HomeComponent } from './home/home.component';
import { SharedModule } from './_modules/shared.module';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrrorComponent } from './errors/server-errror/server-errror.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptor/error.interceptor';
import { CourseService } from './_services/course.service';
import { JwtInterceptor } from './_interceptor/jwt.interceptor';
import { CoursesTabComponent } from './dash-board/courses-tab/courses-tab.component';
import { DeadlinesTabComponent } from './dash-board/deadlines-tab/deadlines-tab.component'
import { NoticeTabComponent } from './dash-board/notice-tab/notice-tab.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { CourseComponent } from './course/course.component';
import { LessonComponent } from './course/lesson/lesson.component';
import { OverviewComponent } from './course/overview/overview.component';
import { ScoreComponent } from './course/score/score.component';
import { VideoTypeComponent } from './course/lesson/video-type/video-type.component';
import { FileTypeComponent } from './course/lesson/file-type/file-type.component';
import { SafeEmbedPipe } from './_pipe/safe-embed.pipe';
import { MessageTypeComponent } from './course/lesson/message-type/message-type.component';
import { AssignmentTypeComponent } from './course/lesson/assignment-type/assignment-type.component';
import { SubmitComponent } from './submit/submit.component';
import { ProfileComponent } from './profile/profile.component';
import { TeacherPanelComponent } from './teacher-panel/teacher-panel.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directive/has-role.directive';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { RolesModalComponent } from './modals/roles-modal/roles-modal.component';
import { CourseDetailComponent } from './teacher-panel/course-detail/course-detail.component';
import { LoginComponent } from './modals/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    HomeComponent,
    NotFoundComponent,
    ServerErrrorComponent,
    TestErrorsComponent,
    CoursesTabComponent,
    DeadlinesTabComponent,
    NoticeTabComponent,
    DashBoardComponent,
    CourseComponent,
    LessonComponent,
    OverviewComponent,
    ScoreComponent,
    VideoTypeComponent,
    FileTypeComponent,
    SafeEmbedPipe,
    MessageTypeComponent,
    AssignmentTypeComponent,
    SubmitComponent,
    LoginComponent,
    ProfileComponent,
    TeacherPanelComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserManagementComponent,
    RolesModalComponent,
    CourseDetailComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
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
