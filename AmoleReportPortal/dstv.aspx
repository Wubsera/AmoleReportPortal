<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dstv.aspx.cs" Inherits="AmoleReportPortal.dstv" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portal Report</title>
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
<body style="margin:0">
    <form id="form1" runat="server" style="min-height: 90vh;">
          <div class="container" style="background-color: white; width: 100%; height: auto;padding:0; overflow-y: hidden; margin-bottom:0px;clear:both; overflow-x: hidden; font-family: Calibri; font-weight: bold; font-size: 16px; color: #000000;" >

                  
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
                        <img class="person"  src="image/person.png" style="margin-right: 5px; height: 75px; margin-left: 0px; margin-bottom: -4px; width: 80px" />
                        <%--                           <asp:ImageButton src="Images/person.png" runat="server" ID="upload" OnClick="upload_Click" Style="margin-right:5px; height:75px; margin-left: 0px;margin-bottom:-4px; Width:80px" />--%>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" class="auto-style1" style="mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0in 5.4pt 0in 5.4pt; height: 4px; width: 100%;">
                <tr style="mso-yfti-irow: 0; mso-yfti-firstrow: yes; mso-yfti-lastrow: yes">
                    <td style="width: 522.95pt; border: solid windowtext 0.0pt; mso-border-alt: solid windowtext .5pt; background: #005CB7; padding: 0in 5.4pt 0in 5.4pt" valign="top" width="697">
                        <div>
                            <span style="font-family: Calibri; font-size: 16pt; color: white; font-weight: bold"><%=reportLink%></span></div>
                    </td>
                    <td style="width: 522.95pt; text-align: right; font-weight: bold; border: solid windowtext 0.0pt; mso-border-alt: solid windowtext .5pt; background: #005CB7; padding: 0in 5.4pt 0in 5.4pt" valign="top" width="697">
                        <%--<span style="font-family: Calibri; font-size: 16pt; color: white"><%=LoginID %> </span>--%>

                        <a href="helpDesk.aspx" style="text-decoration:underline;color:white">Technical Support Help Desk</a>

                    </td>
                </tr>
            </table>
              <br />
&nbsp;
             <a href="PortalReportAvailable.aspx?rptnumber =<%=rptn%>">Go Back to Available Reports</a>
			 > 
			 <a href='javascript:history.go(-1)'>Go Back to Date Filter</a>
              <br />
              <span style="justify-content:flex-end">
                <CR:CrystalReportViewer ID="CrystalReportViewer1"  runat="server" AutoDataBind="true" style="overflow-x:scroll" ReuseParameterValuesOnRefresh="True" HasRefreshButton="True" />
                  </span>
              </div>
          
         <asp:Panel runat="server" ID="powerDiv" BackColor="White" > 
                     <div  style="background-color: white; height: 0px; width: 100%">  
           <%-- <img class="image" name="poweredBy" src="Images/PoweredBy.jpg" style="height: 16px; width: 18px; align-content: flex-end" />
            <span style="font-family: Calibri; font-size: 8pt; font-style: italic; color: blue">POWERED BY FETTAN</span>--%>
                  </div>
                 </asp:Panel>
        <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"   AutoDataBind="true" />--%>  
            <%--    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
                        <asp:UpdatePanel UpdateMode="Conditional" ID="updcsa" runat="server">
                <ContentTemplate>--%>

            

            <%--                   <script type="text/javascript">
    $(function () {
        $("#<%= txtFrom.ClientID  %>").datepicker();
 
        $("#<%= txtTo.ClientID  %>").datepicker();
    });
</script>
                                <script type="text/javascript">
                                    $(function () {
                                        $("#<%= txtFromP.ClientID  %>").datepicker();

        $("#<%= txtToP.ClientID  %>").datepicker();
    });
</script>--%>
            <%--                    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.js">
                    </script>
                    <script type="text/javascript">
                        $(document).ready(function () {
                            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

                            function EndRequestHandler(sender, args) {
                                $('.mydatepickerclass').datepicker({ dateFormat: 'M dd, yy' });
                            }

                        });
                    </script>--%>
               <script type="text/javascript">
                   $(function () {
                       $('#txtTo').datepicker({ dateFormat: 'M dd, yy' });
                       $("#txtTo").datepicker();
                   });
            </script>
            <script type="text/javascript">
                $(function () {
                    $('#txtFrom').datepicker({ dateFormat: 'M dd, yy' });
                    $("#txtFrom").datepicker();
                });
            </script>
            <script type="text/javascript">
                $(function () {
                    $('#txtToP').datepicker({ dateFormat: 'M dd, yy' });
                    $("#txtToP").datepicker();
                });
            </script>
            <script type="text/javascript">
                $(function () {
                    $('#txtFromP').datepicker({ dateFormat: 'M dd, yy' });
                    $("#txtFromP").datepicker();
                });
            </script>
            <script type="text/javascript">
                            $(function () {
                                $('#txtToD').datepicker({ dateFormat: 'M dd, yy' });
                                $("#txtToD").datepicker();
                            });
            </script>
            <script type="text/javascript">
                $(function () {
                    $('#txtFromD').datepicker({ dateFormat: 'M dd, yy' });
                    $("#txtFromD").datepicker();
                });
            </script>
            <br />

            <%-- </ContentTemplate>
                 </asp:UpdatePanel>--%>


               
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
 </form>
                                
</body>
</html>
