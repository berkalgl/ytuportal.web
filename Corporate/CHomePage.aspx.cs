using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web.Corporate
{
    public partial class CHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var empId = Convert.ToInt32(Request.QueryString["EmployeeId"]);
            FillPage();
        }
        private void FillPage()
        {
            var empId = Convert.ToInt32(Request.QueryString["EmployeeId"]);
            EmployeeController empcontroller = new EmployeeController();
            CompanyController comcontroller = new CompanyController();
            var currentcomid = comcontroller.GetCompanyById(empcontroller.GetEmployeeById(empId).EmpComID).ComID;
            AdvertisementController advcontroller = new AdvertisementController();
            var adv = advcontroller.GetAdvertisementsByCompanyId(currentcomid);

            rptAdv.DataSource = adv;
            rptAdv.DataBind();
        }
    }
}