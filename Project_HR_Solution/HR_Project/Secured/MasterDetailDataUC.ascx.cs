using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Project.Secured
{
    public partial class MasterDetailDataUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.HeaderRow != null)
            {
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                
            }
        }

        protected void GridView2_PreRender(object sender, EventArgs e)
        {
            if (GridView2.HeaderRow != null)
            {
                GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
               
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
                switch (e.CommandName)
                {
                    case "First":
                        { GridView1.PageIndex = 0; break; }
                    case "Next":
                        { GridView1.PageIndex++; break; }
                    case "Previous":
                        { GridView1.PageIndex--; break; }
                    case "Last":
                        { GridView1.PageIndex = GridView1.PageCount - 1; break; }
                }
                
            
        }
    }
}