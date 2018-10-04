<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevCompDetail.aspx.vb" Inherits=".frmRevCompDetail" %>

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
                .style8
        {
            width: 33px;
        }
        .style11
        {
            font-family: Tahoma;
            font-size: small;
            width: 223px;
            color: #800000;
        }
                .style22
        {
            width: 135px;
        }
        .style23
        {
            width: 246px;
        }
        .style24
        {
            width: 219px;
        }
        .style25
        {
            width: 223px;
        }
        .style26
        {
            width: 246px;
            color: #333333;
            font-family: Tahoma;
            font-size: small;
            font-weight: bold;
        }
        .style27
        {
            width: 219px;
            color: #333333;
            font-family: Tahoma;
            font-size: small;
            font-weight: bold;
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
                        background="" class="style16">&nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt;<a href=frmRevenueMonitor.aspx> Box Office 
                        </a>&gt;<asp:HyperLink ID="lblMovieId" runat="server">HyperLink</asp:HyperLink>
&nbsp;&gt;
                        <asp:HyperLink ID="lblDate" runat="server">HyperLink</asp:HyperLink>
&nbsp;&gt; <asp:HyperLink ID="lblTheater" runat="server">HyperLink</asp:HyperLink>
&nbsp;</b></TD>
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
                                <table border="0" bordercolor="#ffffff" style="width: 336px">
                                    <tr>
                                        <td align="center" bordercolor="#ffffff" class="style1">
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                ForeColor="#993333" Text="บันทึกรายได้ภาพยนตร์คู่แข่ง"></asp:Label>
                                            <br />
                                            <span class="style10">-----------------------------------------------------</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td bordercolor="#ffffff">
                                                                            <table align="left" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td align="right" class="style22">
                                                                                        <span class="style8">
                                                                                        <label>
                                                                                        <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                                                            Font-Size="Small" ForeColor="#003366" Text="Status :"></asp:Label>
                                                                                        </label>
                                                                                        </span>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <label>
                                                                                        <span>
                                                                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" 
                                                                                            BackColor="White" Font-Names="Tahoma" Font-Size="Small">
                                                                                        </asp:DropDownList>
                                                                                        </span>
                                                                                        </label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td bordercolor="#ffffff" height="100%">
                                                                            <table align="left" bgcolor="#CCCCCC" border="0" bordercolor="#999999" 
                                                                                cellpadding="0" cellspacing="0">
                                                                                <tr bgcolor="#669999">
                                                                                    <td align="left" bgcolor="#669999" bordercolor="#CCCCCC" class="style11">
                                                                                        &nbsp;</td>
                                                                                    <td align="left" class="style27">
                                                                                        Original</td>
                                                                                    <td align="left" class="style26">
                                                                                        Thai</td>
                                                                                    <td align="left" class="style26">
                                                                                        3D</td>
                                                                                    <td align="left" class="style26">
                                                                                        Sum</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="style25">
                                                                                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                                                            Font-Size="Small" ForeColor="#0000CC" Text="Screen :"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="style24">
                                                                                        <asp:TextBox ID="txtScreenOr" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="2"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtScreenTh" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="2"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtScreenTD" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="2"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtScreenSum" runat="server" Columns="6" Font-Bold="True" 
                                                                                            Font-Names="Tahoma" Font-Size="Small" MaxLength="2"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="style25">
                                                                                        <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                                                            Font-Size="Small" ForeColor="#0000CC" Text="Seesion : "></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="style24">
                                                                                        <asp:TextBox ID="txtTimeOr" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="3"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtTimeTh" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="3"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtTimeTD" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="3"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtTimeSum" runat="server" Columns="6" Font-Bold="True" 
                                                                                            Font-Names="Tahoma" Font-Size="Small" MaxLength="3"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="style25">
                                                                                        <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                                                            Font-Size="Small" ForeColor="#0000CC" Text="GBO :"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="style24">
                                                                                        <asp:TextBox ID="txtRevOr" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="10"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtRevTh" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="10"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtRevTD" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="10"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtRevSum" runat="server" Columns="6" Font-Bold="True" 
                                                                                            Font-Names="Tahoma" Font-Size="Small" MaxLength="10"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="style25">
                                                                                        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                                                            Font-Size="Small" ForeColor="#0000CC" Text="Adms :"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="style24">
                                                                                        <asp:TextBox ID="txtAdmsOr" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="6"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtAdmsTh" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="6"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtAdmsTD" runat="server" BackColor="Silver" Columns="6" 
                                                                                            Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" 
                                                                                            MaxLength="6"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" class="style23">
                                                                                        <asp:TextBox ID="txtAdmsSum" runat="server" Columns="6" Font-Bold="True" 
                                                                                            Font-Names="Tahoma" Font-Size="Small" MaxLength="10"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td bordercolor="#ffffff" class="style1">
                                                                            <asp:Label ID="lblError" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                                                                                ForeColor="#CC3300" Text="Error : GBO/ADMS =60-600 !!" Visible="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td bordercolor="#ffffff" class="style1">
                                                                            <div align="center">
                                                                                &nbsp;<asp:Button ID="btnSend" runat="server" Font-Names="Tahoma" Font-Size="Small" 
                                                                                    Text="   Save   " />
                                                                                &nbsp;<asp:Button ID="btnCancel" runat="server" Font-Names="Tahoma" 
                                                                                    Font-Size="Small" Text=" Cancel" />
                                                                                &nbsp;<asp:Button ID="btndelete" runat="server" Text="Delete" />
&nbsp;</div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    <br />
    <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
    <%--<center><font color="rosybrown" face="Tahoma" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font></center>--%>
    <br />
    
    </div>
                <asp:SqlDataSource ID="sqlBoxOffice" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    
            
                
        SelectCommand="SELECT vSumByTheater.movie_id, vSumByTheater.rev_adms, vSumByTheater.rev_amount, vSumByTheater.cntSession, vSumByTheater.cntScreen, vSumByTheater.revDate, vSumByTheater.TheaterId, tblTheater.theater_name, tblTheater.theater_code FROM vSumByTheater LEFT OUTER JOIN tblTheater ON vSumByTheater.TheaterId = tblTheater.theater_id WHERE (vSumByTheater.movie_id = @movId and vSumByTheater.revDate=@revDate)">
                    <SelectParameters>
                        <asp:SessionParameter Name="movId" SessionField="movieId" />
                        <asp:SessionParameter Name="revDate" SessionField="revDate" />
                    </SelectParameters>
                </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>