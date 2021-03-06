<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmReportMovieMarketShareParam.aspx.vb"
    Inherits="Form.frmReportMovieMarketShareParam" %>

<%@ Register Src="~/Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="ucctbvCtlTop" %>
<%@ Register Src="~/Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="ucCopyRights" %>
<%@ Register Src="~/Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="ucMovie1Popup" %>
<%@ Register Src="../Controls/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT&nbsp;Management&nbsp;Information&nbsp;System&nbsp;-&nbsp;Free&nbsp;Ticket&nbsp;Summary/&nbsp;Per&nbsp;CAP&nbsp;Summary&nbsp;/&nbsp;Detail&nbsp;of&nbsp;Ticket&nbsp;Type&nbsp;Report
    </title>
    <link href="../Admin.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <script language="javascript" type="text/javascript" src="../js/Utils.js"></script>

    <script language="javascript" type="text/javascript">
        SetOnKeyDownEnter(window.document)
    </script>

</head>
<body class="masterBody">
    <form id="form1" runat="server">
    <table class="headerTable">
        <tr>
            <td style="height: 23px">
                <ucctbvCtlTop:ctbvCtlTop ID="CtbvCtlTop1" runat="server" />
            </td>
            <td align="right">
                <table>
                    <tr>
                        <td align="center">
                            <a href="frmCTBV_Login.aspx">
                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/images/Exit.png" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td class="logout">
                            Log Out
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="menuLevel">
        <tr>
            <td>
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_RC_Menu.aspx">
                    &nbsp;Reports Center</a> &gt; SDT Market Share</b>
            </td>
        </tr>
    </table>
    <div class="mainDiv">
        <table class="mainTable" height="29" bordercolor="#e6b04d" border="1" align="center"
            cellpadding="3" cellspacing="3">
            <tr>
                <td>
                    <div align="center" class="titleDiv">
                        SDT Market Share                     </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="text-align: center;">
                        <table class="normalTable" align="center">
                            <tr class="valueSet">
                                <td align="right">
                                    Movie :&nbsp;&nbsp;
                                </td>
                                <td>
                                    <ucMovie1Popup:Movie1Popup ID="moviePopup" runat="server" InStatus="1,2,3" AppearOnStatus="1,2,3"
                                        VisibleMovieType="False" />
                                </td>
                            </tr>

                            <tr class="valueSet">
                                <td align="right">
                                                                        Start Date :&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <uc1:DatePicker ID="dtpStartDate" runat="server"></uc1:DatePicker>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td align="right">
                                    End Date :&nbsp;&nbsp;
                                </td>
                                <td>
                                    <uc1:DatePicker ID="dtpEndDate" runat="server"></uc1:DatePicker>
                                </td>
                            </tr>
                                                        <tr class="valueSet">
                                <td align="right">
                                    By :&nbsp;&nbsp;
                                </td>
                                <td style="vertical-align: top">
                                        <asp:DropDownList ID="ddlGroup" runat="server" BackColor="#336699" Font-Bold="True"
                                            ForeColor="White">
                                            <asp:ListItem Value="Circuit">Circuit</asp:ListItem>
                                            <asp:ListItem Value="Theater">Theater</asp:ListItem>
                                        </asp:DropDownList>
                                    &nbsp;&nbsp;</td>
                            </tr>
                            <tr class="valueSet">
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/SearchCCC.png"
                                        AlternateText="SEARCH" />
                                    <asp:ImageButton ID="btnCancelMovie" runat="server" ImageUrl="~/images/CancelCCC.png"
                                        AlternateText="CANCEL" Visible="False" />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <ucCopyRights:Copyrights ID="copyRights" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
