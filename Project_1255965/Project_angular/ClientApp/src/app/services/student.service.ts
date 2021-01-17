import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from '../models/student';
import { dataUrl } from '../shared/common/constants';
import { Course } from '../models/course';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }
  getWithCourse(): Observable<Student[]> {
    return this.http.get<Student[]>(`${dataUrl}/StudentData/StudentsWithCourse`);
  }
  getWithCourseById(id: number): Observable<Student> {
    return this.http.get<Student>(`${dataUrl}/StudentData/StudentsWithCourseById/${id}`);
  }
  insert(t: Student): Observable<Student> {
    // console.log(t);
    return this.http.post<Student>(`${dataUrl}/StudentData/InsertStudentsWithCourse`, t);
  }
  update(t: Student): Observable<Student> {
    return this.http.put<Student>(`${dataUrl}/StudentData/UpdateStudentsWithCourse/${t.StudentId}`, t);
  }
  delete(id: number): Observable<Student> {
    return this.http.delete<Student>(`${dataUrl}/StudentData/DeleteStudent/${id}`);
  }
  deleteCourse(id: number): Observable<Course> {
    return this.http.delete<Course>(`${dataUrl}/CourseData/DeleteCourse/${id}`);
  }
}
