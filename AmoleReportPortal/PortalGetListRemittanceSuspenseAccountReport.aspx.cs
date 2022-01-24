using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class PortalGetListRemittanceSuspenseAccountReport : System.Web.UI.Page
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
        public static string MerchantID;
        public static string EventID;
        public static string ReporttNumber;
        public static string rptn;
        public static string link;
        public static string photo;

        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
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
            phcon.Close();


            //var reportnumber = HttpContext.Current;
            //ReporttNumber = Request["rptnumber"];
            //ReportName = Request["ReportName"];
            //rptnumber = Convert.ToInt32(ReporttNumber);
            // link   = HttpUtility.UrlDecode(Request.QueryString["ReportName"]);
            // rptn = HttpUtility.UrlDecode(Request.QueryString["ReportNumber"]);
            link = PortalGetList.link;
            rptn = PortalGetList.rptn;
            rptnumber = Convert.ToInt32(Decrypt(rptn));
            reportLink = Decrypt(link);

            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                //if (rptnumber != 104 && rptnumber != 109 && rptnumber !=110 && rptnumber!=111)
                //{
                //    DropDownListSelectBranch.Visible = false;
                //    merchant.Visible = false;
                //}
               
                //ReportHeading1 = PortalReportAvailable.ReportHeading1;
                //ReportHeading2 = PortalReportAvailable.ReportHeading2;
                //ReportHeading3 = PortalReportAvailable.ReportHeading3;
                //FullName = PortalReportAvailable.FullName;
                //LastLoggedIn = PortalReportAvailable.LastLoggedIn;
                //txtFrom.Text = DateTime.Now.ToString("MMM dd,yyyy");
                //txtTo.Text = DateTime.Now.ToString("MMM dd,yyyy");
                //From = txtFrom.Text;
                //To = txtTo.Text;
                txtFrom.Attributes.Add("placeholder", "Start Date");
                txtTo.Attributes.Add("placeholder", "End Date");
                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("hi-IN", true);
                time = Convert.ToDateTime(DateTime.Now, theCultureInfo).ToString("h:mm tt");
                date = DateTime.Now.ToString("dddd, dd MMM, yyyy");

                //if (rptnumber == 107)
                //{
                //    reportLink = "Content Sales Report";
                //}
                //else if (rptnumber == 112)
                //{
                //    reportLink = ("Content Sales Detail");
                //}
                //DropDownListSelectBranch.Attributes.Add("placeholder", "Start Date");

            }
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                //txtFrom.Text = DateTime.Now.ToString("dd MMM, yyyy");
                //txtTo.Text = DateTime.Now.ToString("dd MMM, yyyy");
                txtFrom.Text = DateTime.Now.ToString("MMM dd, yyyy");
                txtTo.Text = DateTime.Now.ToString("MMM dd, yyyy");
                From = txtFrom.Text;
                To = txtTo.Text;
                SqlConnection connectionReport = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                SqlCommand commandReport = new SqlCommand("sp_Portal_GetList", connectionReport);
                commandReport.CommandType = CommandType.StoredProcedure;
                commandReport.Parameters.AddWithValue("@ListType", 10);
                commandReport.Parameters.AddWithValue("@LoginID", LoginID);
                commandReport.Connection = connectionReport;
                try
                {
                    connectionReport.Open();
                    DropDownListSelectBranch.DataSource = commandReport.ExecuteReader();
                    DropDownListSelectBranch.DataTextField = "Merchant";
                    DropDownListSelectBranch.DataValueField = "MerchantID";
                    DropDownListSelectBranch.DataBind();
                    //DropDownListSelectBranch.Items.Insert(0, new ListItem("Please Select Merchant", "0"));
                    // DropDownListSelectBranch.SelectedIndex = DropDownListSelectBranch.Items.IndexOf(DropDownListSelectBranch.Items.FindByText("--Please Select Branch--"));
                }

                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Check your connection ');", true);
                    Response.Redirect("Login.aspx");
                }
                finally
                {
                    connectionReport.Close();
                    connectionReport.Dispose();
                }
            }
        }

        protected void DropDownListSelectBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            MerchantID = DropDownListSelectBranch.SelectedValue;
            SqlConnection connectionReport = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
            connectionReport.Open();
            SqlCommand commandReport = new SqlCommand("sp_Portal_GetList", connectionReport);
            commandReport.CommandType = CommandType.StoredProcedure;
            commandReport.Parameters.AddWithValue("@LoginID", LoginID);
            commandReport.Parameters.AddWithValue("@ReportNumber", rptnumber);
            commandReport.Parameters.AddWithValue("@Date1", From);
            commandReport.Parameters.AddWithValue("@Date2", To);
            commandReport.Parameters.AddWithValue("@Integer1", MerchantID);
        }
        public static string Decrypt(string encryptText)
        {
            string encryptionkey = "W1U2B3S4E5R6A7M8E9L0A9K8U7";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(" ", "+"));
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
                    {
                        byte[] plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                    }
                }
            }
        }
        public static string Encrypt(string inputText)
        {
            string encryptionkey = "W1U2B3S4E5R6A7M8E9L0A9K8U7";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream())
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                    {
                        cryptstm.Write(plainText, 0, plainText.Length);
                        cryptstm.Close();
                        return Convert.ToBase64String(mstrm.ToArray());
                    }
                }
            }
        }
        protected void DropDownListSelectBranch_DataBound(object sender, EventArgs e)
        {
            MerchantID = DropDownListSelectBranch.SelectedValue;
            SqlConnection connectionReport = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
            connectionReport.Open();
            SqlCommand commandReport = new SqlCommand("sp_Portal_GetList", connectionReport);
            commandReport.CommandType = CommandType.StoredProcedure;
            commandReport.Parameters.AddWithValue("@LoginID", LoginID);
            commandReport.Parameters.AddWithValue("@ReportNumber", rptnumber);
            commandReport.Parameters.AddWithValue("@Date1", From);
            commandReport.Parameters.AddWithValue("@Date2", To);
            commandReport.Parameters.AddWithValue("@Integer1", MerchantID);
            // MerchantID = DropDownListSelectBranch.SelectedValue;

        }
        protected void Generate_Click(object sender, ImageClickEventArgs e)
        {
            Session["MerchantID"] = MerchantID.ToString();
            Session["From"] = From.ToString();
            Session["To"] = To.ToString();
            Session["time"] = time.ToString();
            Session["date"] = date.ToString();
            Session["reportLink"] = reportLink.ToString();
            Session["rptnumber"] = rptnumber.ToString();
            if (MerchantID!="")
            {
                Response.Redirect("RemittanceSuspenseAccountReport.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Merchant not assigned, please contact amole support ');", true);
            }
        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
            From = txtFrom.Text;
            // txtFrom.Text = Calendar1.SelectedDate.ToString();
        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            To = txtTo.Text;
            // txtTo.Text = Calendar1.SelectedDate.ToString();
            //txtFrom.Text = Calendar1.SelectedDate.ToString("MMM dd,yyyy");
            //    From = txtFrom.Text;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtFrom.Text = Calendar1.SelectedDate.ToString("MMM dd, yyyy");
            From = txtFrom.Text;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtTo.Text = Calendar2.SelectedDate.ToString("MMM dd, yyyy");
            To = txtTo.Text;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }
    }
}