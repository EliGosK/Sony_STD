<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevByScrn.aspx.vb" Inherits=".frmRevByScrn" %>

<%@ Register src="../Controls/ctbvCtlTop.ascx" tagname="ctbvCtlTop" tagprefix="uc1" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                        &nbsp;&gt; 
                        <asp:Label ID="lblScreen" runat="server" Text="lblScreen"></asp:Label>
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
                                        <asp:HyperLinkField DataNavigateUrlFields="revenueId" 
                                            DataNavigateUrlFormatString="frmrevDetail.aspx?revID={0}" 
                                            DataTextField="revenue_Time" HeaderText="Session/Time" 
                                            SortExpression="revenueId" >
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
                                        <asp:HyperLinkField DataTextField="opc" DataTextFormatString="{0:#,##0.00}" 
                                            HeaderText="OPC (%)" SortExpression="opc">
                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" 
                                                BorderWidth="0px" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="revenue_type" HeaderText="Session Type" 
                                            SortExpression="revenue_type" >
                                            <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="movie_system" HeaderText="Film System" 
                                            SortExpression="movie_system" >
                                            <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sound_type" HeaderText="Sound" 
                                            SortExpression="sound_type" >
                                            <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="film_type_sound_name_th" HeaderText="Film Type and Sound" 
                                            SortExpression="film_type_sound_name_th" >
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
        SelectCommand="select R.revenueid
        , R.revenue_adms
        , R.revenue_amount
        , R.revenue_date
        , R.revenue_Time
        , R.revenue_LastUpdate
        , R.revenue_type
        , R.theatersub_id
        , R.user_id
        , R.movie_system
        , R.movies_id
        , R.theater_id
        , R.status_id
        , R.sound_type
        , R.timehour_id
        , R.timemin_id
        , U.user_name
        , RS.status
        , RS.statusColor
        , (convert(decimal(15, 2), R.revenue_adms) / convert(decimal(15, 2), SEAT.theatersub_normalseat)) * 100 as opc
        , SEAT.theatersub_normalseat
        , FTS.film_type_sound_id
        , FTS.film_type_sound_name_th
    from tblRevenue R
        left outer join tblUser U
        on R.user_id = U.user_id 
        left outer join tblRevStatus RS
        on R.status_id = RS.id 
        left outer join (
            select theatersub_normalseat
                , theater_id
                , theatersub_id 
            from tblTheaterSub 
            where (theater_id = @p_theater_id) 
            and (theatersub_id = @p_theatersub_id)
            ) as SEAT
        on R.theater_id = SEAT.theater_id 
        and R.theatersub_id = SEAT.theatersub_id
        left outer join tblFilmTypeSound FTS
        on R.film_type_sound_id = FTS.film_type_sound_id
    where (R.movies_id = @p_movie_id) 
        and (R.theater_id = @p_theater_id) 
        and (R.revenue_date = @p_revenue_date) 
        and (R.theatersub_id = @p_theatersub_id) 
    order by R.movies_id
    , R.theater_id
    , R.theatersub_id
    , R.timehour_id
    , R.timemin_id">
        <SelectParameters>
            <asp:SessionParameter Name="p_movie_id" SessionField="movieId" />
            <asp:SessionParameter Name="p_theater_id" SessionField="theaterId" />
            <asp:SessionParameter Name="p_revenue_date" SessionField="revDate" />
            <asp:SessionParameter Name="p_theatersub_id" SessionField="revScreen" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>