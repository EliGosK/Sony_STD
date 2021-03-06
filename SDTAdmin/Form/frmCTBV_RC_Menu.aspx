<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_RC_Menu.aspx.vb"
    Inherits=".frmCTBV_RC_Menu" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System - Report Center Menu</title>

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
        .style13
        {
            width: 450px;
            font-weight: bold;
        }
        .style16
        {
            width: 322px;
            font-weight: bold;
        }
        .style17
        {
            width: 400px;
            font-weight: bold;
            height: 23px;
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
                    class="style12">&gt; Report Center </span>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f0cd8c"
                    style="height: 154px">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                Report Center</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center">
                            <table style="width: 500px">
                                <tr>
                                    <td bordercolor="#f0cd8c" class="style16" style="text-align: left" bgcolor="#CCCCCC">
                                        Reports Name
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplExportBoxOffice" runat="server" NavigateUrl="~/Form/frmExportParam.aspx"
                                            ForeColor="#3333CC">- Export Box 
                                                                             Office Data to SPIRITworld</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplSdtDailyBoxOffice" runat="server" NavigateUrl="~/Form/frmRptParam.aspx"
                                            ForeColor="#3333CC">- SDT Daily 
                                                                           Box Office (Initial)</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplCompDailyBoxOffice" runat="server" NavigateUrl="~/Form/frmExportForCustomerCompParam.aspx"
                                            ForeColor="#3333CC">- Competitor Daily Box Office (Initial)</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplSdtWeeklyBoxOffice" runat="server" NavigateUrl="~/Form/frmRptPerWeekParam.aspx"
                                            ForeColor="#3333CC">- SDT 
                                                                             Weekly Box Office (for Finance)</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplWeekendTrading" runat="server" NavigateUrl="~/Form/frmRptPerWeekendParam.aspx"
                                            ForeColor="#3333CC">- 
                                                                             Weekend Trading Report</asp:HyperLink>
                                    </td>
                                </tr>
                              <%--   <tr>
                                    <td class="style13" style="text-align: left">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplSdtMarketShare" runat="server" NavigateUrl="~/Form/frmRptMarketShareParam.aspx"
                                            ForeColor="#3333CC">- 
                                                                              SDT Market Share</asp:HyperLink>
                                    </td>
                                </tr>
                                --%>
                                <tr>
                                    <td class="style13" style="text-align: left">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplMovieMarketShare" runat="server" NavigateUrl="~/Form/frmReportMovieMarketShareParam.aspx"
                                            ForeColor="#3333CC">- 
                                                                              SDT Market Share</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplCompMarketShare" runat="server" NavigateUrl="~/Form/frmRptCompMarketShareParam.aspx"
                                            ForeColor="#3333CC">- Competitor Market Share</asp:HyperLink>
                                    </td>
                                </tr>
                                 <%--<tr>
                                    <td class="style13" style="text-align: left">
                                        &nbsp;&nbsp; &nbsp;<asp:HyperLink ID="hplGeneralIndustryMarketShare" runat="server"
                                            NavigateUrl="~/Form/frmRptMarketSareByPeriodParam.aspx" ForeColor="#3333CC">- General Industry Market Share</asp:HyperLink>
                                    </td>
                                </tr>
                                --%>
                                <tr>
                                    <td class="style13" style="text-align: left">
                                        &nbsp;&nbsp; &nbsp;<asp:HyperLink ID="hplGeneralIndustryMarketShare2" runat="server"
                                            NavigateUrl="~/Form/frmReportGeneralIndustryMarketShareParam.aspx" ForeColor="#3333CC">- General Industry Market Share</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplSdtBoxOfficeBySoundAndFilm" runat="server" NavigateUrl="~/Form/frmRptSoundFormat.aspx"
                                            ForeColor="#3333CC">- SDT 
                                                                           Box Office by Sound and Film Format</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplCompBoxOfficeBySoundAndFilm" runat="server" NavigateUrl="~/Form/frmRptCompSoundFormat.aspx"
                                            ForeColor="#3333CC">- 
                                                                           Competitor Box Office by Sound and Film Format</asp:HyperLink>
                                    </td>
                                </tr>
                                 <%--
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplSdtCheckerWage" runat="server" NavigateUrl="~/Form/frmRptBoxOfficeAndLateShowParam.aspx"
                                            ForeColor="#3333CC">- SDT Checker wage and Late Show by Theatre</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplSdtCheckerWage2" runat="server" NavigateUrl="~/Form/frmRptBoxOfficeAndLateShowParam2.aspx"
                                            ForeColor="#3333CC">- SDT Checker wage and Late Show by Theatre 2</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Form/frmRptBoxOfficeAndLateShowParam3.aspx"
                                            ForeColor="#3333CC">- SDT Checker wage and Late Show by User</asp:HyperLink>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplSdtCheckerWageNew" runat="server" NavigateUrl="~/Form/frmReportCheckerWageParam.aspx"
                                            ForeColor="#3333CC">- SDT Checker wage and Late Show</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style17" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplBoxOfficeByTitle" runat="server" NavigateUrl="~/Form/frmRptPDABoxOfficeParam.aspx"
                                            ForeColor="#3333CC">- 
                                                                           Box Office by Title</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplTheaterInfo" runat="server" NavigateUrl="~/Form/frmRptTheatreInformationParam.aspx"
                                            ForeColor="#3333CC">- Theatre Information</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplOccupencyReport" runat="server" NavigateUrl="~/Form/frmRptOcpParam.aspx"
                                            ForeColor="#3333CC">- Occupancy Report</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplIndustryInfo" runat="server" NavigateUrl="~/Form/frmRptIndustryInfoParam.aspx"
                                            ForeColor="#3333CC">- Industry Information by Title</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13" style="text-align: left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="hplFreeTicketSummary" runat="server" NavigateUrl="~/Form/frmReportSummaryTicketParam.aspx"
                                            ForeColor="#3333CC">- Free Ticket / Per CAP / Detail of Ticket Type Summary</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#f0cd8c">
                            <%@ register src="../Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="uc1" %>
                            <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                            <%--<center><font color="rosybrown" face="Tahoma" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.--%>
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

