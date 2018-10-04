<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_MMD_Movie.aspx.vb"
    Inherits="frmCTBV_MMD_Movie" %>

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
        .style30
        {
            width: 432px;
        }
        .style31
        {
            width: 322px;
        }
        .style32
        {
            width: 122px;
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
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_Menu_MMD.aspx">
                    &nbsp;Manage Master Data</a> &gt; </b><strong>MMD : Movie</strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style2">
                                Manage Master Data : Movie
                            </div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="78" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <table style="font-family: Tahoma; font-size: 10pt; font-weight: bold;" border="0"
                                            cellspacing="0" bgcolor="#DADADA">
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA">
                                                    <div align="center" class="style28">
                                                        <a href="frmCTBV_MMD_Movie_Add.aspx?titleId=0">
                                                            <img src="../images/NewCCC.png" border="0"></a></div>
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style25">
                                                    <div align="center" class="style20">
                                                    </div>
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style31">
                                                </td>
                                                <td bgcolor="#DADADA" align="right" valign="middle">
                                                    Title :
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style26" valign="middle">
                                                    <asp:TextBox ID="txtMovies" runat="server" Width="243px"></asp:TextBox>
                                                </td>
                                                <td bgcolor="#DADADA" align="right" valign="middle">
                                                    Status :
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style27" valign="middle">
                                                    <asp:DropDownList ID="ddlStatus" runat="server">
                                                        <asp:ListItem Value="1" Selected="True">-Showing-</asp:ListItem>
                                                        <asp:ListItem Value="2">-Terminated-</asp:ListItem>
                                                        <asp:ListItem Value="99">-ALL-</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" valign="middle" align="center" class="style32">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="68px" />
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" valign="middle" class="style30">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <div align="center" class="style15">
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" DataKeyNames="movie_id" DataSourceID="sqlMovies" Font-Names="Tahoma"
                                                Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="100%">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundField DataField="movie_id" HeaderText="Title I.D." SortExpression="movie_id"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="movie_code" HeaderText="Title Code" SortExpression="movie_code" />
                                                    <asp:HyperLinkField DataNavigateUrlFields="movie_id" DataNavigateUrlFormatString="frmctbv_mmd_movie_add.aspx?titleId={0}"
                                                        DataTextField="MoviesName" HeaderText="Title" SortExpression="MoviesName" />
                                                    <asp:BoundField DataField="MovieType_Des" HeaderText="Type" SortExpression="MovieType_Des" />
                                                    <asp:BoundField DataField="studio_name" HeaderText="Studio" SortExpression="studio_name" />
                                                    <asp:BoundField DataField="distributor_name" HeaderText="Distributor" SortExpression="distributor_name" />
                                                    <asp:HyperLinkField DataTextField="movie_strdate" DataTextFormatString="{0:ddd dd-MMM-yyyy}"
                                                        HeaderText="Release Date" SortExpression="movie_strdate" />
                                                    <asp:BoundField DataField="NewMovieStatusCode" HeaderText="Status" SortExpression="NewMovieStatusCode" />
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
                            <asp:SqlDataSource ID="sqlMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT tblMovie.movie_id, tblMovie.movie_nameen + '/' + tblMovie.movie_nameth AS MoviesName, 
tblMovie.movie_strdate, tblMovie.movie_status, tblMovieType.MovieType_Des, 
tblMovie.studio_id, tblMovie.movie_code, tblDistributor.distributor_name, 
tblStudio.studio_name, tblMovieStatus.movie_statusCode, tblMovieStatus.movie_statusTitle, 
vMovieStatusCode.NewMovieStatusCode, tblMovie.appear_status_id, vMovieStatusCode.SortBy 
FROM tblMovie LEFT OUTER JOIN vMovieStatusCode ON tblMovie.movie_id = vMovieStatusCode.movie_id 
LEFT OUTER JOIN tblStudio ON tblMovie.studio_id = tblStudio.studio_id 
LEFT OUTER JOIN tblDistributor ON tblMovie.distributor_id = tblDistributor.distributor_id 
LEFT OUTER JOIN tblMovieType ON tblMovie.movietype_id = tblMovieType.MovieType_ID 
LEFT OUTER JOIN tblMovieStatus ON tblMovie.movie_status = tblMovieStatus.movie_statusId 
where vMovieStatusCode.NewMovieStatusCode = 'S'
ORDER BY vMovieStatusCode.SortBy, tblMovie.movie_strdate DESC"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlSearchByTextStatus" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT tblMovie.movie_id, tblMovie.movie_nameen + '/' + tblMovie.movie_nameth AS MoviesName, tblMovie.movie_strdate, tblMovie.movie_status, tblMovieType.MovieType_Des, tblMovie.studio_id, tblMovie.movie_code, tblDistributor.distributor_name, tblStudio.studio_name, tblMovieStatus.movie_statusCode, tblMovieStatus.movie_statusTitle, vMovieStatusCode.NewMovieStatusCode, tblMovie.appear_status_id, vMovieStatusCode.SortBy FROM tblMovie LEFT OUTER JOIN vMovieStatusCode ON tblMovie.movie_id = vMovieStatusCode.movie_id LEFT OUTER JOIN tblStudio ON tblMovie.studio_id = tblStudio.studio_id LEFT OUTER JOIN tblDistributor ON tblMovie.distributor_id = tblDistributor.distributor_id LEFT OUTER JOIN tblMovieType ON tblMovie.movietype_id = tblMovieType.MovieType_ID LEFT OUTER JOIN tblMovieStatus ON tblMovie.movie_status = tblMovieStatus.movie_statusId WHERE ((tblMovie.movie_nameen LIKE '%' + @MovieName + '%') OR (tblMovie.movie_nameth LIKE '%' + @MovieName + '%')) AND (tblMovie.movie_status = @statusId) ORDER BY  vMovieStatusCode.SortBy, tblMovie.movie_strdate DESC">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtMovies" Name="MovieName" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlStatus" Name="statusId" PropertyName="SelectedValue">
                                    </asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlSearchByText" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT tblMovie.movie_id, tblMovie.movie_nameen + '/' + tblMovie.movie_nameth AS MoviesName, tblMovie.movie_strdate, tblMovie.movie_status, tblMovieType.MovieType_Des, tblMovie.studio_id, tblMovie.movie_code, tblDistributor.distributor_name, tblStudio.studio_name, tblMovieStatus.movie_statusCode, tblMovieStatus.movie_statusTitle, vMovieStatusCode.NewMovieStatusCode, tblMovie.appear_status_id, vMovieStatusCode.SortBy FROM tblMovie LEFT OUTER JOIN vMovieStatusCode ON tblMovie.movie_id = vMovieStatusCode.movie_id LEFT OUTER JOIN tblStudio ON tblMovie.studio_id = tblStudio.studio_id LEFT OUTER JOIN tblDistributor ON tblMovie.distributor_id = tblDistributor.distributor_id LEFT OUTER JOIN tblMovieType ON tblMovie.movietype_id = tblMovieType.MovieType_ID LEFT OUTER JOIN tblMovieStatus ON tblMovie.movie_status = tblMovieStatus.movie_statusId WHERE ((tblMovie.movie_nameen LIKE '%' + @MovieName + '%') OR (tblMovie.movie_nameth LIKE '%' + @MovieName + '%')) ORDER BY  vMovieStatusCode.SortBy, tblMovie.movie_strdate DESC">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtMovies" Name="MovieName" PropertyName="Text">
                                    </asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlSearchByStatus" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT tblMovie.movie_id, tblMovie.movie_nameen + '/' + tblMovie.movie_nameth AS MoviesName, tblMovie.movie_strdate, tblMovie.movie_status, tblMovieType.MovieType_Des, tblMovie.studio_id, tblMovie.movie_code, tblDistributor.distributor_name, tblStudio.studio_name, tblMovieStatus.movie_statusCode, tblMovieStatus.movie_statusTitle, vMovieStatusCode.NewMovieStatusCode, tblMovie.appear_status_id, vMovieStatusCode.SortBy FROM tblMovie LEFT OUTER JOIN vMovieStatusCode ON tblMovie.movie_id = vMovieStatusCode.movie_id LEFT OUTER JOIN tblStudio ON tblMovie.studio_id = tblStudio.studio_id LEFT OUTER JOIN tblDistributor ON tblMovie.distributor_id = tblDistributor.distributor_id LEFT OUTER JOIN tblMovieType ON tblMovie.movietype_id = tblMovieType.MovieType_ID LEFT OUTER JOIN tblMovieStatus ON tblMovie.movie_status = tblMovieStatus.movie_statusId WHERE (tblMovie.movie_status = @statusId) ORDER BY  vMovieStatusCode.SortBy, tblMovie.movie_strdate DESC">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlStatus" Name="StatusId" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sqlMoviesAll" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="SELECT tblMovie.movie_id, tblMovie.movie_nameen + '/' + tblMovie.movie_nameth AS MoviesName, 
tblMovie.movie_strdate, tblMovie.movie_status, tblMovieType.MovieType_Des, 
tblMovie.studio_id, tblMovie.movie_code, tblDistributor.distributor_name, 
tblStudio.studio_name, tblMovieStatus.movie_statusCode, tblMovieStatus.movie_statusTitle, 
vMovieStatusCode.NewMovieStatusCode, tblMovie.appear_status_id, vMovieStatusCode.SortBy 
FROM tblMovie LEFT OUTER JOIN vMovieStatusCode ON tblMovie.movie_id = vMovieStatusCode.movie_id 
LEFT OUTER JOIN tblStudio ON tblMovie.studio_id = tblStudio.studio_id 
LEFT OUTER JOIN tblDistributor ON tblMovie.distributor_id = tblDistributor.distributor_id 
LEFT OUTER JOIN tblMovieType ON tblMovie.movietype_id = tblMovieType.MovieType_ID 
LEFT OUTER JOIN tblMovieStatus ON tblMovie.movie_status = tblMovieStatus.movie_statusId 
ORDER BY vMovieStatusCode.SortBy, tblMovie.movie_strdate DESC">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlStatus" Name="StatusId" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
                            <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

