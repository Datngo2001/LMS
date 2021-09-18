import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrrorComponent } from './errors/server-errror/server-errror.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { CourseComponent } from './course/course.component';
import { SubmitComponent } from './submit/submit.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'error', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrrorComponent },
  { path: 'dashboard', component: DashBoardComponent, pathMatch: 'full' },
  { path: 'course', component: CourseComponent },
  { path: 'submit', component: SubmitComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
