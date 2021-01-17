import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { StudentViewComponent } from './components/students/student-view/student-view.component';
import { StudentCreateComponent } from './components/students/student-create/student-create.component';
import { StudentEditComponent } from './components/students/student-edit/student-edit.component';
import { CourseCreateComponent } from './components/courses/course-create/course-create.component';
import { CourseEditComponent } from './components/courses/course-edit/course-edit.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'students', component: StudentViewComponent },
  { path: 'createStudent', component: StudentCreateComponent },
  { path: 'editStudent/:id', component: StudentEditComponent },
  { path: 'createCourse', component: CourseCreateComponent },
  { path: 'editCourse', component: CourseEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
