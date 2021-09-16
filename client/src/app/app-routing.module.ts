import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrrorComponent } from './errors/server-errror/server-errror.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { CourseComponent } from './Student/course/course.component';
import { StudentComponent } from './student/student.component';
import { StudentDashBoardComponent } from './student-dash-board/student-dash-board.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'error', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrrorComponent },
  { path: 'student', component: StudentComponent },
  { path: 'course', component: CourseComponent },
  { path: 'studentdashboard', component: StudentDashBoardComponent, pathMatch: 'full' }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
