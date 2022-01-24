using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{

    public partial class helpDeskc : System.Web.UI.Page
    {
        public static string ReportHeading1;
        public static string ReportHeading2;
        public static string ReportHeading3;
        public static string FullName;
        public static string LastLoggedIn;
        static string prevPage = String.Empty;
        SqlConnection connectionHelpdesk;
        public static string LoginID;
        public static int insertedId;
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
            //ReportHeading1 = PortalReportAvailable.ReportHeading1;
            //ReportHeading2 = PortalReportAvailable.ReportHeading2;
            //ReportHeading3 = PortalReportAvailable.ReportHeading3;
            //FullName = PortalReportAvailable.FullName;
            //LastLoggedIn = PortalReportAvailable.LastLoggedIn;
            if ((HttpContext.Current.Request.UrlReferrer == null))
            {
                Response.Redirect("Login.aspx");
            }
            Panel2.Visible = false;
            if (!IsPostBack)
            {
                connectionHelpdesk = new SqlConnection(ConfigurationManager.ConnectionStrings["helpdeskConnection"].ToString());
                SqlCommand commandReport = new SqlCommand("sp_HelpDesk_API_Merchants", connectionHelpdesk);
                commandReport.CommandType = CommandType.StoredProcedure;
                commandReport.Connection = connectionHelpdesk;
                try
                {
                    connectionHelpdesk.Open();
                    MerchantID.DataSource = commandReport.ExecuteReader();
                    MerchantID.DataValueField = "APIMerchantID";
                    MerchantID.DataTextField = "Merchant";
                    MerchantID.DataBind();
                    MerchantID.Items.Insert(0, new ListItem("--- Please select your merchant ---", "0"));
                }

                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Check your connection ');", true);
                    Response.Redirect("Login.aspx");
                }
                finally
                {
                    connectionHelpdesk.Close();
                    connectionHelpdesk.Dispose();
                }
                connectionHelpdesk = new SqlConnection(ConfigurationManager.ConnectionStrings["helpdeskConnection"].ToString());
                SqlCommand commandReport2 = new SqlCommand("sp_HelpDesk_API_Services", connectionHelpdesk);
                commandReport2.CommandType = CommandType.StoredProcedure;
                commandReport2.Connection = connectionHelpdesk;
                try
                {
                    connectionHelpdesk.Open();
                    API.DataSource = commandReport2.ExecuteReader();
                    API.DataValueField = "APIServiceID";
                    API.DataTextField = "APIService";
                    API.DataBind();
                    API.Items.Insert(0, new ListItem("--- Please Select API Service ---", "0"));
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "s", "window.alert('Check your connection ');", true);
                    Response.Redirect("Login.aspx");
                }
                finally
                {
                    connectionHelpdesk.Close();
                    connectionHelpdesk.Dispose();
                }
            }
            API.Visible = false;
            SourceTransID.Visible = false;

            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
            }

            // Code that runs on application startup
 
            if (IssueType.SelectedIndex == 2)
            {
                API.Visible = true;
                SourceTransID.Visible = true;
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (IssueType.SelectedIndex == 2)
                {
                    API.Visible = true;
                    SourceTransID.Visible = true;
                }
                else
                {
                    API.Visible = false;
                    SourceTransID.Visible = false;
                }

                string priorityID = PriorityID.Text;
                string environment = RadioButtonList1.Text;
                string name = Name.Value;
                string company = Company.Value;
                string mobileTel = MobileTel.Value;
                string email = Email.Value;
                string overview = Overview.Value;
                string problem = Problem.Value;
                string APIMerchantID = MerchantID.Text;
                string APIServiceID = API.Text;
                string issueType=IssueType.Text;
                //int source = int.Parse(SourceTransID.Value);
                //int source;
                //if (SourceTransID.Value != "")
                //{
                //    source = int.Parse(SourceTransID.Value);
                //}

                if (IsPostBack)
                {
                    //connectionHelpdesk = new SqlConnection(ConfigurationManager.ConnectionStrings["helpdeskConnection"].ToString());
                    //connectionHelpdesk.Open();
                    string connectionString = ConfigurationManager.ConnectionStrings["helpdeskConnection"].ConnectionString;
                    string insertStoredProcName = "sp_HelpDesk_Request";
                    string columns;
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            //SqlCommand cmd = new SqlCommand("sp_HelpDesk_Request", connectionHelpdesk);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Company", company);
                            cmd.Parameters.AddWithValue("@MobileTel", mobileTel);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@APIMerchantID", APIMerchantID);
                            cmd.Parameters.AddWithValue("@EnvironmentInd", environment);
                            cmd.Parameters.AddWithValue("@IssueType", issueType);
                            cmd.Parameters.AddWithValue("@APIServiceID", APIServiceID);
                            cmd.Parameters.AddWithValue("@SourceTransID", SourceTransID.Value);
                            cmd.Parameters.AddWithValue("@PriorityInd", priorityID);
                            cmd.Parameters.AddWithValue("@Overview", overview);
                            cmd.Parameters.AddWithValue("@Problem", problem);
                            conn.Open();
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    // read all returned values - if you only ever insert
                                    // one row at a time, there will only be one value to read
                                    insertedId = rdr.GetInt32(0);
                                    columns = rdr.GetString(1);
                                    Label1.Text = columns;
                                    if (columns == "Successful.")
                                    {
                                        Label1.Text = "";
                                        Panel1.Visible = false;
                                        Panel2.Visible = true;
                                        ticketID.Text = insertedId.ToString();
                                    }
                                }
                                rdr.Close();
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
        }
        protected void IssueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IssueType.SelectedIndex != 2)
            {
                API.Visible = false;
                SourceTransID.Visible = false;
            }
            else
            {
                API.Visible = true;
                SourceTransID.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}

// int priority = PriorityID.Items.IndexOf(PriorityID.Items.FindByText(priorityID));
//string uat = "U";
//string prod = "P";
//string environment;
//if (PRO.Checked)
//{
//    environment = prod.ToString();
//}
//else
//{
//    environment = uat.ToString();
//}
//void Application_Start(object sender, EventArgs e)
//{
//    // Code that runs on application startup
//    ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
//    new ScriptResourceDefinition
//    {
//        Path = "~/scripts/jquery-1.7.2.min.js",
//        DebugPath = "~/scripts/jquery-1.7.2.min.js",
//        CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
//        CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
//    });
//}

//Label1.Text = (string)cmd.Parameters[returnParameter].Value;
//SqlParameter retval = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
//retval.Direction = System.Data.ParameterDirection.ReturnValue;
//cmd.Parameters.Add(retval);
//cmd.Parameters["@return_value"].Direction = ParameterDirection.Output;
//cmd.ExecuteNonQuery();
// var result = (int)cmd.Parameters["@ReturnValue"].Value;
//object o = cmd.Parameters["@ReturnValue"].Value;
//Label1.Text = Convert.ToInt32(o).ToString();
//Label1.Text = (string)cmd.Parameters["ReturnCode"].Value;
//}

//if (Name.Value.Trim().Length == 0)
//{
//    Label1.Text = "Name is required!";
//    Label1.Style.Add("color", "red");
//    Name.Focus();
//    return;
//}
//if (Company.Value.Trim().Length == 0)
//{
//    Label1.Text = "Company is required!";
//    Label1.Style.Add("color", "red");
//    Company.Focus();
//    return;
//}
//if (MobileTel.Value.Trim().Length == 0)
//{
//    Label1.Text = "Mobile Tel is required!";
//    Label1.Style.Add("color", "red");
//    MobileTel.Focus();
//    return;
//}
//if (Email.Value.Trim().Length == 0)
//{
//    Label1.Text = "Email is required!";
//    Label1.Style.Add("color", "red");
//    Email.Focus();

//    return;
//}

//if (MerchantID.SelectedIndex == 0)
//{
//    //MerchantID.BorderColor = System.Drawing.Color.Red;
//    Label1.Text = "Please Select your merchant!";
//    Label1.Style.Add("color", "red");
//    MerchantID.Focus();


//    return;

//}

//if (IssueType.SelectedIndex == 0)
//{
//    Label1.Text = "Please Select issue type!";
//    Label1.Style.Add("color", "red");
//    IssueType.Focus();
//    // IssueType.BorderColor = System.Drawing.Color.Red;
//    return;
//}
//if (IssueType.SelectedIndex == 2 && API.SelectedIndex == 0)
//{
//    API.Visible = true;
//    SourceTransID.Visible = true;
//    Label1.Text = "Please Select API service!";
//    Label1.Style.Add("color", "red");
//    //IssueType.BorderColor = System.Drawing.Color.Black;
//    API.Focus();
//    //API.BorderColor = System.Drawing.Color.Red;
//    return;
//}
//if (Overview.Value.Trim().Length == 0)
//{
//    Label1.Text = "Overview or summary is required!";
//    Label1.Style.Add("color", "red");
//    Overview.Focus();
//    return;
//}
//if (Problem.Value.Trim().Length == 0)

//{
//    Label1.Text = "Detail problem information is required!";
//    Label1.Style.Add("color", "red");
//    Problem.Focus();
//    return;
//}
//}
//ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Request is submitted successfully!')", true);                    
// Response.Redirect("helpDesk.aspx");
//string message = "Your request have been submitted successfully.";
//string script = "window.onload = function(){ alert('";
//script += message;
//script += "');";
//script += "window.location = '";
//script += Request.Url.AbsoluteUri;
//script += "'; }";
//ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);