<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevByTheaterComp.aspx.vb" Inherits=".frmRevByTheaterComp" %>

<%@ Register src="../Controls/ctbvCtlTop.ascx" tagname="ctbvCtlTop" tagprefix="uc1" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SDT: Box Office</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
 
.style10 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ff0000; FONT-FAMILY: "Tahoma" }
		.style16 {COLOR: #999999; FONT-FAMILY: "Tahoma"; font-size: 14px;}
        .style1 { FONT-WEIGHT: bold; FONT-SIZE: 16px; COLOR: #666666; FONT-FAMILY: Tahoma }
        .style21
        {
            width: 122px;
            font-size: small;
        }
    </style>
</head>
<body  leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <div>
    
			<TABLE width="100%" border="0" align="center" cellPadding="0" cellSpacing="0" borderColor="#d3d3d3"
				bgcolor="#cccccc" id="Table2">
				<TR>
					<TD width="53%" align="left" bgcolor="#ffffff" style="HEIGHT: 23px">
                        <FONT color="#000099" face="Tahoma" size="2"><STRONG>
										<uc1:ctbvCtlTop id="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop></STRONG></FONT></TD>
					<TD width="47%" align="right" bgcolor="#ffffff" style="HEIGHT: 23px"><table width="58" border="0">
							<tr>
								<td width="52"><a href="frmCTBV_Login.aspx">
                                    <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/images/Exit.png" />
                                    </a></td>
							</tr>
							<tr>
								<td class="style10">Log Out
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR background="../images/BG7.jpg">
					<TD height="29" colspan="2" borderColor="honeydew" 
                        background="" class="style16">&nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>
                        &gt;<a href=frmRevenueMonitor.aspx> Box Office 
                        </a>&gt;<asp:HyperLink ID="lblMovieId" runat="server">HyperLink</asp:HyperLink>
&nbsp;&gt;
                        <asp:HyperLink ID="lblDate" runat="server">HyperLink</asp:HyperLink>
&nbsp;&gt;
                        <asp:HyperLink ID="TheaterName" runat="server">TheaterName</asp:HyperLink>
                        </b></TD>
			  </TR>
				<TR>
					<TD height="29" colspan="2" borderColor="honeydew" bgcolor="#ffffff">
						<table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
							bgcolor="#f0cd8c">
							<tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
								<td height="27" background=""><div align="left" class="style1">
                                    <table cellpadding="0" cellspacing="0" style="width:100%;">
                                        <tr>
                                            <td align="right" class="style21">
                                                Title :                                                     </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTitle" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="style21">
                                                        Distributor :</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDis" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="style21">
                                                        Genre :</td>
                                                    <td>
                                                        <asp:TextBox ID="txtGenre" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="style21">
                                                                                                                Release Date :</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDate" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
							  </td>
						  </tr>
							<tr bordercolor="#999999" bgcolor="#ffffff">
<td height="78" align="center" bgcolor="#E2E2E2">
           <table width="100%">
            <tr>
                <td >
                    <table width="100%">
                        <tr width="100%">
                            <td width="100%"  >
                                <asp:GridView ID="grdBoxOffice" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" DataSourceID="sqlBoxOffice" Font-Names="Tahoma" 
                                    Font-Size="Small" ForeColor="#333333" GridLines="None" 
                                    Width="100%" AllowSorting="True" ShowFooter="True">
                                    <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" 
                                        HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:HyperLinkField DataTextField="film_type_sound_name_th" HeaderText="Film Type and Sound" 
                                            DataNavigateUrlFields="revenueid" DataNavigateUrlFormatString="SendRevenue.aspx?MovieTypeId=2&RevenueId={0}" SortExpression="revenueid">
                                            <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField DataTextField="revenue_amount" DataTextFormatString="{0:#,##0}" 
                                            HeaderText="GBO" SortExpression="revenue_amount">
                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Right" />
                                            <ItemStyle Font-Bold="True" HorizontalAlign="Right" BorderColor="White" 
                                                BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField DataTextField="revenue_adms" DataTextFormatString="{0:#,##0}" 
                                            HeaderText="Adms" SortExpression="revenue_adms">
                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" 
                                                BorderWidth="0px" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="revenue_screen" HeaderText="Screen" SortExpression="revenue_screen">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataTextField="revenue_session" DataTextFormatString="{0:#,##0}"
                                            HeaderText="Session" SortExpression="revenue_session">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status">
                                            <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="user_name" HeaderText="Checker" 
                                            SortExpression="user_name" >
                                            <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataTextField="revenue_LastUpdate" 
                                            DataTextFormatString="{0:dd-MMM-yyyy HH:mm}"  HeaderText="Latest Update" 
                                            SortExpression="revenue_LastUpdate">
                                            <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:HyperLinkField>
                                    </Columns>
                                    <PagerStyle BackColor="#284775" Font-Names="Tahoma" Font-Size="X-Small" 
                                        ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    <br>
    <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
    <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURE&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>&nbsp;--%>
                                </td>
                            </tr>
						</table>
					</TD>
				</TR>
			</TABLE>
    
                <br />
    
    </div>
    <%--<asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT tblRevenue.revenueid, tblRevenue.revenue_adms, tblRevenue.revenue_amount, tblRevenue.revenue_date, tblRevenue.revenue_Time, tblRevenue.revenue_LastUpdate, tblRevenue.revenue_type, tblRevenue.theatersub_id, tblRevenue.user_id, tblRevenue.movie_system, tblRevenue.movies_id, tblRevenue.theater_id, tblRevenue.status_id, tblRevenue.sound_type, tblRevenue.timehour_id, tblRevenue.timemin_id, tblUser.user_name, tblRevStatus.status, tblRevStatus.statusColor, tblRevenue.revenue_adms / mSeat.theatersub_normalseat * 100 AS opc FROM tblRevenue LEFT OUTER JOIN tblUser ON tblRevenue.user_id = tblUser.user_id LEFT OUTER JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.id LEFT OUTER JOIN (SELECT theatersub_normalseat, theater_id, theatersub_id FROM tblTheaterSub WHERE (theater_id = @theaterId) AND (theatersub_id = @revScreen)) AS mSeat ON tblRevenue.theater_id = mSeat.theater_id AND tblRevenue.theatersub_id = mSeat.theatersub_id WHERE (tblRevenue.movies_id = @movieId) AND (tblRevenue.theater_id = @theaterId) AND (tblRevenue.revenue_date = @revDate) AND (tblRevenue.theatersub_id = @revScreen) ORDER BY tblRevenue.timehour_id, tblRevenue.timemin_id">
        <SelectParameters>
            <asp:SessionParameter Name="movieId" SessionField="movieId" />
            <asp:SessionParameter Name="theaterId" SessionField="theaterId" />
            <asp:SessionParameter Name="revDate" SessionField="revDate" />
            <asp:SessionParameter Name="revScreen" SessionField="revScreen" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="select RCH.movie_id as movies_id
    , RCH.theater_id
    , RCD.revenue_id as revenueid
    , RCH.revenue_date
    , RCD.adms as revenue_adms
    , RCD.amount as revenue_amount
    , RCD.count_screen as revenue_screen
    , RCD.count_session as revenue_session
    , RCD.update_by as user_id
    , U.user_name
    , RCD.update_date as revenue_LastUpdate
    , RCD.status_id
    , RS.status
    , RS.statusColor
    , FTS.film_type_sound_id
    , FTS.film_type_sound_name_th
from tblRevenueCompHeader RCH
    left join tblRevenueCompDetail RCD
    on RCH.revenue_comp_header_id = RCD.revenue_comp_header_id
    left join tblUser U
    on RCD.update_by = U.user_id
    left outer join tblRevStatus RS
    on RCD.status_id = RS.id 
    left outer join tblFilmTypeSound FTS
    on RCD.film_type_sound_id = FTS.film_type_sound_id
where (RCH.movie_id = @p_movie_id)
    and (RCH.revenue_date = @p_revenue_date)
    and (RCH.theater_id = @p_theater_id)
order by RCH.movie_id
    , RCH.theater_id
    , RCD.film_type_sound_id">
        <SelectParameters>
            <asp:SessionParameter Name="p_movie_id" SessionField="movieId" />
            <asp:SessionParameter Name="p_revenue_date" SessionField="revDate" />
            <asp:SessionParameter Name="p_theater_id" SessionField="theaterId" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>