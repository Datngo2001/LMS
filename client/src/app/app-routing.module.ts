import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { CourseComponent } from './course/course.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrrorComponent } from './errors/server-errror/server-errror.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { SubmitComponent } from './submit/submit.component';
import { TeacherPanelComponent } from './teacher-panel/teacher-panel.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'dashboard', component: DashBoardComponent},
      { path: 'submit', component: SubmitComponent },
      { path: 'course', component: CourseComponent },
      { path: 'profile', component: ProfileComponent},
      { path: 'teacher', component: TeacherPanelComponent },
      { path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]}
    ]
  },
  { path: 'error', component: TestErrorsComponent },
  { path: 'server-error', component: ServerErrrorComponent },
  { path: 'not-found', component: NotFoundComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
