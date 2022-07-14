<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemittanceCheckStatus.aspx.cs" Inherits="AmoleReportPortal.RemittanceCheckStatus" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

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
    <link rel="stylesheet" type="text/css" href="Css/RemittanceCheckStatus.css" />
</head>
<script type="text/javascript">
      <%--  function PrintReceipt1() {
            window.open("Print.html?<%=ReportHeading1%>&&<%=ReportHeading2%>&&<%=ReportHeading3%>", "_blank", "top=70,left=200,width=600,height=670");
        };--%>
    function PrintPanel() {
        var panel = document.getElementById("<%=Panel3.ClientID %>");
                var printWindow = window.open('', '', 'width=100%');
                printWindow.document.write('<html><head><title></title>');
                printWindow.document.write('</head><body >');
                printWindow.document.write(panel.innerHTML);
                printWindow.document.write('</body></html>');
                printWindow.document.close();
                setTimeout(function () {
                    printWindow.print();
                }, 500);
                return false;
            }
</script>

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
            <div class ="main-menu">
            <div class="menu">
                <span class="AMTN">AMTN:</span>
                <asp:TextBox ID="AMTN" runat="server" CssClass="search">

                </asp:TextBox><asp:Button ID="Button1" runat="server" Text="Search" CssClass="search-button" OnClick="Button1_Click" />
                <asp:Label ID="Label7" runat="server" Text=""><span style="font-weight:bold"></span></asp:Label>
            </div>
            
              <asp:Label ID="Label2" CssClass="label2" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            <asp:Panel ID="Panel2" runat="server">
                <asp:Panel ID="Panel3" runat="server">
                    <div class="Receipt">
                        <h3 style="margin-left: 10%;"><u><b>International Money Transfer Check Status</b></u></h3>
                        <div class="left-receipt">
                            <section>
                                AMTN: <span style="font-weight: bold"><%=AMTN2 %> </span>
                            </section>
                            <section>
                                Status: <span style="font-weight: bold"><%=Status%></span>
                            </section>
                            <section>
                                Received: <span style="font-weight: bold"><%=ReceivedDate %></span>
                            </section>
                            <section>
                                Processor: <span style="font-weight: bold"><%=MerchantName %></span>
                            </section>
                            <section>
                                Source Identifier: <span style="font-weight: bold"><%=SourceControlNumber %></span>
                            </section>
                        </div>
                        <div class="right-receipt">
                            <section>
                                Amount: <span style="font-weight: bold"><%=AmountToCustomer %></span>
                            </section>
                            <section>
                                Ex.Rate: <span style="font-weight: bold"><%=ExchangeRate %></span>
                            </section>
                            <section>
                                RefNo: <span style="font-weight: bold"><%=RefNo %></span>
                            </section>
                            <section>
                                ConfNo: <span style="font-weight: bold"><%=ConfNo %></span>
                            </section>

                        </div>
                    </div>
                    <div class="sender-info">
                        <section >
                            How to Receive: <span style="font-weight:bold"><%=RecievedAs %></span> 
                        </section>
                        <div class="sender">
                            <h4><b><u>Sender Information</u></b></h4>
                            <section>
                                Sender Name: <span style="font-weight: bold"><%=SenderName %> </span>
                            </section>
                            <section>
                                City: <span style="font-weight: bold"><%=SenderCity%></span>
                            </section>
                            <section>
                                Country: <span style="font-weight: bold"><%=SenderCountry%></span>
                            </section>
                            <section>
                                Nationality: <span style="font-weight: bold"><%=SenderNationality %></span>
                            </section>
                            <section>
                                Residency: <span style="font-weight: bold"><%=SenderResidency %></span>
                            </section>
                            <section>
                                Birth Date: <span style="font-weight: bold"><%=SBDate %></span>
                            </section>
                            <section>
                                Mobile Number: <span style="font-weight: bold"><%=SenderMobile %></span>
                            </section>
                            <section>
                                Email Address: <span style="font-weight: bold"><%=SenderEmail %></span>
                            </section>
                        </div>
                        <div class="beneficiary">
                            <h4><b><u>Beneficiary information</u></b></h4>
                            <section>
                                Beneficiary Name: <span style="font-weight: bold"><%=RecipientName %></span>
                            </section>
                            <section>
                                City: <span style="font-weight: bold"><%=RecipientCity%></span>
                            </section>
                            <section>
                                Country: <span style="font-weight: bold"><%=RecipientCountry%></span>
                            </section>
                            <section>
                                Nationality: <span style="font-weight: bold"><%=RecipientNationality%></span>
                            </section>
                            <section>
                                Residency: <span style="font-weight: bold"><%=RecipientResidency%></span>
                            </section>
                            <section>
                                Birth Date: <span style="font-weight: bold"><%=RBDate2 %></span>
                            </section>
                            <section>
                                Mobile Number: <span style="font-weight: bold"><%=RecipientMobile %></span>
                            </section>
                            <section>
                                Email Address: <span style="font-weight: bold"><%=RecipientEmail %></span>
                            </section>

                        </div>
                    </div>
                </asp:Panel>
                <div class="print">
                    <asp:Button ID="Button2"  runat="server" OnClick="Button2_Click1"  CssClass="print-button" Text="Reprint Receipt" />
                    <asp:Button ID="Button3"  runat="server" OnClick="Button3_Click"  CssClass="print-button" Text="Done" />
                    <asp:Button ID="Button4"  runat="server" OnClick ="Button4_Click" CssClass="print-button" Text="Cancel Transfer" />
                </div>
            </asp:Panel>
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
            t = setTimeout(logout, 1200000);  // time is in milliseconds //20 minutes
        }
    }
    idleLogout();
</script>

</html>
