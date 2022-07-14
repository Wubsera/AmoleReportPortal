<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="BulkPaymentsBatchFileCheckStatus.aspx.cs" Inherits="AmoleReportPortal.BulkPaymentsBatchFileCheckStatus" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Amole Portal</title>
    <link rel="stylesheet" type="text/css" href="Css/UploadBulkPaymentFile.css" />
    <link rel="icon" href="image/AmoleIcon.jpg" type="image/x-icon" />

    <link rel="stylesheet" type="text/css" href="Css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="Css/bootstrap-datepicker.css" />

      <script src="Css/jquery-1.8.3.min.js"></script>
    <script src="Css/bootstrap.min.js"></script>
    <script src="Css/bootstrap-datepicker.js"></script>
    </head>
    <body>
        <form runat="server">
                       <div class="table1" >
                <div class="left">
                    <img src="Images/AmoleLogo.jpg" />
                    <section>
                        <h1 style="margin-top:5px"><%=ReportHeading1 %></h1>
                        <h2 style="margin-top:-28px;font-size:14pt;"><%=ReportHeading2 %></h2>
                        <h3 style="margin-top:-18px;font-size:14pt;"><%=ReportHeading3 %></h3>
                    </section>
                </div>
                <div class="right">
                    <asp:Image ID="Image1" runat="server" style="margin-left:5px;margin-right:5px" />
                       <h1 style="text-align:right;font-size:15.5pt;font-weight:bold;"><%=FullName %></h1>
                    <section style="text-align:right;margin-top:-10px">                       
                         <span><a href="AboutUs.aspx" style="color:blue">About Us</a>
                        |
                         <a href="ProfileUpdate.aspx" style="color:blue">Profile</a>
                        |
                        <a href="ChangePassword.aspx" style="color:blue">Change Password</a>
                        |
                    <a href="Login.aspx"" style="color:blue">Logoff</a></span>
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
                    <a href="helpDesk.aspx" style="margin-right:5px;text-decoration:underline">Technical Support Help Desk</a>
                    </span>
                </div>
            </div>
            <div class="goback">
                <section>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click" style="text-decoration:underline">Go back to Available Reports </asp:LinkButton>
                </section>
            </div>


            <div class="menu">
                <div class="box1" id="box1" runat="server">
                    <section>
                        <asp:Label ID="Label1" runat="server" Text="">Enter Bulk Payments/Disbursements Batch ID: </asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Style="font-weight: bold; background-color: #FFFFE1; padding: 2px 2px 2px 2px"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Style="color: white; background-color: #005CB7; font-weight: bold; font-size: 13pt; margin-left: 5px; padding: 1px 3px 1px 3px" Text="Search" OnClick="Button1_Click" />
                    </section>
                    <section>
                            <asp:Label ID="error" runat="server" Text="" Style="font-weight: bold; font-size: 13pt; color: red"></asp:Label>
                        </section>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    <div id="box2" runat="server">
                        
                        <section>
                            <asp:Label ID="Label2" runat="server" Text="" Width="500" Style="font-weight: bold; font-size: 14pt; color: blue"><%=MerchantName %></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label3" runat="server" Text="" Width="500">Merchant Account Balance: <span style="font-weight:bold"><%=AvailableBalance %> ETB</span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label4" runat="server" Text="" Width="120">Batch ID: <span style="font-weight:bold;margin-right:5px;"><%=BulkPayID %></span></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text="" Width="140">Status: <span style="font-weight:bold;margin-right:5px"><%=Status %></span></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text="" Width="200">As of: <span style="font-weight:bold;margin-right:5px"><%=StatusDate %></span></asp:Label>
<%--                            <asp:Button ID="Button2" runat="server" Text="Reviewed" OnClick="Button2_Click1" style="background-color:green;color:white;font-size:14pt;font-weight:bold;"/>--%>
                            <asp:ImageButton ID="ImageButton3" ImageUrl="~/image/Reviewed.jpg" Width="120" runat="server" OnClick="Button2_Click1" />
                            <asp:ImageButton ID="ImageButton1" ImageUrl="~/image/Approved.jpg" Width="120" runat="server" OnClick="Button2_Click" />
                        </section>
                        <section>
                            <asp:Label ID="Label7" runat="server" Text="" Width="180">Funding RefNo: <span style="font-weight:bold;margin-right:5px"><%=RefNo %></span></asp:Label>
                            <asp:Label ID="Label8" runat="server" Text="" Width="200">Service Fee RefNo: <span style="font-weight:bold;"><%=FeeRefNo %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label9" runat="server" Text="" Width="468">Description: <span style="font-weight:bold; margin-right:5px"><%=Description %></span></asp:Label>
                             <asp:ImageButton ID="ImageButton2" ImageUrl="~/image/Reject.jpg" Width="120" runat="server" OnClick="Button3_Click" style="margin-top:-30px" />
<%--                            <asp:Button ID="Button3" runat="server" Text="Cancel" OnClick="Button3_Click" style="background-color:red;color:white;font-size:14pt;font-weight:bold;"/> --%>
                        </section>
                        <section>
                            <asp:Label ID="Label10" runat="server" Text="" Width="500">Channel: <span style="font-weight:bold"><%=Channel %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label11" runat="server" Text="" Width="500">Requested By: <span style="font-weight:bold"><%=RequestedBy %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label33" runat="server" Text="" Width="500">Reviewed By: <span style="font-weight:bold"><%=ReviewedBy %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label12" runat="server" Text="" Width="500"><%=ApprovedOrRejectedLabel %> <span style="font-weight:bold"><%=ApprovedOrRejected %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label13" runat="server" Text="" Width="260">File Load Started: <span style="font-weight:bold;margin-right:5px"><%=LoadBegin %></span></asp:Label>
                            <asp:Label ID="Label14" runat="server" Text="" Width="205">Finished: <span style="font-weight:bold;margin-right:5px"><%=LoadEnd %></span></asp:Label>
                            <asp:Label ID="Label15" runat="server" Text="" Width="100">Time: <span style="font-weight:bold;"><%=LoadTime %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label16" runat="server" Text="" Width="260">Validation Started: <span style="font-weight:bold;margin-right:5px"><%=EditBegin %></span></asp:Label>
                            <asp:Label ID="Label17" runat="server" Text="" Width="205">Finished: <span style="font-weight:bold;margin-right:5px"><%=EditEnd %></span></asp:Label>
                            <asp:Label ID="Label18" runat="server" Text="" Width="100">Time: <span style="font-weight:bold;"><%=EditTime %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label19" runat="server" Text="" Width="260">Processing Started: <span style="font-weight:bold;margin-right:5px"><%=ProcBegin %></span></asp:Label>
                            <asp:Label ID="Label20" runat="server" Text="" Width="205">Finished: <span style="font-weight:bold;margin-right:5px"><%=ProcEnd %></span></asp:Label>
                            <asp:Label ID="Label21" runat="server" Text="" Width="100">Time: <span style="font-weight:bold;"><%=ProcTime %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label22" runat="server" Text="" Width="500"> <span style="font-weight:bold;"><%=ReturnMsg %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label23" runat="server" Text="" Width="120">Payees: <span style="font-weight:bold;margin-right:5px"><%=Payees %></span></asp:Label>
                            <asp:Label ID="Label24" runat="server" Text="" Width="120">Panding: <span style="font-weight:bold;margin-right:5px"><%=Pending %></span></asp:Label>
                            <asp:Label ID="Label25" runat="server" Text="" Width="260">Total Amount: <span style="font-weight:bold;"><%=TotalAmount %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label26" runat="server" Text="" Width="120">Valid: <span style="font-weight:bold;margin-right:5px"><%=Valid %></span></asp:Label>
                            <asp:Label ID="Label27" runat="server" Text="" Width="120">Paid: <span style="font-weight:bold;margin-right:5px"><%=Paid %></span></asp:Label>
                            <asp:Label ID="Label28" runat="server" Text="" Width="260">Disbursed: <span style="font-weight:bold;"><%=DisbursedAmount %></span></asp:Label>
                        </section>
                        <section>
                            <asp:Label ID="Label29" runat="server" Text="" Width="120">Errors: <span style="font-weight:bold;margin-right:5px"><%=Errors %></span></asp:Label>
                            <asp:Label ID="Label30" runat="server" Text="" Width="120">Not Paid: <span style="font-weight:bold;margin-right:5px"><%=NotPaid %></span></asp:Label>
                            <asp:Label ID="Label31" runat="server" Text="" Width="260">Service Fee: <span style="font-weight:bold;"><%=ServiceFee %></span></asp:Label>
                        </section>
                    </div>
                    <div runat="server" id="success" style="border: 1px solid; padding: 2px; padding-left: 5px">
                        <img src="image/check4.png" style="margin-left: 120px;" />
                        <section style="margin-top:5px;margin-bottom:15px">
                            <asp:Label ID="Label32" runat="server" CssClass="label2" Text=""> <span style="color:blue;font-size:13pt;font-weight:bold;"> <%=ReturnMsg%></span></asp:Label>
                        </section>
                        <section>
                            <asp:Button ID="Button4" runat="server" Text="OK" OnClick="Button4_Click" Style="background-color: #005CB7; color: white; font-weight: bold; margin-left: 125px; padding: 1px 5px 1px 5px" />
                        </section>
                    </div>
                </div>
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
            t = setTimeout(logout, 1200000);  // time is in milliseconds
        }
    }
    idleLogout();
</script>
<!-- Bootstrap DatePicker -->



<%--<script type="text/javascript">
    $(function () {
        $('[id*=TextBox1]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "MM dd,yyyy"
        });
    });
</script--%>>

</html>

