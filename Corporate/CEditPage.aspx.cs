using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;
using ytuportal.web.Models;

namespace ytuportal.web.Corporate
{
    public partial class CEditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var empid = Convert.ToInt32(Session["EmployeeId"]);
                EmployeeController empcontroller = new EmployeeController();
                var currentemp = empcontroller.GetEmployeeById(empid);

                EName.Text = currentemp.EmpName;
                ETel.Text = currentemp.EmpTel;
                EEmail.Text = currentemp.EmpEmail;
                EBirthday.Text = currentemp.EmpBirthday;
                EJob.Text = currentemp.EmpJob;
                RadioBtnEditGender.Text = currentemp.EmpGender;
            }
        }

        protected void EditEmpBtn_Click(object sender, EventArgs e)
        {
            EmployeeController editempcontroller = new EmployeeController();
            var editempid = Convert.ToInt32(Session["EmployeeId"]);
            var editcurrentemp = editempcontroller.GetEmployeeById(editempid);

            var result = editempcontroller.EditEmployee(new Employees()
            {
                EmpID = editempid,
                EmpName = EName.Text.Trim(),
                EmpTel = ETel.Text.Trim(),
                EmpEmail = EEmail.Text.Trim(),
                EmpGender = RadioBtnEditGender.Text,
                EmpBirthday = EBirthday.Text.Trim(),
                EmpJob = EJob.Text.Trim()
            });

            if(result == "Profile has been updated successfully")
            {
                ReqCheck.ForeColor = Color.Green;
                ReqCheck.Text = result;
            }
            else
            {
                ReqCheck.ForeColor = Color.Red;
                ReqCheck.Text = "We can not update your profile right now, sorry for the delay...";
            }
        }
    }
}