using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        public static string UserProfileID;
        public static int MessageLogID;
        public static string loginid;
        public static string back;
        public static string password;
        public static string ip;
        public static string LoginID;
        public static string HostName;
        public static string SessionID;
        public static string LanguageCD;
        public static string ReportHeading1;
        public static string ReportHeading2;
        public static string ReportHeading3;
        public static string FullName;
        public static string LastLoggedIn;
        static string prevPage = String.Empty;
        public static int ReturnCode;
        public static string Msg;
        public static string photo;

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Button2.Visible = false;
            Label2.Visible = false;
            if (Session["LoginID"] != null)
            {
                LoginID = Session["LoginID"].ToString();
            }
            if (Session["ReportHeading1"] != null)
            {
                ReportHeading1 = Session["ReportHeading1"].ToString();
            }
            if (Session["ReportHeading2"] != null)
            {
                ReportHeading2 = Session["ReportHeading2"].ToString();
            }
            if (Session["ReportHeading3"] != null)
            {
                ReportHeading3 = Session["ReportHeading3"].ToString();
            }
            if (Session["FullName"] != null)
            {
                FullName = Session["FullName"].ToString();
            }
            if (Session["LastLoggedIn"] != null)
            {
                LastLoggedIn = Session["LastLoggedIn"].ToString();
            }
            if (Session["SessionID"] != null)
            {
                SessionID = Session["SessionID"].ToString();
            }
            if (Session["password"] != null)
            {
                password = Session["password"].ToString();
            }
            SqlConnection phcon = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
            phcon.Open();
            SqlCommand phcmd = new SqlCommand("sp_Portal_Report_Heading", phcon);
            phcmd.CommandType = CommandType.StoredProcedure;
            phcmd.Parameters.AddWithValue("@LoginID", LoginID);
            using (SqlDataReader sqlReader = phcmd.ExecuteReader())
            {


                while (sqlReader.Read())
                {
                    try
                    {
                        byte[] PH = (byte[])sqlReader["Photo"];

                        photo = Convert.ToBase64String(PH);
                        Image1.ImageUrl = "data:image;base64," + photo;
                    }
                    catch (Exception)
                    {
                        Image1.ImageUrl = "~/images/AmoleLogo.jpg";
                    }
                    Image1.Width = 85;
                    Image1.Height = 75;


                }
                sqlReader.Close();
            }


            //if (!IsPostBack)
            //{
            //    prevPage = Request.UrlReferrer.ToString();
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ConnectionString;
                string insertStoredProcName = "sp_Change_Password";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //SqlCommand cmd = new SqlCommand("sp_HelpDesk_Request", connectionHelpdesk);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SessionID", SessionID);
                        cmd.Parameters.AddWithValue("@CurrentPassword", Password4.Value);
                        cmd.Parameters.AddWithValue("@NewPassword", Password1.Value);
                        cmd.Parameters.AddWithValue("@ConfirmPassword", Password2.Value);
                        cmd.Parameters.AddWithValue("@ForcePasswordChange", "");
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {

                            //sqlReader.NextResult();

                            while (sqlReader.Read())
                            {
                                //Response.Write("ReturnCode - " + sqlReader.GetValue(0));
                                //Response.Write("ReturnCode - " + sqlReader.GetValue(1));
                                ReturnCode = Convert.ToInt16(sqlReader.GetValue(0));
                                MessageLogID = Convert.ToInt32(sqlReader.GetValue(2));
                                try
                                {
                                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                                    con.Open();
                                    SqlCommand mes = new SqlCommand("sp_MessageLog_Get", con);
                                    mes.CommandType = CommandType.StoredProcedure;
                                    mes.Parameters.AddWithValue("@MessageLogID", MessageLogID);
                                    mes.Parameters.AddWithValue("@LanguageCD", LanguageCD);
                                    using (SqlDataReader mess = mes.ExecuteReader())
                                    {
                                        while (mess.Read())
                                        {
                                            Msg = Convert.ToString(mess.GetValue(2));
                                            if (ReturnCode == 1)
                                            {
                                                Panel1.Visible = true;
                                                Label1.Text = Msg;
                                                currPass.Visible = false;
                                                newPass.Visible = false;
                                                confirmPass.Visible = false;
                                                Button1.Visible = false;
                                                Button2.Visible = true;
                                                LinkButton1.Visible = false;
                                            }
                                            else
                                            {
                                                Panel1.Visible = false;
                                                Label2.Text = Msg;
                                                Label2.Visible = true;
                                                currPass.Visible = true;
                                                newPass.Visible = true;
                                                confirmPass.Visible = true;
                                                Button1.Visible = true;
                                                Button2.Visible = false;
                                                LinkButton1.Visible = true;
                                            }
                                        }
                                        mess.Close();
                                    }


                                    con.Close();
                                }

                                catch (Exception ex)
                                {
                                    Label2.Visible = true;
                                    Label2.Text = ("Session Timeout. Please Logout and Login again.");
                                }

                            }
                            sqlReader.Close();
                            cmd.Dispose();
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Label2.Visible = true;
                   Label2.Text=(""+ex);
                }
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Redirect(prevPage);
            Response.Redirect("PortalReportAvailable.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            // Response.Redirect(prevPage);
            Response.Redirect("PortalReportAvailable.aspx");
        }
    }
}