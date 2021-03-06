<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_Menu_Trailer_Rpt.aspx.vb"
    Inherits=".frmCTBV_Menu_Trailer_Rpt" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Trailer_Header_SetupPopup.ascx" TagName="Trailer_Header_SetupPopup"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Information System - Trailer Reports Menu</title>

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
        .style1
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
        }
        .Smenu
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style18
        {
            height: 25px;
            font-weight: bold;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0" ms_positioning="GridLayout"
    style="font-family: Tahoma;">
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
        <tr background="../images/BG7.jpg" class="Smenu">
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg"
                class="Smenu">
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&nbsp;&gt; </b><b><a href="frmCTBV_Menu_Trailer.aspx">
                    Trailer Menu </a>&nbsp;&gt; </b><strong>Trailer Reports</strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f0cd8c"
                    style="height: 154px">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                Trailer Reports</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 413px">
                                <tr>
                                    <td bordercolor="#f0cd8c" style="text-align: left; font-family: Tahoma; font-weight: bold;
                                        font-size: 14px;" bgcolor="#CCCCCC" class="style18">
                                        Report List
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" class="style18">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Form/frmRptTrailerByLocationParam.aspx"
                                            ForeColor="#3333CC">- Trailer List by Location</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="style18">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Form/frmRptTrailerByCircuitParam.aspx"
                                            ForeColor="#3333CC">- Trailer List by Circuit</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" class="style18">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Form/frmRptTrailerByTotalParam.aspx"
                                            ForeColor="#3333CC">- Trailer List by Title</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" class="style18">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Form/frmRptTrailerByPercentParam.aspx"
                                            ForeColor="#3333CC">- Trailer List by Percentage</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" class="style18">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Form/frmRptTrailerExeByWeekParam.aspx"
                                            ForeColor="#3333CC">- Trailer Execution by Week</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" class="style18">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Form/frmRptTrailerByReleaseParam.aspx"
                                            ForeColor="#3333CC">- 
                                                Trailer List by Release</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" class="style18">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Form/frmRptTrailerViewershipParam.aspx"
                                            ForeColor="#3333CC">- 
                                                Trailer Viewership by Title</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" class="style18">
                                        &nbsp;
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
    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

