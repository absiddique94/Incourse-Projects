import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Course } from 'src/app/models/course';
import { StudentService } from 'src/app/services/student.service';
import { NotifyService } from 'src/app/services/notify.service';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.css'],
  styles: [
    `
    :host {
        display:block;
        width:100%;
    }`
  ]
})
export class StudentCreateComponent implements OnInit {
  student: Student = new Student();
  studentForm: FormGroup = new FormGroup({
    StudentName: new FormControl('', Validators.required),
    Description: new FormControl('', Validators.required),
    FemaleAllowed: new FormControl(''),
    Courses: new FormArray([])
  });
  removeItem(index: number) {
    (this.student.Courses as Course[]).splice(index, 1);
  }
  onSubmit() {
    console.log(this.isDisabled);
    if (this.studentForm.controls.StudentName.invalid ||
      this.studentForm.controls.Description.invalid
    ) {
      this.notifyService.message("Errors in form", 'DISMISS')
      return;
    }
    if ((this.student.Courses as Course[]).length == 0) {
      this.notifyService.message("No course added.", 'DISMISS')
      return;
    }
    this.student.StudentName = this.studentForm.controls.StudentName.value;
    this.student.Description = this.studentForm.controls.Description.value;
    this.student.FemaleAllowed = this.studentForm.controls.FemaleAllowed.value;
    this.student.StudentId = 0;
    console.log(this.student);

    this.studentService.insert(this.student)
      .subscribe(x => {
        this.notifyService.message("Data Saved successfully", 'DISMISS');
        this.studentForm.reset({});
        this.studentForm.markAsUntouched();
        this.studentForm.markAsPristine();
        this.student = new Student();
        this.student.Courses = [];
      }, err => {
          this.notifyService.message("Could not insert data.", 'DISMISS');
          return throwError(err);
      })
  }
  addCourseForm() {
    (this.studentForm.get('Courses') as FormArray).push(
      new FormGroup({
        CourseName: new FormControl('', Validators.required),
        Duration: new FormControl('', Validators.required)
      }));
  }
  addCourseToStudent() {
    console.log(this.CourseArray.controls[0].value);
    let course = new Course();
    Object.assign(course, this.CourseArray.controls[0].value);
    (this.student.Courses as Course[]).push(course);
    this.CourseArray.controls[0].reset({});
    this.CourseArray.controls[0].markAsPristine();
    this.CourseArray.controls[0].markAsUntouched();
  }
  get CourseArray() {
    return this.studentForm.get("Courses") as FormArray;
  }
  get courseLength() {
    return (this.student.Courses ? (this.student.Courses as Course[]).length : 0)
  }
  get isDisabled() {
    return this.studentForm.controls.StudentName.invalid ||
      this.studentForm.controls.Description.invalid || (this.student.Courses as Course[]).length == 0;
  }
  constructor(
    private studentService: StudentService,
    private notifyService: NotifyService
  ) { }

  ngOnInit(): void {
    this.student.Courses = [];
    this.addCourseForm();
  }

}

