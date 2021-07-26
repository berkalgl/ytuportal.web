using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ytuportal.web
{
    public partial class CMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["val"] == "logout")
            {
                Session.Remove("EmployeeName");
                Response.Redirect("/Corporate/CLoginPage.aspx");
            }

            if (Session["EmployeeName"] != null)
            {
                CorporateDefNav.Visible = false;
                CorporateNav.Visible = true;
                EmployeeName.Text = Session["EmployeeName"].ToString();
                EmployeeCompany.Text = Session["EmployeeCompany"].ToString();
                HyperLink1.NavigateUrl = "/Corporate/CHomePage.aspx?EmployeeId=" + Session["EmployeeId"].ToString();
                HyperLink2.NavigateUrl = "/Corporate/CHomePage.aspx?EmployeeId=" + Session["EmployeeId"].ToString();
            }
            else
            {
                CorporateDefNav.Visible = true;
                CorporateNav.Visible = false ;
            }

        }

        protected void AddAdv_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Corporate/CAddAdv.aspx?EmployeeId=" + Session["EmployeeId"].ToString());

        }
    }
}