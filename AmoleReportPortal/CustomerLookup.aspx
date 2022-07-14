<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLookup.aspx.cs" Inherits="AmoleReportPortal.CustomerLookup" %>


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
    <link rel="stylesheet" type="text/css" href="Css/CustomerLookup.css"/>
</head>
<script>
    var loadFile = function (event) {
        var output = document.getElementById('output');
        output.src = URL.createObjectURL(event.target.files[0]);
        output.onload = function () {
            URL.revokeObjectURL(output.src) // free memory
        }
        if (!event || !event.target || !event.target.files || event.target.files.length === 0) {
            return;
        }
        const name = event.target.files[0].name;
        const lastDot = name.lastIndexOf('.');

        const fileName = name.substring(0, lastDot);
        outputfile.value = fileName;
    };
    var loadFile2 = function (event) {
        var output = document.getElementById('output2');
        output.src = URL.createObjectURL(event.target.files[0]);
        output.onload = function () {
            URL.revokeObjectURL(output.src) // free memory
        }
        if (!event || !event.target || !event.target.files || event.target.files.length === 0) {
            return;
        }
        const name = event.target.files[0].name;
        const lastDot = name.lastIndexOf('.');
        const fileName = name.substring(0, lastDot);
        outputfile2.value = fileName;
    };
</script>
<body>
    <div class="form">
        <form runat="server">
            <div class="table1">
                <div class="left">
                    <img src="Images/AmoleLogo.jpg" />
                    <section>
                        <h1 style="margin-top: 5px"><%=ReportHeading1 %></h1>
                        <h2 style="margin-top: -28px"><%=ReportHeading2 %></h2>
                        <h3 style="margin-top: -18px"><%=ReportHeading3 %></h3>
                    </section>
                </div>
                <div class="right">
                    <asp:Image ID="Image3" runat="server" style="margin-left:5px;margin-right:5px" />
                    <h1 style="text-align: right; font-size: 15.5pt; font-weight: bold;"><%=FullName %></h1>
                    <section style="text-align: right; margin-top: -10px">
                        <span><a href="AboutUs.aspx">About Us</a>
                            |
                         <a href="ProfileUpdate.aspx">Profile</a>
                            |
                        <a href="ChangePassword.aspx">Change Password</a>
                            |
                    <a href="Login.aspx">Logoff</a></span>
                        <h4 style="text-align: right; font-size: 10pt; margin-top: 4px; font-weight: bold"><%=LastLoggedIn %></h4>
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
                    <p>Search by AMTN, Mobile Number, School ID, Account Number, Card Number or any other Amole Identifier.</p>
                </section>
                <span class="AMTN">Search Value:</span>
                <asp:TextBox ID="AMTN" runat="server" CssClass="search" OnTextChanged="AMTN_TextChanged"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Search" CssClass="search-button" OnClick="Button1_Click" />
                <asp:Label ID="Label2" Style="font-weight: bold; font-size: 14pt; color: blue" runat="server" Text="">
                </asp:Label>
                <section style="color: red; font-weight: bold; margin-top: 10px">
                    <asp:Label ID="Label1" CssClass="label1" runat="server" Text=""></asp:Label>
                </section>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>

                <asp:Panel ID="Panel1" runat="server" Style="margin-top: -15px">
                    <div class="top">
                        <div class="top-left">
                            <section>
                                Current KYC Level: <span style="font-weight: bolder"><%=NBELevel %></span>&nbsp;&nbsp;
                            Current Status: <span style="font-weight: bold;"><%=StatusX %></span>
                            </section>
                            <section style="margin-top: 25px;">
                                Mobile #: <span style="font-weight: bold"><%=MobileTel %></span>
                            </section>
                            <section style="margin-top: 5px; margin-bottom: 10px; margin-left: 25px">
                                Change to Mobile #: 
                                    <asp:TextBox ID="ChangeToMobile" runat="server" Style="font-weight: bold; padding: 5px; width: 185px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span style="font-weight: bold">First Name:</span><asp:TextBox ID="TextBox1" runat="server" Style="margin-left: 19px; padding: 5px; width: 250px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px;">
                                <span style="font-weight: bold">Father Name:</span><asp:TextBox ID="TextBox2" runat="server" Style="margin-left: 5px; padding: 5px; width: 250px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                Grandfather:
                                <asp:TextBox ID="TextBox3" runat="server" Style="margin-left: 8px; padding: 5px; width: 250px"></asp:TextBox>
                            </section>
                            <section>
                                <span style="font-weight: bold; margin-right: 35px;">Gender: </span>
                                <asp:RadioButton ID="RadioButton1" GroupName="gender" runat="server" Text="Male" />
                                <asp:RadioButton ID="RadioButton2" GroupName="gender" runat="server" Text="Female" />
                            </section>
                            <section style="margin-top: 5px;">
                                <span style="font-weight: bold">Birth Date:</span><asp:TextBox ID="TextBox4" runat="server" Style="margin-left: 23px; padding: 5px; width: 150px"></asp:TextBox>
                                &nbsp;<span style="color: gray">MM/DD/YYYY</span>
                            </section>
                            <section style="margin-top: 5px">
                                Email:
                                <asp:TextBox ID="TextBox5" runat="server" Style="margin-left: 52px; padding: 5px; width: 250px"></asp:TextBox>
                            </section>
                            <div class="identification">
                                <div class="photo">
                                    <section style="margin-top: 10px; margin-left: 15px">
                                        Upload Photo:
                                    </section>
                                    <%--<section style="pointer-events:none">
                                    <img src="image/person.png" id="output" style="width:100px;height:100px;margin-bottom:-10px" />
                                    </section>
                                    <input id='outputfile' type='text' name='outputfile' style="border:0;font-size:9pt;width:185px" readonly /><br/>
                                    <section style="margin-bottom:25px" runat="server">
                                        <asp:FileUpload ID="fuimage" runat="server" type="file" accept="image/*" onchange="loadFile(event)" style="width:90px;cursor:pointer" />
                                    </section>--%>

                                    <section style="margin-bottom: 10px">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="image/person.png" Width="100" Height="100" onclick="window.open(this.src)" Style="cursor: pointer; margin-left: 15px" /><br />
                                        <asp:FileUpload ID="fuimage" runat="server" Width="70px" Style="cursor: pointer; font-size: 8pt; text-align: left; font-weight: bold; margin-right: 5px" />
                                        <asp:Button ID="btnUpload" Text="Display" runat="server" OnClick="Upload_Photo" Style="cursor: pointer; font-size: 8pt; font-weight: bold" />
                                        <asp:Label ID="Label3" runat="server" Text="" Width="100px" Style="font-size: 9pt"></asp:Label>
                                        <br />

                                    </section>

                                    <section runat="server" id="submit">
                                        <asp:Button CssClass="submit" ID="Button2" runat="server" Text="Submit Changes" OnClick="Button2_Click" />
                                    </section>
                                    <section runat="server" id="verify" style="width: 400px">
                                        <asp:Label ID="Label4" runat="server" Text="Enter OTP: "></asp:Label>
                                        <asp:TextBox ID="TextBox16" runat="server" Width="32px" Style="font-weight: bold;" MaxLength="4" AutoCompleteType="None" autocomplete="off"></asp:TextBox>
                                        <asp:Button CssClass="submit3" ID="Button3" runat="server" Text="Verify OTP" OnClick="Button3_Click" />
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="resendotp" OnClick="LinkButton1_Click">Resend OTP</asp:LinkButton>
                                    </section>
                                    <section runat="server">
                                        <asp:Button CssClass="button4" ID="Button4" runat="server" Text="Done" OnClick="Button4_Click" />
                                    </section>

                                </div>

                                <div class="ID">
                                    <section style="margin-top: 10px; margin-left: 15px">
                                        Upload ID:
                                    </section>
                                    <%-- <section style="pointer-events:none">
                                    <img src="image/IDCard.jpg" id="output2" style="width:100px;height:100px;margin-bottom:-10px" />
                                    </section>
                                    <input id='outputfile2' type='text' name='outputfile' style="border:0;font-size:9pt;width:185px" readonly/><br/>--%>
                                    <%--<section>
                                     <asp:FileUpload ID="FileUpload1" runat="server" type="file" accept="image/*"  onchange="loadFile2(event)" style="width:90px;" />
                                    </section>--%>

                                    <section style="margin-bottom: 10px">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="image/IDCard.jpg" Width="100" Height="100" onclick="window.open(this.src)" Style="cursor: pointer; margin-left: 15px" /><br />
                                        <asp:FileUpload ID="FileUpload2" runat="server" Width="70px" Style="cursor: pointer; font-size: 8pt; font-weight: bold; text-align: left; margin-right: 5px" />
                                        <asp:Button ID="Button5" runat="server" OnClick="Upload_ID" Text="Display" Style="cursor: pointer; font-size: 8pt; font-weight: bold;" />
                                        <br />
                                        <asp:Label ID="Label5" runat="server" Text="" Style="font-size: 9pt"></asp:Label><br />

                                        <%--<input id='outputfile2' type='text' name='outputfile' style="border:0;font-size:9pt;width:185px" readonly/>--%>
                                        <br />
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="top-right">
                            <section style="margin-bottom: 5px">
                                <span style="font-weight: bold">Address Line 1: </span>
                                <asp:TextBox ID="TextBox6" runat="server" Style="width: 250px; padding: 5px; margin-left: 14px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span>Address Line 2: </span>
                                <asp:TextBox ID="TextBox7" runat="server" Style="width: 250px; padding: 5px; margin-left: 16px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span>Address Line 3: </span>
                                <asp:TextBox ID="TextBox8" runat="server" Style="width: 250px; padding: 5px; margin-left: 16px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span style="font-weight: bold">City: </span>
                                <asp:TextBox ID="TextBox9" runat="server" Style="width: 250px; padding: 5px; margin-left: 85px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span style="font-weight: bold">Country: </span>
                                <asp:TextBox ID="TextBox10" runat="server" Style="width: 250px; padding: 5px; margin-left: 57px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span>Residency: </span>
                                <asp:TextBox ID="TextBox11" runat="server" Style="width: 250px; padding: 5px; margin-left: 45px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span>Nationality: </span>
                                <asp:TextBox ID="TextBox12" runat="server" Style="width: 250px; padding: 5px; margin-left: 39px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span>Region: </span>
                                <asp:TextBox ID="TextBox13" runat="server" Style="width: 250px; padding: 5px; margin-left: 66px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 5px">
                                <span>Zone: </span>
                                <asp:TextBox ID="TextBox14" runat="server" Style="width: 250px; padding: 5px; margin-left: 78px"></asp:TextBox>
                            </section>
                            <section style="margin-bottom: 10px">
                                <span>Woreda/Sub City: </span>
                                <asp:TextBox ID="TextBox15" runat="server" Style="width: 250px; padding: 5px"></asp:TextBox>
                            </section>
                            <div runat="server" id="TypeOfID" class="TypeOfID">
                                <section style="margin-bottom: 5px">
                                    <span>Type of ID:</span>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Style="width: 263px; padding: 5px; margin-left: 45px"></asp:DropDownList>
                                </section>
                                <section style="margin-bottom: 5px">
                                    <span>ID Number:</span>
                                    <asp:TextBox ID="TextBox18" runat="server" Style="width: 250px; padding: 5px; margin-left: 39px"></asp:TextBox>
                                </section>
                                <section style="margin-bottom: 5px">
                                    Issuer:
                                <asp:TextBox ID="TextBox19" runat="server" Style="width: 250px; padding: 5px; margin-left: 72px"></asp:TextBox>
                                </section>
                                <section style="margin-bottom: 5px">
                                    Issue Date:
                                <asp:TextBox ID="TextBox20" runat="server" Style="width: 250px; padding: 5px; margin-left: 43px" placeholder="MM/DD/YYYY" onfocus="this.placeholder = ''" onblur="this.placeholder = 'MM/DD/YYYY'"></asp:TextBox>
                                </section>
                                <section>
                                    Expiration Date:
                                <asp:TextBox ID="TextBox21" runat="server" Style="width: 250px; padding: 5px; margin-left: 11px;" placeholder="MM/DD/YYYY" onfocus="this.placeholder = ''" onblur="this.placeholder = 'MM/DD/YYYY'"></asp:TextBox>
                                </section>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>

        </form>
    </div>
    <div class="footer">
        <img alt="" src="Images/Amole.png" />
        <span>Powered by Amole</span>
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
            t = setTimeout(logout, 1200000);  // time is in milliseconds // 20 minutes
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
