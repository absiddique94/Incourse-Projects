using HR_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Project.DAL
{
    public class DbDataAccess
    {
        HRDbContext db = new HRDbContext();
        public IQueryable<Department> GetDepartments(string sortExpression,int startRowIndex, int maximumRows)
        {
            List<Department> data=null;
            if (string.IsNullOrEmpty(sortExpression))
            {
                data = db.Departments.OrderBy(x => x.DepartmentId).ToList();
            }
            else if(sortExpression == "DepartmentId")
            {
                data = db.Departments.OrderBy(x => x.DepartmentId).ToList();
            }
            else if (sortExpression == "DepartmentId DESC")
            {
                data = db.Departments.OrderByDescending(x => x.DepartmentId).ToList();
            }
            else if (sortExpression == "DepartmentName")
            {
                data = db.Departments.OrderBy(x => x.DepartmentName).ToList();
            }
            else
            {
                data = db.Departments.OrderByDescending(x => x.DepartmentName).ToList();
            }
            return data  
                .Skip(startRowIndex)
                .Take(maximumRows)
                .AsQueryable();
        }
        public int GetDepartmentCount()
        {
            return db.Departments.Count();
        }
        public void InsertDepartment(Department d)
        {
            db.Departments.Add(d);
            db.SaveChanges();

        }
        public void UpdateDepartment(Department d)
        {
            var dept = db.Departments.First(x => x.DepartmentId== d.DepartmentId);
            dept.DepartmentName = d.DepartmentName;
            db.SaveChanges();
        }
        public void Delete(Department d)
        {
            var dept = db.Departments.First(x => x.DepartmentId == d.DepartmentId);
            db.Departments.Remove(dept);
            db.SaveChanges();
        }
        public string GetDeptName(int id)
        {
            return db.Departments.First(x => x.DepartmentId == id).DepartmentName;
        }
        public IQueryable<Employee> GetEmplyeesOfDept(int id)
        {
            return db.Employees.Where(x => x.DepartmentId == id).AsQueryable();
        }
        public IQueryable<Department> GetDepartmentList()
        {
            return db.Departments;
        }
      
        
        public int GetEmployeeCount()
        {
            return db.Employees.Count();
        }
        public IQueryable<Employee> GetEmployees(string sortExpression,int startRowIndex, int maximumRows)
        {
            List<Employee> data = null;
            if (string.IsNullOrEmpty(sortExpression)) {
                data = db.Employees.OrderBy(x => x.EmployeeId).ToList();
            }
            else if (sortExpression== "EmployeeId")
            {
                data = db.Employees.OrderBy(x => x.EmployeeId).ToList();
            }
            else if (sortExpression == "EmployeeId DESC")
            {
                data = db.Employees.OrderByDescending(x => x.EmployeeId).ToList();
            }
            else if (sortExpression == "EmployeeName")
            {
                data = db.Employees.OrderBy(x => x.EmployeeName).ToList();
            }
            else if (sortExpression == "EmployeeName DESC")
            {
                data = db.Employees.OrderByDescending(x => x.EmployeeName).ToList();
            }
            else if (sortExpression == "BasicSalary")
            {
                data = db.Employees.OrderBy(x => x.BasicSalary).ToList();
            }
            else 
            {
                data = db.Employees.OrderByDescending(x => x.BasicSalary).ToList();
            }
            return data
                .Skip(startRowIndex)
               .Take(maximumRows)
                .AsQueryable();
        }
        public void InsertEmployee(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();

        }
        public void UpdateEmployee(Employee e)
        {
            var emp = db.Employees.First(x => x.EmployeeId ==e.EmployeeId);
            emp.EmployeeName = e.EmployeeName;
            emp.Email = e.Email;
            emp.BasicSalary = e.BasicSalary;
            emp.DepartmentId = e.DepartmentId;
            db.SaveChanges();
        }
        public void DeleteEmployee(Employee e)
        {
            var emp = db.Employees.First(x => x.EmployeeId == e.EmployeeId);
            db.Employees.Remove(emp);
            db.SaveChanges();
        }
    }
}