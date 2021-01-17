using HR_Project.DAL;
using HR_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Project.Secured
{
    public partial class ReportCR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HRDbContext db = new HRDbContext();
            CREmployee rpt = new CREmployee();
            var data = db.Employees.Select(x => new EmployeeDataModel { EmployeeId = x.EmployeeId, EmployeeName = x.EmployeeName, Email = x.Email, BasicSalary = x.BasicSalary, DepartmentId = x.DepartmentId, DepartmentName = x.Department.DepartmentName })
                .ToList();
            rpt.SetDataSource(data);
            CrystalReportViewer1.ReportSource = rpt;
            CrystalReportViewer1.RefreshReport();
        }
    }
}