using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ytuportal.web.Controllers;
using Ionic.Zip;

namespace ytuportal.web.AdvertisementView
{
    public partial class Candidates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertdiv.Visible = false;
            Fill_Page();
        }

        private void Fill_Page()
        {
            var advid = Convert.ToInt32(Request.QueryString["AdvId"]);
            UserController usercontroller = new UserController();
            var candidates = usercontroller.GetCandidatesByAdvId(advid);
            rptCan.DataSource = candidates;
            rptCan.DataBind();
        }

        protected void DCv_Click(object sender, EventArgs e)
        {
            UserController usercontroller = new UserController();
            var advid = Convert.ToInt32(Request.QueryString["AdvId"]);
            var user = usercontroller.GetCandidateByAdvId(advid);
            var userid = user.User.Id;


            var currentUser = usercontroller.GetUserById(Convert.ToInt32(userid));
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Name, Data, ContentType from CVs where UserId=@Id";
                    cmd.Parameters.AddWithValue("@Id", userid);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void DCanBtn_Click(object sender, EventArgs e)
        {
            UserController usercontroller = new UserController();

            var advid = Convert.ToInt32(Request.QueryString["AdvId"]);
            var candidateid = usercontroller.GetCandidateByAdvId(advid).Id;
            var result = usercontroller.DeleteCandidate(candidateid, advid);
            alertdiv.Visible = true;
            Fill_Page();
            Label1.Text = result;
        }

        protected void DMultipleCV_Click(object sender, EventArgs e)
        {
            UserController usercontroller = new UserController();
            var advid = Convert.ToInt32(Request.QueryString["AdvId"]);
            var user = usercontroller.GetCandidateByAdvId(advid);
            var userid = user.User.Id;

            var currentUser = usercontroller.GetUserById(Convert.ToInt32(userid));
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["YtuKariyerConnection"].ConnectionString;
            var candidates = usercontroller.GetCandidatesUserIdByAdvId(advid);

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    ZipFile zipFile = new ZipFile();
                    foreach (var userid2 in candidates)
                    {
                        cmd.CommandText = "select Name, Data, ContentType from CVs where UserId=@Id";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Id", userid2);
                        cmd.Connection = con;
                        con.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["Name"].ToString();
                            zipFile.AddEntry(fileName, bytes);
                        }
                        con.Close();
                    }
                    
                    var zipFileMs = new MemoryStream();
                    zipFile.Save(zipFileMs);
                    byte[] fileData = zipFileMs.GetBuffer();
                    zipFileMs.Seek(0, SeekOrigin.Begin);
                    zipFileMs.Flush();
                    Response.Clear();
                    string zipName = String.Format("CVs_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                    Response.AddHeader("content-disposition", "attachment;filename="+ zipName);
                    Response.ContentType = "application/zip";
                    Response.BinaryWrite(fileData);
                    Response.End();
                }
                
            }
        }
    }
}