using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;
using System.Drawing;

namespace ytuportal.web
{
    public partial class AppliedAdvertisements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }
        private void FillPage()
        {
            UserController usercontroller = new UserController();
            AdvertisementController advcontroller = new AdvertisementController();
            var candidates = usercontroller.GetCandidatesByUserId(Convert.ToInt32(Session["UserId"]));

            rptAdv.DataSource = candidates;
            rptAdv.DataBind();
            
        }

        public string GetClass(object Status)
        {
            if (Status.ToString() == "Passive")
            {
                return "alert alert-danger";
            }
            else
                return "alert alert-warning";
        }

        public string CheckStatus(object Status)
        {
            if(Status.ToString() == "Passive")
            {
                return "Your application has been refused...";
            }
            else
                return "Your application is still on check...";
        }
    }
}