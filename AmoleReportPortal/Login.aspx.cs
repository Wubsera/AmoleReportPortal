using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace AmoleReportPortal
{
    public partial class Login : System.Web.UI.Page
    {
        public static string UserProfileID;
        public static string LoginID;
        public static string MessageLogID;
        public static string loginid;
        public static string back;
        SqlConnection con;
        public static string password;
        public static string ip;
        public static string ForceChangePassword;
        protected void Page_Load(object sender, EventArgs e)
        {

            //loginid = PortalReportAvailable.LoginID;
            // back = PortalReportAvailable.ClientName;
            //Session.Abandon();
            //Session.RemoveAll();
            if (!IsPostBack)
            {

            }
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
            LoginID = HttpContext.Current.Request.Form["LoginID"];
            password = HttpContext.Current.Request.Form["password"];
            string ipaddress = HttpContext.Current.Request.Form["ipaddress"];
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReqLoginID", (LoginID.ToString()));
                cmd.Parameters.AddWithValue("@ReqPassword", (password.ToString()));
                cmd.Parameters.AddWithValue("@WorkstationName", HostName);
                cmd.Parameters.AddWithValue("@IPAddress", ip);
                SqlDataReader check = cmd.ExecuteReader();
                GridView1.DataSource = check;
                GridView1.DataBind();
                GridView1.Visible = false;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    UserProfileID = null;
                    string LanguageCD = null;
                    string SessionToken = null;
                    string SessionID = null;
                    MessageLogID = GridView1.Rows[i].Cells[0].Text;
                    UserProfileID = GridView1.Rows[i].Cells[1].Text;
                    LanguageCD = GridView1.Rows[i].Cells[2].Text;
                    SessionToken = GridView1.Rows[i].Cells[3].Text;
                    SessionID = GridView1.Rows[i].Cells[4].Text;
                    ForceChangePassword = GridView1.Rows[i].Cells[5].Text;
                    if (MessageLogID == "0")
                    {
                        Session["LoginID"] = LoginID.ToString();
                        Session["password"] = password.ToString();
                        Session["SessionID"] = SessionID.ToString();
                        Session["ForceChangePassword"] = ForceChangePassword.ToString();
                        if (ForceChangePassword == "Y")
                        {
                            Response.Redirect("ForcePasswordChange.aspx");
                        }
                        else
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
                    if (MessageLogID == "0")
                    {
                        GridView2.Visible = true;
                    }

                    con.Close();
                }
            }
            catch (NullReferenceException)
            {

            }
            catch (Exception)
            {
                Label1.Text = "Could not connect to Amole.";

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassword.aspx");
        }
    }
}