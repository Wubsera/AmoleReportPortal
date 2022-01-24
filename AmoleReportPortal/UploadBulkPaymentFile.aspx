<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="UploadBulkPaymentFile.aspx.cs" Inherits="AmoleReportPortal.UploadBulkPaymentFile" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
                <div class="box1">
                    <section style="margin-bottom: 10px; margin-top: 5px; font-style: italic; font-family: Calibri; font-size: 13pt">
                        This screen is used to upload your batch bulk payments file for payments to recipients' mobile wallets. The file will be held pending approval by authorized staff.
                    </section>
                    <section>
                        <asp:Label ID="Label8" runat="server" Text="Label">
                            Merchant:
                        </asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server"  Style="font-size: 12pt;  width: 430px;padding:5px; font-weight: bold; background-color: #FFFFE1" autocomplete="off"></asp:DropDownList>
                    </section>
                    <section>
                        <asp:Label ID="Label2" runat="server" Style="padding-bottom: 5px" Height="19px">
                            Description of Batch:
                        </asp:Label>
                        <textarea id="TextArea1" cols="20" rows="2" style="font-size: 12pt; padding-top: 3px; padding-bottom: 3px; width: 360px; font-weight: bold; background-color: #FFFFE1" autocomplete="off"></textarea>
                    </section>
                    <section>
                        <asp:Label ID="Label3" runat="server" Text="Label">
                            Process file after this date:
                        </asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Style="font-size: 12pt; padding-top: 3px; padding-bottom: 3px; width: 140px; font-weight: bold; background-color: #FFFFE1" autocomplete="off"></asp:TextBox>

                        <asp:Label ID="Label9" runat="server" Text="Label">
                            and after this time:
                        </asp:Label>
                        <asp:TextBox ID="TextBox5" runat="server" Style="font-size: 12pt; padding-top: 3px; padding-bottom: 3px; width: 54px; font-weight: bold; background-color: #FFFFE1" autocomplete="off"></asp:TextBox>
                    </section>


                    <br />
                    <section>
                        <asp:FileUpload ID="FileUpload1" runat="server" style="float:left" />
                        <asp:Button ID="btnRead" CssClass="button" runat="server" Text="Import" OnClick="ReadCSV" Style="border-radius: 4px; background-color: #005CB7; font-size: 13pt; color: white; font-family: Calibri; font-weight: bold; cursor: pointer;margin-left:-7px" />
                        <asp:Label ID="Label6" runat="server" Text="" ForeColor="Red"></asp:Label>

                    </section>

                    <section>
                        <asp:Button ID="Button1" runat="server" Text="Submit Batch" Style="margin-left: 222px; margin-top: 10px; border-radius: 4px; background-color: #005CB7; font-size: 13pt; color: white; font-family: Calibri; font-weight: bold; cursor: pointer" />
                    </section>
                </div>
                <div class="box2">
                    <asp:Panel ID="Panel1" runat="server" Style="overflow-y: auto; height: 80vh">
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </asp:Panel>
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
            t = setTimeout(logout, 1800000);  // time is in milliseconds
        }
    }
    idleLogout();
</script>
<!-- Bootstrap DatePicker -->



<script type="text/javascript">
    $(function () {
        $('[id*=TextBox1]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "MM dd,yyyy"
        });
    });
</script>

</html>

