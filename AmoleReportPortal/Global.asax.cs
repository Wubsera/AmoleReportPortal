using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Management;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
namespace AmoleReportPortal
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["UsersOnline"] = 0;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["UsersOnline"] = (int)Application["UsersOnline"] + 1;
            Application.UnLock();
            if (Session["LoginID"] == null)
            {
                Response.Redirect("Login.aspx");
                //Response.Write("<script language='javascript'>window.alert('Session Timeout');window.location='Login.aspx';</script>");
            }
        }
        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["UsersOnline"] = (int)Application["UsersOnline"] - 1;
            Application.UnLock();
            Response.Redirect("Login.aspx");
        }
        protected void Application_AuthorizeRequest(object sender,
                                              EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                WindowsIdentity identity =
                HttpContext.Current.User.Identity as WindowsIdentity;
                Debug.Assert(identity != null);
                WindowsPrincipal principal;
                principal = new WindowsPrincipal(identity);
                Thread.CurrentPrincipal = principal;
            }
        }
        private void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            var httpException = ex as HttpException ?? ex.InnerException as HttpException;
            if (httpException == null) return;

            if (httpException.WebEventCode == WebEventCodes.RuntimeErrorPostTooLarge)
            {
                //handle the error
                Response.Write("Too big a file, can't upload"); //error
            }
        }

    }
}