<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewHelperSample.aspx.cs" Inherits="AmoleReportPortal.GridViewHelperSample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.2)">
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.2)">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <title>GridViewHelper: Creating groups and summaries with 2 lines of code</title>
    <style type="text/css">
        body, a, span, td, input, select, textarea {
            font-size: 12px;
            font-family: Tahoma,Arial,Geneva,Verdana,sans-serif;
        }

        body {
            margin: 5px 5px 5px 5px;
            overflow: auto;
        }

        .auto-style1 {
            width: 457px;
        }

        .auto-style2 {
            width: 608px;
        }
    </style>
    <script type="text/javascript">
        var IE = (navigator.userAgent.indexOf('MSIE') != -1);
        function no_scrollbar() {
            if (!IE) return;
            // no scrollbars no IE
            var root = document.all[1]; // IE >= 4
            var firstCall = (root.style.overflow != 'auto');
            document.body.style.width = root.clientWidth + 'px';

            if (firstCall)
                root.style.overflow = 'auto';
        }
        onload = no_scrollbar;
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainDiv">
            <table cellspacing="5" align="center">
                <tr>
                    <td valign="top" class="auto-style1">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableViewState="False" CellPadding="3" AllowPaging="True" AllowSorting="True">
                            <Columns>
                                <asp:BoundField DataField="ReportNumber" HeaderText="ReportNumber" SortExpression="ReportNumber" />
                                <asp:BoundField DataField="ReportGroup" HeaderText="ReportGroup" SortExpression="ReportGroup" />
                                <asp:BoundField DataField="ReportName" HeaderText="ReportName"
                                    SortExpression="ReportName" />
                                <%--<asp:BoundField DataField="ParmTypeCode" HeaderText="ParmTypeCode" SortExpression="ParmTypeCode" />--%>
                            </Columns>
                        </asp:GridView>
                        <%--<asp:SqlDataSource ID="report" runat="server" ConnectionString="<%$ ConnectionStrings:FettanReportPortalConnectionShoa %>" SelectCommand="sp_Portal_Reports_Available" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                                <asp:ControlParameter ControlID="LoginID" Name="LoginID" 
        PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                    </td>
                    <td valign="top" align="left" width="328" class="auto-style2">&nbsp;<br />
                        &nbsp;<br />
                        &nbsp;</td>
                </tr>
            </table>

        </div>

    </form>
    <script type="text/javascript">
        var util = document.documentElement.clientWidth;
        if (util == 0) util = document.body.clientWidth;
        if (util < screen.width - 50) {
            window.moveTo(0, 0);
            window.resizeTo(screen.width, screen.height - 25);
        }
    </script>
</body>
</html>
