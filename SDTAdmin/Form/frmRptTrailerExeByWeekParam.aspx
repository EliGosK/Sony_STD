<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTrailerExeByWeekParam.aspx.vb" Inherits=".frmRptTrailerExeByWeekParam" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="uc3" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="DatePicker" Src="~/Controls/DatePicker.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Trailer Execute By Week</title>

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
    </style>
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
        <tr background="../images/BG7.jpg" style="color: Gray; font-family: Tahoma; font-size: 13px;">
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg">
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a></b>&nbsp;&gt; <b><a href="frmCTBV_Menu_Trailer.aspx">
                    Trailer Menu </a></b>&nbsp;&gt; <b><a href="frmCTBV_Menu_Trailer_Rpt.aspx">Trailer Reports
                    </a></b>&nbsp;&gt; <strong>Trailer Execution by Week</strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f0cd8c"
                    style="height: 154px">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;
                                color: Gray;">
                                Trailer Execution by Week</div>
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
                                        <uc1:DatePicker ID="dtpStartDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True"></uc1:DatePicker>
                                        <%--<asp:TextBox ID="lblDate" runat="server" BackColor="#336699" Columns="25" Font-Bold="True"
                                            ForeColor="White" ReadOnly="True"></asp:TextBox>
                                        <asp:ImageButton ID="btnCalendar" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/calendar_01.jpg"
                                            Style="width: 33px" />
                                        <asp:DropDownList ID="ddlClnYear" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Calendar ID="clnDate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px"
                                            Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="155px" NextPrevFormat="ShortMonth"
                                            Visible="False" Width="216px">
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
                                    <td class="style11" valign="top" width="40%">
                                        End Week :
                                    </td>
                                    <td align="left" class="style14">
                                        <asp:DropDownList ID="ddlSelectPeriod" runat="server" BackColor="#336699" Font-Bold="True"
                                            ForeColor="White">
                                            <asp:ListItem Value="1"></asp:ListItem>
                                            <asp:ListItem Value="2"></asp:ListItem>
                                            <asp:ListItem Value="3"></asp:ListItem>
                                            <asp:ListItem Value="4"></asp:ListItem>
                                            <asp:ListItem Value="5"></asp:ListItem>
                                            <asp:ListItem Value="6"></asp:ListItem>
                                            <asp:ListItem Value="7"></asp:ListItem>
                                            <asp:ListItem Value="8"></asp:ListItem>
                                            <asp:ListItem Value="9"></asp:ListItem>
                                            <asp:ListItem Value="10"></asp:ListItem>
                                            <asp:ListItem Value="11"></asp:ListItem>
                                            <asp:ListItem Value="12"></asp:ListItem>
                                            <asp:ListItem Value="13"></asp:ListItem>
                                            <asp:ListItem Value="14"></asp:ListItem>
                                            <asp:ListItem Value="15"></asp:ListItem>
                                            <asp:ListItem Value="16" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11" width="40%">
                                        &nbsp;
                                    </td>
                                    <td class="style14" style="text-align: left">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                    </td>
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

