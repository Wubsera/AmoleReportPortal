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
    public partial class RemittanceReprintReceipt : System.Web.UI.Page
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
        //public static string Merchant;
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
        public static string HowToRecieve;
        public static string RecipientResidency;
        public static string RecipientNationality;
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
            Panel2.Visible = false;
            //Remittance_Receipt();
            //GridView2.Visible = false;
            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
               
                //ReportHeading1 = PortalReportAvailable.ReportHeading1;
                //ReportHeading2 = PortalReportAvailable.ReportHeading2;
                //ReportHeading3 = PortalReportAvailable.ReportHeading3;
                //FullName = PortalReportAvailable.FullName;
                //LastLoggedIn = PortalReportAvailable.LastLoggedIn;
                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("hi-IN", true);
                time = Convert.ToDateTime(DateTime.Now, theCultureInfo).ToString("h:mm tt");
                date = DateTime.Now.ToString("dddd, dd MMM, yyyy");

            }
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                SqlConnection connectionReport = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                SqlCommand commandReport = new SqlCommand("sp_Portal_GetList", connectionReport);
                commandReport.CommandType = CommandType.StoredProcedure;
                commandReport.Parameters.AddWithValue("@ListType", 2);
                commandReport.Parameters.AddWithValue("@LoginID", LoginID);
                commandReport.Connection = connectionReport;
                try
                {
                    // connectionReport.Open();
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
                        cmd.Parameters.AddWithValue("@String1", AMTN.Text);

                        conn.Open();
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {

                           
                            GridView2.DataSource = sqlReader;
                            GridView2.DataBind();
                            GridView2.Visible = false;
                            Panel2.Visible = true;
                            for (int i = 0; i < GridView2.Rows.Count; i++)
                            {
                                Status = GridView2.Rows[i].Cells[22].Text;
                                AMTN2 = GridView2.Rows[i].Cells[21].Text;
                                ReceivedDate = GridView2.Rows[i].Cells[23].Text;
                                MerchantName = GridView2.Rows[i].Cells[24].Text;
                                SourceControlNumber = GridView2.Rows[i].Cells[27].Text;
                                AmountToCustomer = GridView2.Rows[i].Cells[29].Text;
                                ExchangeRate = GridView2.Rows[i].Cells[28].Text;
                                RefNo = GridView2.Rows[i].Cells[25].Text;
                                ConfNo = GridView2.Rows[i].Cells[26].Text;
                                SenderName = GridView2.Rows[i].Cells[12].Text;
                                SenderCity = GridView2.Rows[i].Cells[17].Text;
                                SenderCountry = GridView2.Rows[i].Cells[18].Text;
                                SenderNationality = GridView2.Rows[i].Cells[20].Text;
                                SenderResidency = GridView2.Rows[i].Cells[19].Text;
                                SenderBirthDate = GridView2.Rows[i].Cells[16].Text;
                                SenderMobile = GridView2.Rows[i].Cells[13].Text;
                                SenderEmail = GridView2.Rows[i].Cells[14].Text;
                                RecipientName = GridView2.Rows[i].Cells[3].Text;
                                RecipientCity = GridView2.Rows[i].Cells[8].Text;
                                RecipientCountry = GridView2.Rows[i].Cells[9].Text;
                                RecipientResidency = GridView2.Rows[i].Cells[10].Text;
                                RecipientNationality = GridView2.Rows[i].Cells[11].Text;
                                RecipientBirthDate = GridView2.Rows[i].Cells[7].Text;
                                RecipientMobile = GridView2.Rows[i].Cells[4].Text;
                                RecipientEmail = GridView2.Rows[i].Cells[5].Text;
                                HowToRecieve = GridView2.Rows[i].Cells[2].Text;

                                Date2 = DateTime.Parse(SenderBirthDate);
                                SBDate = Date2.ToString("dd MMM yyyy", null);
                                Date3 = DateTime.Parse(RecipientBirthDate);
                                RBDate2 = Date3.ToString("dd MMM yyyy", null);
                                Date4 = DateTime.Parse(ReceivedDate);
                                ReceivedDate = Date4.ToString("dd MMM yyyy - h:MM tt", null);

                                //RBDate = DateTime.ParseExact(RecipientBirthDate, "dd MMM yyyy", null);
                            }

                            //sqlReader.NextResult();


                            sqlReader.Close();
                        }


                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    //Response.Write(ex);
                }
                try
                {
                    //Date = DateTime.ParseExact(RecipientBirthDate, "yyyy-MM-dd HH:mm tt", null);
                    Date = DateTime.Parse(RecipientBirthDate);

                    RBDate = Date.ToString("dd MMM yyyy", null);

                }
                catch (Exception ex)
                {

                }
            }

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
                        cmd.Parameters.AddWithValue("@String1", AMTN.Text);

                        conn.Open();
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {

                            //sqlReader.NextResult();

                            while (sqlReader.Read())
                            {
                                //Response.Write("ReturnCode - " + sqlReader.GetValue(0));
                                //Response.Write("ReturnCode - " + sqlReader.GetValue(1));
                                returnCode = Convert.ToInt32(sqlReader.GetValue(0));
                                columns = Convert.ToString(sqlReader.GetValue(1));

                                if (returnCode == 1)
                                {
                                    Label2.Text = "";

                                }
                                else
                                {
                                    Label2.Text = columns;
                                    Panel2.Visible = false;
                                }

                            }

                            //sqlReader.NextResult();

                            //while (sqlReader.Read())
                            //{
                            //    Response.Write("From third SQL - " + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1));
                            //}

                            sqlReader.Close();
                            cmd.Dispose();
                            conn.Close();
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("Can not open connection ! " + ex);
                }

            }

        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ReprintReceipt.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemittanceReprintReceipt.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }
    }
}