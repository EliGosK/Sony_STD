<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_Trailer_Show.aspx.vb" Inherits=".frmCTBV_Trailer_Show" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<%@ Register src="../Controls/SelectColor.ascx" tagname="SelectColor" tagprefix="uc2" %>
<%@ Register src="../Controls/Movie1Popup.ascx" tagname="Movie1Popup" tagprefix="uc3" %>
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
                        background="../images/BG7.jpg" class="style16">&nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&nbsp;&gt; 
                        </b>
                        <b><a href="frmCTBV_Menu_Trailer.aspx">Trailer Menu </a>&nbsp;&gt; 
                        </b><strong>Input from Checkers</strong></TD>
			  </TR>
				<TR>
					<TD height="29" colspan="2" borderColor="honeydew" bgcolor="#ffffff">
						<table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
							bgcolor="#f0cd8c">
							<tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
								<td height="27" background="../images/BG8.jpg"><div align="center" class="style2">
                                    Input from Checkers</div>
							  </td>
						  </tr>
							<tr bordercolor="#999999" bgcolor="#ffffff">
<td height="78" align="center" bgcolor="#E2E2E2">					      <table width="100%" border="0" cellspacing="1">
										<tr>
										  <td bordercolor="#DADADA" bgcolor="#DADADA">
										    								    
										        </td>					  </tr>
										<tr>
										  <td bgcolor="#f0cd8c"><div align="center" class="style15">
										      <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                                  AutoGenerateColumns="False" CellPadding="4" DataKeyNames="theater_id" 
                                                  DataSourceID="sqlMovies" Font-Names="Tahoma" Font-Size="X-Small" 
                                                   GridLines="None" Width="100%" PageSize="25">
                                                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                  <RowStyle BackColor="#F7F6F3"  />
                                                  <Columns>
                                                        <%--<asp:BoundField DataField="Movie_Id" HeaderText="Title I.D." 
                                                            HeaderStyle-HorizontalAlign="Center"  
                                                            SortExpression="Movie_Id"  ItemStyle-Width = "100" 
                                                            ItemStyle-HorizontalAlign="Center" >
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                                        </asp:BoundField>--%>
                                                        
                                                         <asp:HyperLinkField DataNavigateUrlFields="theater_id" 
                                                          DataNavigateUrlFormatString="frmCTBV_Trailer_Show_Detail.aspx?theater_id={0}" 
                                                          DataTextField="theater_name" HeaderText="Theatre" 
                                                          SortExpression="theater_name" ItemStyle-Width="30%" ItemStyle-Font-Bold="true" 
                                                          ItemStyle-Font-Underline="true" />
                                                          
                                                          <asp:BoundField DataField="circuit_name" HeaderText="Circuit" 
                                                           SortExpression="circuit_name" ItemStyle-Width="25%" />
                                                          <asp:BoundField DataField="user_name" HeaderText="Checker" 
                                                          SortExpression="user_name" ItemStyle-Width="25%" />
                                                      <asp:HyperLinkField DataTextField="last_update_dtm" 
                                                          DataTextFormatString="{0:ddd dd-MMM-yyyy HH:mm}"  HeaderText="Latest Update"  
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
                                                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                              </asp:GridView>
										  </div>										  </td>
										</tr>
									</table>								  
    <br />
    <%@ register src="../Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="uc1" %>
    <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
    <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>--%>
    <br />
        </form>
        <asp:SqlDataSource ID="sqlMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
            SelectCommand="SELECT t.theater_id, t.theater_name, t.circuit_id, c.circuit_name, trailer.user_name, trailer.last_update_dtm FROM tblTheater AS t LEFT OUTER JOIN tblCircuit AS c ON t.circuit_id = c.circuit_id LEFT OUTER JOIN (SELECT DISTINCT tm.circuit_id, tm.theater_id, MAX(tm.last_update_dtm) AS last_update_dtm, MAX(tm.last_update_by) AS last_update_by, MAX(u.user_name) AS user_name FROM tblTrailer_Master AS tm LEFT OUTER JOIN tblUser AS u ON tm.last_update_by = u.user_id WHERE (tm.active_flag = 'Y') AND (tm.confirm_flag = 'Y') GROUP BY tm.circuit_id, tm.theater_id) AS trailer ON t.theater_id = trailer.theater_id ORDER BY t.circuit_id, t.theater_name">
        </asp:SqlDataSource>
    </body>
</HTML>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>