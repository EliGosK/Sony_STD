<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_MMD_Theater.aspx.vb"
    Inherits="frmCTBV_MMD_Theater" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System -Manage Master Data Theatre</title>

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
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style17
        {
            font-family: "Tahoma";
        }
        .style18
        {
            font-size: 14px;
            font-weight: bold;
        }
        .style20
        {
            font-size: 14px;
            font-family: "Tahoma";
        }
        .style24
        {
            font-size: 14px;
        }
        .style25
        {
            width: 6%;
        }
        .style26
        {
            width: 5%;
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
            <td height="29" colspan="2" bordercolor="honeydew" background="" class="style16">
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_Menu_MMD.aspx">
                    &nbsp;Manage Master Data</a> &gt; </b><strong>MMD : Theatre </strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td>
                            <div align="center">
                                <span class="style2">Manage Master Data : Theatre </span>
                            </div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td valign="top" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c" valign="top">
                                        <table width="100%" valign="top" border="0" cellspacing="0" bgcolor="#DADADA">
                                            <tr bgcolor="#CCCCCC">
                                                <td bgcolor="#DADADA" class="style25">
                                                    <div align="center">
                                                        <a href="frmCTBV_MMD_Theater_Add.aspx">
                                                            <img src="../images/NewCCC.png" border="0"></a>
                                                    </div>
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style26">
                                                    <div align="center" class="style20">
                                                        <p>
                                                            <br>
                                                        </p>
                                                    </div>
                                                </td>
                                                <td width="24%" bordercolor="#E9E9E9" bgcolor="#DADADA">
                                                    &nbsp;
                                                </td>
                                                <td width="24%" bordercolor="#E9E9E9" bgcolor="#DADADA">
                                                    &nbsp;
                                                </td>
                                                <td width="29%" bordercolor="#E9E9E9" bgcolor="#DADADA">
                                                    &nbsp;
                                                </td>
                                                <td width="5%" bordercolor="#E9E9E9" bgcolor="#DADADA">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f0cd8c">
                            <div align="center" class="style1">
                                <asp:GridView ID="grdTheater" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataKeyNames="theater_id" DataSourceID="sqlTheater" Font-Names="Tahoma"
                                    Font-Size="X-Small" ForeColor="Silver" GridLines="None" HorizontalAlign="Center"
                                    PageSize="20" Width="100%">
                                    <PagerSettings Position="TopAndBottom" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#CCCCCC" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="theater_code" HeaderText="Theatre Code" SortExpression="theater_code">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataNavigateUrlFields="theater_id" DataNavigateUrlFormatString="frmctbv_mmd_theater_edit.aspx?theaterId={0}"
                                            DataTextField="theater_name" HeaderText="Theatre" SortExpression="theater_name">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="group_type" HeaderText="Group Type" SortExpression="group_type">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TheaterNo" HeaderText="Total Screen" SortExpression="TheaterNo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataTextField="nomalseat" DataTextFormatString="{0:#,##0}" HeaderText="Capacity">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="theater_status" HeaderText="Status" SortExpression="theater_status">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="theater_des" HeaderText="Comment" SortExpression="theater_des" />
                                        <asp:BoundField DataField="circuit_name" HeaderText="Circuit" SortExpression="circuit_name" />
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
                <asp:SqlDataSource ID="sqlTheater" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                    SelectCommand="SELECT DISTINCT tblTheater.theater_id
	, tblTheater.theater_code
	, tblTheater.theater_name
	, tblTheater.group_type
	, tblTheater.theater_status
	, ISNULL(tblTheater.theater_des, '') AS theater_des
	, tblCircuit.circuit_name
	, tblCircuit.circuit_id
	, ISNULL(Tsub.status_flag, '') AS TSubStatus_flag
	, ISNULL(Tsub.TheaterNo, 0) AS TheaterNo
	, ISNULL(Tsub.nomalseat, 0) AS nomalseat
	, ISNULL(Tsub.vipseat, 0) AS vipseat
FROM tblTheater
RIGHT OUTER JOIN tblCircuit
	ON tblTheater.circuit_id = tblCircuit.circuit_id
LEFT OUTER JOIN (
	SELECT DISTINCT theater_id
		, COUNT(theatersub_id) AS TheaterNo
		, SUM(theatersub_normalseat) AS nomalseat
		, SUM(theatersub_vipseat) AS vipseat
		, status_flag
	FROM tblTheaterSub AS tblTheaterSub
	WHERE (status_flag = 'Y')
	GROUP BY theater_id
		, status_flag
	) AS Tsub
	ON tblTheater.theater_id = Tsub.theater_id
GROUP BY tblTheater.theater_id
	, tblTheater.theater_code
	, tblTheater.theater_name
	, tblTheater.group_type	
	, tblTheater.theater_status
	, tblTheater.theater_des
	, tblCircuit.circuit_name
	, tblCircuit.circuit_id
	, Tsub.status_flag
	, Tsub.TheaterNo
	, Tsub.nomalseat
	, Tsub.vipseat
ORDER BY tblCircuit.circuit_id
	, tblTheater.theater_status DESC
	, tblTheater.theater_name"></asp:SqlDataSource>
                <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
                <ucCopyRights:Copyrights ID="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

