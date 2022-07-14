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
using System.Text.RegularExpressions;
using System.Drawing;

namespace AmoleReportPortal
{
    public partial class UploadBulkPaymentFile : System.Web.UI.Page
    {

        public static string LoginID;
        public static string ClientName;
        public static string date;
        public static string time;
        public static string ReportNumber;
        public static string ReportName;
        public static string ReportName2;
        public static string reportLink;
        public static string ReportHeading1;
        public static string ReportHeading2;
        public static string ReportHeading3;
        public static string FullName;
        public static string LastLoggedIn;
        public static string photo;
        public static string location;
        public static string greport;
        public static string rptnumber;
        public static string From;
        public static string To;
        public static string FromP;
        public static string ToP;
        public static string Checked;
        public static string BranchId;
        public static string pageName;
        public static string MerchantID;
        public static int returnCode;
        public static int BulkPayID;
        public static string ReturnMsg1;
        public static int BatchID1;
        public static int TotalRecipients;
        public static decimal BatchTotalAmount;
        public static string ProcessAfterMsg;
        static string prevPage = String.Empty;
        public static string FileName;

        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(Button1, "") + ";this.value='Please wait....';this.disabled = true;");
            Button1.Enabled = false;
            Label6.Text = "";
            Button1.Visible = false;
            Panel1.Visible = true;
            success.Visible = false;
            TextBox1.Text= DateTime.Now.ToString("MMMM dd, yyyy");
            IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("hi-IN", true);
            appt.Value= Convert.ToDateTime(DateTime.Now, theCultureInfo).ToString("h:mm tt");

            time = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
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
                //rptnumber = Convert.ToInt32(reporttNumber);
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
                if (Session["reportLink"] != null)
                {
                reportLink = Session["reportLink"].ToString();
                }
            if (Session["rptnumber"] != null)
            {
                rptnumber = Session["rptnumber"].ToString();
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
            From = PortalGetList.From;
            To = PortalGetList.To;

            if (Login.LoginID != null)
            {
                if (!IsPostBack) //check if the webpage is loaded for the first time.
                {
                    ViewState["PreviousPage"] =
                Request.UrlReferrer;//Saves the Previous page url in ViewState
                }

                date = DateTime.Now.ToString("dddd, dd MMM, yyyy");
                ClientName = PortalReportAvailable.ClientName;

            }
            else
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
                    connectionReport.Open();
                    DropDownList1.DataSource = commandReport.ExecuteReader();
                    DropDownList1.DataTextField = "Merchant";
                    DropDownList1.DataValueField = "MerchantID";
                    DropDownList1.DataBind();
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
        protected void ReadCSV(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    Button1.Enabled = true;
                    var folder = Server.MapPath("~/Files/");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    //Upload and save the file

                    string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(csvPath);
                    FileName = FileUpload1.FileName;
                    Session["FileName"] = FileName.ToString();
                    //Create a DataTable.
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[2] {
                new DataColumn("Mobile Number", typeof(string)),
                new DataColumn("Amount",typeof(decimal)) });

                    //Read the contents of CSV file.
                    string csvData = File.ReadAllText(csvPath);

                    //Execute a loop over the rows.
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            dt.Rows.Add();
                            int i = 0;

                            //Execute a loop over the columns.
                            foreach (string cell in row.Split(',', '\t'))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell;
                                i++;
                            }
                        }
                    }

                    //Bind the DataTable.
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    if (Directory.Exists(folder))
                    {
                        Directory.Delete(folder, true);
                    }
                    Button1.Visible = true;
                    Label6.Text = "";
                }
                catch (Exception)
                {
                    Label6.Text = "File type must be in CSV (Comma Delimited) or TXT (Tab Delimited) format.";
                    Button1.Visible = false;
                    Panel1.Visible = false;

                }

            }
            else
            {
                Label6.Text = "Please select a file.";
                Panel1.Visible = false;
            }
            
        }

        protected void fettanMark_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MerchantID = DropDownList1.SelectedValue;
            if (Session["FileName"] != null)
            {
                FileName = Session["FileName"].ToString();
            }

            string connectionString = ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ConnectionString;
                string insertStoredProcName = "sp_Portal_Report";
                string columns;
            try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        cmd.Parameters.AddWithValue("@ReportNumber", rptnumber);
                        cmd.Parameters.AddWithValue("@Integer1", MerchantID);
                        cmd.Parameters.AddWithValue("@String1", TextArea1.Value );
                        cmd.Parameters.AddWithValue("@String2", FileName);
                        cmd.Parameters.AddWithValue("@Date1", TextBox1.Text );
                        cmd.Parameters.AddWithValue("@Date2", appt.Value);
                       
                        conn.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                returnCode = rdr.GetInt32(0);
                                columns = rdr.GetString(1);
                                BulkPayID = rdr.GetInt32(2);

                                if (returnCode == 1)
                                {
                                for (int i = 0; i < GridView1.Rows.Count; i++)
                                {
                                    
                                    try
                                    {
                                        
                                        string connectionString2 = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                                        string insertStoredProcName2 = "sp_Portal_131_BulkPay_Recipient";
                                       

                                        using (SqlConnection conn2 = new SqlConnection(connectionString2))
                                        using (SqlCommand cmd2 = new SqlCommand(insertStoredProcName2, conn2))
                                        {
                                            cmd2.CommandType = CommandType.StoredProcedure;

                                            string mobileTel = GridView1.Rows[i].Cells[0].Text;
                                            string amount = GridView1.Rows[i].Cells[1].Text;
                                            cmd2.Parameters.AddWithValue("@BulkPayID", BulkPayID);
                                            cmd2.Parameters.AddWithValue("@MobileTelx", mobileTel);
                                            cmd2.Parameters.AddWithValue("@Amountx", amount);


                                            conn2.Open();
                                            using (SqlDataReader rdr2 = cmd2.ExecuteReader())
                                            {
                                                while (rdr2.Read())
                                                {
                                                    int returnCode2 = rdr2.GetInt32(0);
                                                  string columns2 = rdr2.GetString(1);
                                                }
                                                rdr2.Close();
                                            }
                                            conn2.Close();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                       // Label6.Text = ;

                                    }

                                }

                                try
                                    {

                                    string connectionString3 = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                                    string insertStoredProcName3 = "sp_Portal_131_BulkPay_Submit_Complete";
                                    
                                    
                                        using (SqlConnection conn3 = new SqlConnection(connectionString3))
                                        using (SqlCommand cmd3 = new SqlCommand(insertStoredProcName3, conn3))
                                        {
                                            cmd3.CommandType = CommandType.StoredProcedure;

                                            cmd3.Parameters.AddWithValue("@BulkPayID", BulkPayID);
                                            conn3.Open();
                                            using (SqlDataReader rdr3 = cmd3.ExecuteReader())
                                            {
                                                while (rdr3.Read())
                                                {
                                                    int returnCode3 = rdr3.GetInt32(0);
                                                 ReturnMsg1 = rdr3.GetString(1);
                                                 BatchID1 = rdr3.GetInt32(2);
                                                 TotalRecipients = rdr3.GetInt32(3);
                                                 BatchTotalAmount = rdr3.GetDecimal(4);
                                                ProcessAfterMsg = rdr3.GetString(5);
                                                if (returnCode3 == 1)
                                                {
                                                    success.Visible = true;
                                                    Panel1.Visible = false;

                                                   
                                                }
                                                else
                                                {
                                                   success.Visible = false;
                                                    Label6.Visible = true;
                                                    Label6.Text = ReturnMsg1;


                                                }
                                                }
                                                rdr3.Close();
                                            }
                                            conn3.Close();
                                        //GridView1.Visible = false;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                   // Label6.Text = ""+ex;
                                    }

                                }
                                else
                                {
                                Label6.Text = columns;
                                }

                            }
                            rdr.Close();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                Label6.Text = "" + ex;
                   
                }
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            success.Visible = false;
            Panel1.Visible = false;
        }
       
    }
}