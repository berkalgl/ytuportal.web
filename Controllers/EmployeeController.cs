using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ytuportal.web.Models;

namespace ytuportal.web.Controllers
{
    public class EmployeeController
    {
        public Employees GetEmployeeById(int id)
        {
            Employees employee = new Employees();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Employee WHERE EmployeeID = @Id";

            com.Parameters.AddWithValue("@Id", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                employee.EmpID = Convert.ToInt32(dataRow["EmployeeID"]);
                employee.EmpName = dataRow["EmployeeName"].ToString();
                employee.EmpTel = dataRow["EmployeeTel"].ToString();
                employee.EmpEmail = dataRow["EmployeeEmail"].ToString();
                employee.EmpPass = dataRow["EmployeePassword"].ToString();
                employee.EmpGender = dataRow["EmployeeGender"].ToString();
                employee.EmpBirthday = dataRow["EmployeeBirthday"].ToString();
                employee.EmpJob = dataRow["EmployeeJob"].ToString();
                employee.EmpComName = dataRow["EmployeeCompany"].ToString();
                employee.EmpComID = Convert.ToInt32(dataRow["CompanyID"]);
           
            }

            return employee;
        }

        public string InsertEmployee(Employees employee)
        {

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "INSERT INTO Employee(EmployeeName,EmployeeTel,EmployeeEmail,EmployeePassword,CompanyID,EmployeeCompany) values(@EmployeeName,@EmployeeTel,@EmployeeEmail,@EmployeePassword,@CompanyID,@EmployeeCompany)";

            com.Parameters.AddWithValue("@EmployeeName", employee.EmpName);
            com.Parameters.AddWithValue("@EmployeeTel", employee.EmpTel);
            com.Parameters.AddWithValue("@EmployeeEmail", employee.EmpEmail);
            com.Parameters.AddWithValue("@EmployeePassword", employee.EmpPass);
            com.Parameters.AddWithValue("@CompanyID", employee.EmpComID);
            com.Parameters.AddWithValue("@EmployeeCompany", employee.EmpComName);


            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Data inserted successfully";

        }

        public string EditEmployee(Employees employee)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            SqlCommand com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "UPDATE Employee SET EmployeeName = @EmployeeName, EmployeeTel = @EmployeeTel, EmployeeEmail = @EmployeeEmail, EmployeeGender = @EmployeeGender, EmployeeBirthday = @EmployeeBirthday, EmployeeJob = @EmployeeJob WHERE EmployeeID = @EmployeeID";

            com.Parameters.AddWithValue("@EmployeeName", employee.EmpName);
            com.Parameters.AddWithValue("@EmployeeTel", employee.EmpTel);
            com.Parameters.AddWithValue("@EmployeeEmail", employee.EmpEmail);
            com.Parameters.AddWithValue("@EmployeeGender", employee.EmpGender);
            com.Parameters.AddWithValue("@EmployeeBirthday", employee.EmpBirthday);
            com.Parameters.AddWithValue("@EmployeeJob", employee.EmpJob);
            com.Parameters.AddWithValue("@EmployeeID", employee.EmpID);
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Profile has been updated successfully";
        }

        public int CheckEmployee(string Email)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            con.Open();
            string checkemployee = "SELECT COUNT(*) FROM Employee where EmployeeEmail = '" + Email + "'";


            SqlCommand com = new SqlCommand(checkemployee, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

            con.Close();

            return temp;
        }
    }
}