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
    public partial class ResetPassword : System.Web.UI.Page
    {
        public static string SessionID;
        public static string ForceChangePassword;
        public static string Msg;
        public static int MessageLogID;
        public static string MessageLogID2;
        public static string LanguageCD;
        public static string ip;
        static string prevPage = String.Empty;
        public static int ReturnCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Panel1.Visible = false;

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
                string insertStoredProcName = "sp_Reset_Password";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //SqlCommand cmd = new SqlCommand("sp_HelpDesk_Request", connectionHelpdesk);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID.Value );
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {

                            //sqlReader.NextResult();

                            while (sqlReader.Read())
                            {
                                ReturnCode = Convert.ToInt16(sqlReader.GetValue(0));
                                MessageLogID = Convert.ToInt32(sqlReader.GetValue(2));
                               
                                    string connectionString2 = ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ConnectionString;
                                    string insertStoredProcName2 = "sp_MessageLog_Get";
                                    try
                                    {
                                        using (SqlConnection conn2 = new SqlConnection(connectionString2))
                                        using (SqlCommand cmd2 = new SqlCommand(insertStoredProcName2, conn2))
                                        {
                                            conn2.Open();
                                            cmd2.CommandType = CommandType.StoredProcedure;
                                            //SqlCommand cmd = new SqlCommand("sp_HelpDesk_Request", connectionHelpdesk);
                                            cmd2.CommandType = CommandType.StoredProcedure;
                                            cmd2.Parameters.AddWithValue("@MessageLogID", MessageLogID);
                                            using (SqlDataReader sqlReader2 = cmd2.ExecuteReader())
                                            {

                                                //sqlReader.NextResult();

                                                while (sqlReader2.Read())
                                                {
                                                    Msg = Convert.ToString(sqlReader2.GetValue(2));
                                                if (ReturnCode == 1)
                                                {
                                                    Label2.Visible = false;
                                                    Panel1.Visible = true;
                                                    Label1.Text = Msg;
                                                    inpLoginID.Visible = false;
                                                    Button1.Visible = false;
                                                    Button2.Visible = true;
                                                    LinkButton1.Visible = false;
                                                }
                                                else
                                                {
                                                    Label2.Visible = true;
                                                    Panel1.Visible = false;
                                                    Label2.Text = Msg;
                                                    inpLoginID.Visible = true;
                                                    Button1.Visible = true;
                                                    Button2.Visible = false;
                                                    LinkButton1.Visible = true;
                                                }
                                                }
                                                sqlReader2.Close();
                                            }
                                            cmd2.Dispose();
                                            conn2.Close();
                                        }
                                    }

                                    catch (Exception ex)
                                    {
                                    Label2.Visible = true;
                                    Label2.Text = " Session Timout. Please Logout and Login again.";
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
                    Label2.Text = ("" + ex);
                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // Response.Redirect(prevPage);
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}