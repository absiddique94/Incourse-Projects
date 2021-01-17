using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_angularJS.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
        }
        [Display(Name = "ID")]
        public int StudentId { get; set; }
        [Required, StringLength(30), Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Required, StringLength(150), Display(Name = "Student Description")]
        public string Description { get; set; }
        [Display(Name = "Female Allowed")]
        public bool FemaleAllowed { get; set; }

        //
        public virtual ICollection<Course> Courses { get; set; }
    }
    public class Course
    {

        [Display(Name = "Course ID")]
        public int CourseId { get; set; }
        [Required, StringLength(40), Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Required, Display(Name = "Duration (Hrs)")]
        public int Duration { get; set; }

        [Required, ForeignKey("Student"), Display(Name = "Student")]
        public int StudentId { get; set; }
        //
        public virtual Student Student { get; set; }

    }

    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
