using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Work_01
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetLastVisit();
        }
        public void GetLastVisit()
        {
            if (Request.Cookies["UserData"] == null)
            {
                this.Literal1.Text = "You are visting first time";
            }
            else
            {
                var cookie1 = Request.Cookies["UserData"];
                this.Literal1.Text = cookie1.Values["LastVist"].ToString();
            }
            var cookie = new HttpCookie("UserData");
            cookie.Values.Add("LastVist", DateTime.Now.ToString());
            cookie.Expires = DateTime.Now.AddDays(14);
            Response.Cookies.Add(cookie);
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            var authManager = HttpContext.Current.GetOwinContext().Authentication;
            authManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}