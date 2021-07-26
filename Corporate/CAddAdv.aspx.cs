using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web.Corporate
{
    public partial class CAddAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var empId = Convert.ToInt32(Request.QueryString["EmployeeId"]);
                EmployeeController empcontroller = new EmployeeController();
                var employee = empcontroller.GetEmployeeById(empId);
                

                Adv_AttController adv_attcontroller = new Adv_AttController();
                var levels = adv_attcontroller.GetAdvLevels();
                var styles = adv_attcontroller.GetAdvStyles();

                DdlLevels.DataTextField = "Name";
                DdlLevels.DataValueField = "Id"; 
                DdlLevels.DataSource = levels;
                DdlLevels.DataBind();

                DdlStyle.DataTextField = "Name";
                DdlStyle.DataValueField = "Id"; 
                DdlStyle.DataSource = styles;
                DdlStyle.DataBind();

                CName.Text = employee.EmpComName.ToString();


            }
        }

        protected void AddAdvBtn_Click(object sender, EventArgs e)
        {
            var empId = Convert.ToInt32(Request.QueryString["EmployeeId"]);
            EmployeeController empcontroller = new EmployeeController();
            var employee = empcontroller.GetEmployeeById(empId);
            AdvertisementController advcontroller = new AdvertisementController();

            var result = advcontroller.InsertAdvertisement(new Models.Advertisements()
            {
                Position = AddPosition.Text.Trim(),
                Level = new Models.Adv_Level()
                {
                    Id = Convert.ToInt32(DdlLevels.SelectedValue)
                },
                Title = AddAdvTitle.Text.Trim(),
                Definition = AddAdvDefinition.Text.Trim(),
                Attribute = AddAdvAttribute.Text.Trim(),
                Style = new Models.Adv_Style()
                {
                    Id = Convert.ToInt32(DdlStyle.SelectedValue)
                },
                Place = AddAdvPlace.Text.Trim(),
                Sector = AddAdvSector.Text.Trim(),
                Firstdate = AddAdvFirstDate.Text.Trim(),
                Company = new Models.Companies()
                {
                    ComID = employee.EmpComID
                }

            });

            Literal1.Text = result;
        }
    }
}