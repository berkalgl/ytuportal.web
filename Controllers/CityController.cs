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
    public class CityController
    {
        public Cities GetCityById(int id)
        {
            Cities city = new Cities();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Cities WHERE Id = @Id";

            com.Parameters.AddWithValue("@Id", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                city.id = id;
                city.name = dataRow["Name"].ToString();
            }

            return city;
        }

        public List<Cities> GetCities()
        {
            List<Cities> cities2 = new List<Cities>();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Cities ORDER BY Name";

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                Cities city = new Cities();

                city.id = Convert.ToInt32(dataRow["Id"]);
                city.name = dataRow["Name"].ToString();

                cities2.Add(city);
            }

            return cities2;
        }
    }
}