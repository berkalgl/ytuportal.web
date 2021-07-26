using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;

namespace ytuportal.web.Corporate
{
    public partial class CRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertdiv.Visible = false;
            if (!IsPostBack)
            {
                CityController citycontroller = new CityController();

                var cities = citycontroller.GetCities();

                DropDownCityList.DataTextField = "Name";
                DropDownCityList.DataValueField = "Id";
                DropDownCityList.DataSource = cities;
                DropDownCityList.DataBind();
            }

        }

        protected void AddEmployeeBtn_Click(object sender, EventArgs e)
        {
            
            if(TextName.Text != "" && TextPhone.Text != "" && TextCName.Text !="" && TextEmail.Text != "" && TextPassword.Text != "")
            {
                EmployeeController empcontroller = new EmployeeController();
                CompanyController comcontroller = new CompanyController();
                var checkemplyee = empcontroller.CheckEmployee(TextEmail.Text);

                if(checkemplyee == 0)
                {
                    int AddCom = comcontroller.InsertCompany(new Models.Companies()
                    {
                        ComName = TextCName.Text.Trim(),
                        ComCity = new Models.Cities()
                        {
                            id = Convert.ToInt32(DropDownCityList.SelectedValue)
                        }
                    });

                    var AddEmp = empcontroller.InsertEmployee(new Models.Employees()
                    {
                        EmpName = TextName.Text.Trim(),
                        EmpTel = TextPhone.Text.Trim(),
                        EmpEmail = TextEmail.Text.Trim(),
                        EmpPass = TextPassword.Text.Trim(),
                        EmpComID = AddCom,
                        EmpComName = TextCName.Text.Trim()

                    });
                    Literal1.Text = AddEmp;
                }
                else
                {
                    alertdiv.Visible = true;
                    Literal2.Text = "This mail address has been taken";
                }
            }
            else
            {
                alertdiv.Visible = true;
                Literal2.Text = "Please fulfill all the blanks";
            }
            

        }
    }
}