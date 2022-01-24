using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class ReprintReceipt : System.Web.UI.Page
    {
        public static string ReportHeading1;
        public static string ReportHeading2;
        public static string ReportHeading3;
        public static string AMTN;
        public static string Status;
        public static string ReceivedDate;
        public static string MerchantName;
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
        public static string HoToReceive;


        protected void Page_Load(object sender, EventArgs e)
        {
            date = DateTime.Now.ToString("dd MMM yyyy - h:mm tt");
            ReportHeading1 = RemittanceReprintReceipt.ReportHeading1;
            ReportHeading2 = RemittanceReprintReceipt.ReportHeading2;
            ReportHeading3 = RemittanceReprintReceipt.ReportHeading3;
            AMTN = RemittanceReprintReceipt.AMTN2;
            Status = RemittanceReprintReceipt.Status;
            ReceivedDate = RemittanceReprintReceipt.ReceivedDate;
            MerchantName = RemittanceReprintReceipt.MerchantName;
            SourceIdentifier = RemittanceReprintReceipt.SourceControlNumber;
            Amount = RemittanceReprintReceipt.AmountToCustomer;
            ExchangeRate = RemittanceReprintReceipt.ExchangeRate;
            RefNo = RemittanceReprintReceipt.RefNo;
            ConfNo = RemittanceReprintReceipt.ConfNo;
            SenderName = RemittanceReprintReceipt.SenderName;
            SenderCity = RemittanceReprintReceipt.SenderCity;
            SenderCountry = RemittanceReprintReceipt.SenderCountry;
            SenderNationality = RemittanceReprintReceipt.SenderNationality;
            SenderResidency = RemittanceReprintReceipt.SenderResidency;
            SBDate = RemittanceReprintReceipt.SBDate;
            SenderMobile = RemittanceReprintReceipt.SenderMobile;
            SenderEmail = RemittanceReprintReceipt.SenderEmail;
            RecipientName = RemittanceReprintReceipt.RecipientName;
            RecipientCity = RemittanceReprintReceipt.RecipientCity;
            RecipientCountry = RemittanceReprintReceipt.RecipientCountry;
            RecipientNationality =  RemittanceReprintReceipt.RecipientNationality;
            RecipientResidency =  RemittanceReprintReceipt.RecipientResidency;
            RBDate = RemittanceReprintReceipt.RBDate2;
            RecipientMobile = RemittanceReprintReceipt.RecipientMobile;
            RecipientEmail = RemittanceReprintReceipt.RecipientEmail;
            HoToReceive = RemittanceReprintReceipt.HowToRecieve;
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