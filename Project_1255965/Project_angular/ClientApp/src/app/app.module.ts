import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './components/home/home.component';
import { StudentViewComponent } from './components/students/student-view/student-view.component';
import { StudentEditComponent } from './components/students/student-edit/student-edit.component';
import { StudentCreateComponent } from './components/students/student-create/student-create.component';
import { CourseCreateComponent } from './components/courses/course-create/course-create.component';
import { CourseViewComponent } from './components/courses/course-view/course-view.component';
import { CourseEditComponent } from './components/courses/course-edit/course-edit.component';
import { DeleteDialogComponent } from './components/common/delete-dialog/delete-dialog.component';
import { AppNavComponent } from './app-nav/app-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { StudentService } from './services/student.service';
import { CourseService } from './services/course.service';
import { NotifyService } from './services/notify.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIncludeModule } from './shared/common/mat-include/mat-include.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StudentViewComponent,
    StudentEditComponent,
    StudentCreateComponent,
    CourseCreateComponent,
    CourseViewComponent,
    CourseEditComponent,
    DeleteDialogComponent,
    AppNavComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    LayoutModule,
    MatIncludeModule,
    HttpClientModule,
    NgMaterialMultilevelMenuModule
  ],
  entryComponents: [DeleteDialogComponent],
  providers: [StudentService, CourseService, NotifyService],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
