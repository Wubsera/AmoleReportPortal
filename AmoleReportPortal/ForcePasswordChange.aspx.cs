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
    public partial class ForcePasswordChange : System.Web.UI.Page
    {
        public static string LoginID;
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
            Label2.Visible = false;

            if (Session["LoginID"] != null)
            {
                LoginID = Session["LoginID"].ToString();
            }
            if (Session["SessionID"] != null)
            {
                SessionID = Session["SessionID"].ToString();
            }
            if (Session["ForceChangePassword"] != null)
            {
                ForceChangePassword = Session["ForceChangePassword"].ToString();
            }
            //Session["LoginID"] = Login.LoginID;


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
                        cmd.Parameters.AddWithValue("@SessionID", SessionID);
                        cmd.Parameters.AddWithValue("@CurrentPassword", "");
                        cmd.Parameters.AddWithValue("@NewPassword", Password1.Value);
                        cmd.Parameters.AddWithValue("@ConfirmPassword", Password2.Value);
                        cmd.Parameters.AddWithValue("@ForcePasswordChange", ForceChangePassword);
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
                                                newPass.Visible = false;
                                                confirmPass.Visible = false;
                                                Button1.Visible = false;
                                                Button2.Visible = true;
                                            }
                                            else
                                            {
                                                Panel1.Visible = false;
                                                Label2.Text = Msg;
                                                Label2.Visible = true;
                                                newPass.Visible = true;
                                                confirmPass.Visible = true;
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
                                        Response.Write("Can not open connection ! " + ex);
                                    }
                                // columns = Convert.ToString(sqlReader.GetValue(1));

                            }
                            sqlReader.Close();
                            cmd.Dispose();
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Session Timeout");
                }
            }            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Session.Clear();
            string hostName = Request.UserHostName;
            string HostName = Dns.GetHostName();
            IPHostEntry myIP = Dns.GetHostEntry(HostName);
            IPAddress[] address = myIP.AddressList;
            for (int i = 0; i < address.Length; i++)
            {
                ip = address[i].ToString();
            }
            string ipaddress = HttpContext.Current.Request.Form["ipaddress"];
            try
            {
               SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReqLoginID", LoginID);
                cmd.Parameters.AddWithValue("@ReqPassword", Password1.Value);
                cmd.Parameters.AddWithValue("@WorkstationName", HostName);
                cmd.Parameters.AddWithValue("@IPAddress", ip);
                SqlDataReader check = cmd.ExecuteReader();
                GridView1.DataSource = check;
                GridView1.DataBind();
                GridView1.Visible = false;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string UserProfileID = null;
                    string LanguageCD = null;
                    string SessionToken = null;
                    string SessionID = null;
                    MessageLogID2 = GridView1.Rows[i].Cells[0].Text;
                    UserProfileID = GridView1.Rows[i].Cells[1].Text;
                    LanguageCD = GridView1.Rows[i].Cells[2].Text;
                    SessionToken = GridView1.Rows[i].Cells[3].Text;
                    SessionID = GridView1.Rows[i].Cells[4].Text;
                    ForceChangePassword = GridView1.Rows[i].Cells[5].Text;
                    if (MessageLogID2 == "0")
                    {
                        Session["LoginID"] = LoginID.ToString();
                        Session["SessionID"] = SessionID.ToString();
                        {
                            Response.Redirect("PortalReportavailable.aspx");
                        }
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                        conn.Open();
                        SqlCommand mes = new SqlCommand("sp_MessageLog_Get", conn);
                        mes.CommandType = CommandType.StoredProcedure;
                        mes.Parameters.AddWithValue("@MessageLogID", MessageLogID);
                        mes.Parameters.AddWithValue("@LanguageCD", LanguageCD);
                        SqlDataReader mess = mes.ExecuteReader();
                        GridView2.DataSource = mess;
                        GridView2.DataBind();
                        GridView2.HeaderRow.Visible = false;
                        GridView2.Rows[0].Cells[0].Visible = false;
                        GridView2.Rows[0].Cells[1].Visible = false;
                        GridView2.Rows[0].Cells[2].Visible = true;

                        conn.Close();

                    }
                    //if (MessageLogID2 == "0")
                    //{
                    //    GridView2.Visible = true;
                    //}

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Label2.Visible = true;
                Label2.Text = ("Session Timeout. Please Logout and Login again.");

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect(prevPage);
            Response.Redirect("Login.aspx");
        }
    }
}