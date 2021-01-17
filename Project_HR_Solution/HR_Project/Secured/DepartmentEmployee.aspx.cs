using HR_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Project.Secured
{
    public partial class DepartmentEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string GetDeptName(int id)
        {
            return new DbDataAccess().GetDeptName(id);
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.HeaderRow != null)
            {
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridView1.HeaderRow.CssClass = "thead-light";
            }
        }
    }
}