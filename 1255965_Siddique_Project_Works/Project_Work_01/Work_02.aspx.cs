using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Work_01
{
    public partial class Work_02 : System.Web.UI.Page
    {
        public object ListView1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            FileUpload fu = e.Item.FindControl("FileUpload1") as FileUpload;
            if (fu.HasFile)
            {
                if (fu.PostedFile.ContentLength > 0)
                {
                    string ex = Path.GetExtension(fu.PostedFile.FileName);
                    string f = Guid.NewGuid() + ex;
                    fu.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + f);
                    e.Values["Picture"] = f;
                }
            }
        }

        protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            FileUpload fu = ListView1.EditItem.FindControl("FileUpload1") as FileUpload;
            if (fu.HasFile)
            {
                if (fu.PostedFile.ContentLength > 0)
                {
                    string ex = Path.GetExtension(fu.PostedFile.FileName);
                    string f = Guid.NewGuid() + ex;
                    fu.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + f);
                    e.NewValues["Picture"] = f;
                }
            }
        }
    }
}