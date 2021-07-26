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
    public class CompanyController
    {
        public Companies GetCompanyByName(string CName)
        {
            Companies company = new Companies();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT CompanyID FROM Company WHERE CompanyName = @CompanyName";

            com.Parameters.AddWithValue("@CompanyName", CName);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                company.ComID = Convert.ToInt32(dataRow["CompanyID"]);

            }

            return company;
        }

        public Companies GetCompanyById(int id)
        {
            Companies company = new Companies();
            var citycontroller = new CityController();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Company WHERE CompanyID = @CompanyID";

            com.Parameters.AddWithValue("@CompanyID", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                company.ComID = Convert.ToInt32(dataRow["CompanyID"]);
                company.ComName = dataRow["CompanyName"].ToString();
                company.ComSector = dataRow["CompanySector"].ToString();
                company.ComNumberOfEmp = dataRow["NumberOfEmployees"].ToString();
                company.ComAddress = dataRow["CompanyAddress"].ToString();
                company.ComCountry = dataRow["CompanyCountry"].ToString();
                company.ComWebSite = dataRow["CompanyWebSite"].ToString();
                company.ComDefinition = dataRow["CompanyDefinition"].ToString();
                company.ComTel = dataRow["CompanyTel"].ToString();
                company.ComCity = citycontroller.GetCityById(Convert.ToInt32(dataRow["CompanyCity"]));
            }

            return company;

        }

        public int InsertCompany (Companies Company)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "INSERT INTO Company(CompanyName,CompanyCity) output INSERTED.CompanyID VALUES(@CompanyName,@CompanyCity)";

            com.Parameters.AddWithValue("@CompanyName", Company.ComName);
            com.Parameters.AddWithValue("@CompanyCity", Company.ComCity.id);

            con.Open();
            int modified = (int)com.ExecuteScalar();

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return modified;

            
        }
    }
}