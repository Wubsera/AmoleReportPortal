<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AmoleReportPortal.WebForm1" %>

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
    <title>Portal Report</title>
    <link rel="stylesheet" type="text/css" href="Css/WebForm1.css" />
</head>
<body>
    <div class="form">
        <form runat="server">
            <div class="table1">
                <div class="left">
                    <img src="Images/AmoleLogo.jpg" />
                    <section>
                        <h1><%=ReportHeading1 %></h1>
                        <h2><%=ReportHeading2 %></h2>
                        <h3><%=ReportHeading3 %></h3>
                    </section>
                </div>
                <div class="right">
                    <img src="Images/AmoleLogo.jpg" />
                    <h1><%=FullName %></h1>
                    <span><a href="AboutUs.aspx">About Us</a>
                        |
                    <a href="Login.aspx">Logoff</a></span>
                    <h2><%=LastLoggedIn %></h2>
                </div>
            </div>
            <div class="table2">
                <div class="left">
                    <span>About Us</span>
                </div>
                <div class="right">
                    <a href="helpDesk.aspx">Technical Support Help Desk</a>
                </div>
            </div>
            <div class="goback">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Go back to the previous page </asp:LinkButton>
            </div>
            <div class="menu">
                <div class="box1">
                    <section>
                        <img src="image/AmoleImage3.png" />
                    </section>
                    <section>
                        <h1>Amole Reporting Portal</h1>
                    </section>
                    <section>
                        <h2>Version: 1.0.0.1</h2>
                    </section>
                    <section>
                        <h3>Released: 28 Nov, 2019</h3>
                    </section>

                </div>
                <div class="box2">
                    <section>
                        <h1>Moneta Technologies S.C.</h1>
                    </section>
                    <section>
                        <h2>A World of Convenience</h2>
                    </section>
                    <section>
                        <h3>Bloom Tech Tower</h3>
                    </section>
                    <section>
                        <h3>10th floor</h3>
                    </section>
                    <section>
                        <h3>Tel: +251 (11) 558 9851</h3>
                    </section>
                    <section>
                        <h3>Kazanchis</h3>
                    </section>
                    <section>
                        <h3>Addis Ababa, Ethiopia</h3>
                    </section>
                    <section>
                        <h4><a href="https://www.myamole.com">myamole.com</a></h4>
                    </section>
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
