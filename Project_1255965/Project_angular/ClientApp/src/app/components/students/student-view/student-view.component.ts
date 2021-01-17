import { Component, OnInit, ViewChild, ViewChildren, QueryList, ChangeDetectorRef } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Course } from 'src/app/models/course';
import { MatPaginator } from '@angular/material/paginator';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student.service';
import { NotifyService } from 'src/app/services/notify.service';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from '../../common/delete-dialog/delete-dialog.component';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-student-view',
  templateUrl: './student-view.component.html',
  styleUrls: ['./student-view.component.css'],
  styles: [
    `
    :host {
        display:block;
        width:100%;
    }`
  ],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class StudentViewComponent implements OnInit {
  @ViewChild('outerSort', { static: true }) sort: MatSort;
  @ViewChildren('innerSort') innerSort: QueryList<MatSort>;
  @ViewChildren('innerTables') innerTables: QueryList<MatTable<Course>>;
  @ViewChild(MatPaginator, { static: false }) paginator;
  //set paginator(value: MatPaginator) {
  //  this.dataSource.paginator = value;
  //}
  //dataSource: MatTableDataSource<User>; //
  dataSource: MatTableDataSource<Student>;
  //usersData: User[] = []; //
  studentsData: Student[] = [];
  columnsToDisplay = ['select', 'StudentName', 'Description', 'FemaleAllowed', 'actions']; 
  innerDisplayedColumns = ['CourseName', 'Duration', 'actions']; 
  expandedElement: Student | null; 
  constructor(
    private studentService: StudentService,
    private notifyService: NotifyService,
    private deleteDialog: MatDialog,
    private cd: ChangeDetectorRef
  ) { }
  initTable(data: Student[]) {
    this.dataSource = new MatTableDataSource(data);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
  confirmDelete(item: Student) {
    let dialogRef = this.deleteDialog.open(DeleteDialogComponent, {
      width: '450px'
    });

    dialogRef.afterClosed().subscribe(
      result => {
        if (result) {
          this.studentService.delete(item.StudentId)
            .subscribe(x => {
              this.dataSource.data = this.dataSource.data.filter(data => data.StudentId != item.StudentId);
              this.notifyService.message("Data deleted.", ["DISMISS"])
            });
        }
        else { console.log("let it go"); }
      }
    );
  }
  confirmDeleteCourse(item: Course) {
    console.log(this.expandedElement);
    console.log(item);
    let dialogRef = this.deleteDialog.open(DeleteDialogComponent, {
      width: '450px'
    });

    dialogRef.afterClosed().subscribe(
      result => {
        if (result) {
          this.studentService.deleteCourse(item.CourseId)
            .subscribe(x => {
              let ds = this.expandedElement.Courses as MatTableDataSource<Course>;
              ds.data = ds.data.filter(data => data.CourseId != item.CourseId);
              this.notifyService.message("Data deleted.", ["DISMISS"])
            });
        }
        else { console.log("let it go"); }
      }
    );
  }
  ngOnInit() {


    this.studentService.getWithCourse()
      .subscribe(x => {
        this.studentsData = x;
        //USERS.forEach(user => {
        //  if (user.addresses && Array.isArray(user.addresses) && user.addresses.length) {
        //    this.usersData = [...this.usersData, { ...user, addresses: new MatTableDataSource(user.addresses) }];
        //  } else {
        //    this.usersData = [...this.usersData, user];
        //  }
        //});
        this.studentsData.forEach(student => {
          if ((student.Courses as Course[]).length == 0) student.Courses = null;
          if (student.Courses && Array.isArray(student.Courses) && student.Courses.length) {
            student.Courses = new MatTableDataSource(student.Courses);
          }
        });
        console.log(this.studentsData);
        this.initTable(this.studentsData);



      }, err => {
          console.log(err);
          return throwError(err);
      })

  }

  toggleRow(element: Student) {
    element.Courses && (element.Courses as MatTableDataSource<Course>).data.length ? (this.expandedElement = this.expandedElement === element ? null : element) : null;
    this.cd.detectChanges();
    this.innerTables.forEach((table, index) => (table.dataSource as MatTableDataSource<Course>).sort = this.innerSort.toArray()[index]);
  }

  applyFilter(filterValue: string) {
    //this.innerTables.forEach((table, index) => (table.dataSource as MatTableDataSource<Address>).filter = filterValue.trim().toLowerCase());
    this.dataSource.filter = filterValue.trim().toLowerCase()
  }

}


