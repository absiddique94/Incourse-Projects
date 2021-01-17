import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course';
import { Student } from 'src/app/models/student';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CourseService } from 'src/app/services/course.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-edit',
  templateUrl: './course-edit.component.html',
  styleUrls: ['./course-edit.component.css']
})
export class CourseEditComponent implements OnInit {

  course: Course = null;
  students: Student[] = [];
  courseForm: FormGroup = new FormGroup({
    CourseName: new FormControl('', Validators.required),
    Duration: new FormControl('', Validators.required),
    StudentId: new FormControl('', Validators.required)
  })
  constructor(
    private courseService: CourseService,
    private activatedRoute: ActivatedRoute
  ) { }
  get f() {
    return this.courseForm.controls;
  }
  onSubmit() {
    if (this.courseForm.invalid) return;
    Object.assign(this.course, this.courseForm.value);
    console.log(this.course);
    this.courseService.update(this.course)
      .subscribe(x => {

        this.courseForm.markAsUntouched();
        this.courseForm.markAsPristine();
      }, err => {
        console.log(err);

      })
  }
  initForm() {
    this.courseForm.setValue({
      CourseName: this.course.CourseName,
      Duration: this.course.Duration,
      StudentId: this.course.StudentId
    })
  }
  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.params.id;
    this.courseService.getStudentOptions()
      .subscribe(x => {
        this.students = x;

      }, err => {

      });
    this.courseService.getById(id)
      .subscribe(x => {
        this.course = x;
        this.initForm();
      }, err => {

      })
  }

}
