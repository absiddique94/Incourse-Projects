import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course';
import { Student } from 'src/app/models/student';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-course-create',
  templateUrl: './course-create.component.html',
  styleUrls: ['./course-create.component.css'],
  styles: [
    `
    :host {
        display:block;
        width:100%;
    }`
  ]
})
export class CourseCreateComponent implements OnInit {
  course: Course = new Course();
  students: Student[] = [];
  courseForm: FormGroup = new FormGroup({
    CourseName: new FormControl('', Validators.required),
    Duration: new FormControl('', Validators.required),
    StudentId: new FormControl('', Validators.required)
  })
  constructor(
    private courseService: CourseService
  ) { }
  get f() {
    return this.courseForm.controls;
  }
  onSubmit() {
    if (this.courseForm.invalid) return;
    Object.assign(this.course, this.courseForm.value);
    this.courseService.insert(this.course)
      .subscribe(x => {
        this.courseForm.reset({});
        this.courseForm.markAsUntouched();
        this.courseForm.markAsPristine();
      }, err => {
        console.log(err);

      })
  }
  ngOnInit(): void {
    this.courseService.getStudentOptions()
      .subscribe(x => {
        this.students = x;
      }, err => {

      })
  }

}
