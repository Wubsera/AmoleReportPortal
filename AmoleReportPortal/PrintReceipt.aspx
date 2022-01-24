<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintReceipt.aspx.cs" Inherits="AmoleReportPortal.PrintReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Amole Portal</title>
        <link rel="icon" href="image/AmoleImage.png" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="Css/PrintReceipt.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="print-receipt">
            <div class="print-header">
                <div class="print-header-left">
                    <section>
                        <h2><%=ReportHeading1 %></h2>
                    </section>
                    <section>
                        <%=ReportHeading2 %>
                    </section>
                    <section>
                        <%=ReportHeading3 %>
                    </section>
                </div>
                <div class="print-header-right">
                    <section>
                        <div class="imagebutton">
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/image/printer.png" ToolTip="Print Receipt" OnClientClick="javascript:window.print();" />
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/back.png" ToolTip="Go Back Remittance Cash-Out" OnClientClick="JavaScript:window.history.back(-1); return false;"/>
<%--                             <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/image/back.png" ToolTip="Go Back Remittance Cash-Out" OnClientClick="JavaScript:window.history.back(-1); return false;" OnClick="ImageButton1_Click" />--%>

                        </div>
                    </section>
                    <section>
                        <h4 style="font-size:15pt">International Money Transfer Receipt</h4>
                    </section>
                </div>
            </div>
            <div class="body">
                <div class="body-left">
                    <section>
                        AMTN: <span style="font-weight: bold"><%=AMTN %> </span>
                    </section>
                    <section>
                        Status: <span style="font-weight: bold"><%=Status%></span>
                    </section>
                    <section>
                        Received: <span style="font-weight: bold"><%=ReceivedDate %></span>
                    </section>
                    <section>
                        Processor: <span style="font-weight: bold"><%=Processor %></span>
                    </section>
                    <section>
                        Source Identifier: <span style="font-weight: bold"><%=SourceIdentifier %></span>
                    </section>
                </div>
                <div class="body-right">
                    <div class="align" style="width: 200px; float: right; margin-right: 10px">
                        <div class="left" style="width: 50%; float: left">
                            <section>Amount:</section>
                            <section>Ex.Rate:</section>
                            <section>RefNo:</section>
                            <section>ConfNo:</section>
                        </div>
                        <div class="right" style="width: 50%; float: left; font-weight: bold">
                            <section style="text-align: left">
                                <span><%=Amount %> ETB </span>
                            </section>
                            <section style="text-align: left">
                                <span><%=ExchangeRate %></span>
                            </section>
                            <section style="text-align: left">
                                <span><%=RefNo %> </span>
                            </section>
                            <section style="text-align: left">
                                <span><%=ConfNo %></span>
                            </section>
                        </div>
                        <%--<section style="font-weight:bold">
                        Amount:<span style="font-weight: bold;text-align:left"><%=Amount %> ETB</span>
                    </section>
                    <section >
                     Ex.Rate:<span style="font-weight: bold;text-align:left"><%=ExchangeRate %></span>
                    </section>
                    <section>
                       RefNo:<span style="font-weight: bold;text-align:left"><%=RefNo %></span>
                    </section>
                    <section>
                        ConfNo:<span style="font-weight: bold;text-align:left"><%=ConfNo %></span>
                    </section>--%>
                    </div>
                </div>
            </div>
            <section style="margin-top:10px;">
                    How to Receive: <span style="font-weight:bold"> <%=HowReceived %></span>
                </section>
            <div class="footer">
                <div class="sender">
                    
                    <h4>Sender Information</h4>
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
                    <h4>Beneficiary information</h4>
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
                        Birth Date: <span style="font-weight: bold"><%=RBDate %></span>
                    </section>
                    <section>
                        Mobile Number: <span style="font-weight: bold"><%=RecipientMobile %></span>
                    </section>
                    <section>
                        Email Address: <span style="font-weight: bold"><%=RecipientEmail %></span>
                    </section>

                </div>


            </div>

            <%--  <div class="print">
                <div class="print-r">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/image/printer.png" ToolTip="Print Receipt" OnClientClick="javascript:window.print();"/>

                <asp:Button ID="Button1" runat="server" CssClass="print-button" Text="Print Receipt" OnClientClick="javascript:window.print();" />
                </div>
                <div class="print-b">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/back.png" ToolTip="Go Back Remittance Cash-Out" OnClientClick="JavaScript:window.history.back(-1); return false;" />
                <asp:Button ID="btnCancel" runat="server" CssClass="print-back" Text="Go Back to Remittance" OnClientClick="JavaScript:window.history.back(-1); return false;" />
                </div>
            </div>--%>
            <div class="review">
                    <div class="processed">
                         <section>
                          <p>Processed by Agent</p> 
                        </section>
                        <section>
                          <p>Reviewed and Approved by</p> 
                        </section>                    
                    </div>
                     <div class="approved">
                        <section>
                          <p>Date</p> 
                        </section>
                        <section>
                          <p>Date</p> 
                        </section> 
                    </div>
                </div>
            <div class="image">
                
                <div class="logo">
                    <img alt="" src="Images/AmoleImage.png" />
                </div>
                <div class="para">
                    <p>Enabling commerce in the new service economy</p>
                </div>
            </div>
            <div class="private">
                <div class="conf">
                    <span>Private & Confidential</span>
                </div>
                <div class="date">
                    <span><%=date %></span>
                </div>
                <div class="page">
                    <span>Page 1 of 1</span>
                </div>

            </div>

        </div>

    </form>
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
</body>
</html>
