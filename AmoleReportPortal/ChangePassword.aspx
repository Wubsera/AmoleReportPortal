<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AmoleReportPortal.ChangePassword" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Amole Portal</title>
    <link rel="icon" href="image/AmoleIcon.jpg" type="image/x-icon" />
        <link rel="stylesheet" type="text/css" href="Css/ChangePassword.css" />
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/jquery-ui.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="form">
        <form runat="server">
             <div class="table1" >
                <div class="left">
                    <img src="Images/AmoleLogo.jpg" />
                    <section>
                        <h1 style="margin-top:5px"><%=ReportHeading1 %></h1>
                        <h2 style="margin-top:-28px"><%=ReportHeading2 %></h2>
                        <h3 style="margin-top:-18px"><%=ReportHeading3 %></h3>
                    </section>
                </div>
                <div class="right">
                    <asp:Image ID="Image1" runat="server" style="margin-left:5px;margin-right:5px" />
                       <h1 style="text-align:right;font-size:15.5pt;font-weight:bold;"><%=FullName %></h1>
                    <section style="text-align:right;margin-top:-10px">                       
                         <span><a href="AboutUs.aspx" >About Us</a>
                        |
                         <a href="ProfileUpdate.aspx" >Profile</a>
                        |
                        <a href="ChangePassword.aspx">Change Password</a>
                        |
                    <a href="Login.aspx"">Logoff</a></span>
                         <h4 style="text-align:right;font-size:10pt;margin-top:4px;font-weight:bold"><%=LastLoggedIn %></h4>
                           </section>
                </div>
            </div>
            <div class="table2">
                <div class="left">
                    <span>Change Password</span>
                </div>
                <div class="right">
                    <span>
                    <a href="helpDesk.aspx" style="margin-right:5px">Technical Support Help Desk</a>
                    </span>
                </div>
            </div>
            <div class="goback">
                <section>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Go back to Available Reports </asp:LinkButton>
                </section>
            </div>
            <div class="menu">
                
                     <div >
                    <asp:Panel ID="Panel1" runat="server" style="width:450px">
                       <span style="margin-left:150px"><img src="image/CheckMark8.jpg" width="100" /></span> 
                        <h3 style="margin-left:75px;margin-top:-20px">Password Successfully Changed</h3>
                        <section style="margin-bottom: 10px;font-weight:bold">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </section>
                    </asp:Panel>
                    
                    <section style="color:red;font-weight:bold;margin-bottom:10px">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </section>
                    <section style="margin-bottom:5px" id="currPass" runat="server">
                        <span style="font-family:Calibri;font-size:13pt">Current Password:</span>
                        <span style="margin-left:3px">
                            <input id="Password4" runat="server" type="password" style="padding-top:3px;padding-bottom:3px;background-color:#FFFFE1;font-size:12pt" autocomplete="off" />
                        </span>
                    </section>
                    <section style="margin-bottom:5px" id="newPass" runat="server">
                        <span style="font-family:Calibri;font-size:13pt">New Password:</span>
                        <span style="margin-left:24px">
                            <input id="Password1" runat="server" type="password" style="padding-top:3px;padding-bottom:3px;background-color:#FFFFE1;font-size:12pt" autocomplete="off" />
                        </span>
                    </section>
                     <section style="margin-bottom:25px" id="confirmPass" runat="server">
                        <span style="font-family:Calibri;font-size:13pt">Confirm Password:</span>
                         <span>
                         <input id="Password2" runat="server" type="password" style="padding-top:3px;padding-bottom:3px;background-color:#FFFFE1;font-size:12pt" autocomplete="off" />
                         </span>
                    </section>
                    <section>
                    <asp:Button ID="Button1" runat="server" Text="Change Password" CssClass="button1" OnClick="Button1_Click" style="border-radius:4px;margin-left:180px" />
                    <asp:Button ID="Button2" runat="server" Text="Go back to Available Reports" CssClass="button1" OnClick="Button2_Click" Width="240" style="margin-left:80px;border-radius:4px;margin-top:10px"/>
                         </section>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                </div>
            </div>
        </form>
    </div>
    <div class="footer">
        <img alt="" src="Images/Amole.png" />
        <span>Powered by Amole
        </span>
    </div>
</body>
    <script>
    function idleLogout() {
        var t;
        window.onload = resetTimer;
        window.onmousemove = resetTimer;
        window.onmousedown = resetTimer; // catches touchscreen presses
        window.onclick = resetTimer;     // catches touchpad clicks
        window.onscroll = resetTimer;    // catches scrolling with arrow keys
        window.onkeypress = resetTimer;

        function logout() {
            window.location.href = 'Login.aspx';
        }

        function resetTimer() {
            clearTimeout(t);
            t = setTimeout(logout, 1200000);  // time is in milliseconds
        }
    }
    idleLogout();
</script>   
     <script>
        $(document).ready(function () {      // Wait for the HTML to finish loading.
            var resize = function () {
                var height = $(window).height();  // Get the height of the browser window area.
                var element = $("body");          // Find the element to resize.
                element.height(height);           // Set the element's height.
            }
            resize();
            $(window).bind("resize", resize);
        });
    </script>
    <script>
        setInterval(function () {
            var dt = new Date(), h = dt.getHours(), m = dt.getMinutes(), s = dt.getSeconds(),
            curTime = dt
            document.getElementById('time').innerHTML = curTime;
        }, 500);
    </script>
</html>
