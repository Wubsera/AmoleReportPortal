<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="helpDeskRP.aspx.cs" Inherits="AmoleReportPortal.helpDeskRP" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Amole Portal</title>
    <link rel="icon" href="image/AmoleIcon.jpg" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="Css/helpdeskc.css" />
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/jquery-ui.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="form">
        <form runat="server">
            <div class="table1">
                <div class="left">
                    <img src="Images/AmoleLogo.jpg" />
                    <section>
                        <h1>Amole Payment Services</h1>
                        <h2>at Dashen Bank S.C.</h2>
                        <h3>Addis Ababa, Ethiopia</h3>
                    </section>
                </div>
                <div class="right">
                    <img src="Images/AmoleLogo.jpg" />
                </div>
            </div>
            <div class="table2">
                <div class="left">
                    <span>Submit Helpdesk Request</span>
                </div>
                <div class="right">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" style="color:white;font-family:Calibri;font-size:12pt;font-weight:bold;">Return to Login Screen</asp:LinkButton>
                </div>
            </div>
            
            <asp:Panel ID="Panel1" runat="server" CssClass="panel">
                  <div class="Box">
                      <div class="box1">
                          <h2>Your Contact Information</h2>
                          <input id="Name" runat="server" type="text" placeholder="Name" autocomplete="off" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Name'" />
                          <input id="Company" runat="server" type="text" placeholder="Company" autocomplete="off" onfocus="this.placeholder=''" onblur="this.placeholder='Company'" />                     
                           <input id="MobileTel" runat="server" type="text" placeholder="Mobile Tel" autocomplete="off" onfocus="this.placeholder=''" onblur="this.placeholder='Mobile Tel'"/>
                            <input id="Email"  runat="server" type="text" name="Email" placeholder="Email" autocomplete="off" onfocus="this.placeholder=''" onblur="this.placeholder='Email'" />
                         <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email"
                              ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                              Display="Dynamic" ErrorMessage="Invalid email" style="margin-left:2em;"></asp:RegularExpressionValidator>--%>
                          <%--<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ErrorMessage="Invalid Email" ValidationGroup="Issue"></asp:RegularExpressionValidator>--%>
                          <asp:DropDownList ID="MerchantID" runat="server" CssClass="DropDownList1">
                          </asp:DropDownList>
<%--                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select your merchant" ControlToValidate="MerchantID" Display="Dynamic" ValidationGroup="Issue" InitialValue="0" style="font-family:Calibri;font-size:12pt;font-weight:normal;margin-left:3em;color:red"></asp:RequiredFieldValidator>--%>
                      </div>
                      <div class="box2">
                          <h2>What type of problem are you having?</h2>
                            <h4>Environment:</h4>
                          <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radio" ValidationGroup="radioEnv">
                              <asp:ListItem Text="UAT (Test Environment)" Value="U" ></asp:ListItem>
                              <asp:ListItem Text="Production" Value="P"></asp:ListItem>
                          </asp:RadioButtonList>
              <%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select environment" ControlToValidate="RadioButtonList1" Display="Dynamic" ValidationGroup="radioTest" InitialValue="0" style="font-family:Calibri;font-size:12pt;font-weight:normal;margin-left:2em;color:red"></asp:RequiredFieldValidator>
                          <asp:RadioButton ID="UAT" runat="server" CssClass="radio" GroupName="radioEnv" Checked="true" Text="UAT (Test Environment)" />
                          <asp:RadioButton ID="PRO" runat="server" CssClass="radio" GroupName="radioEnv" Text="Production" />--%>
                        
                            <asp:DropDownList ID="IssueType" runat="server" CssClass="dropdown" OnSelectedIndexChanged="IssueType_SelectedIndexChanged" ValidationGroup="Issue" AutoPostBack="true">
                              <asp:ListItem Text=" --- Select Issue Type  ---" Value="Null"></asp:ListItem>
                              <asp:ListItem Text="General Issue" Value="G"></asp:ListItem>
                              <asp:ListItem Text="Online APIs" Value="A"></asp:ListItem>
                          </asp:DropDownList>
<%--                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select issue type" ControlToValidate="IssueType" Display="Dynamic" ValidationGroup="Issue" InitialValue="Null" style="font-family:Calibri;font-size:12pt;font-weight:normal;color:red;margin-left:2em"></asp:RequiredFieldValidator>--%>
                          <asp:DropDownList ID="API" runat="server" CssClass="dropdown" ValidationGroup="Issue">
                               </asp:DropDownList>
<%--                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select API service" ControlToValidate="API" Display="Dynamic" ValidationGroup="Issue" InitialValue="0" style="font-family:Calibri;font-size:12pt;font-weight:normal;margin-left:2em;color:red"></asp:RequiredFieldValidator>--%>
                          <div class="input">
                              <input id="SourceTransID" runat="server" type="text" placeholder="Your Transaction ID" autocomplete="off" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Your Transaction ID'" />
                              </div>
                      </div>
                  </div>
                <div class="box3">
                    <h2>Please tell us the details of your issue</h2>
                      <asp:DropDownList ID="PriorityID" runat="server" CssClass="priority" ValidationGroup="Issue">
                          <asp:ListItem Value="1" Text= "1 - Low Priority"></asp:ListItem>
                          <asp:ListItem Value="2" Text ="2 - Medium Priority, as soon as possible"></asp:ListItem>
                          <asp:ListItem Value="3" Text= "3 - High Priority, we need help"></asp:ListItem>
                          <asp:ListItem Value="4" Text="4 - Severe Priority, customer affected"></asp:ListItem>
                    </asp:DropDownList>
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select priority" ControlToValidate="PriorityID" Display="Dynamic" ValidationGroup="Issue" InitialValue="Null" style="font-family:Calibri;font-size:12pt;font-weight:normal;color:red" ></asp:RequiredFieldValidator>--%>
                    <div class="input">
                        &nbsp;<input id="Overview" runat="server" type="text" placeholder="Overview" autocomplete="off" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Overview'"  />
                    </div>
                    <div class="textarea">
                        <textarea id="Problem" runat="server" cols="20" rows="2" placeholder="Put your problem here ..." autocomplete="off" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Put your problem here ...'"></textarea>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="cancel" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="submit" OnClick="Button2_Click" ValidationGroup="Issue"/>
                    <asp:Label ID="Label1" runat="server" CssClass="label1"></asp:Label>
                </div>
        </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" CssClass="panel1">
                <div class ="success">
                <img src="image/check4.png" />
                  <h2>Request successfully submitted</h2>
                </div>
                    <asp:Label ID="ticketID" runat="server" CssClass="label2" Text="">Ticket #<%=insertedId%></asp:Label>
                <p>A member of Amole Teachnical Support Team will be in contact with you as soon as possible based on the priority of the request and other issues in progress.</p>
                <asp:Button ID="Button3" runat="server" CssClass="button" Text="Continue" OnClick="Button3_Click" />
            </asp:Panel>
        </form>
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
            t = setTimeout(logout, 1200000);  // time is in milliseconds //20 minutes
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