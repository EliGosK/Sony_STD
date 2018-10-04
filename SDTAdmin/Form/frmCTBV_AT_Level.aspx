<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_Level.aspx.vb"
    Inherits=".frmCTBV_AT_Level" %>

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
            width: 5%;
        }
        .style26
        {
            width: 270px;
        }
        .style27
        {
            width: 79px;
        }
        .style28
        {
            font-weight: normal;
        }
        .style29
        {
            width: 807px;
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
                    &nbsp;Admin Tools</a>&nbsp;&gt;<a href="frmCTBV_AT_LavelAndWage.aspx"> &nbsp;Checker Level and 
                Wage</a> &gt;&nbsp;Checker Level Detail</b>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="stChecker Level Detail</span>
                            yle1">
                                <span class="style2">
                            </div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="78" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <table border="0" cellspacing="0" bgcolor="#DADADA">
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA">
                                                    <div align="center" class="style28">
                                                        <a href="frmCTBV_AT_LevelAdd.aspx?levelid=0">
                                                            <img src="../images/NewCCC.png" border="0"></a></div>
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style25">
                                                    <div align="center" class="style20">
                                                    </div>
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
                                                CellPadding="4" DataKeyNames="checker_level_id" DataSourceID="sqlDist" Font-Names="Tahoma"
                                                Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="600px">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundField DataField="checker_level_id" HeaderText="Level I.D." SortExpression="checker_level_id"
                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:HyperLinkField DataNavigateUrlFields="checker_level_id" DataNavigateUrlFormatString="frmCTBV_AT_LevelAdd.aspx?levelid={0}"
                                                        DataTextField="checker_level_name" HeaderText="Level Name" SortExpression="checker_level_name" />
                                                    <asp:BoundField DataField="present_level_flag" HeaderText="Present Level" SortExpression="present_level_flag"
                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="former_level_flag" HeaderText="Former Level" SortExpression="former_level_flag"
                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
                            <asp:SqlDataSource ID="sqlDist" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT checker_level_id, checker_level_name, 
                                CASE present_level_flag WHEN 'Y' THEN 'Yes'
                                ELSE 'No' END as present_level_flag, 
                                CASE former_level_flag WHEN 'Y' THEN 'Yes'
                                ELSE 'No' END as former_level_flag, 
                                create_dtm, create_by, last_update_dtm, last_update_by FROM tblChecker_Level">
                            </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

