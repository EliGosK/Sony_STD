<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_MessageNew.aspx.vb"
    Inherits=".frmCTBV_AT_MessageNew" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SDT Management Information System - New Message</title>

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
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style28
        {
            font-weight: normal;
        }
        .style32
        {
            width: 198px;
            text-align: right;
            height: 28px;
        }
        .style39
        {
            height: 291px;
        }
        .style40
        {
            height: 28px;
        }
        .style45
        {
            width: 7%;
            height: 18px;
        }
        .style47
        {
            height: 28px;
            width: 7%;
        }
        .style48
        {
            width: 198px;
        }
        .style49
        {
            height: 42px;
            width: 7%;
        }
        .style50
        {
            width: 198px;
            text-align: right;
            height: 42px;
        }
        .style51
        {
            height: 42px;
        }
        .style52
        {
            width: 198px;
            height: 18px;
        }
        .style53
        {
            height: 18px;
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
                                &nbsp;Admin Tools</a> &gt; <a href="frmCTBV_AT_Message.aspx">&nbsp;Message To Checker</a>
                                &gt; </b><strong>Create Message To Checker</strong>
                        </td>
                    </tr>
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style2">
                                Create Message To Checker</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c" class="style39">
                                        <table width="100%" border="0" cellspacing="0" bgcolor="#DADADA" style="font-family: Tahoma;
                                            font-size: 10pt; color: #0000FF;" align="left">
                                            <tr bgcolor="#CCCCCC">
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style45">
                                                    <div align="center" class="style28">
                                                    </div>
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style52">
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style53">
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC" align="right">
                                                <td bordercolor="#DADADA" bgcolor="#DADADA">
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style48">
                                                    Send Date :
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" valign="top" align="left">
                                                    <asp:TextBox ID="txtTime" runat="server" Width="265px" ReadOnly="True"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td bordercolor="#DADADA" bgcolor="#DADADA">
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" valign="top" align="right" class="style48">
                                                    Message :
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" align="left">
                                                    <asp:TextBox ID="txtQue" runat="server" Height="195px" TextMode="MultiLine" Width="480px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style47">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style32" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" align="left">
                                                    <asp:CheckBox ID="chkCheckAll" AutoPostBack="true" runat="server" ForeColor="Black"
                                                        Text="Send All Theater" />
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style47">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style32" valign="top">
                                                    Sent To :
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" align="left">
                                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CellPadding="4" DataSourceID="SqlChecker" Font-Names="Tahoma" Font-Size="9pt"
                                                        ForeColor="#333333" GridLines="None" Width="470px">
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox runat="server" ID="RowIDCheckBox" AutoPostBack="true" /><asp:Label
                                                                        runat="server" ID="lblTheaterId" Text='<%#DataBinder.Eval(Container.DataItem, "theater_id")%>'
                                                                        Visible="False" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="theater_id" HeaderText="ID" SortExpression="theater_id"
                                                                ItemStyle-Width="50px" />
                                                            <asp:BoundField DataField="theater_name" HeaderText="Theatre" SortExpression="theater_name"
                                                                FooterStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField DataField="circuit_name" HeaderText="Circuit" SortExpression="circuit_name" />
                                                        </Columns>
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                        <EditRowStyle BackColor="#999999" />
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style49">
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style50">
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" align="left" class="style51" valign="bottom">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnSend" runat="server" Text="Send" ForeColor="#0033CC" Width="63px" />
                                                </td>
                                            </tr>
                                            <tr bgcolor="#CCCCCC">
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" colspan="3" class="style40">
                                                    <asp:SqlDataSource ID="SqlCircuit" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                                        SelectCommand="SELECT circuit_id, circuit_name FROM tblCircuit"></asp:SqlDataSource>
                                                    <asp:SqlDataSource ID="SqlChecker" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                                        SelectCommand="SELECT tblTheater.theater_id, tblTheater.theater_code, tblTheater.theater_name, tblTheater.circuit_id, tblCircuit.circuit_name, CASE tblTheater.circuit_id WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 WHEN 4 THEN 4 ELSE 5 END AS sortCiecuit, tblTheater.theater_status FROM tblTheater LEFT OUTER JOIN tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id WHERE (tblTheater.theater_status = 'Enabled') ORDER BY sortCiecuit, tblTheater.theater_name">
                                                    </asp:SqlDataSource>
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
