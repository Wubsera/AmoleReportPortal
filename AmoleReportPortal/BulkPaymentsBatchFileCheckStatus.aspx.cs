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
    public partial class BulkPaymentsBatchFileCheckStatus : System.Web.UI.Page
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
        public static string returnCode;
        public static string ReturnMsg;
        public static string BulkPayID;
        public static string MerchantName;
        public static string AvailableBalance;
        public static string Channel;
        public static string Status;
        public static string StatusDate;
        public static string RefNo;
        public static string FundingRefNo;
        public static string FeeRefNo;
        public static string Description;
        public static string FileName;
        public static string ProcessAfter;
        public static string Payees;
        public static string Valid;
        public static string Errors;
        public static string Pending;
        public static string Paid;
        public static string NotPaid;
        public static string TotalAmount;
        public static string DisbursedAmount;
        public static string ServiceFee;
        public static string RequestedBy;
        public static string ReviewedBy;
        public static string ApprovedOrRejected;
        public static string LoadBegin;
        public static string LoadEnd;
        public static string LoadTime;
        public static string EditBegin;
        public static string EditEnd;
        public static string EditTime;
        public static string ProcBegin;
        public static string ProcEnd;
        public static string ProcTime;
        public static string ApprovalButtonsInd;
        public static string ReviewButtonInd;
        public static string ApprovedOrRejectedLabel;
        public static string BatchID1;
        public static string TotalRecipients;
        public static string BatchTotalAmount;
        public static string RejectButtonInd;
        static string prevPage = String.Empty;

        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            box2.Visible = false;
            error.Visible = false;
            success.Visible = false;
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

            if (Login.LoginID != null)
            {
                if (!IsPostBack) //check if the webpage is loaded for the first time.
                {
                    ViewState["PreviousPage"] =
                Request.UrlReferrer;//Saves the Previous page url in ViewState
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int returnCode1;
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
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        cmd.Parameters.AddWithValue("@ReportNumber", rptnumber);
                        cmd.Parameters.AddWithValue("@String1", TextBox1.Text);
                        conn.Open();
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {
                            GridView1.DataSource = sqlReader;
                            GridView1.DataBind();
                            GridView1.Visible = false;
                            //int returnCode1 = sqlReader.GetInt32(0);
                            
                            for (int i = 0; i < GridView1.Rows.Count; i++)
                            {
                                returnCode= GridView1.Rows[i].Cells[0].Text;
                                ReturnMsg = GridView1.Rows[i].Cells[1].Text;
                                BulkPayID = GridView1.Rows[i].Cells[2].Text;
                                MerchantName = GridView1.Rows[i].Cells[3].Text;
                                AvailableBalance = GridView1.Rows[i].Cells[4].Text;
                                Channel = GridView1.Rows[i].Cells[5].Text;
                                Status = GridView1.Rows[i].Cells[6].Text;
                                StatusDate = GridView1.Rows[i].Cells[7].Text;
                                RefNo = GridView1.Rows[i].Cells[8].Text;
                                FeeRefNo = GridView1.Rows[i].Cells[9].Text;
                                Description = GridView1.Rows[i].Cells[10].Text;
                                FileName = GridView1.Rows[i].Cells[11].Text;
                                ProcessAfter = GridView1.Rows[i].Cells[12].Text;
                                Payees = GridView1.Rows[i].Cells[13].Text;
                                Valid = GridView1.Rows[i].Cells[14].Text;
                                Errors = GridView1.Rows[i].Cells[15].Text;
                                Pending = GridView1.Rows[i].Cells[16].Text;
                                Paid = GridView1.Rows[i].Cells[17].Text;
                                NotPaid = GridView1.Rows[i].Cells[18].Text;
                                TotalAmount = GridView1.Rows[i].Cells[19].Text;
                                DisbursedAmount = GridView1.Rows[i].Cells[20].Text;
                                ServiceFee = GridView1.Rows[i].Cells[21].Text;
                                RequestedBy = GridView1.Rows[i].Cells[22].Text;
                                ReviewedBy = GridView1.Rows[i].Cells[23].Text;
                                ApprovedOrRejectedLabel = GridView1.Rows[i].Cells[24].Text;
                                ApprovedOrRejected = GridView1.Rows[i].Cells[25].Text;
                                LoadBegin = GridView1.Rows[i].Cells[26].Text;
                                LoadEnd = GridView1.Rows[i].Cells[27].Text;
                                LoadTime = GridView1.Rows[i].Cells[28].Text;
                                EditBegin = GridView1.Rows[i].Cells[29].Text;
                                EditEnd = GridView1.Rows[i].Cells[30].Text;
                                EditTime = GridView1.Rows[i].Cells[31].Text;
                                ProcBegin = GridView1.Rows[i].Cells[32].Text;
                                ProcEnd = GridView1.Rows[i].Cells[33].Text;
                                ProcTime = GridView1.Rows[i].Cells[34].Text;
                                ReviewButtonInd = GridView1.Rows[i].Cells[35].Text;
                                ApprovalButtonsInd = GridView1.Rows[i].Cells[36].Text;
                                RejectButtonInd= GridView1.Rows[i].Cells[37].Text;
                            }
                            returnCode1 = Int32.Parse(returnCode);
                            if (returnCode1 >=1)
                            {
                                box2.Visible = true;
                                ImageButton1.Visible = false;
                                ImageButton2.Visible = false;
                                ImageButton3.Visible = false;
                                //Button3.Visible = false;
                                if (ReviewButtonInd == "Y")
                                {
                                    ImageButton1.Visible = false;
                                    ImageButton2.Visible = false;
                                    ImageButton3.Visible = true;
                                }
                                if (ApprovalButtonsInd == "Y")
                                {
                                    ImageButton1.Visible = true;
                                    ImageButton3.Visible = false;
                                }
                                if (ImageButton3.Visible ==false && ImageButton1.Visible==false)
                                {
                                    ImageButton2.Visible = false;
                                }
                                else
                                {
                                    ImageButton2.Visible = true;
                                }

                                error.Visible = false;
                            }
                            else
                            {
                                error.Visible = true;
                                box2.Visible = false;
                                error.Text = ReturnMsg;
                            }
                      
                            sqlReader.Close();
                            cmd.Dispose();
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    error.Visible = true;
                    error.Text = ReturnMsg +ex;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                string connectionString3 = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                string insertStoredProcName3 = "sp_Portal_130_BulkPay_Status_Set";
                using (SqlConnection conn3 = new SqlConnection(connectionString3))
                using (SqlCommand cmd3 = new SqlCommand(insertStoredProcName3, conn3))
                {
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@LoginID", LoginID);
                    cmd3.Parameters.AddWithValue("@BatchID", BulkPayID);
                    cmd3.Parameters.AddWithValue("@ApproveRejectInd", "A");
                    conn3.Open();
                    using (SqlDataReader rdr3 = cmd3.ExecuteReader())
                    {
                        while (rdr3.Read())
                        {
                            int returnCode = rdr3.GetInt32(0);
                            ReturnMsg = rdr3.GetString(1);
                            if (returnCode >= 1)
                            {
                                box2.Visible = false;
                                success.Visible = true;
                            }
                            else
                            {
                                success.Visible = false;
                                error.Visible = true;
                                error.Text = ReturnMsg;
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
                error.Visible = true;
                error.Text = ReturnMsg + ex;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {

                string connectionString3 = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                string insertStoredProcName3 = "sp_Portal_130_BulkPay_Status_Set";
                using (SqlConnection conn3 = new SqlConnection(connectionString3))
                using (SqlCommand cmd3 = new SqlCommand(insertStoredProcName3, conn3))
                {
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@LoginID", LoginID);
                    cmd3.Parameters.AddWithValue("@BatchID", BulkPayID);
                    cmd3.Parameters.AddWithValue("@ApproveRejectInd", "R");
                    conn3.Open();
                    using (SqlDataReader rdr3 = cmd3.ExecuteReader())
                    {
                        while (rdr3.Read())
                        {
                            int returnCode = rdr3.GetInt32(0);
                            ReturnMsg = rdr3.GetString(1);
                            if (returnCode >= 1)
                            {
                                box2.Visible = false;
                                success.Visible = false;
                                error.Visible = true;
                                error.Text = ReturnMsg;
                            }
                            else
                            {
                                success.Visible = false;
                                error.Visible = true;
                                error.Text = ReturnMsg;
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
                error.Visible = true;
                error.Text = ReturnMsg + ex;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            success.Visible = false;
        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            try
            {
                string connectionString3 = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                string insertStoredProcName3 = "sp_Portal_130_BulkPay_Status_Set";
                using (SqlConnection conn3 = new SqlConnection(connectionString3))
                using (SqlCommand cmd3 = new SqlCommand(insertStoredProcName3, conn3))
                {
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@LoginID", LoginID);
                    cmd3.Parameters.AddWithValue("@BatchID", BulkPayID);
                    cmd3.Parameters.AddWithValue("@ReviewedInd", "Y");
                    conn3.Open();
                    using (SqlDataReader rdr3 = cmd3.ExecuteReader())
                    {
                        while (rdr3.Read())
                        {
                            int returnCode = rdr3.GetInt32(0);
                            ReturnMsg = rdr3.GetString(1);
                            if (returnCode >= 1)
                            {
                                box2.Visible = false;
                                success.Visible = true;
                            }
                            else
                            {
                                success.Visible = false;
                                error.Visible = true;
                                error.Text = ReturnMsg;
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
                error.Visible = true;
                error.Text = ReturnMsg + ex;
            }
        }
    }
}










//ReturnMsg = sqlReader.GetString(1);
//BulkPayID = sqlReader.GetInt32(2);
//MerchantName = sqlReader.GetString(3);
//AvailableBalance = sqlReader.GetDecimal(4);
//Channel = sqlReader.GetString(5);
//Status = sqlReader.GetString(6);
//StatusDate = sqlReader.GetString(7);
//RefNo = sqlReader.GetInt64(8);
//FeeRefNo = sqlReader.GetInt64(9);
//Description = sqlReader.GetString(10);
//FileName = sqlReader.GetString(11);
//ProcessAfter = sqlReader.GetString(12);
//Payees = sqlReader.GetInt32(13);
//Valid = sqlReader.GetInt32(14);
//Errors = sqlReader.GetInt32(15);
//Pending = sqlReader.GetInt32(16);
//Paid = sqlReader.GetInt32(17);
//NotPaid = sqlReader.GetInt32(18);
//TotalAmount = sqlReader.GetDecimal(19);
//DisbursedAmount = sqlReader.GetDecimal(20);
//ServiceFee = sqlReader.GetDecimal(21);
//RequestedBy = sqlReader.GetString(22);
//ApprovedOrRejected = sqlReader.GetString(23);
//LoadBegin = sqlReader.GetString(24);
//LoadEnd = sqlReader.GetString(25);
//LoadTime = sqlReader.GetString(26);
//EditBegin = sqlReader.GetString(27);
//EditEnd = sqlReader.GetString(28);
//EditTime = sqlReader.GetString(29);
//ProcBegin = sqlReader.GetString(30);
//ProcEnd = sqlReader.GetString(31);
//ProcTime = sqlReader.GetString(32);
//ApprovalButtonsInd = sqlReader.GetString(33);
//if (ApprovalButtonsInd != "Y")
//{
//    Button2.Visible = false;
//    Button3.Visible = false;
//    confirm.Visible = false;
//    deny.Visible = false;
//}


//while (sqlReader.Read())
//{

//}