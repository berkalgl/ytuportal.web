using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReqDiv.Visible = false;

            if(!IsPostBack)
            {
                HttpCookie cookie1 = Request.Cookies.Get("Email");
                HttpCookie cookie2 = Request.Cookies.Get("Password");
                HttpCookie cookie3 = Request.Cookies.Get("RememberMe");

                if (cookie1 != null || cookie2 != null || cookie3 != null)
                {
                    // Just Load the Values in TextBoxes From Cookies
                    TextEmail.Text = cookie1.Value.ToString();
                    TextPassword.Text = cookie2.Value.ToString();
                    RememberCheckBox.Checked = true;
                }
            }
           

        }

        protected void RememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RememberCheckBox.Checked == true)
            {
                Response.Cookies["Email"].Value = TextEmail.Text;
                Response.Cookies["Password"].Value = TextPassword.Text;
                Response.Cookies["RememberMe"].Value = "1";

            }
            else if (RememberCheckBox.Checked == false)
            {
                Response.Cookies.Remove("Email");
                Response.Cookies.Remove("Username");
                Response.Cookies.Remove("Password");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            UserController usercontroller = new UserController();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            con.Open();
            string checkuser = "SELECT COUNT(*) FROM Users where email = '" + TextEmail.Text + "'";
            

            SqlCommand com = new SqlCommand(checkuser, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

            con.Close();


            if (temp == 1)
            {
                con.Open();
                string CheckPasswordQuery = "SELECT password FROM Users where email ='" + TextEmail.Text + "'";
                SqlCommand passCom = new SqlCommand(CheckPasswordQuery, con);
                string CheckPassword = passCom.ExecuteScalar().ToString();

                if(CheckPassword == TextPassword.Text && RememberCheckBox.Checked == true)
                {
                    var user = usercontroller.GetUserByEmail(TextEmail.Text);
                    Session["UserName"] = user.Fname.ToString();
                    Session["UserSurname"] = user.Sname.ToString();
                    Session["UserEmail"] = user.Email.ToString();
                    Session["UserId"] = user.Id.ToString();

                    HttpCookie cookie = new HttpCookie("RememberMe", "1");
                    HttpCookie emailcookie = new HttpCookie("Email", TextEmail.Text);
                    HttpCookie passwordcookie = new HttpCookie("Password", TextPassword.Text);
                    emailcookie.Expires = DateTime.Now.AddHours(1);
                    passwordcookie.Expires = DateTime.Now.AddHours(1);
                    cookie.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(cookie);
                    Response.Cookies.Add(emailcookie);
                    Response.Cookies.Add(passwordcookie);

                    Response.Redirect("/Default.aspx");
                }
                else if (CheckPassword == TextPassword.Text )
                {
                    var user = usercontroller.GetUserByEmail(TextEmail.Text);
                    Session["UserName"] = user.Fname.ToString();
                    Session["UserSurname"] = user.Sname.ToString();
                    Session["UserEmail"] = user.Email.ToString();
                    Session["UserId"] = user.Id.ToString();
                    Response.Redirect("/Default.aspx");
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