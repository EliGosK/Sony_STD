<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_LateShow.aspx.vb"
    Inherits=".frmCTBV_AT_LateShow" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Information System - Late Show Config</title>

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
        .style10
        {
            font-weight: bold;
            font-size: 12px;
            color: #ff0000;
            font-family: "Tahoma";
        }
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style2
        {
            font-weight: bold;
            font-size: 14px;
            color: #999999;
            font-family: "Tahoma";
        }
        .styleForm
        {
            vertical-align: top;
        }
        .styleTD1
        {
            vertical-align: top;
            text-align: right;
            font-family: Tahoma;
            font-size: 10pt;
            color: #0000FF;
        }
        .styleTD2
        {
            vertical-align: top;
            text-align: right;
            font-family: Tahoma;
            font-size: 10pt;
            color: #0000FF;
        }
        .styleTD3
        {
            width: 55%;
            vertical-align: top;
            text-align: left;
            font-family: Tahoma;
            font-size: 10pt;
            color: #0000FF;
        }
    </style>
</head>
<body ms_positioning="GridLayout" leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
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
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg" class="style16">
                            &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_AT_Main.aspx">
                                &nbsp;Admin Tools</a>&nbsp;&gt;<a href="frmCTBV_AT_LavelAndWage.aspx"> &nbsp;Checker
                                    Level and Wage</a> &gt;&nbsp;Late Show Config</b>
                        </td>
                    </tr>
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style2">
                                Late Show Config</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c" class="styleForm">
                                        <table width="100%" border="0" cellspacing="0" bordercolor="#E9E9E9" bgcolor="#DADADA">
                                            <tr>
                                                <td class="styleTD1">
                                                </td>
                                                <td class="styleTD2">
                                                </td>
                                                <td align="right">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="styleTD1">
                                                    &nbsp;
                                                </td>
                                                <td class="styleTD2">
                                                    Late Show From :
                                                </td>
                                                <td class="styleTD3">
                                                    <asp:TextBox ID="txtTimeFrom" runat="server" onblur="ValidTime()" Width="150px"></asp:TextBox>
                                                    <asp:Label ID="lblFormatTime" runat="server" ForeColor="#FF6666">* Format hh:mm 
                                                    Ex. 23:00</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="styleTD1">
                                                    &nbsp;
                                                </td>
                                                <td class="styleTD2">
                                                    Late Show To :
                                                </td>
                                                <td class="styleTD3">
                                                    <asp:TextBox ID="txtTimeTo" runat="server" onblur="ValidTime()" Width="150px"></asp:TextBox>
                                                    <asp:Label ID="lblFormatTime0" runat="server" ForeColor="#FF6666">* Format hh:mm 
                                                    Ex. 23:59</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="styleTD1">
                                                    &nbsp;
                                                </td>
                                                <td class="styleTD2">
                                                    Expense :
                                                </td>
                                                <td class="styleTD3">
                                                    <asp:TextBox ID="txtExpense" runat="server" onblur="ValidNum(2)" Width="150px"></asp:TextBox>
                                                    <asp:Label ID="lblFormatTime1" runat="server" ForeColor="#FF9999">*</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="styleTD1">
                                                    &nbsp;
                                                </td>
                                                <td align="center" colspan="2">
                                                    <asp:Label ID="lblError" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red"></asp:Label>
                                                    &nbsp; &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="styleTD1">
                                                    &nbsp;
                                                </td>
                                                <td class="styleTD2">
                                                    &nbsp;
                                                </td>
                                                <td class="styleTD3">
                                                    &nbsp;<asp:ImageButton ID="imbSaveClose" runat="server" ImageUrl="~/images/SaveCCC.png"
                                                        AlternateText="SAVE" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imbCancel" runat="server" ImageUrl="~/images/CancelCCC.png"
                                                        AlternateText="CANCEL" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/DeleteCCC.png"
                                                        AlternateText="DELETE" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CellPadding="4" DataKeyNames="show_seq_no" DataSourceID="sqlMovieLateShow" Font-Names="Tahoma"
                                                        Font-Size="10pt" ForeColor="#333333" GridLines="None" Width="600px">
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <Columns>
                                                            <asp:CommandField ShowSelectButton="True" SelectText="Select" ItemStyle-ForeColor="#FF6600" />
                                                            <asp:BoundField DataField="RowCountNow" HeaderText="Seq No." SortExpression="RowCountNow"
                                                                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="show_time_from" HeaderText="Late Show From" SortExpression="show_time_from"
                                                                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="show_time_to" HeaderText="Late Show To" SortExpression="show_time_to"
                                                                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="expense_amt" HeaderText="Expense" SortExpression="expense_amt"
                                                                HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    </asp:GridView>
                                                    <asp:SqlDataSource ID="sqlMovieLateShow" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                                        SelectCommand="SELECT RowCountNow, show_seq_no, substring(show_time_from,1,2) + ':' + substring(show_time_from,3,2) AS show_time_from, substring(show_time_to,1,2) + ':' + substring(show_time_to,3,2) AS show_time_to, expense_amt, create_dtm, create_by, last_update_dtm, last_update_by FROM (SELECT ROW_NUMBER() OVER (ORDER BY show_time_from ASC) AS RowCountNow, * FROM tblMovie_Late_Show) AS Reg ORDER BY show_time_from ASC">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="styleTD2">
                                                    &nbsp;
                                                </td>
                                                <td class="styleTD3">
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

