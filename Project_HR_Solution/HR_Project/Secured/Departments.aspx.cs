using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Project.Secured
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
        }

        protected void lvDepartments_Sorting(object sender, ListViewSortEventArgs e)
        {
            Debug.WriteLine(e.SortExpression);
        }
    }
}