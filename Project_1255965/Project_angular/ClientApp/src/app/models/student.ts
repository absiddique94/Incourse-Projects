import { Course } from './course';
import { MatTableDataSource } from '@angular/material/table';

export class Student {
  constructor(
    public StudentId?: number,
    public StudentName?: string,
    public Description?: string,
    public FemaleAllowed?: boolean,
    public Courses?: Course[] | MatTableDataSource<Course>
  ) { }
}
export interface StudentDataSource {
  StudentId?: number;
  StudentName?: string;
  Description?: string;
  FemaleAllowed?: boolean;
  Courses?: MatTableDataSource<Course>;
}
