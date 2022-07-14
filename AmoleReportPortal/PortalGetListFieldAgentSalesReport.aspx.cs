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
    public partial class PortalGetListFieldAgentSalesReport : System.Web.UI.Page
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
        public static string RegionID;
        public static string EventID;
        public static string ReporttNumber;
        public static string rptn;
        public static string link;
        public static string Location1;
        public static string City;
        public static string Woreda;
        public static string photo;

        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Location1 = String1.Text;
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

            //if (Session["LoginID"] != null)
            //{
            //    LoginID = Session["LoginID"].ToString();
            //}

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
                try
                {
                    //Merchant List 
                    SqlConnection MerchantConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                    SqlCommand MerchantCommand = new SqlCommand("sp_Portal_GetList", MerchantConnection);
                    MerchantCommand.CommandType = CommandType.StoredProcedure;
                    MerchantCommand.Parameters.AddWithValue("@ListType", 2);
                    MerchantCommand.Parameters.AddWithValue("@LoginID", LoginID);
                    MerchantCommand.Connection = MerchantConnection;

                    MerchantConnection.Open();
                    MerchantDropdown.DataSource = MerchantCommand.ExecuteReader();
                    MerchantDropdown.DataTextField = "Merchant";
                    MerchantDropdown.DataValueField = "MerchantID";
                    MerchantDropdown.DataBind();
                    MerchantConnection.Close();

                    //Region List 
                    SqlConnection RegionConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                    SqlCommand RegionCommand = new SqlCommand("sp_Portal_GetList", RegionConnection);
                    RegionCommand.CommandType = CommandType.StoredProcedure;
                    RegionCommand.Parameters.AddWithValue("@ListType", 101);
                    RegionCommand.Parameters.AddWithValue("@LoginID", LoginID);
                    RegionCommand.Connection = RegionConnection;

                    RegionConnection.Open();
                    RegionDropdown.DataSource = RegionCommand.ExecuteReader();
                    RegionDropdown.DataTextField = "Region";
                    RegionDropdown.DataValueField = "RegionID";
                   
                    RegionDropdown.DataBind();
                    RegionConnection.Close();

                   
                    //City List 
                    SqlConnection CityConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                    SqlCommand CityCommand = new SqlCommand("sp_Portal_GetList", CityConnection);
                    CityCommand.CommandType = CommandType.StoredProcedure;
                    CityCommand.Parameters.AddWithValue("@ListType", 103);
                    CityCommand.Parameters.AddWithValue("@LoginID", LoginID);
                    CityCommand.Connection = CityConnection;

                    CityConnection.Open();
                    CityDropdown.DataSource = CityCommand.ExecuteReader();
                    CityDropdown.DataTextField = "City";
                    CityDropdown.DataValueField = "City";
                    CityDropdown.DataBind();
                    CityConnection.Close();

                    
                }

                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Check your connection ');", true);
                    Response.Redirect("Login.aspx");
                }
            }
        }

      

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
            From = txtFrom.Text;
        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            To = txtTo.Text;
            //txtTo.Text = Calendar1.SelectedDate.ToString();
            //txtFrom.Text = Calendar1.SelectedDate.ToString("MMM dd,yyyy");
            //From = txtFrom.Text;
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

        protected void MerchantDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            MerchantID = MerchantDropdown.SelectedValue;
            
        }

        protected void RegionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection ZoneConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
            SqlCommand ZoneCommand = new SqlCommand("sp_Portal_GetList", ZoneConnection);
            ZoneCommand.CommandType = CommandType.StoredProcedure;
            ZoneCommand.Parameters.AddWithValue("@ListType", 102);
            ZoneCommand.Parameters.AddWithValue("@LoginID", LoginID);
            ZoneCommand.Parameters.AddWithValue("@Integer1", RegionDropdown.SelectedValue);
            ZoneCommand.Connection = ZoneConnection;

            ZoneConnection.Open();
            ZoneDropdown.DataSource = ZoneCommand.ExecuteReader();
            ZoneDropdown.DataTextField = "Zone";
            ZoneDropdown.DataValueField = "ZoneID";
            ZoneDropdown.DataBind();
            ZoneConnection.Close();
        }

        protected void ZoneDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Woreda List 
            SqlConnection WoredaConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
            SqlCommand WoredaCommand = new SqlCommand("sp_Portal_GetList", WoredaConnection);
            WoredaCommand.CommandType = CommandType.StoredProcedure;
            WoredaCommand.Parameters.AddWithValue("@ListType", 104);
            WoredaCommand.Parameters.AddWithValue("@LoginID", LoginID);
            WoredaCommand.Parameters.AddWithValue("@Integer1", ZoneDropdown.SelectedValue);
            WoredaCommand.Connection = WoredaConnection;

            WoredaConnection.Open();
            WoredaDropdown.DataSource = WoredaCommand.ExecuteReader();
            WoredaDropdown.DataTextField = "Woreda";
            WoredaDropdown.DataValueField = "WoredaID";
            WoredaDropdown.DataBind();
            WoredaConnection.Close();
        }

        protected void CityDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            City = CityDropdown.SelectedValue.ToString();
        }

        protected void WoredaDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

            Woreda = WoredaDropdown.SelectedItem.ToString();
        }
        protected void Generate_Click(object sender, ImageClickEventArgs e)
        {
            string Region = RegionDropdown.SelectedItem.ToString();
            string Zone = ZoneDropdown.SelectedItem.ToString();
            string City = CityDropdown.SelectedItem.ToString();
            string Woreda = WoredaDropdown.SelectedItem.ToString();
            Session["MerchantID"] = MerchantID.ToString();
            Session["From"] = From.ToString();
            Session["To"] = To.ToString();
            Session["time"] = time.ToString();
            Session["date"] = date.ToString();
            Session["reportLink"] = reportLink.ToString();
            Session["rptnumber"] = rptnumber.ToString();
            Session["Region"] = Region.ToString();
            Session["Zone"] = Zone.ToString();
            Session["City"] = City.ToString();
            Session["Woreda"] = Woreda.ToString();
            System.Threading.Thread.Sleep(5000);
            if (MerchantID != "")
            {
                Response.Redirect("FieldAgentSalesReport.aspx");

            }
            //else
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Merchant not assigned, please contact amole support ');", true);
            //}
        }
    }
}