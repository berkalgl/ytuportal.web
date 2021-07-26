using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web.Corporate
{
    public partial class CPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            EmployeeController empcontroller = new EmployeeController();
            var passempid = Convert.ToInt32(Session["EmployeeId"]);
            var passcurrentemp = empcontroller.GetEmployeeById(passempid);
            string result;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            SqlCommand com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "UPDATE Employee SET EmployeePassword = @EmployeePassword where EmployeeID = @EmployeeID";

            com.Parameters.AddWithValue("@EmployeeID", passempid);
            com.Parameters.AddWithValue("@EmployeePassword", EditPassword.Text);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                result = ex.Message;
            }

            result = "You changed your password successfully";

            if (result == "You changed your password successfully")
            {
                ReqCheck.ForeColor = Color.Green;
                ReqCheck.Text = result;
            }
            else
            {
                ReqCheck.ForeColor = Color.Red;
                ReqCheck.Text = result;
            }

            
        }

        protected void confirmPassword_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = !String.IsNullOrEmpty(confirmPassword.Text);
        }
    }
}