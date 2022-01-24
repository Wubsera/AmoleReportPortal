using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.Security;

namespace AmoleReportPortal
{
    public partial class AboutUs : System.Web.UI.Page
    {

        public static string LoginID;
        public static string ClientName;
        public static string date;
        public static string time;
        public static string ReportNumber;
        public static string ReportName;
        public static string reportLink;
        public static string ReportHeading1;
        public static string ReportHeading2;
        public static string ReportHeading3;
        public static string FullName;
        public static string LastLoggedIn;
        public static string photo;
        public static string location;
        public static string greport;
        public static int rptnumber;
        public static string From;
        public static string To;
        public static string FromP;
        public static string ToP;
        public static string Checked;
        public static string BranchId;
        public static string pageName;
        static string prevPage = String.Empty;

        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
            }
                var reportnumber = HttpContext.Current;
                string reporttNumber = Request["ReportNumber"];
                ReportName = Request["ReportName"];
                rptnumber = Convert.ToInt32(reporttNumber);
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Portal_Report_Heading", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LoginID", LoginID);
            using (SqlDataReader sqlReader = cmd.ExecuteReader())
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

            //ReportHeading1 = PortalReportAvailable.ReportHeading1;
            //ReportHeading2 = PortalReportAvailable.ReportHeading2;
            //ReportHeading3 = PortalReportAvailable.ReportHeading3;
            //FullName = PortalReportAvailable.FullName;
            //LastLoggedIn = PortalReportAvailable.LastLoggedIn;
            reportLink = PortalGetList.reportLink;
            From = PortalGetList.From;
            To = PortalGetList.To;
            IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("hi-IN", true);
            time = Convert.ToDateTime(DateTime.Now, theCultureInfo).ToString("h:mm tt");
            //if(!IsPostBack)
            //{
            //    string Path = System.Web.HttpContext.Current.Request.UrlReferrer.AbsolutePath;
            //    System.IO.FileInfo Info = new System.IO.FileInfo(Path);
            //    pageName = Info.Name;
            //}
            if (Login.LoginID != null)
            {
                if (!IsPostBack) //check if the webpage is loaded for the first time.
                {
                    ViewState["PreviousPage"] =
                Request.UrlReferrer;//Saves the Previous page url in ViewState
                }

                //date = UserEnvironment.date;
                date = DateTime.Now.ToString("dddd, dd MMM, yyyy");
                // LoginID = Session["LoginID"].ToString();
                LoginID = PortalReportAvailable.LoginID;
                //string date = DateTime.Now.ToString("D");
                ClientName = PortalReportAvailable.ClientName;
                reportLink = PortalReportAvailable.repLink;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void fettanMark_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }
    }
}