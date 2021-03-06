<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTrailerByTotalParam.aspx.vb" Inherits=".frmRptTrailerByTotalParam" %>


<%@ Register src="../Controls/ctbvCtlTop.ascx" tagname="ctbvCtlTop" tagprefix="uc1" %>
<%@ Register src="../Controls/Trailer_Header_SetupPopup.ascx" tagname="Trailer_Header_SetupPopup" tagprefix="uc3" %>
<%@ Register src="../Controls/Movie1Popup.ascx" tagname="Movie1Popup" tagprefix="uc2" %>
<%@ Register src="../Controls/MoviePopupSN.ascx" tagname="MoviePopupSN" tagprefix="uc4" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">

A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
 
            #Table2
            {
                height: 216px;
            }
		.style10 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ff0000; FONT-FAMILY: "Tahoma" }
            .style15
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            height: 11px;
        }
        .style16
        {
            width: 380px;
            height: 11px;
        }
        .style11
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
        }
        .style14
        {
            width: 380px;
        }
        .style17
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            height: 22px;
        }
        .style18
        {
            width: 380px;
            height: 22px;
        }
        </style>
</head>
<body  leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
		<form id="Form2" method="post" runat="server">
			<TABLE width="100%" border="0" align="center" cellPadding="0" cellSpacing="0" borderColor="#d3d3d3"
				bgcolor="#cccccc" id="Table2">
				<TR>
					<TD width="53%" align="left" bgcolor="#ffffff" style="HEIGHT: 23px">
                        <FONT color="#000099" face="Tahoma" size="2"><STRONG>
										<uc1:ctbvCtlTop id="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop></STRONG></FONT></TD>
					<TD width="47%" align="right" bgcolor="#ffffff" style="HEIGHT: 23px"><table width="58" border="0">
							<tr>
								<td width="52">
                                    <asp:ImageButton ID="imbOut" runat="server" ImageUrl="~/images/Exit.png" />
                                </td>
							</tr>
							<tr>
								<td class="style10">Log Out
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR background="../images/BG7.jpg" style="color: Gray; font-family: Tahoma; font-size: 14px;">
					<TD height="29" colspan="2" borderColor="honeydew" 
                        background="../images/BG7.jpg" >&nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&nbsp;&gt; 
                        </b>
                        <b><a href="frmCTBV_Menu_Trailer.aspx">Trailer Menu </a>&nbsp;&gt; 
                        </b>
                        <b><a href="frmCTBV_Menu_Trailer_Rpt.aspx">Trailer Reports </a>&nbsp;&gt; 
                        </b>
                        <strong>Trailer List by Title</strong></TD>
			  </TR>
				<TR>
					<TD height="29" colspan="2" borderColor="honeydew" bgcolor="#ffffff">
						<table width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
							bgcolor="#f0cd8c" style="height: 154px">
							<tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
								<td height="27" background="../images/BG8.jpg">
								<div align="center" style="font-family:Tahoma; font-size:11pt; font-weight:bold; color:Gray;" >
                                    Trailer List by Title</div>
							  </td>
						  </tr>
							<tr bordercolor="#999999" bgcolor="#ffffff">
<td align="center" bgcolor="#CCCCCC">					      
  <table border="0" cellspacing="0" width= 100% cellpadding="0">
										<tr>
										  <td width= 40% class="style15">  
                                                  </td>
										  <td style="text-align: left" class="style16">  
                                                                                </td>
										</tr>
										<tr>
										  <td width= 40% class="style11" valign="top">
                                                  Setup No. :</td>
										  <td align="left">
                                                      <uc3:Trailer_Header_SetupPopup ID="SetupPopup1"  runat="server" />
                                                </td>
										</tr>
										<tr>
										  <td width= 40% class="style11">
                                        Circuit :
                                    </td>
										  <td align="left">
                                        <asp:DropDownList ID="ddlCircuitID" runat="server" Font-Size="10pt">
                                            
                                        </asp:DropDownList>
                                                </td>
										</tr>
										<tr>
										  <td width= 40% class="style11" valign="top">
                                                  Trailer I.D. :</td>
										  <td align="left">
                                                      <uc4:MoviePopupSN ID="MoviePopupSN1" runat="server" InStatus="0,1,2,3" _AppearOnStatus="0,1,2,3,4" />
                                                </td>
										</tr>
										<tr>
										  <td class="style17" width= 40% >
                                                  </td>
										  <td class="style18" style="text-align: left">
                                                </td>
										</tr>
										<tr>
										  <td class="style11" width= 40% >
                                                  &nbsp;</td>
										  <td class="style14" style="text-align: left">
                                                  <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                                </td>
										</tr>
										</table>
				                </td>
							</tr>
							<tr bordercolor="#999999" bgcolor="#ffffff">
                                <td align="center" bgcolor="#f0cd8c">
                                    <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                                    <font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>&nbsp;
                                </td>
							</tr>
					  </table>
					</TD>
				</TR>
			</TABLE>

		</form>

            </body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>