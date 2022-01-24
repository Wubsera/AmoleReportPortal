using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class CustomerLookup : System.Web.UI.Page
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
        public static string NBELevel;
        public static string StatusX;
        public static string MobileTel;
        public static string FirstName;
        public static string SecondName;
        public static string ThirdName;
        public static string Gender;
        public static string BirthDate;
        public static string Email;
        public static string Address1;
        public static string Address2;
        public static string Address3;
        public static string City;
        public static string Country;
        public static string Residency;
        public static string Nationality;
        public static string Region;
        public static string Zone;
        public static string WoredaSubCity;
        public static string columns;
        public static int returnCode;
        public static string Columns;
        public static DateTime Date;
        public static string CBDate;
        public static string CustomerID;
        public static int PendingID;
        public static string gender;
        public static string IDType;
        public static byte[] photo;
        public static byte[] ID;
        public static decimal size;
        public static decimal size2;
        public static int CustomerPendingID;
        public static string returnMsg;
        public static string photop;


        ReportDocument crystalReport = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] != null)
            {
                LoginID = Session["LoginID"].ToString();
            }
            else
            {
                
                Response.Redirect("Login.aspx");
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

                        photop = Convert.ToBase64String(PH);
                        Image3.ImageUrl = "data:image;base64," + photop;
                    }
                    catch (Exception)
                    {
                        Image3.ImageUrl = "~/images/AmoleLogo.jpg";
                    }
                    Image3.Width = 85;
                    Image3.Height = 75;


                }
                sqlReader.Close();
            }
            if (!IsPostBack)
            {
                submit.Visible = false;
                verify.Visible = false;
                Label2.Visible = false;
                TypeOfID.Visible = false;
                Button4.Visible = false;
                link = PortalGetList.link;
                rptn = PortalGetList.rptn;
                rptnumber = Convert.ToInt32(Decrypt(rptn));
                reportLink = Decrypt(link);
                Panel1.Visible = true;
                if ((HttpContext.Current.Request.UrlReferrer == null))
                {
                    Response.Redirect("Login.aspx");
                }
                if (!IsPostBack)
                {
                    Panel1.Visible = false;

                    IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("hi-IN", true);
                    time = Convert.ToDateTime(DateTime.Now, theCultureInfo).ToString("h:mm tt");
                    date = DateTime.Now.ToString("dddd, dd MMM, yyyy");

                }
                Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                if ((HttpContext.Current.Request.UrlReferrer == null))
                {
                    Response.Redirect("Login.aspx");
                }

                SqlConnection connectionReport = new SqlConnection(ConfigurationManager.ConnectionStrings["FettanReportPortalConnection"].ToString());
                SqlCommand commandReport = new SqlCommand("sp_Portal_GetList", connectionReport);
                commandReport.CommandType = CommandType.StoredProcedure;
                commandReport.Parameters.AddWithValue("@ListType", 11);
                commandReport.Connection = connectionReport;
                try
                {
                    connectionReport.Open();
                    DropDownList1.DataSource = commandReport.ExecuteReader();
                    DropDownList1.DataTextField = "ImageType";
                    DropDownList1.DataValueField = "ImageCode";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Please Select ID Type", "0"));
                    // DropDownListSelectBranch.SelectedIndex = DropDownListSelectBranch.Items.IndexOf(DropDownListSelectBranch.Items.FindByText("--Please Select Branch--"));
                }

                catch (Exception ex)
                {
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Check your connection ');", true);
                    //Response.Redirect("Login.aspx");
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
               
                string connectionString = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                string insertStoredProcName = "sp_Portal_119_Customer_KYC_Get";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //SqlCommand cmd = new SqlCommand("sp_HelpDesk_Request", connectionHelpdesk);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        cmd.Parameters.AddWithValue("@SearchString", AMTN.Text);

                        conn.Open();
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {
                            GridView1.DataSource = sqlReader;
                            GridView1.DataBind();
                            Panel1.Visible = true;
                            GridView1.Visible = false;
                            submit.Visible = true;
                            verify.Visible = false;
                            Label2.Visible = false;
                            TypeOfID.Visible = true;
                            Button4.Visible = false;
                            for (int i = 0; i < GridView1.Rows.Count; i++)
                            {
                                CustomerID = GridView1.Rows[i].Cells[2].Text;
                                NBELevel = GridView1.Rows[i].Cells[3].Text;
                                StatusX = GridView1.Rows[i].Cells[4].Text;
                                MobileTel = GridView1.Rows[i].Cells[5].Text;
                                FirstName = GridView1.Rows[i].Cells[6].Text;
                                SecondName = GridView1.Rows[i].Cells[7].Text;
                                ThirdName = GridView1.Rows[i].Cells[8].Text;
                                Gender = GridView1.Rows[i].Cells[9].Text;
                                BirthDate = GridView1.Rows[i].Cells[10].Text;
                                Email = GridView1.Rows[i].Cells[11].Text;
                                Address1 = GridView1.Rows[i].Cells[12].Text;
                                Address2 = GridView1.Rows[i].Cells[13].Text;
                                Address3 = GridView1.Rows[i].Cells[14].Text;
                                City = GridView1.Rows[i].Cells[15].Text;
                                Country = GridView1.Rows[i].Cells[16].Text;
                                Residency = GridView1.Rows[i].Cells[17].Text;
                                Nationality = GridView1.Rows[i].Cells[18].Text;
                                Region = GridView1.Rows[i].Cells[19].Text;
                                Zone = GridView1.Rows[i].Cells[20].Text;
                                WoredaSubCity = GridView1.Rows[i].Cells[21].Text;

                                //Date = DateTime.ParseExact(BirthDate, "dd MMM yyyy", null);

                                //if (AllowPickup == "Y")
                                //{
                                //    releaseCash.Visible = true;
                                //}
                            }

                            //sqlReader.NextResult();


                            sqlReader.Close();
                        }


                        conn.Close();

                    }
                    try
                    {
                        Date = DateTime.Parse(BirthDate);

                        CBDate = Date.ToString("MMM dd, yyyy", null);
                    }
                    catch (Exception)
                    {

                    }
                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.Text=""+(ex);
                }
            }

            if (IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                string insertStoredProcName = "sp_Portal_119_Customer_KYC_Get";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        cmd.Parameters.AddWithValue("@SearchString", AMTN.Text);

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
                                    TextBox1.Text = "";

                                    Label1.Visible = false;
                                    TextBox1.Text = FirstName;
                                    TextBox2.Text = SecondName;
                                    if (ThirdName != "&nbsp;")
                                    {
                                        TextBox3.Text = ThirdName;
                                    }
                                    if (Gender == "M")
                                    {
                                        RadioButton1.Checked = true;
                                    }
                                    else if (Gender == "F")
                                    {
                                        RadioButton2.Checked = true;
                                    }
                                    if (BirthDate != "&nbsp;")
                                    {
                                        TextBox4.Text = CBDate;
                                    }
                                    if (Email != "&nbsp;")
                                    {
                                        TextBox5.Text = Email;
                                    }
                                    if (Address1 != "&nbsp;")
                                    {
                                        TextBox6.Text = Address1;
                                    }
                                    if (Address2 != "&nbsp;")
                                    {
                                        TextBox7.Text = Address2;
                                    }
                                    if (Address3 != "&nbsp;")
                                    {
                                        TextBox8.Text = Address3;
                                    }
                                    if (City != "&nbsp;")
                                    {
                                        TextBox9.Text = City;
                                    }
                                    if (Country != "&nbsp;")
                                    {
                                        TextBox10.Text = Country;
                                    }
                                    if (Residency != "&nbsp;")
                                    {
                                        TextBox11.Text = Residency;
                                    }
                                    if (Nationality != "&nbsp;")
                                    {
                                        TextBox12.Text = Nationality;
                                    }
                                    if (Region != "&nbsp;")
                                    {
                                        TextBox13.Text = Region;
                                    }
                                    if (Zone != "&nbsp;")
                                    {
                                        TextBox14.Text = Zone;
                                    }
                                    if (WoredaSubCity != "&nbsp;")
                                    {
                                        TextBox15.Text = WoredaSubCity;
                                    }
                                    ChangeToMobile.Enabled = true;
                                    TextBox1.Enabled = true;
                                    TextBox2.Enabled = true;
                                    TextBox3.Enabled = true;
                                    TextBox4.Enabled = true;
                                    TextBox5.Enabled = true;
                                    TextBox6.Enabled = true;
                                    TextBox7.Enabled = true;
                                    TextBox8.Enabled = true;
                                    TextBox9.Enabled = true;
                                    TextBox10.Enabled = true;
                                    TextBox11.Enabled = true;
                                    TextBox12.Enabled = true;
                                    TextBox13.Enabled = true;
                                    TextBox14.Enabled = true;
                                    TextBox15.Enabled = true;
                                    //TextBox16.Enabled = false;
                                    TextBox18.Enabled = true;
                                    TextBox19.Enabled = true;
                                    TextBox20.Enabled = true;
                                    TextBox21.Enabled = true;
                                    DropDownList1.Enabled = true;
                                    RadioButton1.Enabled = true;
                                    RadioButton2.Enabled = true;
                                    fuimage.Enabled = true;
                                    FileUpload2.Enabled = true;
                                    btnUpload.Enabled = true;
                                    Button5.Enabled = true;

                                }
                                else
                                {
                                    Label1.Visible = true;
                                    Label1.Text = columns;
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
                    Label1.Text="" + ex;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //size = Math.Round(((decimal)fuimage.PostedFile.ContentLength / (decimal)1024), 2);
                //    photo = new byte[fuimage.PostedFile.InputStream.Length];
                //    fuimage.PostedFile.InputStream.Read(photo, 0, photo.Length);
                //     size2 = Math.Round(((decimal)FileUpload2.PostedFile.ContentLength / (decimal)1024), 2);
                //    ID = new byte[FileUpload2.PostedFile.InputStream.Length];
                //FileUpload2.PostedFile.InputStream.Read(ID, 0, ID.Length);
                if (RadioButton1.Checked == true)
                {
                    gender = RadioButton1.Text;
                }
                else if (RadioButton2.Checked == true)
                {
                    gender = RadioButton2.Text;
                }
                if (DropDownList1.SelectedValue != "0")
                {
                    IDType = DropDownList1.SelectedValue;
                }


                string connectionString = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                string insertStoredProcName = "sp_Portal_119_Customer_KYC_Update";
                int returnCode2;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                        cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@SecondName", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@ThirdName", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@ChangeToMobile", ChangeToMobile.Text);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@BirthDate", TextBox4.Text);
                        cmd.Parameters.AddWithValue("@Email", TextBox5.Text);
                        cmd.Parameters.AddWithValue("@Address1", TextBox6.Text);
                        cmd.Parameters.AddWithValue("@Address2", TextBox7.Text);
                        cmd.Parameters.AddWithValue("@Address3", TextBox8.Text);
                        cmd.Parameters.AddWithValue("@City", TextBox9.Text);
                        cmd.Parameters.AddWithValue("@Country", TextBox10.Text);
                        cmd.Parameters.AddWithValue("@Residency", TextBox11.Text);
                        cmd.Parameters.AddWithValue("@Nationality", TextBox12.Text);
                        cmd.Parameters.AddWithValue("@Region", TextBox13.Text);
                        cmd.Parameters.AddWithValue("@Zone", TextBox14.Text);
                        cmd.Parameters.AddWithValue("@WoredaSubCity", TextBox15.Text);
                        cmd.Parameters.AddWithValue("@PhotoImage", SqlDbType.VarBinary).Value = photo;
                        cmd.Parameters.AddWithValue("@IDImage", SqlDbType.VarBinary).Value = ID;
                        cmd.Parameters.AddWithValue("@IDType", IDType);
                        cmd.Parameters.AddWithValue("@IDNumber", TextBox18.Text);
                        cmd.Parameters.AddWithValue("@Issuer", TextBox19.Text);
                        cmd.Parameters.AddWithValue("@IssueDate", TextBox20.Text);
                        cmd.Parameters.AddWithValue("@ExpirationDate", TextBox21.Text);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                returnCode2 = Convert.ToInt32(rd.GetValue(0));

                                if (returnCode2 == 1)
                                {
                                   if (size>500)
                                    {
                                        Label1.Visible = true;
                                        Label1.Text = "Photo size not exceed 500KB";
                                    }
                                   else if(size2> 500)
                                    {
                                        Label1.Visible = true;
                                        Label1.Text = "ID size not exceed 500KB.";
                                    }
                                   //else if (size==0)
                                   // {
                                   //     Label1.Visible = true;
                                   //     Label1.Text = returnMsg;
                                   // }
                                   // else if (size2 == 0)
                                   // {
                                   //     Label1.Visible = true;
                                   //     Label1.Text = returnMsg;
                                   // }
                                    else
                                    {
                                        returnMsg = Convert.ToString(rd.GetValue(1));
                                        PendingID = Convert.ToInt32(rd.GetValue(2));
                                        verify.Visible = true;
                                        submit.Visible = false;
                                        TypeOfID.Visible = true;
                                        Button4.Visible = false;
                                        Label1.Visible = false;
                                        ChangeToMobile.Enabled = false;
                                        TextBox1.Enabled = false;
                                        TextBox2.Enabled = false;
                                        TextBox3.Enabled = false;
                                        TextBox4.Enabled = false;
                                        TextBox5.Enabled = false;
                                        TextBox6.Enabled = false;
                                        TextBox7.Enabled = false;
                                        TextBox8.Enabled = false;
                                        TextBox9.Enabled = false;
                                        TextBox10.Enabled = false;
                                        TextBox11.Enabled = false;
                                        TextBox12.Enabled = false;
                                        TextBox13.Enabled = false;
                                        TextBox14.Enabled = false;
                                        TextBox15.Enabled = false;
                                        //TextBox16.Enabled = false;
                                        TextBox18.Enabled = false;
                                        TextBox19.Enabled = false;
                                        TextBox20.Enabled = false;
                                        TextBox21.Enabled = false;
                                        DropDownList1.Enabled = false;
                                        RadioButton1.Enabled = false;
                                        RadioButton2.Enabled = false;
                                        fuimage.Enabled = false;
                                        FileUpload2.Enabled = false;
                                        btnUpload.Enabled = false;
                                        Button5.Enabled = false;
                                    }
                                    
                                }
                                else
                                {
                                    returnMsg = Convert.ToString(rd.GetValue(1));
                                    Panel1.Visible = true;
                                    Label1.Visible = true;
                                    Label1.Text = returnMsg;
                                    TypeOfID.Visible = true;
                                    submit.Visible = true;
                                }
                            }
                        }



                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.Text=""+ex;
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
                string insertStoredProcName = "sp_Portal_119_Customer_KYC_Verify";
                string columns;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginID", LoginID);
                        cmd.Parameters.AddWithValue("@PendingID", PendingID);
                        cmd.Parameters.AddWithValue("@OTP", TextBox16.Text);
                        conn.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                returnCode = rdr.GetInt32(0);
                                columns = rdr.GetString(1);
                                Label1.Text = columns;
                                if (returnCode == 1)
                                {
                                    verify.Visible = false;
                                    submit.Visible = false;
                                    Label2.Visible = true;
                                    TypeOfID.Visible = true;
                                    Button4.Visible = true;
                                    Button1.Visible = false;
                                    Label1.Visible = false;
                                    Label2.Text = columns;
                                }
                                else
                                {
                                    Label2.Visible = false;
                                    Panel1.Visible = true;
                                    Label1.Visible = true;
                                    TypeOfID.Visible = true;
                                    verify.Visible = true;
                                    Label1.Text = columns;
                                }

                            }
                            rdr.Close();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.Text=""+(ex);
                }
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //var filePath = Server.MapPath("~/Photo/" + fuimage.FileName);

            ////var filePath=   Image1.ImageUrl = "~/Photo/" + Path.GetFileName(fuimage.FileName);
            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //}
            //System.IO.File.Delete(Request.PhysicalApplicationPath + "Photo/" + fuimage.FileName);
            string Photo = Server.MapPath("~/Photo/");

            //Check whether Directory (Folder) exists.
            if (Directory.Exists(Photo))
            {
                Directory.Delete(Photo, true);
            }
            else
            {

            }
            string ID = Server.MapPath("~/ID/");

            //Check whether Directory (Folder) exists.
            if (Directory.Exists(ID))
            {
                Directory.Delete(ID, true);
            }
            else
            {

            }
            Response.Redirect("CustomerLookup.aspx");
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            TypeOfID.Visible = true;
            verify.Visible = true;
            string connectionstring = ConfigurationManager.ConnectionStrings["RemittanceCashOutConnection"].ConnectionString;
            string updateOTP = "sp_Portal_119_Customer_KYC_Resend_OTP";
            string columns;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand(updateOTP, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", LoginID);
                    cmd.Parameters.AddWithValue("@CustomerPendingID", PendingID);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            returnCode = sdr.GetInt32(0);
                            columns = sdr.GetString(1);
                            if (returnCode == 1)
                            {
                                Label2.Visible = true;
                                Label2.Text = columns;
                                //ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('" + columns + " ');", true);
                            }
                        }
                    }
                    con.Close();
                }


            }
            catch(Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "" + ex;
            }
        }
        protected void Upload_Photo(object sender, EventArgs e)
        {
            if (fuimage.FileName!="")
            {
                string folderPath = Server.MapPath("~/Photo/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                fuimage.SaveAs(folderPath + Path.GetFileName(fuimage.FileName));
                Label3.Text = fuimage.FileName;
                //Display the Picture in Image control.
                Image1.ImageUrl = "~/Photo/" + Path.GetFileName(fuimage.FileName);
                size = Math.Round(((decimal)fuimage.PostedFile.ContentLength / (decimal)1024), 2);
                photo = new byte[fuimage.PostedFile.InputStream.Length];
                fuimage.PostedFile.InputStream.Read(photo, 0, photo.Length);
            }
            else
            {
               // Label3.Text = "";
            }
        }
        protected void Upload_ID(object sender, EventArgs e)
        {
            if (FileUpload2.FileName != "")
            {
                string folderPath2 = Server.MapPath("~/ID/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath2))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath2);
                }

                //Save the File to the Directory (Folder).
                FileUpload2.SaveAs(folderPath2 + Path.GetFileName(FileUpload2.FileName));
                Label5.Text = FileUpload2.FileName;
                //Display the Picture in Image control.
                Image2.ImageUrl = "~/ID/" + Path.GetFileName(FileUpload2.FileName);
                size2 = Math.Round(((decimal)FileUpload2.PostedFile.ContentLength / (decimal)1024), 2);
                ID = new byte[FileUpload2.PostedFile.InputStream.Length];
                FileUpload2.PostedFile.InputStream.Read(ID, 0, ID.Length);
            }
            else
            {
                //Label5.Text = "";
            }
        }

        protected void AMTN_TextChanged(object sender, EventArgs e)
        {
            NBELevel = "";
            StatusX = "";
            MobileTel = "";
            ChangeToMobile.Text ="";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox15.Text = "";
            TextBox16.Text = "";
            DropDownList1.SelectedIndex = 0;
            TextBox18.Text = "";
            TextBox19.Text = "";
            TextBox20.Text = "";
            TextBox21.Text = "";


        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalReportAvailable.aspx");
        }
    }
}
