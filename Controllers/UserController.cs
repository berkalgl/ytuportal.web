using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ytuportal.web.Models;

namespace ytuportal.web.Controllers
{
    public class UserController
    {
        public Users GetUserById(int id)
        {
            Users user = new Users();
            CityController citycontroller = new CityController();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Users WHERE Id = @Id";

            com.Parameters.AddWithValue("@Id", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                user.Id = Convert.ToInt32(dataRow["Id"]);
                user.Fname = dataRow["fname"].ToString();
                user.Sname = dataRow["sname"].ToString();
                user.Email = dataRow["email"].ToString();
                user.Birthday = dataRow["birthday"].ToString();
                user.Photo = dataRow["photo"] as byte[];
                user.Position = dataRow["position"].ToString();
                if ((dataRow["City"]) == DBNull.Value)
                {
                    user.City = null;
                }
                else
                {
                    user.City = citycontroller.GetCityById(Convert.ToInt32(dataRow["City"]));
                }
                user.Password = dataRow["password"].ToString();
                user.District = dataRow["district"].ToString();
                user.Gender = dataRow["gender"].ToString();
                user.Address = dataRow["address"].ToString();
                user.Phone = dataRow["phone"].ToString();
                user.CV = dataRow["cv"] as byte[];
                user.Departman = dataRow["departman"].ToString();
                user.University = dataRow["University"].ToString();
            }

            return user;
        }

        public string EditUser(Users user)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            SqlCommand com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "UPDATE Users SET fname = @fname, sname = @sname, email = @email, password = @password, birthday = @birthday, gender = @gender, phone = @phone, City = @city, district = @district, address = @address, position = @position, info = @info, departman = @departman, university = @university WHERE Id = @Id";
            //com.Parameters.AddWithValue("@Id", user.Id);
            //com.Parameters.AddWithValue("@fname", user.Fname);
            //com.Parameters.AddWithValue("@email", user.Email);
            ////com.Parameters.AddWithValue("@sname", user.Sname);
            //com.Parameters.AddWithValue("@gender", user.Gender);
            //com.Parameters.AddWithValue("@birthday", user.Birthday);
            //com.Parameters.AddWithValue("@phone", user.Phone);
            //com.Parameters.AddWithValue("@city", user.City.id);
            //com.Parameters.AddWithValue("@district", user.District);
            //com.Parameters.AddWithValue("@address", user.Address);
            //com.Parameters.AddWithValue("@position", user.Position);
            //com.Parameters.AddWithValue("@info", user.Info);
            //com.Parameters.AddWithValue("@departman", user.Departman);
            //com.Parameters.AddWithValue("@university", user.University);

            if (String.IsNullOrEmpty(user.Id.ToString()))
            {
                com.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@Id", user.Id);

            if (String.IsNullOrEmpty(user.Fname))
            {
                com.Parameters.AddWithValue("@fname", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@fname", user.Fname);
            if (String.IsNullOrEmpty(user.Password))
            {
                com.Parameters.AddWithValue("@password", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@password", user.Password);


            if (String.IsNullOrEmpty(user.Sname))
            {
                com.Parameters.AddWithValue("@sname", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@sname", user.Sname);

            if (String.IsNullOrEmpty(user.Email))
            {
                com.Parameters.AddWithValue("@email", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@email", user.Email);

            if (String.IsNullOrEmpty(user.Gender))
            {
                com.Parameters.AddWithValue("@gender", DBNull.Value);
            }
            else
                 com.Parameters.AddWithValue("@gender", user.Gender);


            if (String.IsNullOrEmpty(user.Birthday))
            {
                com.Parameters.AddWithValue("@birthday", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@birthday", user.Birthday);

            if (String.IsNullOrEmpty(user.Phone))
            {
                com.Parameters.AddWithValue("@phone", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@phone", user.Phone);

            if (String.IsNullOrEmpty(user.City.ToString()))
            {
                com.Parameters.AddWithValue("@city", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@city", user.City.id);


            if (String.IsNullOrEmpty(user.District))
            {
                com.Parameters.AddWithValue("@district", DBNull.Value);
            }
            else
                 com.Parameters.AddWithValue("@district", user.District);

            if (String.IsNullOrEmpty(user.Address))
            {
                com.Parameters.AddWithValue("@address", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@address", user.Address);

            if (String.IsNullOrEmpty(user.Position))
            {
                com.Parameters.AddWithValue("@position", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@position", user.Position);

            if (String.IsNullOrEmpty(user.Info))
            {
                com.Parameters.AddWithValue("@info", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@info", user.Info);

            if (String.IsNullOrEmpty(user.Departman))
            {
                com.Parameters.AddWithValue("@departman", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@departman", user.Departman);

            if (String.IsNullOrEmpty(user.University))
            {
                com.Parameters.AddWithValue("@university", DBNull.Value);
            }
            else
                com.Parameters.AddWithValue("@university", user.University);


            try
            {
                con.Open();
                com.ExecuteNonQuery();

                if (user.Photo.Length != 0)
                {
                    com.Parameters.Clear();
                    com.CommandText = "UPDATE Users SET photo = @Photo WHERE Id = @Id";
                    com.Parameters.AddWithValue("@Photo", user.Photo);
                    com.Parameters.AddWithValue("@Id", user.Id);

                    com.ExecuteNonQuery();
                }

                //if (user.CV.Length != 0)
                //{
                //    com.Parameters.Clear();
                //    com.CommandText = "UPDATE Users SET cv = @Cv WHERE Id = @Id";
                //    com.Parameters.AddWithValue("@Cv", user.CV);
                //    com.Parameters.AddWithValue("@Id", user.Id);

                //    com.ExecuteNonQuery();
                //}
                con.Close();
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Data updated successfully";
        }

        public string InsertUser(Users user)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            SqlCommand com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "INSERT INTO Users(fname,sname,email,password) values(@fname,@sname,@email,@password)";

            com.Parameters.AddWithValue("@fname", user.Fname);
            com.Parameters.AddWithValue("@sname", user.Sname);
            com.Parameters.AddWithValue("@email", user.Email);
            com.Parameters.AddWithValue("@password", user.Password);

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

        public Users GetUserByEmail(string UserMail)
        {
            Users user = new Users();
            CityController citycontroller = new CityController();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Users WHERE email = @email";

            com.Parameters.AddWithValue("@email", UserMail);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                user.Id = Convert.ToInt32(dataRow["Id"]);
                user.Fname = dataRow["fname"].ToString();
                user.Sname = dataRow["sname"].ToString();
                user.Email = dataRow["email"].ToString();
                user.Birthday = dataRow["birthday"].ToString();
                user.Photo = dataRow["photo"] as byte[];
                user.Position = dataRow["position"].ToString();

                if ((dataRow["City"]) == DBNull.Value )
                {
                    user.City = null;
                }
                else
                {
                    user.City = citycontroller.GetCityById(Convert.ToInt32(dataRow["City"]));
                }

                user.District = dataRow["district"].ToString();
                user.Gender = dataRow["gender"].ToString();
                user.Address = dataRow["address"].ToString();
                user.Phone = dataRow["phone"].ToString();
                user.CV = dataRow["cv"] as byte[];
                user.Departman = dataRow["departman"].ToString();
                user.University = dataRow["University"].ToString();

            }

            return user;

        }
        
        public Candidate GetCandidateByAdvId(int id)
        {
            Candidate candidate = new Candidate();
            AdvertisementController advcontroller = new AdvertisementController();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Candidates WHERE AdvId = @AdvId AND CStatus = 'Active'";

            com.Parameters.AddWithValue("@AdvId", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;
                
                candidate.User = GetUserById(Convert.ToInt32(dataRow["UserId"]));
                candidate.Id = Convert.ToInt32(dataRow["CandidateId"]);
                candidate.Adv = advcontroller.GetAdvById(Convert.ToInt32(dataRow["AdvId"]));
                candidate.CStatus = dataRow["CStatus"].ToString();
            }

            return candidate;
        }

        public Candidate GetCandidateByUserId(int id)
        {
            Candidate candidate = new Candidate();
            AdvertisementController advcontroller = new AdvertisementController();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Candidates WHERE UserId = @UserId";

            com.Parameters.AddWithValue("@UserId", id);

            var adp = new SqlDataAdapter(com);

            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;

                candidate.User = GetUserById(Convert.ToInt32(dataRow["UserId"]));
                candidate.Id = Convert.ToInt32(dataRow["CandidateId"]);
                candidate.Adv = advcontroller.GetAdvById(Convert.ToInt32(dataRow["AdvId"]));
                candidate.CStatus = dataRow["CStatus"].ToString();
            }

            return candidate;
        }

        public List<Candidate> GetCandidatesByAdvId(int id)
        {
            List<Candidate> candidates = new List<Candidate>();
            AdvertisementController advcontroller = new AdvertisementController();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Candidates WHERE AdvId = @AdvId AND CStatus='Active'";
           
            com.Parameters.AddWithValue("@AdvId", id);

            var adp = new SqlDataAdapter(com);
            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;
                var candidate = new Candidate
                {
                    User = GetUserById(Convert.ToInt32(dataRow["UserId"])),
                    CStatus = dataRow["CStatus"].ToString(),
                    Adv = advcontroller.GetAdvById(Convert.ToInt32(dataRow["AdvId"]))
                };
                candidates.Add(candidate);
            }

            return candidates;
        }

        public List<Candidate> GetCandidatesByUserId(int id)
        {
            List<Candidate> candidates = new List<Candidate>();
            AdvertisementController advcontroller = new AdvertisementController();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT * FROM Candidates WHERE UserId = @UserId";

            com.Parameters.AddWithValue("@UserId", id);

            var adp = new SqlDataAdapter(com);
            var datatable = new DataTable();

            adp.Fill(datatable);

            foreach (var row in datatable.Rows)
            {
                DataRow dataRow = row as DataRow;
                var candidate = new Candidate
                {
                    User = GetUserById(Convert.ToInt32(dataRow["UserId"])),
                    CStatus = dataRow["CStatus"].ToString(),
                    Adv = advcontroller.GetAdvById(Convert.ToInt32(dataRow["AdvId"]))
                };
                candidates.Add(candidate);
            }

            return candidates;
        }

        public string DeleteCandidate(int id,int id2)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();
            var com2 = new SqlCommand();

            com.Connection = con;
            com.CommandText = "UPDATE Candidates SET CStatus = 'Passive' WHERE CandidateId = @CandidateId";
            com2.Connection = con;
            com2.CommandText = "UPDATE Advertisement SET Candidate = Candidate - 1 WHERE AdvId = @AdvId ";

            com.Parameters.AddWithValue("@CandidateId", id);
            com2.Parameters.AddWithValue("@AdvId", id2);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                com2.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Candidate has been deleted successfully";
        }

        public ArrayList GetCandidatesUserIdByAdvId(int id)
        {
            AdvertisementController advcontroller = new AdvertisementController();

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "SELECT UserId FROM Candidates WHERE AdvId = @AdvId AND CStatus='Active' GROUP BY UserId";

            com.Parameters.AddWithValue("@AdvId", id);
            con.Open();

            ArrayList userids = new ArrayList();
            SqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                userids.Add(reader["UserId"]);
            }
            con.Close();
            return userids;
        }

        public int CheckUser(string Email)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString);
            con.Open();
            string checkuser = "SELECT COUNT(*) FROM Users where email = '" + Email + "'";


            SqlCommand com = new SqlCommand(checkuser, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

            con.Close();

            return temp;
        }

    }
}