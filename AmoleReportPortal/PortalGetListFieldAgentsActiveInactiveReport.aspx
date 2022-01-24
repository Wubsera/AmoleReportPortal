<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PortalGetListFieldAgentsActiveInactiveReport.aspx.cs" Inherits="AmoleReportPortal.PortalGetListFieldAgentsActiveInactiveReport" %>

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
    <link rel="icon" href="image/AmoleIcon.jpg" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="Css/PortalGetList.css" />
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
                    <asp:Image ID="Image1" runat="server" style="margin-left:5px;margin-right:5px"/>
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
                    <span><%=reportLink %></span>
                </div>
                <div class="right">
                    <span>
                    <a href="helpDesk.aspx" style="margin-right:5px">Technical Support Help Desk</a>
                    </span>
                </div>
            </div>
            <div class="goback">
                 <section>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Go back to Available Reports </asp:LinkButton>
                </section>
            </div>
            <div class="menu">
                <section>
                    <asp:Label ID="Label1" runat="server" CssClass="merchant" Text="Merchant:"></asp:Label>
                    <asp:DropDownList ID="DropDownListSelectBranch" CssClass="ddselctbranch"
                        runat="server" AutoPostBack="true" OnDataBound="DropDownListSelectBranch_DataBound"
                        OnSelectedIndexChanged="DropDownListSelectBranch_SelectedIndexChanged">
                    </asp:DropDownList>
                </section>
                <section>
                    <asp:Label ID="Label6" runat="server" CssClass="fromdate" Text="From Business Day:"></asp:Label>
                    <asp:Label ID="Label7" runat="server" CssClass="todate" Text="To Business Day:"></asp:Label>
                </section>
                <section>
                    <asp:TextBox ID="txtFrom" CssClass="txtFrom" AutoCompleteType="Disabled" runat="server"
                        onblur="this.placeholder = 'Start Date'" onfocus="this.placeholder = 'Start Date'"
                        OnTextChanged="txtFrom_TextChanged"></asp:TextBox>
                    <asp:TextBox ID="txtTo" CssClass="txtTo" AutoCompleteType="Disabled" runat="server"
                        onfocus="this.placeholder = 'End Date'" onblur="this.placeholder = 'End Date'"
                        OnTextChanged="txtTo_TextChanged"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" CssClass="image" src="Images/run.png" runat="server"
                        ToolTip="GENERATE REPORT" OnClick="Generate_Click" />
                </section>
                <div class="calendar">
                    <section>
                        <asp:Calendar ID="Calendar1" runat="server"
                            Font-Underline="False" BackColor="white" BorderColor="Gray"
                            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri"
                            Font-Size="10pt" ForeColor="Black" ShowGridLines="True"
                            Height="188px" Width="210px" EnableTheming="True"
                            OnSelectionChanged="Calendar1_SelectionChanged">
                            <SelectedDayStyle Font-Bold="True" BorderColor="Gray" />
                            <SelectorStyle BorderColor="Gray" />
                            <TodayDayStyle BackColor="WhiteSmoke" ForeColor="Black"
                                BorderColor="Gray" BorderStyle="Double" />
                            <OtherMonthDayStyle ForeColor="Gray" />
                            <NextPrevStyle Font-Size="10pt" ForeColor="Green" Font-Bold="true" />
                            <DayHeaderStyle BackColor="White" Font-Bold="True" Height="1px" />
                            <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt"
                                Font-Names="Calibri" ForeColor="#990000" />
                        </asp:Calendar>
                    </section>
                    <section>
                        <asp:Calendar ID="Calendar2" runat="server" Font-Underline="False"
                            BackColor="white" BorderColor="Gray" BorderWidth="1px" DayNameFormat="Shortest"
                            Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" ShowGridLines="True"
                            Height="188px" Width="210px" EnableTheming="True" OnSelectionChanged="Calendar2_SelectionChanged">
                            <SelectedDayStyle Font-Bold="True" BorderColor="Gray" />
                            <SelectorStyle BorderColor="Gray" />
                            <TodayDayStyle BackColor="WhiteSmoke" ForeColor="Black"
                                BorderColor="Gray" BorderStyle="Double" />
                            <OtherMonthDayStyle ForeColor="Gray" />
                            <NextPrevStyle Font-Size="10pt" ForeColor="Green" Font-Bold="true" />
                            <DayHeaderStyle BackColor="White" Font-Bold="True" Height="1px" />
                            <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt"
                                Font-Names="Calibri" ForeColor="#990000" />
                        </asp:Calendar>
                    </section>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
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
            t = setTimeout(logout, 1200000);  // time is in milliseconds
        }
    }
    idleLogout();
</script>

</html>
