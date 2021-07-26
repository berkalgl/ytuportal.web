using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;

namespace ytuportal.web.Corporate
{
    public partial class CRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RBtn_Click(object sender, EventArgs e)
        {
            string EmployeeName = string.Empty;
            string EmployeePassword = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT EmployeeName, EmployeePassword FROM Employee WHERE EmployeeEmail = @EmployeeEmail"))
                {
                    cmd.Parameters.AddWithValue("@EmployeeEmail", REmail.Text.Trim());
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            EmployeeName = sdr["EmployeeName"].ToString();
                            EmployeePassword = sdr["EmployeePassword"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            if (!string.IsNullOrEmpty(EmployeePassword))
            {
                MailMessage mm = new MailMessage("ytucareer@gmail.com", REmail.Text.Trim());
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", EmployeeName, EmployeePassword);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "ytucareer@gmail.com";
                NetworkCred.Password = "ytucareer123";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ReqEmail.ForeColor = Color.Green;
                ReqEmail.Text = "Password has been sent to your email address.";
            }
            else
            {
                ReqEmail.ForeColor = Color.Red;
                ReqEmail.Text = "This email address does not match our records.";
            }
        }
    }
}