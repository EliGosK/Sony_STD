<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptBoxOfficeAndLateShowParam3.aspx.vb" Inherits=".frmRptBoxOfficeAndLateShowParam3" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="uc3" %>
<%@ Register Src="../Controls/TheatrePopup.ascx" TagName="TheatrePopup" TagPrefix="uc4" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="DatePicker" Src="~/Controls/DatePicker.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <style type="text/css">
        A:link
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:visited
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:hover
        {
            color: #cccccc;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:active
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        #Table2
        {
            height: 216px;
        }
        .style10
        {
            font-weight: bold;
            font-size: 12px;
            color: #ff0000;
            font-family: "Tahoma";
        }
        .style2
        {
            font-weight: bold;
            font-size: 14px;
            color: #999999;
            font-family: "Tahoma";
        }
        .style12
        {
            font-weight: bold;
            font-size: 14px;
            color: #666666;
            font-family: "Tahoma";
        }
        .style1
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
        }
        .style15
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            height: 11px;
        }
        .style16
        {
            width: 380px;
            height: 11px;
        }
        .style11
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
        }
        .style14
        {
            width: 380px;
        }
        .style17
        {
            height: 12.75pt;
            width: 28pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial;
            text-align: center;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style18
        {
            width: 178pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style19
        {
            height: 12.75pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial;
            text-align: center;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style20
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
    </style>
    
    <script language="javascript" type="text/javascript">
        function AddDays(p_day) {
            var year, month, day;

            if (!p_day || p_day == '' || isNaN(p_day)) { return; }

            var dtpStartDate = document.getElementById('<%= dtpStartDate.TxtDateClientID %>');
            year = parseInt(dtpStartDate.value.substring(6), 10); // Year
            month = parseInt(dtpStartDate.value.substring(3, 5), 10) - 1; // Month (0-11)
            day = parseInt(dtpStartDate.value.substring(0, 2), 10); // Day
            if (isNaN(year) || isNaN(month) || isNaN(day)) { return; }

            var dtm = new Date(year, month, day);
            dtm.setDate(dtm.getDate() + parseInt(p_day));

            var dtpEndDate = document.getElementById('<%= dtpEndDate.TxtDateClientID %>');
            year = dtm.getFullYear() + "";
            month = (dtm.getMonth() + 1) + "";
            day = dtm.getDate() + "";
            dtpEndDate.value = lpad(day, "0", 2) + "/" + lpad(month, "0", 2) + "/" + lpad(year, "0", 2);
        }

        function lpad(p_str, p_pad, p_length) {
            while (p_str.length < p_length) { p_str = p_pad + p_str; }
            return p_str;
        }

        function rpad(p_str, p_pad, p_length) {
            while (p_str.length < p_length) { p_str = p_str + p_pad; }
            return p_str;
        }
    </script>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form2" method="post" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#d3d3d3"
        bgcolor="#cccccc" id="Table2">
        <tr>
            <td width="53%" align="left" bgcolor="#ffffff" style="height: 23px">
                <font color="#000099" face="Tahoma" size="2"><strong>
                    <uc1:ctbvCtlTop ID="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop>
                </strong></font>
            </td>
            <td width="47%" align="right" bgcolor="#ffffff" style="height: 23px">
                <table width="58" border="0">
                    <tr>
                        <td width="52">
                            <asp:ImageButton ID="imbOut" runat="server" ImageUrl="~/images/Exit.png" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            Log Out
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr background="../images/BG7.jpg">
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg">
                <span class="style2">&nbsp;<a href="frmCTBV_Menu.aspx">Main Menu </a></span><span
                    class="style12">&gt; <a href="frmCTBV_RC_Menu.aspx">Reports Center </a>&gt; SDT
                    Checker wage and Late Show by User</span>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f0cd8c"
                    style="height: 154px">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                SDT Checker wage and Late Show by User</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#CCCCCC">
                            <table border="0" cellspacing="0" width="100%" cellpadding="0">
                                <tr>
                                    <td width="40%" class="style15">
                                    </td>
                                    <td style="text-align: left" class="style16">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="40%" class="style11" valign="top">
                                        Start Date :
                                    </td>
                                    <td align="left" class="style14">
                                        <uc1:DatePicker ID="dtpStartDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True" OnClientDateSelectionChanged="AddDays(6);"></uc1:DatePicker>
                                        <%--<asp:TextBox ID="lblDate" runat="server" BackColor="#336699" Columns="25" Font-Bold="True"
                                            ForeColor="White" ReadOnly="True"></asp:TextBox>
                                        <asp:ImageButton ID="btnCalendar" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/calendar_01.jpg"
                                            Style="width: 33px" />
                                        <asp:DropDownList ID="ddlClnYearFrom" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Calendar ID="clnDateFrom" runat="server" BackColor="White" BorderColor="White"
                                            BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="155px"
                                            NextPrevFormat="ShortMonth" Visible="False" Width="216px">
                                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                            <TodayDayStyle BackColor="#CCCCCC" />
                                            <OtherMonthDayStyle ForeColor="#999999" />
                                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                                Font-Size="12pt" ForeColor="#333399" />
                                        </asp:Calendar>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="40%" class="style11" valign="top">
                                        End Date :
                                    </td>
                                    <td align="left" class="style14">
                                        <uc1:DatePicker ID="dtpEndDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True"></uc1:DatePicker>
                                        <%--<asp:TextBox ID="lblDateEnd" runat="server" BackColor="#336699" Columns="25" Font-Bold="True"
                                            ForeColor="White" ReadOnly="True"></asp:TextBox>
                                        <asp:ImageButton ID="btnCalendar0" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/calendar_01.jpg"
                                            Style="width: 33px" />
                                        <asp:DropDownList ID="ddlClnYearTo" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Calendar ID="clnDateTo" runat="server" BackColor="White" BorderColor="White"
                                            BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="155px"
                                            NextPrevFormat="ShortMonth" Visible="False" Width="216px">
                                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                            <TodayDayStyle BackColor="#CCCCCC" />
                                            <OtherMonthDayStyle ForeColor="#999999" />
                                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                                Font-Size="12pt" ForeColor="#333399" />
                                        </asp:Calendar>--%>
                                        <asp:Label ID="lblError" runat="server" Font-Size="8pt" Font-Bold="true" ForeColor="Red"
                                            Text="<br>Invalid Date" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11" width="40%">
                                        &nbsp;
                                    </td>
                                    <td class="style14" style="text-align: left">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style11" width="40%">
                                        &nbsp;
                                    </td>
                                    <td class="style14" style="text-align: left">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#f0cd8c">
                            <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                            <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>&nbsp;--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

