import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Course } from '../models/course';
import { Student } from '../models/student';
import { dataUrl } from '../shared/common/constants';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http: HttpClient) { }
  get(): Observable<Course[]> {
    return this.http.get<Course[]>(`${dataUrl}/CourseData/GetCourses`);
  }
  getById(id: number): Observable<Course> {
    return this.http.get<Course>(`${dataUrl}/CourseData/GetCourseById/${id}`);
  }
  getStudentOptions(): Observable<Student[]> {
    return this.http.get<Student[]>(`${dataUrl}/CourseData/GetStudentsForDropDown`);
  }
  insert(c: Course): Observable<Course> {
    return this.http.post<Course>(`${dataUrl}/CourseData/InsertCourse`, c);
  }
  update(c: Course): Observable<Course> {
    return this.http.put<Course>(`${dataUrl}/CourseData/UpdateCourse/${c.CourseId}`, c);
  }
  delete(id: number): Observable<Course> {
    return this.http.delete<Course>(`${dataUrl}/CourseData/DeleteCourse/${id}`);
  }
}
