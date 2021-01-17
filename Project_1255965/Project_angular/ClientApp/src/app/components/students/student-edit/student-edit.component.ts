import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Course } from 'src/app/models/course';
import { throwError } from 'rxjs';
import { StudentService } from 'src/app/services/student.service';
import { NotifyService } from 'src/app/services/notify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css'],
  styles: [
    `
    :host {
        display:block;
        width:100%;
    }`
  ]
})
export class StudentEditComponent implements OnInit {

  student: Student = null;
  studentForm: FormGroup = new FormGroup({
    StudentName: new FormControl('', Validators.required),
    Description: new FormControl('', Validators.required),
    FemaleAllowed: new FormControl(''),
    Courses: new FormArray([]),
    NewCourses: new FormArray([])
  });
  removeItem(index: number) {
    (this.student.Courses as Course[]).splice(index, 1);
  }
  onSubmit() {
    if (this.studentForm.controls.StudentName.invalid ||
      this.studentForm.controls.Description.invalid ||
      (this.student.Courses as Course[]).length == 0
    ) return;
    this.student.StudentName = this.studentForm.controls.StudentName.value;
    this.student.Description = this.studentForm.controls.Description.value;
    this.student.FemaleAllowed = this.studentForm.controls.FemaleAllowed.value;
    let i = 0;
    for (let x of this.CourseArray.controls) {
      console.log();
      (this.student.Courses as Course[])[i].Duration = x.get("Duration").value;
      (this.student.Courses as Course[])[i].CourseName = x.get("CourseName").value;
      i++;
    }
    console.log(this.student);

    this.studentService.update(this.student)
      .subscribe(x => {
        this.notifyService.message("Data Saved successfully", 'DISMISS');

        this.studentForm.markAsUntouched();
        this.studentForm.markAsPristine();
        this.student = new Student();


      }, err => {
          this.notifyService.message("Could not insert data.", 'DISMISS');
          return throwError(err);
      })
  }
  addCourseForm() {
    (this.studentForm.get('NewCourses') as FormArray).push(
      new FormGroup({
        CourseName: new FormControl('', Validators.required),
        Duration: new FormControl('', Validators.required)
      }));
  }
  addCourseToStudent() {
    console.log(this.NewCourseArray.controls[0].value);
    let course = new Course();
    Object.assign(course, this.NewCourseArray.controls[0].value);
    (this.student.Courses as Course[]).push(course);
    (this.studentForm.get('Courses') as FormArray).push(
      new FormGroup({
        CourseName: new FormControl(course.CourseName, Validators.required),
        Duration: new FormControl(course.Duration, Validators.required)
      }));
    this.NewCourseArray.controls[0].reset({});
    this.NewCourseArray.controls[0].markAsPristine();
    this.NewCourseArray.controls[0].markAsUntouched();
  }
  get CourseArray() {
    return this.studentForm.get("Courses") as FormArray;
  }
  get NewCourseArray() {
    return this.studentForm.get("NewCourses") as FormArray;
  }
  initForm() {
    this.studentForm.setValue({
      StudentName: this.student.StudentName,
      Description: this.student.Description,
      FemaleAllowed: this.student.FemaleAllowed,
      Courses: [],
      NewCourses: []
    });
    for (let x of this.student.Courses as Course[]) {
      (this.studentForm.get('Courses') as FormArray).push(
        new FormGroup({
          CourseName: new FormControl(x.CourseName, Validators.required),
          Duration: new FormControl(x.Duration, Validators.required)
        }));
    }
    this.addCourseForm();
  }
  removeCourseItem(index: number) {
    this.CourseArray.removeAt(index);
  }
  constructor(
    private studentService: StudentService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.params.id;
    console.log(id);
    this.studentService.getWithCourseById(id)
      .subscribe(x => {
        console.log(x);
        this.student = x;
        this.initForm();
      }, err => {
        this.notifyService.message("Failed to fetch student data.", 'DISMISS');
        return throwError(err);
      })

  }


}
