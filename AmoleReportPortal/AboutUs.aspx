<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="AmoleReportPortal.AboutUs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/jquery-ui.min.js" type="text/javascript"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Amole Portal</title>
    <link rel="stylesheet" type="text/css" href="Css/AboutUs.css" />
    <link rel="icon" href="image/AmoleIcon.jpg" type="image/x-icon" />
</head>
<body>
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
                    <span>About Us</span>
                </div>
                <div class="right">
                    <span>
                    <a href="helpDesk.aspx"  style="margin-right:5px" >Technical Support Help Desk</a>
                    </span>
                </div>
            </div>
            <div class="goback">
                <section>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Go back to Available Reports </asp:LinkButton>
                </section>
            </div>
            <div class="menu">
                <div class="box1">
                        <img src="image/AmoleImage3.png" />
                    <section style="font-size:13pt;margin-top:-15px;margin-left:60px">
                        <p style="margin-bottom:-15px">Amole Portal</p>
                        <p style="margin-bottom:-15px">Version: 2.0</p>
                        <p>Released: 06 Jun, 2021</p>
                        </section>

                </div>
                <div class="box2">
                        <h1 style="color:black;font-size:20pt;">A world of convenience… </h1>
                        <h3 style="color:darkblue;font-size:16pt;margin-bottom:-25px">Moneta Technologies S.C.</h3>
                        <h5 style="font-family:Calibri;font-size:13pt;margin-bottom:-28px">Bloom Tech Tower, 10th floor</h5>
                        <h5 style="font-family:Calibri;font-size:13pt;margin-bottom:-28px">Joseph Tito Ave</h5>
                        <h5 style="font-family:Calibri;font-size:13pt;margin-bottom:-28px">Kirkos Sub City, Woreda 08</h5>
                        <h5 style="font-family:Calibri;font-size:13pt;margin-bottom:-28px">Tel: +251 (11) 558 9851</h5>
                        <h5 style="font-family:Calibri;font-size:13pt;">Email:  <a href="mailto:info@MyAmole.com">info@MyAmole.com</a></h5>
                    <div class="join_us">
                        <h4 style="font-size:22pt;margin-top:-10px;margin-left:50px">Join Us</h4>
                        <span>
                            <section>
                                <a href="https://www.facebook.com/MyAmoleOfficial/">
                                    <img src="image/facebook.png" title="Facebook"></a>&nbsp;
                        <a href="https://twitter.com/myamole">
                            <img src="image/Twitter.png" title="Twitter"></a>
                                <a href="https://www.instagram.com/myamole/">
                                    <img src="image/Instagram.png" title="Instagram"></a>&nbsp;
                        <a href="https://t.me/myamole">

                            <img src="image/telegram2.png" title="Telegram">
                        </a>
                            </section>
                        </span>

                    </div>
                        <%--<h4><a href="https://www.myamole.com">myamole.com</a></h4>--%>
            </div>
    </div>
    <div class="footer">
        <img alt="" src="Images/Amole.png"/>
        <span>Powered by Amole
        </span>
        </div>
        </form>

</body>

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
            t = setTimeout(logout, 1800000);  // time is in milliseconds
        }
    }
    idleLogout();
</script>

</html>