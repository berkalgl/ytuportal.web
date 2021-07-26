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

namespace ytuportal.web
{
    public partial class UserRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RecBtn_Click(object sender, EventArgs e)
        {
            string Name = string.Empty;
            string Password = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT fname, sname, password FROM Users WHERE email = @email"))
                {
                    cmd.Parameters.AddWithValue("@email", RecEmail.Text.Trim());
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            Name = sdr["fname"].ToString() + "" + sdr["sname"].ToString();
                            Password = sdr["password"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            if (!string.IsNullOrEmpty(Password))
            {
                MailMessage mm = new MailMessage("ytucareer@gmail.com", RecEmail.Text.Trim());
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", Name, Password);
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