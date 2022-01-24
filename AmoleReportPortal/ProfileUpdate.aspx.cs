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
    public partial class ProfileUpdate : System.Web.UI.Page
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



                if (!IsPostBack)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ConnectionString;
                    string insertStoredProcName = "sp_Portal_Profile_Get";
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                        {
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SessionID", SessionID);

                            using (SqlDataReader sqlg = cmd.ExecuteReader())
                            {
                                while (sqlg.Read())
                                {
                                    ReturnCode = Convert.ToInt16(sqlg.GetValue(0));
                                    Msg = Convert.ToString(sqlg.GetValue(1));
                                    if (ReturnCode == 1)
                                    {
                                        string languagecd = Convert.ToString(sqlg.GetValue(2));
                                        if (languagecd == "EN")
                                        {
                                            language.SelectedIndex = 0;
                                        }
                                        else if (languagecd == "AM")
                                        {
                                            language.SelectedIndex = 1;
                                        }
                                    if (languagecd == "OR")
                                    {
                                        language.SelectedIndex = 2;
                                    }
                                    else if (languagecd == "TG")
                                    {
                                        language.SelectedIndex = 3;
                                    }
                                    firstName.Value = Convert.ToString(sqlg.GetValue(3));
                                        lastName.Value = Convert.ToString(sqlg.GetValue(4));
                                        email.Value = Convert.ToString(sqlg.GetValue(5));
                                        mobile.Value = Convert.ToString(sqlg.GetValue(6));
                                        address1.Value = Convert.ToString(sqlg.GetValue(7));
                                        address2.Value = Convert.ToString(sqlg.GetValue(8));
                                        organization.Value = Convert.ToString(sqlg.GetValue(9));
                                        jobTitle.Value = Convert.ToString(sqlg.GetValue(10));

                                    }


                                }
                                sqlg.Close();
                                cmd.Dispose();
                                conn.Close();
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Label2.Visible = true;
                        Label2.Text = ("" + ex);
                    }
                }
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ConnectionString;
                string insertStoredProcName = "sp_Portal_Profile_Update";
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
                        cmd.Parameters.AddWithValue("@LanguageCD", language.SelectedValue);
                        cmd.Parameters.AddWithValue("@FirstName", firstName.Value);
                        cmd.Parameters.AddWithValue("@LastName", lastName.Value);
                        cmd.Parameters.AddWithValue("@Email", email.Value);
                        cmd.Parameters.AddWithValue("@MobileNumber", mobile.Value);
                        cmd.Parameters.AddWithValue("@Address1", address1.Value);
                        cmd.Parameters.AddWithValue("@Address2", address2.Value);
                        cmd.Parameters.AddWithValue("@Organization", organization.Value);
                        cmd.Parameters.AddWithValue("@JobTitle", jobTitle.Value);
                        using (SqlDataReader sqlReader2 = cmd.ExecuteReader())
                        {

                            //sqlReader.NextResult();

                            while (sqlReader2.Read())
                            {
                                //Response.Write("ReturnCode - " + sqlReader.GetValue(0));
                                //Response.Write("ReturnCode - " + sqlReader.GetValue(1));
                                ReturnCode = Convert.ToInt16(sqlReader2.GetValue(0));
                                MessageLogID = Convert.ToInt32(sqlReader2.GetValue(2));
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
                                                Label1.Visible = true;
                                                Panel2.Visible = false;
                                                Button1.Visible = false;
                                                Button2.Visible = true;
                                                LinkButton1.Visible = false;
                                            }
                                            else
                                            {
                                                LinkButton1.Visible = true;
                                                Panel1.Visible = false;
                                                Label2.Text = Msg;
                                                Label2.Visible = true;
                                                Panel2.Visible = true;
                                                Button1.Visible = true;
                                                Button2.Visible = false;
                                            }
                                        }
                                        mess.Close();
                                    }


                                    con.Close();
                                }

                                catch (Exception ex)
                                {
                                   Label2.Text=("" + ex);
                                }

                            }
                            sqlReader2.Close();
                            cmd.Dispose();
                            conn.Close();
                        }
                    }
                }
                catch (NullReferenceException en)
                {
                    Label2.Visible = true;
                    Label2.Text = ""+en;
                }
                catch (Exception ex)
                {
                    Label2.Visible = true;
                    Label2.Text = ""+ex;
                }

            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }

        protected void language_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connectionReport = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                SqlCommand commandReport = new SqlCommand("sp_Portal_GetList", connectionReport);
                commandReport.CommandType = CommandType.StoredProcedure;
                commandReport.Parameters.AddWithValue("@ListType", 12);
                commandReport.Connection = connectionReport;
                try
                {
                    connectionReport.Open();
                    language.DataSource = commandReport.ExecuteReader();
                    language.DataTextField = "Language";
                    language.DataValueField = "LanguageCD";
                    language.DataBind();
                    // DropDownListSelectBranch.SelectedIndex = DropDownListSelectBranch.Items.IndexOf(DropDownListSelectBranch.Items.FindByText("--Please Select Branch--"));
                }

                catch (Exception ex)
                {
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Check your connection ');", true);
                    //Response.Redirect("Login.aspx");
                    Label2.Visible = true;
                    Label2.Text = "" + ex;
                }
                finally
                {
                    connectionReport.Close();
                    connectionReport.Dispose();
                }
            }
        }
    }
}