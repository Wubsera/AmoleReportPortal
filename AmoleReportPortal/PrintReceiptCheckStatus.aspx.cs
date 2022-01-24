using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class PrintReceiptCheckStatus : System.Web.UI.Page
    {
        public static string ReportHeading1;
        public static string ReportHeading2;
        public static string ReportHeading3;
        public static string AMTN;
        public static string Status;
        public static string ReceivedDate;
        public static string Processor;
        public static string SourceIdentifier;
        public static string Amount;
        public static string ExchangeRate;
        public static string RefNo;
        public static string ConfNo;
        public static string SenderName;
        public static string SenderCity;
        public static string SenderCountry;
        public static string SenderNationality;
        public static string SenderResidency;
        public static string SBDate;
        public static string SenderMobile;
        public static string SenderEmail;
        public static string RecipientName;
        public static string RecipientCity;
        public static string RecipientCountry;
        public static string RecipientNationality;
        public static string RecipientResidency;
        public static string RBDate;
        public static string RecipientMobile;
        public static string RecipientEmail;
        static string prevPage = String.Empty;
        public static string date;
        public static string HowReceived;


        protected void Page_Load(object sender, EventArgs e)
        {
            date = DateTime.Now.ToString("dd MMM yyyy - h:mm tt");
            ReportHeading1 = RemittanceCheckStatus.ReportHeading1;
            ReportHeading2 = RemittanceCheckStatus.ReportHeading2;
            ReportHeading3 = RemittanceCheckStatus.ReportHeading3;
            AMTN = RemittanceCheckStatus.AMTN2;
            Status = RemittanceCheckStatus.Status;
            ReceivedDate = RemittanceCheckStatus.ReceivedDate;
            Processor = RemittanceCheckStatus.MerchantName;
            SourceIdentifier = RemittanceCheckStatus.SourceControlNumber;
            Amount = RemittanceCheckStatus.AmountToCustomer;
            ExchangeRate = RemittanceCheckStatus.ExchangeRate;
            RefNo = RemittanceCheckStatus.RefNo;
            ConfNo = RemittanceCheckStatus.ConfNo;
            SenderName = RemittanceCheckStatus.SenderName;
            SenderCity = RemittanceCheckStatus.SenderCity;
            SenderCountry = RemittanceCheckStatus.SenderCountry;
            SenderNationality = RemittanceCheckStatus.SenderNationality;
            SenderResidency = RemittanceCheckStatus.SenderResidency;
            SBDate = RemittanceCheckStatus.SBDate;
            SenderMobile = RemittanceCheckStatus.SenderMobile;
            SenderEmail = RemittanceCheckStatus.SenderEmail;
            RecipientName = RemittanceCheckStatus.RecipientName;
            RecipientCity = RemittanceCheckStatus.RecipientCity;
            RecipientCountry = RemittanceCheckStatus.RecipientCountry;
            //RecipientNationality = 
            // RecipientResidency = 
            RBDate = RemittanceCheckStatus.RBDate2;
            RecipientMobile = RemittanceCheckStatus.RecipientMobile;
            RecipientEmail = RemittanceCheckStatus.RecipientEmail;
            HowReceived = RemittanceCheckStatus.RecievedAs;
            //if (!IsPostBack)
            //{
            //    prevPage = Request.UrlReferrer.ToString();
            //}
            //string from = Request.UrlReferrer.ToString();
            //string here = Request.Url.AbsoluteUri.ToString();

            //if (from != here)
            //    Session["page"] = Request.UrlReferrer.ToString();
            if (!Page.IsPostBack)
                ViewState["ReferringURL"] = Request.ServerVariables["HTTP_REFERER"];

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect(prevPage);
            //object refUrl = Session["page"];
            //if (refUrl != null)
            //    Response.Redirect((string)refUrl);
            if (ViewState["ReferringURL"] != null)
                Response.Redirect(ViewState["ReferringURL"].ToString());
        }
    }
}