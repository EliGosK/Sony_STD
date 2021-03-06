<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_Trailer_Show_Detail.aspx.vb" Inherits=".frmCTBV_Trailer_Show_Detail" %>


<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<%@ Register src="../Controls/SelectColor.ascx" tagname="SelectColor" tagprefix="uc2" %>
<%@ Register src="../Controls/Movie1Popup.ascx" tagname="Movie1Popup" tagprefix="uc3" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SDT Management Information System - Manage Master Data Movie</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css">
A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
 

.style2 { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #999999; FONT-FAMILY: "Tahoma" }
.style10 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ff0000; FONT-FAMILY: "Tahoma" }
.style15 {
	FONT-WEIGHT: bold;
	FONT-SIZE: 16px;
	FONT-FAMILY: "Tahoma";
	color: #666666;
}
.lbl{
	FONT-SIZE: 10pt;
	FONT-FAMILY: "Tahoma";
	color:Navy;
}
		.style16 {COLOR: #999999; FONT-FAMILY: "Tahoma"; font-size: 14px;}
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
		
		
		<SCRIPT LANGUAGE="Javascript" SRC="../js/ColorPicker2.js"></SCRIPT>
		
</HEAD>
	<body MS_POSITIONING="GridLayout" leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
	    <form id="form1" runat="server">
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
                        background="../images/BG7.jpg" class="style16">&nbsp;<b><a href="frmCTBV_Menu.aspx">Main 
                        Menu </a>&nbsp;&gt; 
                        </b>
                        <b><a href="frmCTBV_Menu_Trailer.aspx">Trailer Menu </a>&nbsp;&gt; 
                        </b>
                        <b><a href="frmCTBV_Trailer_Show.aspx">Input from Checkers </a>&nbsp;&gt; 
                        </b>
                        <strong>Input from Checker Details</strong></TD>
			  </TR>
				<TR>
					<TD height="29" colspan="2" borderColor="honeydew" bgcolor="#ffffff">
						<table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
							bgcolor="#f0cd8c">
							<tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
								<td height="27" background="../images/BG8.jpg"><div align="center" class="style2">
                                    				Input from Checker Details</div>
							  </td>
						  </tr>
							<tr bordercolor="#999999" bgcolor="#ffffff">
<td height="78" align="center" bgcolor="#E2E2E2">					      <table width="100%" border="0" cellspacing="1">
										<tr>
										  <td bordercolor="#DADADA" bgcolor="#DADADA">
										    								    
										        </td>
										        </tr>
										        <tr bordercolor="#f0cd8c" bgcolor="#DADADA">
										  <td align="center" >
										    								    
										        <asp:Label ID="lblTheater" runat="server" CssClass="lbl"></asp:Label>
										    								    
										        </td>
										   </tr>
										<tr>
										  <td bgcolor="#f0cd8c"><div align="center" class="style15">
										      <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                                  AutoGenerateColumns="False" CellPadding="4" DataKeyNames="theater_id" 
                                                  DataSourceID="sqlTailer" Font-Names="Tahoma" Font-Size="10pt" 
                                                   GridLines="None" Width="100%" PageSize="25">
                                                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                  <RowStyle BackColor="#F7F6F3"  />
                                                  <Columns>                                                          
                                                          <asp:BoundField DataField="TheaterSub_id" HeaderText="Screen" 
                                                           SortExpression="TheaterSub_id" ItemStyle-Width="5%" >
<ItemStyle Width="5%"></ItemStyle>
                                                          </asp:BoundField>
                                                          <asp:BoundField DataField="real_movie_id" HeaderText="Title I.D." 
                                                          SortExpression="real_movie_id" ItemStyle-Width="10%" >
<ItemStyle Width="10%"></ItemStyle>
                                                          </asp:BoundField>
                                                          <asp:BoundField DataField="real_movie_name" HeaderText="Title" ItemStyle-Font-Bold="true" 
                                                          SortExpression="real_movie_name" ItemStyle-Width="25%"   >
<ItemStyle Width="25%"></ItemStyle>
                                                          </asp:BoundField>
                                                          <asp:BoundField DataField="Movie_Collection" HeaderText="Trailers" 
                                                          SortExpression="Movie_Collection" ItemStyle-Width="40%" >
<ItemStyle Width="40%"></ItemStyle>
                                                          </asp:BoundField>
                                                      <asp:HyperLinkField DataTextField="last_update_dtm" 
                                                          DataTextFormatString="{0:ddd dd-MMM-yyyy HH:mm}" HeaderText="Latest Update"  
                                                          ItemStyle-HorizontalAlign="Center"    HeaderStyle-HorizontalAlign="Center" 
                                                          SortExpression="last_update_dtm" >
                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width ="20%"></ItemStyle>
                                                      </asp:HyperLinkField>
                                                  </Columns>
                                                  
                                                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                      HorizontalAlign="Left" />
                                                  <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                                  <AlternatingRowStyle BackColor="White" />
                                              </asp:GridView>
										  </div>										  </td>
										</tr>
									</table>								  
    <br />
    <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
    <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>--%>
    <br />
        <asp:SqlDataSource ID="sqlTailer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    
        
        SelectCommand="SELECT tblTrailer_Master.trailer_no, tblTrailer_Master.circuit_id, tblTrailer_Master.theater_id, tblTrailer_Master.TheaterSub_id, tblTrailer_Master.real_movie_id, tblTrailer_Master.collection_no, tblTrailer_Master.confirm_flag, tblTrailer_Master.active_flag, tblTrailer_Master.create_dtm, tblTrailer_Master.create_by, tblTrailer_Master.last_update_dtm, tblTrailer_Master.last_update_by, dbo.funGetConcatMovieByColNo(tblTrailer_Master.collection_no,0,7) AS Movie_Collection, tblMovie.movie_nameth + ' / ' + tblMovie.movie_nameen AS real_movie_name FROM tblTrailer_Master LEFT OUTER JOIN tblMovie ON tblTrailer_Master.real_movie_id = tblMovie.movie_id WHERE (tblTrailer_Master.confirm_flag = 'Y' OR tblTrailer_Master.confirm_flag = 'y') AND (tblTrailer_Master.active_flag = 'Y' OR tblTrailer_Master.active_flag = 'y')">
                </asp:SqlDataSource>
                </FONT>
            		</form>
		</body>
</HTML>


<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>