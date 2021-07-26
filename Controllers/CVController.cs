using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using ytuportal.web.Models;

namespace ytuportal.web.Controllers
{
    public class CVController
    {
        
        public string InsertNullCV(CV Cv)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            SqlCommand com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "INSERT INTO Cvs(UserId) values(@UserId)";

            
            if (String.IsNullOrEmpty(Cv.UserId.Id.ToString()))
            {
                com.Parameters.AddWithValue("@UserId", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@UserId", Cv.UserId.Id);


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

    }
}