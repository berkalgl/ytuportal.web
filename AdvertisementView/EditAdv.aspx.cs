using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web.AdvertisementView
{
    public partial class EditAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var advId = Convert.ToInt32(Request.QueryString["AdvId"]);
                AdvertisementController advcontroller = new AdvertisementController();
                var currrent_adv = advcontroller.GetAdvById(advId);


                Adv_AttController adv_attcontroller = new Adv_AttController();
                var levels = adv_attcontroller.GetAdvLevels();
                var styles = adv_attcontroller.GetAdvStyles();

                EditDdlLevels.DataTextField = "Name";
                EditDdlLevels.DataValueField = "Id";
                EditDdlLevels.DataSource = levels;
                EditDdlLevels.DataBind();

                EditDdlStyle.DataTextField = "Name";
                EditDdlStyle.DataValueField = "Id";
                EditDdlStyle.DataSource = styles;
                EditDdlStyle.DataBind();

                CName.Text = currrent_adv.Company.ComName.ToString();

                EditPosition.Text = currrent_adv.Position;
                EditAdvTitle.Text = currrent_adv.Title;
                EditAdvDefinition.Text = currrent_adv.Definition;
                EditAdvAttribute.Text = currrent_adv.Attribute;
                EditAdvPlace.Text = currrent_adv.Place;
                EditAdvSector.Text = currrent_adv.Sector;
                EditAdvFirstDate.Text = currrent_adv.Firstdate;
                EditAdvLastDay.Text = currrent_adv.Lastdate;
                RadioBtnEditStatus.Text = currrent_adv.Status;

            }
        }

        protected void EditAdvBtn_Click(object sender, EventArgs e)
        {
            AdvertisementController advcontroller = new AdvertisementController();
            var editadvid = Convert.ToInt32(Request.QueryString["AdvId"]);
            var editadv = advcontroller.GetAdvById(editadvid);

            var result = advcontroller.EditAdvertisement(new Models.Advertisements()
            {
                Id = editadv.Id,
                Position = EditPosition.Text.Trim(),
                Title = EditAdvTitle.Text.Trim(),
                Definition = EditAdvDefinition.Text.Trim(),
                Attribute = EditAdvAttribute.Text.Trim(),
                Place = EditAdvPlace.Text.Trim(),
                Sector = EditAdvSector.Text.Trim(),
                Firstdate = EditAdvFirstDate.Text.Trim(),
                Lastdate = EditAdvLastDay.Text.Trim(),
                Level = new Models.Adv_Level()
                {
                    Id = Convert.ToInt32(EditDdlLevels.SelectedValue)
                },
                Style = new Models.Adv_Style()
                {
                    Id = Convert.ToInt32(EditDdlStyle.SelectedValue)
                },
                Status = RadioBtnEditStatus.Text
            });
            Literal1.Text = result;

        }
    }
}