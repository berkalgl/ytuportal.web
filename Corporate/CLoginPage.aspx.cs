using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web.Corporate
{
    public partial class CLoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReqDiv.Visible = false;
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            EmployeeController empController = new EmployeeController();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            con.Open();
            string checkuser = "SELECT COUNT(*) FROM Employee where EmployeeEmail = '" + TextEmail.Text + "'";


            SqlCommand com = new SqlCommand(checkuser, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

            con.Close();




            if (temp == 1)
            {
                con.Open();
                string CheckPasswordQuery = "SELECT EmployeePassword FROM Employee where EmployeeEmail ='" + TextEmail.Text + "'";
                SqlCommand passCom = new SqlCommand(CheckPasswordQuery, con);
                string CheckPassword = passCom.ExecuteScalar().ToString();

                string GetTheEmployeeQuery = "SELECT EmployeeID FROM Employee where  EmployeeEmail ='" + TextEmail.Text + "'";
                SqlCommand TheEmployeeIdCom = new SqlCommand(GetTheEmployeeQuery, con);
                int TheEmployeeId = Convert.ToInt32(TheEmployeeIdCom.ExecuteScalar());

                if (CheckPassword == TextPassword.Text)
                {
                    var employee = empController.GetEmployeeById(TheEmployeeId);
                    Session["EmployeeName"] = employee.EmpName.ToString();
                    Session["EmployeeEmail"] = employee.EmpEmail.ToString();
                    Session["EmployeeCompany"] = employee.EmpComName.ToString();
                    Session["EmployeeId"] = employee.EmpID.ToString();
                    Response.Redirect("/Corporate/CHomePage.aspx?EmployeeId=" + employee.EmpID.ToString());
                }
                else
                {
                    ReqDiv.Visible = true;
                    ReqControl.Text = ("Invalid Email or Password");
                }
            }
            else
            {
                ReqDiv.Visible = true;
                ReqControl.Text = ("Invalid Email or Password");
            }


        }
    }
}