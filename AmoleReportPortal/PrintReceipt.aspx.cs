using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class PrintReceipt : System.Web.UI.Page
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
            ReportHeading1 = PortalRemittanceCashOut.ReportHeading1;
            ReportHeading2 = PortalRemittanceCashOut.ReportHeading2;
            ReportHeading3 = PortalRemittanceCashOut.ReportHeading3;
            AMTN = PortalRemittanceCashOut.AMTN2;
            Status = PortalRemittanceCashOut.Status;
            ReceivedDate = PortalRemittanceCashOut.ReceivedDate;
            Processor = PortalRemittanceCashOut.MerchantName;
            SourceIdentifier = PortalRemittanceCashOut.SourceControlNumber;
            Amount = PortalRemittanceCashOut.AmountToCustomer;
            ExchangeRate = PortalRemittanceCashOut.ExchangeRate;
            RefNo = PortalRemittanceCashOut.RefNo;
            ConfNo = PortalRemittanceCashOut.ConfNo;
            SenderName = PortalRemittanceCashOut.SenderName;
            SenderCity = PortalRemittanceCashOut.SenderCity;
            SenderCountry = PortalRemittanceCashOut.SenderCountry;
            SenderNationality = PortalRemittanceCashOut.SenderNationality;
            SenderResidency = PortalRemittanceCashOut.SenderResidency;
            SBDate = PortalRemittanceCashOut.SBDate;
            SenderMobile = PortalRemittanceCashOut.SenderMobile;
            SenderEmail = PortalRemittanceCashOut.SenderEmail;
            RecipientName = PortalRemittanceCashOut.RecipientName;
            RecipientCity = PortalRemittanceCashOut.RecipientCity;
            RecipientCountry = PortalRemittanceCashOut.RecipientCountry;
            RecipientNationality = PortalRemittanceCashOut.RecipientNationality;
            RecipientResidency = PortalRemittanceCashOut.RecipientResidency;
            RBDate = PortalRemittanceCashOut.RBDate2;
            RecipientName = PortalRemittanceCashOut.RecipientMobile;
            RecipientEmail = PortalRemittanceCashOut.RecipientEmail;
            HowReceived = PortalRemittanceCashOut.HowReceived;
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