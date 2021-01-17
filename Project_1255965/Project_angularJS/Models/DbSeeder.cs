using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_angularJS.Models
{
    public static class DbSeeder
    {
        public static void Seed(CourseDbContext db)
        {
            Student s1 = new Student { StudentName = "Asad Hossain", Description = "He is a good student", FemaleAllowed = false };
            s1.Courses.Add(new Course { CourseName = "Wood Work", Duration = 6 });
            s1.Courses.Add(new Course { CourseName = "Furniture Works", Duration = 6 });
            db.Students.Add(s1);
            db.SaveChanges();
        }
    }
}
