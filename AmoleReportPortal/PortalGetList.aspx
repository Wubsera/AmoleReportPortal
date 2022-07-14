<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="PortalGetList.aspx.cs" Inherits="AmoleReportPortal.PortalGetList" %>     
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>  --%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Amole Portal</title>
    <link rel="icon" href="image/AmoleIcon.jpg" type="image/x-icon" />
    <%--<link rel="stylesheet" type="text/css" href="Css/UserEnvironment.css" />--%>
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/jquery-ui.min.js" type="text/javascript"></script>
        <%--<meta http-equiv="refresh" content="360;URL=Login.aspx"/>--%> 
    <style type="text/css">
        .container {
            height: 100%;
            width: 100%;
        }

        .MsoNormal {
            width: 103px;
            height: 50px;
        }

        .MsoNormal2 {
            width: 100%;
            height: 19px;
        }

        .auto-style1 {
            width: 931pt;
        }

        .auto-style2 {
            height: 10pt;
            width: 96px;
        }

        .auto-style3 {
            width: 518px;
        }

        .auto-style4 {
            width: 900px;
        }
        .auto-style6 {
            width: 97px;
            height: 75px;
        }
        .auto-style7 {
            height: 487px;
            width: 100%;
        }
        .auto-style8 {
            height: 367px;
        }
        .auto-style9 {
            width: 23px;
        }
        .auto-style10 {
            width: 473px;
            height: 184px;
            margin-left: 97px;
        }
        .auto-style12 {
            width: 167px;
        }
        .auto-style13 {
            width: 6px;
        }
        .auto-style15 {
            margin-left: 97px;
        }
        .auto-style16 {
            cursor: pointer;
            margin-left: 16px;
        }
        .auto-style17 {
            margin-left: 9px;
        }
        .auto-style18 {
            margin-left: 11px;
        }
        .auto-style19 {
            width: 307px;
        }
        #header-content {
  position: absolute;
  bottom: 0;
  left: 0;
}
            .auto-style20 {
            width: 28px;
            height: 24px;
            margin-left: 0px;
        }
        .auto-style21 {
            font-weight: normal;
        }
            .auto-style14 {
                font-family: Calibri;
                font-style: italic;
                font-size: small;
                color: #0000FF;
                            }
        .auto-style22 {
            width: 6px;
            font-size: small;
        }
        </style>
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

</head>
<body style="padding: 0; margin: 0; height: 490px;font-family:Calibri">
    <form id="form1" runat="server" style="font-family:Calibri">

          <div class="auto-style7" style="background-color: white; overflow-y: hidden; overflow-x: hidden; font-family: Calibri; font-weight: bold; font-size: 16px; color: #000000;" >
                  
            <%--<img src="Images/loginInstance.jpg" />--%>
  <table border="0" cellpadding="0" cellspacing="0" class="auto-style1" style="mso-border-alt: solid windowtext .0pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0in 5.4pt 0in 5.4pt; height: 50px; width: 100%">
                <%-- <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes">
                    <td style="border: 0;  background: #F1A936"  valign="top" class="auto-style3">
                        <p class="MsoNormal">--%>
                <tr style="mso-yfti-irow: 0; mso-yfti-firstrow: yes; mso-yfti-lastrow: yes">
                    <td style="border: solid windowtext 0.0pt; mso-border-alt: solid windowtext .5pt; background: #FDDB00; padding: 0in 5.4pt 0in 5.4pt" valign="top" class="auto-style2">
                        <p class="MsoNormal">
                           

                            <img alt="" class="auto-style6" src="Images/AmoleLogo.jpg"style="margin-top: -10px" /></td>
                    <td style="border: 0; background: #FDDB00; font-style: italic" class="auto-style4">
                        <div style="height: 32px">
                            <span style="font-family: Calibri; font-size: 28pt; color: darkblue; font-weight: bold"><%=ReportHeading1 %></span>
                        </div>
                        <div style="height: 20px; margin-top: 5px">
                            <span style="font-family: Calibri; font-size: 16pt; color: black; font-weight: bold"><%=ReportHeading2%> </span>
                        </div>
                        <div style="height: 24px">
                            <span style="font-family: Calibri; font-size: 16pt; color: black; font-weight: bold"><%=ReportHeading3%></span>
                        </div>
                    </td>
                    <td style="border: 0; background: #FDDB00; text-align: right; margin-top: 20px" class="auto-style3">
                        <%--                       <a href="Login.aspx"><span style="font-family:Calibri;font-size:16px;color:black;font-weight: bold">LOGOUT</span></a>--%>
                        <asp:Label ID="Label4" runat="server" Text="Label"><span style="font-family: Calibri; font-weight: bold; font-size: 16pt; color: black; margin-right: 5px"><%=FullName%> </span>
                        </asp:Label>
                        <div>
                        <asp:Label ID="Label3" runat="server" Text="Label" ><a href="AboutUs.aspx"  style="font-family: Calibri; font-size: 13pt; color: blue; font-weight: bold; margin-right: 0px;text-align:right;text-decoration:none">About Us</a></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text=""><span style="font-family:Calibri;font-size:24px">|</span></asp:Label>
                            <asp:Label ID="Label10" runat="server" Text="Label"><a href="Login.aspx" style="font-family: Calibri; font-size: 13pt; color: blue; font-weight: bold; margin-right: 5px;text-decoration:none">Logoff</a></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Label"><span style="font-family: Calibri; font-size: 9pt; color: black; font-weight: bold; margin-right: 5px"><%=LastLoggedIn%> </span>
                            </asp:Label>
                        </div>


                    </td>

                    <td style="border: 0; background: #FDDB00; text-align: right; font-weight: bold">
                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                        <%--<asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click"/><br />--%>
                        <%--<asp:Image ID="Image1" runat="server" />--%>
                        <%--<asp:FileUpload ID="fileupload" runat="server" src="Images/person.png"  Style="height: 75px; width: 87px;margin-right:5px"/>--%>
                        <img class="person" src="image/person.png" style="margin-right: 5px; height: 75px; margin-left: 0px; margin-bottom: -4px; width: 80px" />
                        <%--                           <asp:ImageButton src="Images/person.png" runat="server" ID="upload" OnClick="upload_Click" Style="margin-right:5px; height:75px; margin-left: 0px;margin-bottom:-4px; Width:80px" />--%>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" class="auto-style1" style="mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0in 5.4pt 0in 5.4pt; height: 4px; width: 100%;">
                <tr style="mso-yfti-irow: 0; mso-yfti-firstrow: yes; mso-yfti-lastrow: yes">
                    <td style="width: 522.95pt; border: solid windowtext 0.0pt; mso-border-alt: solid windowtext .5pt; background: #005CB7; padding: 0in 5.4pt 0in 5.4pt" valign="top" width="697">
                        <div>
                            <span style="font-family: Calibri; font-size: 16pt; color: white; font-weight: bold"><%=reportLink%></span>

                        </div>
                    </td>
                    <td style="width: 522.95pt; text-align: right; font-weight: bold; border: solid windowtext 0.0pt; mso-border-alt: solid windowtext .5pt; background: #005CB7; padding: 0in 5.4pt 0in 5.4pt" valign="top" width="697">
                        <%--<span style="font-family: Calibri; font-size: 16pt; color: white"><%=LoginID %> </span>--%>

                        <a href="helpDesk.aspx" style="text-decoration:underline;color:white">Technical Support Help Desk</a>

                    </td>
                </tr>
            </table>
              &nbsp;&nbsp;
                <%--<a href='javascript:history.go(-1)'>Go Back to Available Reports</a>--%>
              <br />
              <span style="font-family:Calibri">&nbsp;
              <a href="PortalReportAvailable.aspx?rptnumber =<%=rptn %>">Go Back to Available Reports</a></span><br />
&nbsp;<div style="background-color: white" class="auto-style8">
        <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"   AutoDataBind="true" />--%>  
            <%--    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
                        <asp:UpdatePanel UpdateMode="Conditional" ID="updcsa" runat="server">
                <ContentTemplate>--%>
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>                            
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="merchant" runat="server" Text="Merchant" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"></asp:Label>
                <asp:DropDownList ID="DropDownListSelectBranch" runat="server"  AutoPostBack="true" Height="28px" OnDataBound="DropDownListSelectBranch_DataBound" OnSelectedIndexChanged="DropDownListSelectBranch_SelectedIndexChanged"  Style="font-family: Calibri; font-size: 12pt; color: black; font-weight: bold; " Width="347px" CssClass="auto-style18" BackColor="#FFFFE1">
                </asp:DropDownList>
                    <br />
                             

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label11" runat="server" autocomplete="off" Text="From Business Day:" Style="font-family:Calibri"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   
                <asp:Label ID="Label12" runat="server" Text="To Business Day:" Style="font-family:Calibri"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
                   
                 <table style="border-left:100px">
                        <tr>
                            <td class="auto-style19">
                                <asp:TextBox ID="txtFrom" AutoCompleteType="Disabled" runat="server" BackColor="#ffffe1" BorderColor="Gray" BorderStyle="Double" Height="30px" onblur="this.placeholder = 'Start Date'" onfocus="this.placeholder = 'Start Date'" OnTextChanged="txtFrom_TextChanged" Style="font-family: Calibri; font-size: 13pt; text-align:center; color: blue; font-weight: bold" Width="210px" CssClass="auto-style15"></asp:TextBox>
                               </td>
                               <td>
                                   &nbsp;&nbsp;
                                 <asp:TextBox ID="txtTo" AutoCompleteType="Disabled" runat="server" OnTextChanged="txtTo_TextChanged" onfocus="this.placeholder = 'End Date'" onblur="this.placeholder = 'End Date'" Style="font-family: Calibri; font-size: 13pt; text-align:center; color: blue; font-weight: bold;" Width="209px" Height="30px" BorderStyle="Double" BackColor="#ffffe1" BorderColor="Gray" CssClass="auto-style17"></asp:TextBox>
                                 </td>
                            <td>
                              <%--<asp:ImageButton ID="ImageButton3" runat="server" ToolTip="GENERATE REPORT" BackColor="white"  CssClass="auto-style16" Height="48px" OnClick="Generate_Click"  src="Images/run.png"  style="border-radius: 15px; font-family:Calibri;font-size:18pt;color:blue;font-weight:bold" Width="59px" />--%>  
                            </td>
                    </tr>
                     </table>
                      <table class="auto-style10">

                        <tr>
                            <td class="auto-style12" style="font-family:Calibri" >
                            <asp:Calendar ID="Calendar1" runat="server" Font-Underline="False" BackColor="white" BorderColor="Gray"  
                            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt"  
                            ForeColor="Black" ShowGridLines="True"  OnSelectionChanged="Calendar1_SelectionChanged"  
                             Height="188px" Width="210px" EnableTheming="True">  
                            <SelectedDayStyle Font-Bold="True" BorderColor="Gray" />  
                            <SelectorStyle BorderColor="Gray" />  
                            <TodayDayStyle BackColor="WhiteSmoke" ForeColor="Black" BorderColor="Gray" BorderStyle="Double" />  
                            <OtherMonthDayStyle ForeColor="Gray" />  
                            <NextPrevStyle Font-Size="10pt" ForeColor="Green" Font-Bold="true" />  
                            <DayHeaderStyle BackColor="White" Font-Bold="True" Height="1px" />  
                            <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" Font-Names="Calibri" ForeColor="#990000" />  
                             </asp:Calendar>  

                                <%--<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>--%>
           </td>
            <td class="auto-style13"></td>
            <td class="auto-style9" style="font-family:Calibri">  
                           <asp:Calendar ID="Calendar2" runat="server" Font-Underline="False" BackColor="white" BorderColor="Gray"  
                            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt"  
                            ForeColor="Black" ShowGridLines="True"  OnSelectionChanged="Calendar2_SelectionChanged"  
                             Height="188px" Width="210px" EnableTheming="True">  
                            <SelectedDayStyle Font-Bold="True" BorderColor="Gray" />  
                            <SelectorStyle BorderColor="Gray" />  
                            <TodayDayStyle BackColor="WhiteSmoke" ForeColor="Black" BorderColor="Gray" BorderStyle="Double" />  
                            <OtherMonthDayStyle ForeColor="Gray" />  
                            <NextPrevStyle Font-Size="10pt" ForeColor="Green" Font-Bold="true" />  
                            <DayHeaderStyle BackColor="White" Font-Bold="True" Height="1px" />  
                            <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" Font-Names="Calibri" ForeColor="#990000" />  
                             </asp:Calendar>   
                <%--<asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>--%>

                                </td>
                            </tr>
                        </table>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />
                    <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate" />--%>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate" />--%>
            <div id="header-content" style="background-color: white; " class="auto-style11">
      <span class="auto-style9"><img alt="" class="auto-style20" src="Images/Amole.png" /> 
              </span><span class="auto-style21"><span class="auto-style14"></span><span style="font-family: Calibri; font-style: italic; color: blue" class="auto-style22">Powered&nbsp; by Amole</span></span>
    </div>

                    <br />


                    </div>


    

        </div>
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

    </form>
                               
</body>
 
</html>