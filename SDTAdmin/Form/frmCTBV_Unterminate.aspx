<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_Unterminate.aspx.vb" Inherits=".frmCTBV_Unterminate" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SDT Management Informaion System - Add Movie</title>
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
 
.style1 { FONT-WEIGHT: bold; FONT-SIZE: 16px; COLOR: #666666; FONT-FAMILY: Tahoma }
.style2 { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #999999; FONT-FAMILY: "Tahoma" }
.style10 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ff0000; FONT-FAMILY: "Tahoma" }
		.style16 {COLOR: #999999; FONT-FAMILY: "Tahoma"; font-size: 14px;}
             .lbl 
             {
             	font-size: 14px; font-family: "Tahoma";
                font-weight: 700; 
                text-align:right;
                               
            }
            .style17
            {
                height: 7px;
            }
            .style18
            {
                height: 205px;
            }
            </style>
		<script language="JavaScript" type="text/JavaScript">
<!--

        function CheckboxesCheckUncheck(objChk)
        {
            //กำหนด Element หลัก ในที่นี้คือ GridView
            var ctrlParent = document.getElementById('grdTheater');
            //alert(ctrlParent);
            //กำหนด Element ลูก ในที่นี้คือ Checkbox ControlID
            var ctrlChild = "chkBxSelect";
            //Get Control ที่อยู่ใน Parent ในที่นี้คือ GridView
            var Inputs = ctrlParent.getElementsByTagName('input');
                 for(var i = 0; i < Inputs.length; ++i)
                    { // วน Loop Control โดยเช็คว่า Type คือ Checkbox และ indexOf Child ลูก
                        if(Inputs[i].type == 'checkbox' && Inputs[i].id.indexOf(ctrlChild,0) >= 0)
                           Inputs[i].checked = objChk.checked;
                    }
        }

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
//-->
		</script>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-874">
	</HEAD>
	<body MS_POSITIONING="GridLayout"  leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
		<form id="Form2" method="post" runat="server">
			<TABLE width="100%" border="0" align="center" cellPadding="0" 
            cellSpacing="0" borderColor="#d3d3d3"
				bgcolor="#cccccc" id="Table2">
				<TR>
					<TD width="53%" align="left" bgcolor="#ffffff" style="HEIGHT: 23px"><FONT face="Tahoma"><FONT size="2"><FONT color="#000099"><STRONG>
										<uc1:ctbvCtlTop id="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop></STRONG></FONT></FONT></FONT></TD>
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
                        Menu </a>&gt; <a href="frmCTBV_Menu_MMD.aspx">&nbsp;Manage Master Data</a> &gt; <a href="frmCTBV_MMD_Movie.aspx">
                        MMD : Movie </a>&gt;<a href="frmCTBV_MMD_Movie_Add.aspx?titleId=0">&nbsp;Movie</a> &gt;
                        </b> <strong>Movie Status</strong></TD>
			  </TR>
				<TR>
					<TD height="277" colspan="2" borderColor="honeydew" bgcolor="#ffffff"><FONT size="2"><FONT color="#000000"><FONT face="Tahoma" size="1"><STRONG>
									</STRONG></FONT></FONT></FONT>
						<table width="100%" height="200" border="1" align="center" cellpadding="3" cellspacing="3"
							bgcolor="#f0cd8c">
							<tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
								<td background="../images/BG8.jpg" bgcolor="#f0cd8c" class="style17"><div align="center" class="style1">
                                    <span class="style2">
                                    &nbsp;Movie Status</span></div>
							  </td>
						  </tr>
							<tr valign="top"  bordercolor="#999999" bgcolor="#ffffff">
<td align="center" bgcolor="#E2E2E2" class="style18"> <table width="100%" border="0" cellspacing="1">
										<tr>
										  <td  bgcolor="#f0cd8c"><div align="center" >
										    <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                                              
                                              <tr bgcolor="#F0DFD0">
                                                <td  align="center" height="40"> 
                                                    <br />
                                                    <br />
                                                    <br />
                                                        <asp:Button ID="btnTerminater" runat="server" Text="Terminated" />
                                                    <asp:Button ID="btnShowing" runat="server" Text="Showing" />
                                                    <asp:Button ID="btnRelease" runat="server" Text="Not Released" />
                                                    <asp:Button ID="Button1" runat="server" Text="Cancel" />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                        <br />
                                                  </td>
							</tr>
					  </table>
    			  </TD>
				</TR>
			</TABLE>
    <div align="center">
        <br />
        <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
        <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>--%>
        <br />
                        </table>
                <asp:SqlDataSource ID="sqlDistibutor" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    
                                SelectCommand="SELECT distributor_name, distributor_id FROM tblDistributor WHERE (active_flag = 'Y')">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlStudio" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    SelectCommand="SELECT studio_id, studio_name FROM tblStudio">
                </asp:SqlDataSource>
    
		        <asp:SqlDataSource ID="sqlTheater" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    SelectCommand="SELECT tblTheater.theater_id, tblTheater.theater_code, tblTheater.theater_name, COUNT(tblTheaterSub.TheaterSub_id) AS TheaterNo, SUM(tblTheaterSub.TheaterSub_normalseat) AS nomalseat, SUM(tblTheaterSub.TheaterSub_vipseat) AS vipseat FROM tblTheater LEFT OUTER JOIN tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id GROUP BY tblTheater.theater_id, tblTheater.theater_code, tblTheater.theater_name">
                </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlTheatrehow" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                                
                                
                                SelectCommand="SELECT tblTheater.theater_name, tblTheater.theater_code, temprelease.onrelease_id, temprelease.onrelease_status, temprelease.onrelease_startdate, tblMovieStatus.movie_statusTitle, tblMovieStatus.movie_statusCode, temprelease.onrelease_enddate, tblTheater.theater_id FROM tblMovieStatus RIGHT OUTER JOIN (SELECT onrelease_id, onrelease_status, onrelease_startdate, onrelease_enddate, movies_id, theater_id FROM tblRelease WHERE (movies_id = @titleId)) AS temprelease ON tblMovieStatus.movie_statusId = temprelease.onrelease_status RIGHT OUTER JOIN (SELECT theater_id, theater_code, theater_name, theater_des, theater_status, theater_lastupdate, user_id, circuit_id FROM tblTheater AS tblTheater_1 WHERE (theater_status = 'Enabled')) AS tblTheater ON temprelease.theater_id = tblTheater.theater_id ORDER BY temprelease.onrelease_status, tblTheater.theater_name">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="titleId" QueryStringField="titleId" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:HiddenField ID="hidDEL_tblRevenue" runat="server" />
                            <asp:HiddenField ID="hidDEL_tblCompRevenue" runat="server" />
                            <asp:HiddenField ID="hidDEL_tblRelease" runat="server" />
                             <asp:HiddenField ID="hidAppear" runat="server" />
                            <asp:HiddenField ID="hidTrailerColDtl" runat="server" />
                </form>
		</body>
</HTML>


<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>