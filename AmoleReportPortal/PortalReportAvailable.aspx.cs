using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.ComponentModel;

namespace AmoleReportPortal
{
    public partial class PortalReportAvailable : System.Web.UI.Page
    {

        public static string date;
        public static string time;
        public static string ClientName;
        public static string LoginID;
        public static string repLink;
        public static string ReportHeading1;
        public static string ReportHeading2;
        public static string ReportHeading3;
        public static string FullName;
        public static string LastLoggedIn;
        public static string photo;
        public string rptnumber;
        public string ReportName;
        public static string ReportName2;
        public static string pass;
        public static byte[] PH;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                if(Session["LoginID"]!=null)
                {
                    LoginID = Session["LoginID"].ToString();
                }
    
                var clientName = HttpContext.Current;
                try
                {
                    SqlConnection connectionReport = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                    connectionReport.Open();
                    SqlCommand commandReport = new SqlCommand("sp_Portal_Reports_Available ", connectionReport);
                    commandReport.CommandType = CommandType.StoredProcedure;
                    commandReport.Parameters.AddWithValue("@LoginID", LoginID);
                    SqlDataReader checkedReport = commandReport.ExecuteReader();
                    shoa.SelectParameters.Add("LoginID", LoginID);
                    GridViewHelper helper = new GridViewHelper(this.GridView1);
                    helper.RegisterGroup("ReportGroup", true, true);

                   // helper.ApplyGroupSort();

                    connectionReport.Close();
                    if (!IsPostBack)
                    {
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_Portal_Report_Heading", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {
                           

                            while (sqlReader.Read())
                            {
                                //GridView2.DataSource = sqlReader;
                                //GridView2.DataBind();
                                //GridView2.Visible = false;
                                ReportHeading1 = Convert.ToString(sqlReader.GetValue(0));
                                ReportHeading2 = Convert.ToString(sqlReader.GetValue(1));
                                ReportHeading3 = Convert.ToString(sqlReader.GetValue(2));
                                FullName = Convert.ToString(sqlReader.GetValue(3));
                                LastLoggedIn = Convert.ToString(sqlReader.GetValue(4));
                                try
                                { 
                                PH =   (byte[])sqlReader["Photo"];
                                
                                    photo = Convert.ToBase64String(PH);
                                    Image1.ImageUrl = "data:image;base64," + photo;
                                }                               
                                catch(Exception)
                                {
                                    Image1.ImageUrl = "~/images/AmoleLogo.jpg";
                                }
                                Image1.Width = 85;
                                Image1.Height = 75;
                                

                            }
                            sqlReader.Close();
                        }


                        //for (int i = 0; i < GridView2.Rows.Count; i++)
                        //{
                        //    ReportHeading1 = GridView2.Rows[i].Cells[0].Text;
                        //    ReportHeading2 = GridView2.Rows[i].Cells[1].Text;
                        //    ReportHeading3 = GridView2.Rows[i].Cells[2].Text;
                        //    FullName = GridView2.Rows[i].Cells[3].Text;
                        //    LastLoggedIn = GridView2.Rows[i].Cells[4].Text;
                        //    Session["ReportHeading1"] = ReportHeading1.ToString();
                        //    Session["ReportHeading2"] = ReportHeading2.ToString();
                        //    Session["ReportHeading3"] = ReportHeading3.ToString();
                        //    Session["FullName"] = FullName.ToString();
                        //    Session["LastLoggedIn"] = LastLoggedIn.ToString();
                        //    //Session.Clear();
                        //    //photo = GridView2.Rows[i].Cells[5].Text;
                        //}
                        con.Close();
                    }

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        //GridView1.Rows[0].Visible = false;
                        //GridView1.Rows[1].Visible = false;
                    }
                }
                catch (SqlException  ex)
                {
                    Label1.Visible = true;
                   Label1.Text=("" + ex);
                    Response.Redirect("Login.aspx");
                }
            }
            catch (System.ComponentModel.Win32Exception ex2)
            {
                Label1.Visible = true;
                Label1.Text = ""+ex2;
                Response.Redirect("Login.aspx");
            }
            try
            {
            Session["ReportHeading1"] = ReportHeading1.ToString();
            Session["ReportHeading2"] = ReportHeading2.ToString();
            Session["ReportHeading3"] = ReportHeading3.ToString();
            Session["FullName"] = FullName.ToString();
            Session["LastLoggedIn"] = LastLoggedIn.ToString();
            Session["photo"] = photo.ToString();
           
          

            }
            catch(Exception ex)
            {

            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            foreach (GridViewRow r in GridView1.Rows)
            {       
                if (r.RowType == DataControlRowType.DataRow)
                {
                    r.Attributes["Font"] += new FontFamily("Calibri");
                    for (int columnIndex = 1; columnIndex < r.Cells.Count; columnIndex++)
                    {
                        ReportName = HttpUtility.UrlEncode(Encrypt(r.Cells[2].Text));
                        rptnumber = HttpUtility.UrlEncode(Encrypt(r.Cells[0].Text));
                        //ReportNumber = GridView1.Rows[columnIndex].Cells[0].Text;
                        r.Cells[columnIndex].Attributes["style"] += "background-color:White";
                        //r.Cells[columnIndex].Attributes["padding"]= "100px 0 0 0";
                        r.Cells[columnIndex].ForeColor = Color.FromName("blue");
                        r.Cells[columnIndex].ForeColor = Color.FromName("blue");
                        //r.Cells[columnIndex].Font.Bold = false;
                        //r.Cells[columnIndex].Attributes["Font"] += FontSize.Small;
                        r.Cells[columnIndex].Attributes["Font"] += new FontFamily("Calibri");
                        r.Cells[columnIndex].Attributes["style"] = "cursor:pointer";
                        r.Cells[columnIndex].Attributes.Add("onclick", "top.location.href='PortalGetList.aspx?ReportNumber=" + rptnumber + "&ReportName=" + ReportName + "'");
                        r.Cells[columnIndex].Attributes.Add("onmouseover", "this.style.backgroundColor='#e1e1ff'");
                        r.Cells[columnIndex].Attributes.Add("onmouseout", "this.style.backgroundColor='white'");
                        r.Cells[columnIndex].BackColor = Color.FromName("white");
                        
                    }
                }
            }
            
            e.Row.Font.Underline = true;
            e.Row.ForeColor = Color.FromName("blue");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Cells[0].Visible = false;
                GridView1.Rows[i].Cells[2].Font.Underline = true;

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
        protected void logout_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}