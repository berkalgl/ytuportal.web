using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;
using ytuportal.web.Models;

namespace ytuportal.web
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CityController citycontroller = new CityController();

                var cities = citycontroller.GetCities();

                DropDownCityList.DataTextField = "Name";
                DropDownCityList.DataValueField = "Id";
                DropDownCityList.DataSource = cities;
                DropDownCityList.DataBind();



                var userid = Convert.ToInt32(Session["UserId"]);
                UserController userController = new UserController();

                var currentUser = userController.GetUserById(userid);


                EditFname.Text = currentUser.Fname;
                EditLname.Text = currentUser.Sname;
                EditEmail.Text = currentUser.Email;
                EditBday.Text = currentUser.Birthday;
                EditAddress.Text = currentUser.Address;
                EditDistrict.Text = currentUser.District;
                EditPhone.Text = currentUser.Phone;
                EditPosition.Text = currentUser.Position;
                EditDepartment.Text = currentUser.Departman;
                EditUni.Text = currentUser.University;
                //EditPhoto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])currentUser.Photo);
            }
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            UserController userControllerEdit = new UserController();
            var edituserid = Convert.ToInt32(Session["UserId"]);
            var editcurrentUser = userControllerEdit.GetUserById(edituserid);
            int length = EditImage.PostedFile.ContentLength;
            byte[] Uptadedpic = new byte[length];
            EditImage.PostedFile.InputStream.Read(Uptadedpic, 0, length);


            string filename = Path.GetFileName(CvUpload.PostedFile.FileName);
            string contentType = CvUpload.PostedFile.ContentType;
            using (Stream fs = CvUpload.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "UPDATE CVs SET Name = @Name,  ContentType =@ContentType, Data = @Data WHERE UserId= @UserId";
                        using (SqlCommand com = new SqlCommand(query))
                        {
                            com.Connection = con;
                            com.Parameters.AddWithValue("@Name", filename);
                            com.Parameters.AddWithValue("@ContentType", contentType);
                            com.Parameters.AddWithValue("@Data", bytes);
                            com.Parameters.AddWithValue("@UserId", edituserid);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                 }
            
            }

                var result2 = userControllerEdit.EditUser(new Users()
                {
                    Id = editcurrentUser.Id,
                    Fname = EditFname.Text.Trim(),
                    Sname = EditLname.Text.Trim(),
                    Email = EditEmail.Text.Trim(),
                    Birthday = EditBday.Text.Trim(),
                    Address = EditAddress.Text.Trim(),
                    District = EditDistrict.Text.Trim(),
                    City = new Models.Cities()
                    {
                        id = Convert.ToInt32(DropDownCityList.SelectedValue)
                    },
                    Phone = EditPhone.Text.Trim(),
                    Position = EditPosition.Text.Trim(),
                    Departman = EditDepartment.Text.Trim(),
                    University = EditUni.Text.Trim(),
                    Photo = Uptadedpic,
                    Gender = RadioBtnEditGender.Text,
                    Password = editcurrentUser.Password
                });

            
            Literal2.Text = result2;
        }

        protected void ChangePassBtn_Click(object sender, EventArgs e)
        {
            UserController usercontroller = new UserController();
            var passuserid = Convert.ToInt32(Request.QueryString["UserId"]);
            var passcurrentUser = usercontroller.GetUserById(passuserid);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            SqlCommand com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "UPDATE Users SET password = @password where Id = @Id";

            com.Parameters.AddWithValue("@Id", passuserid);
            com.Parameters.AddWithValue("@password", EditPassword.Text);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                Literal2.Text = ex.Message;
            }

            Literal2.Text = "You changed your password successfully";

        }

        protected void ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = !String.IsNullOrEmpty(confirmPassword.Text);

        }
    }
}