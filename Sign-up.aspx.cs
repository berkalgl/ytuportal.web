using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web
{
    public partial class Sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertdiv.Visible = false;
        }

        public void Refress()
        {
            TextEmail.Text = "";
            TextName.Text = "";
            TextSurname.Text = "";
            TextPassword.Text = "";
        }

        protected void AddUserBtn_Click(object sender, EventArgs e)
        {

            if (TextName.Text != "" && TextSurname.Text != "" && TextEmail.Text != "" && TextPassword.Text !="")
            {
                UserController usercontroller = new UserController();
                var checkuser = usercontroller.CheckUser(TextEmail.Text);

                if(checkuser == 0)
                {
                    var result = usercontroller.InsertUser(new Models.Users()
                    {
                        Fname = TextName.Text.Trim(),
                        Sname = TextSurname.Text.Trim(),
                        Email = TextEmail.Text.Trim(),
                        Password = TextPassword.Text.Trim(),
                    });

                    var user = usercontroller.GetUserByEmail(TextEmail.Text);

                    CVController cvcontroller = new CVController();
                    var result2 = cvcontroller.InsertNullCV(new Models.CV()
                    {
                        UserId = new Models.Users()
                        {
                            Id = Convert.ToInt32(user.Id)
                        }
                    });
                    Literal1.Text = result;

                    Response.Redirect("/LoginPage.aspx");
                }
                else
                {
                    Refress();
                    alertdiv.Visible = true;
                    Literal2.Text = "This mail address has been taken";
                }
            }
            else
            {
                Refress();
                alertdiv.Visible = true;
                Literal2.Text = "Please fulfill all the blanks";
            }

           

        }
    }
}