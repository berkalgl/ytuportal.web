using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ytuportal.web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                NavRig.Visible = false;
                UserNav.Visible = true;
                UserName.Text = Session["UserName"].ToString();
                UserNameSurname.Text = Session["UserName"].ToString() + " " + Session["UserSurname"].ToString();
                UserEmail.Text = Session["UserEmail"].ToString();
                ProfileLink.NavigateUrl = "/UserPage.aspx";
            }
            else
            {
                UserNav.Visible = false;
                NavRig.Visible = true;
            }

        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            Response.Redirect("/Default.aspx");
        }
    }
}