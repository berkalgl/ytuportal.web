using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web.AdvertisementView
{
    public partial class ViewAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertdiv.Visible = false;
            if(!IsPostBack)
            {
                var advid = Convert.ToInt32(Request.QueryString["AdvId"]);
                AdvertisementController advcontroller = new AdvertisementController();
                var currentadv = advcontroller.GetAdvById(advid);

                ViewPosition.Text = currentadv.Position;
                ViewCompany.Text = currentadv.Company.ComName;
                ViewLocation.Text = currentadv.Place;
                ViewReleaseDate.Text = currentadv.Firstdate;
                ViewDefinition.Text = currentadv.Definition;
                ViewQua.Text = currentadv.Attribute;
                ViewPosition2.Text = currentadv.Position;
                ViewSector.Text = currentadv.Sector;
                ViewStyle.Text = currentadv.Style.Name;
                ViewLevel.Text = currentadv.Level.Name;
                ViewLocation2.Text = currentadv.Place;
                ViewRDate.Text = currentadv.Firstdate;
                ViewLDate.Text = currentadv.Lastdate;
            }
        }

        protected void ApplyBtn_Click(object sender, EventArgs e)
        {
            string result;

            if (Session["UserId"] != null)
            {
                var advid = Convert.ToInt32(Request.QueryString["AdvId"]);
                AdvertisementController advcontroller = new AdvertisementController();
                UserController usercontroller = new UserController();
                var currentuser = usercontroller.GetUserById(Convert.ToInt32(Session["UserId"]));
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
                var com = new SqlCommand();
                var com2 = new SqlCommand();

                com.Connection = con;
                com.CommandText = "INSERT INTO Candidates(UserId,AdvId,CStatus) values(@UserId,@AdvId,@CStatus)";
                com2.Connection = con;
                com2.CommandText = "UPDATE Advertisement SET Candidate = Candidate + 1 WHERE AdvId = @AdvId ";
                
                com.Parameters.AddWithValue("@UserId", currentuser.Id);
                com.Parameters.AddWithValue("@AdvId", advid);
                com.Parameters.AddWithValue("@CStatus", "Active");
                com2.Parameters.AddWithValue("@AdvId", advid);

                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    com2.ExecuteNonQuery();
                    con.Close();
                }

                catch (Exception ex)
                {
                    result = ex.Message;
                }

                alertdiv.Visible = true;
                result = "Application has been sent successfully";
                Literal1.Text = result;

            }
            else
            {
                alertdiv.Visible = true;
                result = "Please Log in";
                Literal1.Text = result;
            }
            
        }
    }
}