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
    public class AdvertisementController
    {
        public string InsertAdvertisement(Advertisements advertisement)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "INSERT INTO Advertisement(AdvTitle,AdvPosition,AdvSector,AdvPlace,AdvFirstDate,AdvLastAppDate,CompanyID,AdvDefinition,AdvAttribute,AdvStyle,AdvLevel,Candidate,Status) values(@AdvTitle,@AdvPosition,@AdvSector,@AdvPlace,@AdvFirstDate,@AdvLastAppDate,@CompanyID,@AdvDefinition,@AdvAttribute,@AdvStyle,@AdvLevel,@Candidate,@Status)";

            if(String.IsNullOrEmpty(advertisement.Title))
            {
                com.Parameters.AddWithValue("@AdvTitle", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvTitle", advertisement.Title);

            if (String.IsNullOrEmpty(advertisement.Position))
            {
                com.Parameters.AddWithValue("@AdvPosition", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvPosition", advertisement.Position);

            if(String.IsNullOrEmpty(advertisement.Sector))
            {
                com.Parameters.AddWithValue("@AdvSector", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvSector", advertisement.Sector);

            if(String.IsNullOrEmpty(advertisement.Place))
            {
                com.Parameters.AddWithValue("@AdvPlace", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvPlace", advertisement.Place);

            if(String.IsNullOrEmpty(advertisement.Company.ToString()))
            {
                com.Parameters.AddWithValue("@CompanyID", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@CompanyID", advertisement.Company.ComID);

            if(String.IsNullOrEmpty(advertisement.Firstdate))
            {
                com.Parameters.AddWithValue("@AdvFirstDate", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvFirstDate", advertisement.Firstdate);
            
            if(String.IsNullOrEmpty(advertisement.Lastdate))
            {
                com.Parameters.AddWithValue("@AdvLastAppDate", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvLastAppDate", advertisement.Lastdate);

            if(String.IsNullOrEmpty(advertisement.Lastdate))
            {
                com.Parameters.AddWithValue("@AdvDefinition", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvDefinition", advertisement.Definition);

            if(String.IsNullOrEmpty(advertisement.Attribute))
            {
                com.Parameters.AddWithValue("@AdvAttribute", DBNull.Value);
            }
            com.Parameters.AddWithValue("@AdvAttribute", advertisement.Attribute);

            if(String.IsNullOrEmpty(advertisement.Style.ToString()))
            {
                com.Parameters.AddWithValue("@AdvStyle", DBNull.Value);
            }

            else
            com.Parameters.AddWithValue("@AdvStyle", advertisement.Style.Id);

            if (String.IsNullOrEmpty(advertisement.Level.ToString()))
            {
                com.Parameters.AddWithValue("@AdvStyle", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvLevel", advertisement.Level.Id);

            com.Parameters.AddWithValue("@Candidate","0");
            com.Parameters.AddWithValue("@Status", "Active");

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

        public string EditAdvertisement(Advertisements advertisement)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            SqlCommand com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "UPDATE Advertisement SET AdvTitle = @AdvTitle,AdvPosition=@AdvPosition,AdvSector=@AdvSector,AdvPlace=@AdvPlace,AdvFirstDate=@AdvFirstDate,AdvLastAppDate=@AdvLastAppDate,AdvDefinition=@AdvDefinition,AdvAttribute=@AdvAttribute,AdvStyle=@AdvStyle,AdvLevel=@AdvLevel,Status=@Status WHERE AdvId = @AdvId";

            com.Parameters.AddWithValue("@AdvId", advertisement.Id);

            if (String.IsNullOrEmpty(advertisement.Title))
            {
                com.Parameters.AddWithValue("@AdvTitle", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvTitle", advertisement.Title);

            if (String.IsNullOrEmpty(advertisement.Position))
            {
                com.Parameters.AddWithValue("@AdvPosition", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvPosition", advertisement.Position);

            if (String.IsNullOrEmpty(advertisement.Sector))
            {
                com.Parameters.AddWithValue("@AdvSector", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvSector", advertisement.Sector);

            if (String.IsNullOrEmpty(advertisement.Place))
            {
                com.Parameters.AddWithValue("@AdvPlace", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvPlace", advertisement.Place);

            if (String.IsNullOrEmpty(advertisement.Firstdate))
            {
                com.Parameters.AddWithValue("@AdvFirstDate", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvFirstDate", advertisement.Firstdate);

            if (String.IsNullOrEmpty(advertisement.Lastdate))
            {
                com.Parameters.AddWithValue("@AdvLastAppDate", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvLastAppDate", advertisement.Lastdate);

            if (String.IsNullOrEmpty(advertisement.Lastdate))
            {
                com.Parameters.AddWithValue("@AdvDefinition", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvDefinition", advertisement.Definition);

            if (String.IsNullOrEmpty(advertisement.Attribute))
            {
                com.Parameters.AddWithValue("@AdvAttribute", DBNull.Value);
            }
            else
            com.Parameters.AddWithValue("@AdvAttribute", advertisement.Attribute);

            if (String.IsNullOrEmpty(advertisement.Style.ToString()))
            {
                com.Parameters.AddWithValue("@AdvStyle", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvStyle", advertisement.Style.Id);

            if (String.IsNullOrEmpty(advertisement.Level.ToString()))
            {
                com.Parameters.AddWithValue("@AdvLevel", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@AdvLevel", advertisement.Level.Id);

            com.Parameters.AddWithValue("@Candidate", "0");
            com.Parameters.AddWithValue("@Status", advertisement.Status);

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

            return "Data updated successfully";

        }

        public Advertisements GetAdvById(int id)
        {
            Advertisements adv = new Advertisements();
            var companycontroller = new CompanyController();
            var adv_attcontroller = new Adv_AttController();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Advertisement WHERE AdvId = @AdvId";

            com.Parameters.AddWithValue("@AdvId", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach(var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;
                adv.Id = Convert.ToInt32(dataRow["AdvId"]);
                adv.Title = dataRow["AdvTitle"].ToString();
                adv.Attribute = dataRow["AdvAttribute"].ToString();
                adv.Definition = dataRow["AdvDefinition"].ToString();
                adv.Position = dataRow["AdvPosition"].ToString();
                adv.Sector = dataRow["AdvSector"].ToString();
                adv.Place = dataRow["AdvPlace"].ToString();
                adv.Firstdate = dataRow["AdvFirstDate"].ToString();
                adv.Lastdate = dataRow["AdvLastAppDate"].ToString();
                adv.Company = companycontroller.GetCompanyById(Convert.ToInt32(dataRow["CompanyID"]));
                adv.Level = adv_attcontroller.GetAdvLevelById(Convert.ToInt32(dataRow["AdvLevel"]));
                adv.Style = adv_attcontroller.GetAdvStyleById(Convert.ToInt32(dataRow["AdvStyle"]));
                adv.Status = dataRow["Status"].ToString();
                adv.NumberOfCandidate = Convert.ToInt32(dataRow["Candidate"]);
            }
            return adv;
        }

        public List<Advertisements> GetAdvertisementsByCompanyId(int id)
        {
            List<Advertisements> advs = new List<Advertisements>();
            var companycontroller = new CompanyController();
            var adv_attcontroller = new Adv_AttController();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Advertisement WHERE CompanyID = @CompanyID";

            com.Parameters.AddWithValue("CompanyID", id);

            var adp = new SqlDataAdapter(com);
            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                var adv = new Advertisements
                {
                    Id = Convert.ToInt32(dataRow["AdvId"]),
                    Title = dataRow["AdvTitle"].ToString(),
                    Position = dataRow["AdvPosition"].ToString(),
                    Sector = dataRow["AdvSector"].ToString(),
                    Place = dataRow["AdvPlace"].ToString(),
                    Firstdate = dataRow["AdvFirstDate"].ToString(),
                    Lastdate = dataRow["AdvLastAppDate"].ToString(),
                    Company = companycontroller.GetCompanyById(Convert.ToInt32(dataRow["CompanyID"])),
                    Level = adv_attcontroller.GetAdvLevelById(Convert.ToInt32(dataRow["AdvLevel"])),
                    Style = adv_attcontroller.GetAdvStyleById(Convert.ToInt32(dataRow["AdvStyle"])),
                    NumberOfCandidate = Convert.ToInt32(dataRow["Candidate"]),
                    Status = dataRow["Status"].ToString()
                 };
                advs.Add(adv);
            }

            return advs;
        }

        public List<Advertisements> GetAdvertisementsByAdvId(int advid)
        {
            List<Advertisements> advs = new List<Advertisements>();
            var companycontroller = new CompanyController();
            var adv_attcontroller = new Adv_AttController();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Advertisement WHERE AdvId = @AdvId";
            com.Parameters.AddWithValue("@AdvId", advid);

            var adp = new SqlDataAdapter(com);
            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                var adv = new Advertisements
                {
                    Id = Convert.ToInt32(dataRow["AdvId"]),
                    Title = dataRow["AdvTitle"].ToString(),
                    Position = dataRow["AdvPosition"].ToString(),
                    Sector = dataRow["AdvSector"].ToString(),
                    Place = dataRow["AdvPlace"].ToString(),
                    Firstdate = dataRow["AdvFirstDate"].ToString(),
                    Lastdate = dataRow["AdvLastAppDate"].ToString(),
                    Company = companycontroller.GetCompanyById(Convert.ToInt32(dataRow["CompanyID"])),
                    Level = adv_attcontroller.GetAdvLevelById(Convert.ToInt32(dataRow["AdvLevel"])),
                    Style = adv_attcontroller.GetAdvStyleById(Convert.ToInt32(dataRow["AdvStyle"])),
                    NumberOfCandidate = Convert.ToInt32(dataRow["Candidate"]),
                    Status = dataRow["Status"].ToString()
                };
                advs.Add(adv);
            }

            return advs;
        }

        public List<Advertisements> GetAdvertisements()
        {
            List<Advertisements> advs = new List<Advertisements>();
            var companycontroller = new CompanyController();
            var adv_attcontroller = new Adv_AttController();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Advertisement";

            var adp = new SqlDataAdapter(com);
            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                var adv = new Advertisements
                {
                    Id = Convert.ToInt32(dataRow["AdvId"]),
                    Title = dataRow["AdvTitle"].ToString(),
                    Position = dataRow["AdvPosition"].ToString(),
                    Sector = dataRow["AdvSector"].ToString(),
                    Place = dataRow["AdvPlace"].ToString(),
                    Firstdate = dataRow["AdvFirstDate"].ToString(),
                    Lastdate = dataRow["AdvLastAppDate"].ToString(),
                    Company = companycontroller.GetCompanyById(Convert.ToInt32(dataRow["CompanyID"])),
                    Level = adv_attcontroller.GetAdvLevelById(Convert.ToInt32(dataRow["AdvLevel"])),
                    Style = adv_attcontroller.GetAdvStyleById(Convert.ToInt32(dataRow["AdvStyle"])),
                    NumberOfCandidate = Convert.ToInt32(dataRow["Candidate"]),
                    Status = dataRow["Status"].ToString()
                };
                advs.Add(adv);
            }

            return advs;
        }

        public List<Advertisements> SearchAdvertisement(string sposition)
        {
            List<Advertisements> advs = new List<Advertisements>();
            var companycontroller = new CompanyController();
            var adv_attcontroller = new Adv_AttController();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Advertisement WHERE AdvPosition LIKE '" +sposition+ "%'";

            var adp = new SqlDataAdapter(com);
            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                var adv = new Advertisements
                {
                    Id = Convert.ToInt32(dataRow["AdvId"]),
                    Title = dataRow["AdvTitle"].ToString(),
                    Position = dataRow["AdvPosition"].ToString(),
                    Sector = dataRow["AdvSector"].ToString(),
                    Place = dataRow["AdvPlace"].ToString(),
                    Firstdate = dataRow["AdvFirstDate"].ToString(),
                    Lastdate = dataRow["AdvLastAppDate"].ToString(),
                    Company = companycontroller.GetCompanyById(Convert.ToInt32(dataRow["CompanyID"])),
                    Level = adv_attcontroller.GetAdvLevelById(Convert.ToInt32(dataRow["AdvLevel"])),
                    Style = adv_attcontroller.GetAdvStyleById(Convert.ToInt32(dataRow["AdvStyle"])),
                    NumberOfCandidate = Convert.ToInt32(dataRow["Candidate"]),
                    Status = dataRow["Status"].ToString()
                };
                advs.Add(adv);
            }

            return advs;
        }


    }
}