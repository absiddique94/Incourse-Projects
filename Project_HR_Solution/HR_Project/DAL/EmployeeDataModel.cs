using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Project.DAL
{
    public class EmployeeDataModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}