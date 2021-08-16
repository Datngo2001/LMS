import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrrorComponent } from './errors/server-errror/server-errror.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { CourseComponent } from './Student/course/course.component';
import { StudentComponent } from './student/student.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'error', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrrorComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
  { path: 'student', component: StudentComponent },
  { path: 'course', component: CourseComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
