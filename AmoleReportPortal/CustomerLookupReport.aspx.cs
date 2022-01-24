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
    public partial class CustomerLookupReport : System.Web.UI.Page
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
        public static DateTime date1;
        public static DateTime date2;
        public static string ToD;
        public static string Checked;
        public static string BranchId;
        public static string ReporttNumber;
        public static string rptn;
        public static string rptnumber2;
        public static string SearchValue;
        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptn = PortalGetListDSTVTransactionLogReport.rptn;
            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                rptnumber = PortalGetList.rptnumber;
                CrystalReportViewer1.Visible = true;
                CrystalReportViewer1.DisplayPage = true;
                CrystalReportViewer1.DisplayStatusbar = true;
                CrystalReportViewer1.DisplayToolbar = true;
                CrystalReportViewer1.HasCrystalLogo = false;
                CrystalReportViewer1.HasSearchButton = true;
                CrystalReportViewer1.SeparatePages = true;
                CrystalReportViewer1.ShowAllPageIds = true;
                CrystalReportViewer1.HasToggleGroupTreeButton = false;
                
                //ReportHeading1 = PortalReportAvailable.ReportHeading1;
                //ReportHeading2 = PortalReportAvailable.ReportHeading2;
                //ReportHeading3 = PortalReportAvailable.ReportHeading3;
                //FullName = PortalReportAvailable.FullName;
                //LastLoggedIn = PortalReportAvailable.LastLoggedIn;
               // reportLink = PortalGetListDSTVTransactionLogReport.reportLink;
               // From = PortalGetListDSTVTransactionLogReport.From;
                //To = PortalGetListDSTVTransactionLogReport.To;
                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("hi-IN", true);
                time = Convert.ToDateTime(DateTime.Now, theCultureInfo).ToString("h:mm tt");
            }
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
        protected void Page_Init(object sender, EventArgs e)
        {
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
            if (Session["time"] != null)
            {
                time = Session["time"].ToString();
            }
            if (Session["date"] != null)
            {
                date = Session["date"].ToString();
            }
            if (Session["reportLink"] != null)
            {
                reportLink = Session["reportLink"].ToString();
            }
            if (Session["rptnumber"] != null)
            {
                rptnumber2 = Session["rptnumber"].ToString();
            }
            if (Session["SearchValue1"] != null)
            {
                SearchValue = Session["SearchValue1"].ToString();
            }

            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    crystalReport.Load(Server.MapPath("CustomerLookupReport1.rpt"));
                    SqlConnection conn = new SqlConnection(ConfigurationManager
                      .ConnectionStrings["FettanReportPortalConnection"].ConnectionString);

                    SqlCommand cmd = new SqlCommand("sp_Portal_Report", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", LoginID);
                    cmd.Parameters.AddWithValue("@Reportnumber", rptnumber2);
                    cmd.Parameters.AddWithValue("@String1", SearchValue);
                    //cmd.Parameters.AddWithValue("@Date1", From);
                    //cmd.Parameters.AddWithValue("@Date2", To);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    crystalReport.SetDataSource(dt);
                    CrystalReportViewer1.ReportSource = crystalReport;
                    CrystalReportViewer1.DataBind();
                    crystalReport.SetParameterValue("ReportHeading1", ReportHeading1);
                    crystalReport.SetParameterValue("ReportHeading2", ReportHeading2);
                    crystalReport.SetParameterValue("ReportHeading3", ReportHeading3);
                    crystalReport.SetParameterValue("ReportName", reportLink);
                    //crystalReport.SetParameterValue("From", From);
                    //crystalReport.SetParameterValue("To", To);
                    crystalReport.SetParameterValue("time", time);
                    crystalReport.SetParameterValue("date", date);
                    CrystalReportViewer1.HasCrystalLogo = false;
                    CrystalReportViewer1.HasToggleParameterPanelButton = false;
                    Session["ReportDocument"] = crystalReport;
                    //crystalReport.Dispose();
                    //crystalReport.Close();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Check your connection ');", true);
                     //Response.Redirect("Login.aspx");
                    Response.Write(ex);
                }
            }

            else
            {
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                CrystalReportViewer1.ReportSource = doc;
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalGetListCustomerLookupReport.aspx");
        }
    }
}