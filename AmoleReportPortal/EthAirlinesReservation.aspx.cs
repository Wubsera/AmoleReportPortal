using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class EthAirlinesReservation : System.Web.UI.Page
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
        public static string location;
        public static string greport;
        public static int rptnumber;
        public static string From;
        public static string To;
        public static string FromP;
        public static string date1;
        public static string date2;
        public static string ToD;
        public static string Checked;
        public static string BranchId;
        public static string ReporttNumber;
        public static string rptn;
        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptn = PortalGetList.rptn;
            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }
            CrystalReportViewer1.Visible = true;
            CrystalReportViewer1.DisplayPage = true;
            CrystalReportViewer1.DisplayStatusbar = true;
            CrystalReportViewer1.DisplayToolbar = true;
            CrystalReportViewer1.HasCrystalLogo = false;
            CrystalReportViewer1.HasSearchButton = true;
            CrystalReportViewer1.SeparatePages = true;
            CrystalReportViewer1.ShowAllPageIds = true;
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
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    crystalReport.Load(Server.MapPath("EthAirlinesPayment.rpt"));
                    SqlConnection conn = new SqlConnection(ConfigurationManager
                      .ConnectionStrings["FettanReportPortalConnection"].ConnectionString);

                    SqlCommand cmd = new SqlCommand("sp_Portal_Report", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", PortalReportAvailable.LoginID);
                    cmd.Parameters.AddWithValue("@ReportNumber", PortalGetList.rptnumber);
                    cmd.Parameters.AddWithValue("@Date1", PortalGetList.From);
                    cmd.Parameters.AddWithValue("@Date2", PortalGetList.To);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    crystalReport.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = crystalReport;
                    CrystalReportViewer1.DataBind();
                    //CrystalReportViewer1.ShowFirstPage();
                    //CrystalReportViewer1.ShowLastPage();
                    //CrystalReportViewer1.ShowNextPage();
                    //CrystalReportViewer1.ShowPreviousPage();                                  
                    crystalReport.SetParameterValue("ReportHeading1", PortalReportAvailable.ReportHeading1);
                    crystalReport.SetParameterValue("ReportHeading2", PortalReportAvailable.ReportHeading2);
                    crystalReport.SetParameterValue("ReportHeading3", PortalReportAvailable.ReportHeading3);
                    crystalReport.SetParameterValue("ReportName", PortalGetList.reportLink);
                    //crystalReport.SetParameterValue("ReportName", ReportName);
                    crystalReport.SetParameterValue("From", PortalGetList.From);
                    crystalReport.SetParameterValue("To", PortalGetList.To);
                    crystalReport.SetParameterValue("time", PortalGetList.time);
                    crystalReport.SetParameterValue("date", PortalGetList.date);
                    //crystalReport.SetParameterValue("time", time);
                    //crystalReport.SetParameterValue("Location", PortalReportEdna.greport);
                    CrystalReportViewer1.HasCrystalLogo = false;
                    CrystalReportViewer1.HasToggleParameterPanelButton = false;
                    Session["ReportDocument"] = crystalReport;
                }
                catch (Exception)
                {
                    //Response.Write("Check Your Connection");
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Check Your Connection');", true);
                }
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                CrystalReportViewer1.ReportSource = doc;
            }


        }
    }
}