<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT.aspx.vb" Inherits="frmCTBV_AT" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System - Admin Tools</title>

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
        .style10
        {
            font-weight: bold;
            font-size: 12px;
            color: #ff0000;
            font-family: "Tahoma";
        }
        .style15
        {
            font-weight: bold;
            font-size: 16px;
            font-family: "Tahoma";
            color: #666666;
        }
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style26
        {
            width: 244px;
        }
        .style27
        {
            width: 144px;
        }
        .style29
        {
            height: 27px;
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
                            <a href="frmCTBV_Login.aspx">
                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/images/Exit.png" />
                            </a>
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
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg"
                class="style16">
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_AT_Main.aspx">
                    Admin Tools</a> &gt; User Setting</b>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <font size="2"><font color="#000000"><font face="Tahoma" size="1"><strong></strong></font>
                </font></font>
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td class="style29">
                            <div align="center" class="style1">
                                User Setting</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="78" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <table width="100%" border="0" cellspacing="0" bgcolor="#DADADA">
                                            <tr bgcolor="#CCCCCC">
                                                <td bordercolor="#DADADA" bgcolor="#DADADA">
                                                    <div align="left">
                                                        &nbsp;&nbsp;&nbsp;<a href="frmCTBV_AT_Add.aspx?userId=0"><img src="../images/NewCCC.png" border="0"></a>&nbsp;
                                                    </div>
                                                </td>
                                                <td width="250px" bordercolor="#E9E9E9" bgcolor="#DADADA" class="style26" valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td width="60px" bordercolor="#E9E9E9" bgcolor="#DADADA" class="style27" valign="bottom">
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <div align="center" class="style15">
                                            <asp:GridView ID="grdAdmin" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" DataSourceID="sqlUser" Font-Names="Tahoma" Font-Size="X-Small"
                                                ForeColor="Silver" GridLines="None" HorizontalAlign="Center" PageSize="20" Width="100%">
                                                <PagerSettings Position="TopAndBottom" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#CCCCCC" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:HyperLinkField DataNavigateUrlFields="user_id" DataNavigateUrlFormatString="frmCTBV_AT_Add.aspx?userId={0}"
                                                        DataTextField="user_id" HeaderText="User I.D." SortExpression="user_id">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:HyperLinkField>
                                                    <asp:BoundField DataField="user_name" HeaderText="Name" SortExpression="user_name">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                <%--                                    <asp:BoundField DataField="user_password" HeaderText="Password" SortExpression="user_password">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>--%>
                                                    <asp:BoundField DataField="usergroup_id" HeaderText="Group" SortExpression="usergroup_id">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="user_status" HeaderText=" Status" SortExpression="user_status">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <PagerStyle BackColor="#CCCCCC" Font-Bold="False" Font-Italic="False" Font-Names="Tahoma"
                                                    Font-Size="Small" ForeColor="#CC6600" HorizontalAlign="Right" BorderColor="#CCCCCC" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
                            <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
    </table>
    <asp:SqlDataSource ID="sqlUser" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT [user_id], [user_name], [user_password], [user_email], [user_tel], [user_errlogincount], [user_errlogindate], [user_logindate], [user_logoutdate], [user_timecount], [usergroup_id], [user_status] FROM [tblUser]">
    </asp:SqlDataSource>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

