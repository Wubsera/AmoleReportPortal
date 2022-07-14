using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class PortalGetListBulkPaymentBatchFileDetailReport : System.Web.UI.Page
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
        public static string ReporttNumber;
        public static string rptn;
        public static string link;
        public static string AmountToReceive;
        public static string AllowPickup;
        public static string TransaferDate;
        public static string ReceiveTo;
        public static string RecipientName;
        public static string RecipientMobile;
        public static string RecipientGender;
        public static string RecipientBirthDate;
        public static string RecipientCity;
        public static string SenderName;
        public static string SenderMobile;
        public static string SenderCity;
        public static string SenderCountry;
        public static string Merchant;
        public static string SourceControlNumber;
        public static int returnCode;
        public static string Status;
        public static string AMTN2;
        public static string ReceivedDate;
        public static string MerchantName;
        public static string AmountToCustomer;
        public static string ExchangeRate;
        public static string RefNo;
        public static string ConfNo;
        public static string SenderNationality;
        public static string SenderResidency;
        public static string SenderBirthDate;
        public static string SenderEmail;
        public static string RecipientCountry;
        public static string RecipientNationality;
        public static string RecipientResidency;
        public static string RecipientEmail;
        public static string StatusDesc;
        public static string SecretQuestion;
        public static string SecretAnswer;
        public static string columns;
        public static string RBDate;
        public static string SBDate;
        public static string RBDate2;
        public static DateTime Date;
        public static DateTime Date2;
        public static DateTime Date3;
        public static DateTime Date4;
        public static string HowReceived;
        public static string SearchValue1;
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

            link = PortalGetList.link;
            rptn = PortalGetList.rptn;
            rptnumber = Convert.ToInt32(Decrypt(rptn));
            reportLink = Decrypt(link);
            Panel1.Visible = false;

            Panel2.Visible = false;
            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("hi-IN", true);
                time = Convert.ToDateTime(DateTime.Now, theCultureInfo).ToString("h:mm tt");
                date = DateTime.Now.ToString("dddd, dd MMM, yyyy");

            }
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ConnectionString;
                string insertStoredProcName = "sp_Portal_Report";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //SqlCommand cmd = new SqlCommand("sp_HelpDesk_Request", connectionHelpdesk);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        cmd.Parameters.AddWithValue("@ReportNumber", rptnumber);
                        cmd.Parameters.AddWithValue("@String1", SearchValue.Text);

                        conn.Open();
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {

                            Panel1.Visible = true;
                            GridView1.DataSource = sqlReader;
                            GridView1.DataBind();
                                    SearchValue1 = SearchValue.Text;
                                    Label2.Visible = false;
                                    Session["time"] = time.ToString();
                                    Session["date"] = date.ToString();
                                    Session["reportLink"] = reportLink.ToString();
                                    Session["rptnumber"] = rptnumber.ToString();
                                    Session["SearchValue1"] = SearchValue1.ToString();
                                    Response.Redirect("BulkPaymentBatchFileDetailReport.aspx");
                            sqlReader.Close();
                        }

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
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


        

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }
    }
}