<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_Menu_Ticket.aspx.vb"
    Inherits="frmCTBV_Menu_Ticket" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System - Ticket / Cap Master</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
        .style1
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
        }
        .style2
        {
            font-weight: bold;
            font-size: 14px;
            color: #999999;
            font-family: "Tahoma";
        }
        .style10
        {
            font-weight: bold;
            font-size: 12px;
            color: #ff0000;
            font-family: "Tahoma";
        }
        #Table2
        {
            height: 216px;
        }
    </style>

    <script language="JavaScript" type="text/JavaScript">
<!--



        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }
//-->
    </script>

    <meta http-equiv="Content-Type" content="text/html; charset=windows-874">
</head>
<body ms_positioning="GridLayout" leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#d3d3d3"
        bgcolor="#cccccc" id="Table2">
        <tr>
            <td width="53%" align="left" bgcolor="#ffffff" style="height: 23px">
                <font face="Tahoma"><font size="2"><font color="#000099"><strong>
                    <uc1:ctbvCtlTop ID="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop>
                </strong></font></font></font>
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
                <span class="style2">&nbsp;<a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; &nbsp;Ticket
                    / Cap Master</span>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f0cd8c"
                    style="height: 154px">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                Ticket / Cap Master</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center">
                            <table border="0" cellspacing="6" style="width: 180px">
                                <tr>
                                    <td bordercolor="#f0cd8c">
                                        <asp:ImageButton ID="ibnTicket1" runat="server" BorderColor="#FF9900" BorderStyle="Dotted"
                                            BorderWidth="1px" AlternateText="Checker Level" ImageUrl="~/images/MenuTicket1.jpg"
                                            PostBackUrl="~/Form/frmCTBV_MMD_FreeTicketAndPerCap.aspx" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibnTicket2" runat="server" ImageUrl="~/images/MenuTicket2.jpg"
                                            BorderColor="#FF9900" BorderStyle="Dotted" BorderWidth="1px" PostBackUrl="~/Form/frmCTBV_MMD_FreeTicketAndPerCap_Movie.aspx" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibnTicket3" runat="server" BorderColor="#FF9900" BorderStyle="Dotted"
                                            BorderWidth="1px" AlternateText="Former Wage" ImageUrl="~/images/MenuTicket3.jpg"
                                            PostBackUrl="~/Form/frmCTBV_MMD_TicketType.aspx" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibnTicket4" runat="server" BorderColor="#FF9900" BorderStyle="Dotted"
                                            BorderWidth="1px" AlternateText="Present Wage" ImageUrl="~/images/MenuTicket4.jpg"
                                            PostBackUrl="~/Form/frmCTBV_MMD_TicketType_Movie.aspx" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
    <ucCopyRights:Copyrights ID="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

