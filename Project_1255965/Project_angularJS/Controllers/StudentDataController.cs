using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_angularJS.Models;

namespace Project_angularJS.Controllers
{
    [Produces("application/json")]

    public class StudentDataController : Controller
    {
        CourseDbContext db;
        public StudentDataController(CourseDbContext db) { this.db = db; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudentsWithCourse()
        {
            var data = db.Students.Include(x => x.Courses).ToList();

            return Json(data);

        }
        [HttpGet]
        public IActionResult StudentsWithCourseById(int id)
        {
            var data = db.Students.Include(x => x.Courses).First(x => x.StudentId == id);

            return Json(data);

        }
        [HttpPost]
        public IActionResult InsertStudentsWithCourse([FromBody]Student t)
        {
            db.Students.Add(t);
            db.SaveChanges();

            return Json(t);

        }
        [HttpPut]
        public IActionResult UpdateStudentsWithCourse(int id, [FromBody]Student t)
        {
            var original = db.Students.Include(x => x.Courses).First(x => x.StudentId == id);
            original.StudentName = t.StudentName;
            original.Description = t.Description;
            original.FemaleAllowed = t.FemaleAllowed;
            if (t.Courses != null && t.Courses.Count > 0)
            {
                var crs = t.Courses.ToArray();
                for (var i = 0; i < crs.Length; i++)
                {
                    var temp = original.Courses.FirstOrDefault(c => c.CourseId == crs[i].CourseId);
                    if (temp != null)
                    {
                        temp.CourseName = crs[i].CourseName;
                        temp.Duration = crs[i].Duration;
                    }
                    else
                    {
                        original.Courses.Add(crs[i]);
                    }
                }
                crs = original.Courses.ToArray();
                for (var i = 0; i < crs.Length; i++)
                {
                    var temp = t.Courses.FirstOrDefault(x => x.CourseId == crs[i].CourseId);
                    if (temp == null)
                        db.Entry(crs[i]).State = EntityState.Deleted;
                }
            }

            db.SaveChanges();

            return Json(t);

        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var original = db.Students.First(x => x.StudentId == id);
            db.Students.Remove(original);
            db.SaveChanges();
            return Json(original);
        }
    }
}