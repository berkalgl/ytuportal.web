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
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userid = Convert.ToInt32(Session["UserId"]);
                UserController usercontroller = new UserController();

                var currentUser = usercontroller.GetUserById(userid);

                if(currentUser.Photo == null)
                {
                    UserPhoto.ImageUrl = "/UploadedItems/765-default-avatar.png";
                }
                else
                {
                    UserPhoto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])currentUser.Photo);
                }

                UserInterests.Text = currentUser.Info;
                UserName.Text = currentUser.Fname +" "+ currentUser.Sname;
                UserPosition.Text = currentUser.Position;
                UserBday.Text = currentUser.Birthday;
                UserEmail.Text = currentUser.Email;
                UserTel.Text = currentUser.Phone;
                EditLink.NavigateUrl = "/EditPage";
                if(currentUser.City == null && currentUser.District == null)
                {
                    UserAddress.Text = "";
                }
                else if(currentUser.City != null)
                {
                    UserAddress.Text = currentUser.City.name;
                }
                else if(currentUser.District != null)
                {
                    UserAddress.Text = currentUser.District;
                }
                else
                {
                    UserAddress.Text = currentUser.District + "/" + currentUser.City.name;
                }

                if (currentUser.Departman == null && currentUser.University == null)
                {
                    UserEducation.Text = "";
                }
                else if(currentUser.Departman != null)
                {
                    UserEducation.Text = currentUser.Departman;
                }
                else if(currentUser.University != null)
                {
                    UserEducation.Text = currentUser.University;
                }
                else
                {
                    UserEducation.Text = currentUser.Departman + "/" + currentUser.University;
                }
                

            }

        }

        protected void DownloadCv_Click(object sender, EventArgs e)
        {

            var userid = Convert.ToInt32(Request.QueryString["UserId"]);
            UserController usercontroller = new UserController();

            var currentUser = usercontroller.GetUserById(userid);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Name, Data, ContentType from CVs where UserId=@Id";
                    cmd.Parameters.AddWithValue("@Id", userid);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}