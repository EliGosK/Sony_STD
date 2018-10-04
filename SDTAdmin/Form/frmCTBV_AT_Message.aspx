<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_Message.aspx.vb"
    Inherits="frmCTBV_AT_Message" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System - Manage Master Data Movie</title>

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
        .style20
        {
            font-size: 14px;
            font-family: "Tahoma";
        }
        .style25
        {
            width: 5%;
        }
        .style28
        {
            font-weight: normal;
        }
        .style29
        {
            width: 807px;
        }
        .style30
        {
            width: 273px;
            text-align: right;
            vertical-align: top;
        }
        .style32
        {
            width: 273px;
            text-align: right;
            height: 28px;
        }
        .style35
        {
            height: 33px;
        }
        .style36
        {
            width: 273px;
            text-align: right;
            vertical-align: top;
            height: 33px;
        }
        .style37
        {
            width: 807px;
            height: 33px;
        }
        .style38
        {
            width: 5%;
            height: 33px;
        }
        .style39
        {
            height: 291px;
        }
        .style40
        {
            height: 28px;
        }
        .style41
        {
            width: 807px;
            height: 28px;
        }
        .style42
        {
            width: 5%;
            height: 28px;
        }
        .style43
        {
            height: 19px;
        }
        .style44
        {
            width: 273px;
            text-align: right;
            height: 19px;
        }
        .style45
        {
            width: 807px;
            height: 19px;
        }
        .style46
        {
            width: 5%;
            height: 19px;
        }
        .style47
        {
            height: 17px;
        }
        .style48
        {
            width: 273px;
            text-align: right;
            height: 17px;
        }
        .style49
        {
            width: 807px;
            height: 17px;
        }
        .style50
        {
            width: 5%;
            height: 17px;
        }
    </style>

    <script language="JavaScript" type="text/JavaScript">
<!--



function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
//-->
    </script>

    <meta http-equiv="Content-Type" content="text/html; charset=windows-874">
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
                                &nbsp;Admin Tools</a> &gt; </b><strong>Message To Checker</strong>
                        </td>
                    </tr>
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style2">
                                Message To Checker</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="78" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c" class="style39">
                                        <table width="100%" border="0" cellspacing="0" bgcolor="#DADADA" style="font-family: Tahoma;
                                            font-size: 10pt; color: #0000FF;">
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA">
                                                    <div align="center" class="style28">
                                                        <asp:ImageButton ID="btnNewMsg" runat="server" ImageUrl="~/images/NewCCC.png" AlternateText="New Message" />
                                                    </div>
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style30">
                                                    <div align="center" class="style20">
                                                    </div>
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style29">
                                                    &nbsp;
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style25">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA" class="style35">
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style36">
                                                    Send Date :
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style37" valign="top">
                                                    <asp:TextBox ID="txtTime" runat="server" Width="265px" ReadOnly="True"></asp:TextBox>
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style38">
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style30">
                                                    Message :
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style29">
                                                    <asp:TextBox ID="txtQue" runat="server" Height="195px" TextMode="MultiLine" Width="480px"
                                                        ReadOnly="True"></asp:TextBox>
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style25">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA" class="style43">
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style44">
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style45" style="color: #FF0000">
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style46">
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA" class="style40">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style32">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style41" style="color: #FF0000">
                                                    <asp:Table ID="tbl" runat="server" CellPadding="6" CellSpacing="0" BackColor="LightGoldenrodYellow"
                                                        Font-Names="Arial" Font-Size="8pt" ForeColor="Black" GridLines="Both" Border="1"
                                                        BorderColor="Orange" Width="600px">
                                                        <asp:TableRow runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="8pt"
                                                            HorizontalAlign="Center" BackColor="Snow">
                                                            <asp:TableCell runat="server" RowSpan="2">Circuit</asp:TableCell>
                                                            <asp:TableCell runat="server" ColumnSpan="2">Answer 1</asp:TableCell>
                                                            <asp:TableCell runat="server" ColumnSpan="2">Answer 2</asp:TableCell>
                                                            <asp:TableCell runat="server" ColumnSpan="2">Answer 3</asp:TableCell>
                                                            <asp:TableCell runat="server" ColumnSpan="2">Answer 4</asp:TableCell>
                                                            <asp:TableCell runat="server" ColumnSpan="2">Answer 5</asp:TableCell>
                                                            <asp:TableCell runat="server" ColumnSpan="2">SUM TOTAL</asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="8pt"
                                                            HorizontalAlign="Center" BackColor="Snow">
                                                            <asp:TableCell runat="server">(Total)</asp:TableCell>
                                                            <asp:TableCell runat="server">(%)</asp:TableCell>
                                                            <asp:TableCell runat="server">(Total)</asp:TableCell>
                                                            <asp:TableCell runat="server">(%)</asp:TableCell>
                                                            <asp:TableCell runat="server">(Total)</asp:TableCell>
                                                            <asp:TableCell runat="server">(%)</asp:TableCell>
                                                            <asp:TableCell runat="server">(Total)</asp:TableCell>
                                                            <asp:TableCell runat="server">(%)</asp:TableCell>
                                                            <asp:TableCell runat="server">(Total)</asp:TableCell>
                                                            <asp:TableCell runat="server">(%)</asp:TableCell>
                                                            <asp:TableCell runat="server">(Total)</asp:TableCell>
                                                            <asp:TableCell runat="server">(%)</asp:TableCell>
                                                        </asp:TableRow>
                                                    </asp:Table>
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style42">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA" class="style47">
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style48">
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style49" style="color: #FF0000">
                                                    <asp:HiddenField ID="hidPage" runat="server" />
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style50">
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA" class="style40">
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style32">
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style41" style="color: #FF0000">
                                                    &nbsp;
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style42">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <div align="center" class="style15">
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" DataSourceID="sqlMsg" Font-Names="Tahoma" Font-Size="X-Small"
                                                ForeColor="#333333" GridLines="None" Width="100%" EnableSortingAndPagingCallbacks="True"
                                                PageSize="20" ShowFooter="True">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundField DataField="circuit_name" HeaderText="Circuit" SortExpression="circuit_name"
                                                        ItemStyle-Width="15%">
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="theater_name" HeaderText="Theatre" SortExpression="theater_name"
                                                        ItemStyle-Width="20%">
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="user_name" HeaderText="Checker" SortExpression="user_name"
                                                        ItemStyle-Width="15%">
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="answer_no" HeaderText="Answer" SortExpression="answer_no"
                                                        ItemStyle-Width="10%">
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="answer_desc" HeaderText="Detail" SortExpression="answer_desc"
                                                        ItemStyle-Width="20%">
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:HyperLinkField DataTextField="last_update_dtm" DataTextFormatString="{0:ddd dd-MMM-yyyy a\t h:mm tt}"
                                                        HeaderText="Time of reply" SortExpression="last_update_dtm" ItemStyle-Width="20%">
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:HyperLinkField>
                                                </Columns>
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
                            <ucCopyRights:Copyrights id="copyRights" runat="server" />
                            <asp:SqlDataSource ID="sqlMsg" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT question_no, theater_id, theater_name, answer_desc, create_dtm, create_by, last_update_dtm, last_update_by, answer_no, circuit_id, circuit_name, user_name, question_desc, QuestionCreate_dtm, question_descShow, read_flag, CASE circuit_id WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 WHEN 4 THEN 4 ELSE 5 END AS sortCiecuit FROM vMessage WHERE (question_no = 1) ORDER BY sortCiecuit, theater_name ">
                            </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

