using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                //CityController citycontroller = new CityController();

                //var cities = citycontroller.GetCities();

                //CitiesDDlist.DataTextField = "Name";
                //CitiesDDlist.DataValueField = "Id";
                //CitiesDDlist.DataSource = cities;
                //CitiesDDlist.DataBind();
            }
            FillPage();
           
        }

        private void FillPage()
        {
            AdvertisementController advcontroller = new AdvertisementController();
            var adv = advcontroller.GetAdvertisements();

            rptAdv.DataSource = adv;
            rptAdv.DataBind();
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            AdvertisementController advcontroller = new AdvertisementController();
            var adv = advcontroller.SearchAdvertisement(SearchBox.Text.ToString());
            rptAdv.DataSource = adv;
            rptAdv.DataBind();
        }
    }
   
}