<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_PresentAdd.aspx.vb"
    Inherits=".frmCTBV_AT_PresentAdd" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System - Manage Master Distributor</title>

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
        .txtRight
        {
            text-align: right;
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
            width: 15%;
        }
        .style26
        {
            width: 270px;
        }
        .style27
        {
            width: 79px;
        }
        .style29
        {
            width: 807px;
        }
        .style31
        {
            font-size: 10px;
        }
        .style42
        {
            font-size: 14;
            font-family: "Tahoma";
            height: 6px;
        }
        .style42
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 26px;
        }
        .style46
        {
            font-size: 14;
            font-family: "Tahoma";
            height: 6px;
            font-weight: bold;
        }
        .style50
        {
            width: 59px;
        }
        .style51
        {
            height: 17px;
        }
        .style52
        {
            font-size: 14px;
            font-family: "Tahoma";
            font-weight: 700;
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
        <tr background="../images/BG7.jpg">
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg"
                class="style16">
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_AT_Main.aspx">
                    &nbsp;Admin Tools </a>&nbsp;&gt;<a href="frmCTBV_AT_LavelAndWage.aspx"> &nbsp;Checker Level 
                and Wage </a>&gt;&nbsp;<a href="frmCTBV_AT_Present.aspx"> &nbsp;Present Wage Details
                        </a>&gt;&nbsp;Present Wage</b>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                <span class="style2">Present Wage</span>
                            </div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <div align="center" class="style15">
                                            <table id="tblData" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style21">
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Present Level :</div>
                                                    </td>
                                                    <td>
                                                        <span class="style31">
                                                            <asp:DropDownList ID="ddlPresent" runat="server" DataSourceID="sqlPresent0" DataTextField="checker_level_name"
                                                                DataValueField="checker_level_id">
                                                            </asp:DropDownList>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Screen :</div>
                                                    </td>
                                                    <td>
                                                        <span class="style31">
                                                            <asp:DropDownList ID="ddlScreen" runat="server" Width="65px">
                                                                <asp:ListItem Value="1"></asp:ListItem>
                                                                <asp:ListItem Value="2"></asp:ListItem>
                                                                <asp:ListItem Value="3"></asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
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
                                                                <asp:ListItem Value="16"></asp:ListItem>
                                                                <asp:ListItem Value="17"></asp:ListItem>
                                                                <asp:ListItem Value="18"></asp:ListItem>
                                                                <asp:ListItem Value="19"></asp:ListItem>
                                                                <asp:ListItem Value="20"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Present Wage :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <asp:TextBox ID="txtName" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9900"
                                                            onblur="ValidNum()" CssClass="txtRight" Width="120px"></asp:TextBox>
                                                        &nbsp;Baht
                                                    </td>
                                                </tr>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0" class="style42">
                                    <td width="47%" align="right" class="style51">
                                    </td>
                                    <td width="53%" class="style52">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="47%" align="right" class="style20">
                                        &nbsp;
                                    </td>
                                    <td width="53%" class="style20">
                                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                                            Visible="False">Please check require flield (*)</asp:Label>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td colspan="2">
                                        <table border="0" align="center" cellpadding="0" cellspacing="0" style="height: 31px;
                                            width: 120px">
                                            <tr>
                                                <td class="style50">
                                                    <div align="center">
                                                        <asp:ImageButton ID="imbSaveClose" runat="server" ImageUrl="~/images/SaveCCC.png"
                                                            AlternateText="SAVE" />
                                                    </div>
                                                </td>
                                                <td width="66" align="right">
                                                    <asp:ImageButton ID="imbCancel" runat="server" ImageUrl="~/images/backCCC.png" AlternateText="BACK" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="78" align="center" bgcolor="#E2E2E2">
                            <table id="tblGrid" runat="server" width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <table border="0" cellspacing="0" bgcolor="#DADADA">
                                            <tr bgcolor="#CCCCCC">
                                                <td width="2%" bordercolor="#DADADA" bgcolor="#DADADA">
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style25">
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style29">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style26" valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style27" valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style25">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E2E2E2">
                                        <div align="center" class="style15">
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" DataKeyNames="checker_level_id" DataSourceID="sqlPresent" Font-Names="Tahoma"
                                                Font-Size="9pt" ForeColor="#333333" GridLines="None" Width="600px">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <%--<asp:HyperLinkField DataNavigateUrlFields="checker_level_id,screen_id" DataNavigateUrlFormatString="frmCTBV_AT_PresentAdd.aspx?levelid={0}&screenid={1}"
                                                        Text="Select" />--%>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnSelect" runat="server" CausesValidation="False" CommandName="Select"
                                                                Text="Select" CommandArgument='<%# Bind("Present_Wage_id") %>' ForeColor="#FF6600"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="checker_level_name" HeaderText="Present Level" SortExpression="checker_level_name"
                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="screen_id" HeaderText="Screen" SortExpression="screen_id"
                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="wage_amt" HeaderText="Present Wage" SortExpression="wage_amt"
                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Del"
                                                                Text="Delete" OnClientClick="return confirm('Do you want to delete this data?')"
                                                                CommandArgument='<%# Bind("Present_Wage_id") %>' ForeColor="#FF6600"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                            <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
                            <ucCopyRights:Copyrights id="copyRights" runat="server" />
                            <asp:SqlDataSource ID="sqlPresent" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT cp.checker_level_id, cl.checker_level_name, cp.screen_id, cp.wage_amt, 
                                cp.create_dtm, cp.create_by, cp.last_update_dtm, cp.last_update_by,
                                cl.present_level_flag, convert(varchar(20), cp.checker_level_id) + 'A' + convert(varchar(20),cp.screen_id) as Present_Wage_id
                                FROM tblChecker_Present_Wage cp
                                Left join tblChecker_Level cl
                                ON cp.checker_level_id = cl.checker_level_id
                                WHERE cl.present_level_flag = 'Y' "></asp:SqlDataSource>
                            <asp:SqlDataSource ID="sqlPresent0" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT checker_level_id, checker_level_name from tblChecker_Level
where present_level_flag = 'Y'"></asp:SqlDataSource>
    </form>
    </table>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

