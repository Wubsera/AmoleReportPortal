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
using System.Drawing;
namespace AmoleReportPortal
{
    public partial class PortalGetListCustomerLookupReport : System.Web.UI.Page
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
        public static string ReporttNumber;
        public static string rptn;
        public static string link;
        public static string CustomerName;
        public static string SearchValue1;
        public static int returnCode;
        public static string columns;
        public static string AccountName0;
        public static string AccountName1;
        public static string AccountName2;
        public static string AccountName3;
        public static string AccountName4;
        public static string AccountName5;
        public static string AccountName6;
        public static string AccountName7;
        public static string AccountName8;
        public static string AccountName9;
        public static string Status;
        public static string AccountNumber;
        public static string Balance;
        public static int CustomerID;
        public static string CustomerPhoto;
        public static byte[] CustomerPH;

        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            Button1.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(Button1, "") + ";this.value='Please wait....';this.disabled = true;");
            Button1.Width = 105;
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
                        Image2.ImageUrl = "data:image;base64," + photo;
                    }
                    catch (Exception)
                    {
                        Image2.ImageUrl = "~/images/AmoleLogo.jpg";
                    }
                    Image2.Width = 85;
                    Image2.Height = 75;
                }
                sqlReader.Close();
            }
            link = PortalGetList.link;
            rptn = PortalGetList.rptn;
            rptnumber = Convert.ToInt32(Decrypt(rptn));
            reportLink = Decrypt(link);

            Panel2.Visible = false;
            Panel4.Visible = false; 
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
            if (IsPostBack)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Portal_Report", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", LoginID);
                    cmd.Parameters.AddWithValue("@ReportNumber", rptnumber);
                    cmd.Parameters.AddWithValue("@String1", SearchValue.Text);
                    SqlDataReader mess = cmd.ExecuteReader();
                    GridView1.DataSource = mess;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Label2.Text = "" + ex;
                }
            }
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                System.Threading.Thread.Sleep(5000);
                Button1.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(Button1, "") + ";this.value='Please wait....';this.disabled = true;");
                Button1.Width = 105;
                string connectionString = ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ConnectionString;
                string insertStoredProcName = "sp_Portal_Report";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        cmd.Parameters.AddWithValue("@ReportNumber", rptnumber);
                        cmd.Parameters.AddWithValue("@String1", SearchValue.Text);


                        conn.Open();
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {
                           

                            while (sqlReader.Read())
                            {

                                returnCode = Convert.ToInt32(sqlReader.GetValue(0));
                                columns = Convert.ToString(sqlReader.GetValue(1));
                                CustomerID = Convert.ToInt32(sqlReader.GetValue(20));

                                if (returnCode == 1)
                                {
                                    Panel1.Visible = true;
                                    if (IsPostBack)
                                    {
                                        string connectionPhoto = ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ConnectionString;
                                        string StringPhoto = "sp_Portal_Customer_Photo_Get";
                                        try
                                        {
                                            using (SqlConnection conphoto = new SqlConnection(connectionPhoto))
                                            using (SqlCommand cmdphoto = new SqlCommand(StringPhoto, conphoto))
                                            {
                                                cmdphoto.CommandType = CommandType.StoredProcedure;
                                                cmdphoto.Parameters.AddWithValue("@CustomerID", CustomerID);

                                                conphoto.Open();
                                                using (SqlDataReader sqlReaderphtoto = cmdphoto.ExecuteReader())
                                                {


                                                    while (sqlReaderphtoto.Read())
                                                    {

                                                       int returnCodephoto = Convert.ToInt32(sqlReaderphtoto.GetValue(0));
                                                        

                                                        if (returnCodephoto == 1)
                                                        {
                                                            byte[] PHP = (byte[])sqlReaderphtoto["Photo"];

                                                           string photop = Convert.ToBase64String(PHP);
                                                            Image1.ImageUrl = "data:image;base64," + photop;
                                                        }
                                                        else
                                                        {
                                                            Image1.ImageUrl = "~/image/person.png";
                                                        }
                                                        Image1.Width = 85;
                                                        Image1.Height = 75;
                                                    }
                                                    sqlReaderphtoto.Close();
                                                }
                                                conphoto.Close();
                                            }
                                            
                                        }
                                        catch
                                        {

                                        }
                                        }
                                    TextBox1.Text = GridView1.Rows[0].Cells[2].Text;
                                    TextBox2.Text = GridView1.Rows[0].Cells[3].Text;
                                    TextBox3.Text = GridView1.Rows[0].Cells[6].Text;
                                    TextBox7.Text = GridView1.Rows[0].Cells[7].Text;
                                    TextBox8.Text = GridView1.Rows[0].Cells[10].Text;
                                    TextBox9.Text = GridView1.Rows[0].Cells[11].Text;
                                    Label12.Text = GridView1.Rows[0].Cells[12].Text;
                                    Label13.Text = GridView1.Rows[0].Cells[14].Text;
                                    TextBox4.Text = GridView1.Rows[0].Cells[4].Text;
                                    TextBox5.Text = GridView1.Rows[0].Cells[5].Text;
                                    TextBox6.Text = GridView1.Rows[0].Cells[8].Text;
                                    TextBox10.Text = GridView1.Rows[0].Cells[13].Text;
                                    TextBox11.Text = GridView1.Rows[0].Cells[15].Text;
                                    TextBox12.Text = GridView1.Rows[0].Cells[9].Text;

                                    if(TextBox1.Text == "&nbsp;")
                                    {
                                        TextBox1.Text = "";
                                    }
                                    if (TextBox2.Text == "&nbsp;")
                                    {
                                        TextBox2.Text = "";
                                    }
                                    if (TextBox3.Text == "&nbsp;")
                                    {
                                        TextBox3.Text = "";
                                    }
                                    if (TextBox4.Text == "&nbsp;")
                                    {
                                        TextBox4.Text = "";
                                    }
                                    if (TextBox5.Text == "&nbsp;")
                                    {
                                        TextBox5.Text = "";
                                    }
                                    if (TextBox6.Text == "&nbsp;")
                                    {
                                        TextBox6.Text = "";
                                    }
                                    if (TextBox7.Text == "&nbsp;")
                                    {
                                        TextBox7.Text = "";
                                    }
                                    if (TextBox8.Text == "&nbsp;")
                                    {
                                        TextBox8.Text = "";
                                    }
                                    if (TextBox9.Text == "&nbsp;")
                                    {
                                        TextBox9.Text = "";
                                    }
                                    if (TextBox10.Text == "&nbsp;")
                                    {
                                        TextBox10.Text = "";
                                    }
                                    if (TextBox11.Text == "&nbsp;")
                                    {
                                        TextBox11.Text = "";
                                    }
                                    if (TextBox12.Text == "&nbsp;")
                                    {
                                        TextBox12.Text = "";
                                    }

                                    if (Label12.Text == "&nbsp;")
                                    {
                                        TextBox10.Visible = false;
                                    }
                                    else
                                    {
                                        TextBox10.Visible = true;
                                    }
                                    if (Label13.Text == "&nbsp;")
                                    {
                                        TextBox11.Visible = false;
                                    }
                                    else
                                    {
                                        TextBox11.Visible = true;
                                    }
                                    GridView1.HeaderRow.Visible = false;
                                    for (int i = 0; i < GridView1.Rows.Count; i++)
                                    {
                                        GridView1.Rows[i].Cells[0].Visible = false;
                                        GridView1.Rows[i].Cells[1].Visible = false;
                                        GridView1.Rows[i].Cells[2].Visible = false;
                                        GridView1.Rows[i].Cells[3].Visible = false;
                                        GridView1.Rows[i].Cells[4].Visible = false;
                                        GridView1.Rows[i].Cells[5].Visible = false;
                                        GridView1.Rows[i].Cells[6].Visible = false;
                                        GridView1.Rows[i].Cells[7].Visible = false;
                                        GridView1.Rows[i].Cells[8].Visible = false;
                                        GridView1.Rows[i].Cells[9].Visible = false;
                                        GridView1.Rows[i].Cells[10].Visible = false;
                                        GridView1.Rows[i].Cells[11].Visible = false;
                                        GridView1.Rows[i].Cells[12].Visible = false;
                                        GridView1.Rows[i].Cells[13].Visible = false;
                                        GridView1.Rows[i].Cells[14].Visible = false;
                                        GridView1.Rows[i].Cells[15].Visible = false;
                                        GridView1.Rows[i].Cells[20].Visible = false;
                                    }

                                    Label2.Visible = false;
                                    Panel4.Visible = true;

                                }
                                else
                                {
                                    GridView1.Visible = false;
                                    Panel4.Visible = false;
                                    Label2.Visible = true;
                                    Label2.Text = columns;
                                    Panel1.Visible = false;
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
                    Label1.Visible = true;
                    Label1.Text = "" + ex;
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