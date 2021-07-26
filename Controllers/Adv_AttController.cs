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
    public class Adv_AttController
    {
        public Adv_Level GetAdvLevelById(int id)
        {
            Adv_Level adv_level = new Adv_Level();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Adv_Level WHERE Adv_levelID = @Adv_levelID";

            com.Parameters.AddWithValue("@Adv_levelID", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                adv_level.Id = id;
                adv_level.Name = dataRow["Adv_levelName"].ToString();
            }

            return adv_level;

        }
        public List<Adv_Level> GetAdvLevels()
        {
            List<Adv_Level> Adv_levels = new List<Adv_Level>();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Adv_Level";

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                Adv_Level adv_level = new Adv_Level();

                adv_level.Id = Convert.ToInt32(dataRow["Adv_levelId"]);
                adv_level.Name = dataRow["Adv_levelName"].ToString();

                Adv_levels.Add(adv_level);
            }

            return Adv_levels;
        }
        public Adv_Style GetAdvStyleById(int id)
        {
            Adv_Style adv_style = new Adv_Style();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Adv_Style WHERE Adv_StyleID = @Id";

            com.Parameters.AddWithValue("@Id", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                adv_style.Id = id;
                adv_style.Name = dataRow["Adv_StyleName"].ToString();
            }

            return adv_style;

        }
        public List<Adv_Style> GetAdvStyles()
        {
            List<Adv_Style> Adv_styles = new List<Adv_Style>();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Adv_Style";

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                Adv_Style adv_style = new Adv_Style();

                adv_style.Id = Convert.ToInt32(dataRow["Adv_StyleId"]);
                adv_style.Name = dataRow["Adv_StyleName"].ToString();

                Adv_styles.Add(adv_style);
            }

            return Adv_styles;
        }

    }
}