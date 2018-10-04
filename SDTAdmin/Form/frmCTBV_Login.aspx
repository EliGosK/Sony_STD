<%@ Page Language="vb" AutoEventWireup="false" Codebehind="frmCTBV_Login.aspx.vb" Inherits="Form.FrmCtbvLogin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>::: Welcome to SDT Management Information System - Login</title>
		<script language="Javascript" src="../js/Duo-Web-v1.bundled.js" type="text/javascript"></script>
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta http-equiv="X-Frame-Options" content="allow">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-874">
		<script>
		    function calledFn(request, host) {		        
		        Duo.init({
		            'host': host,
		            'sig_request': request,
		            'post_action': 'frmCTBV_Menu.aspx'
		        });
		    }
		    function calledFn2(request, host) {
		        Duo.init({
		            'host': host,
		            'sig_request': request,
		            'post_action': 'frmCTBV_AT_Add.aspx'
		        });
		    }
		    function forRentClicked(sender)
            {
                //var tb1 = document.getElementById('<%= txtPassword.ClientID %>');
                //tb1.type = sender.checked?'text':'password';
            }
		</script>
	</HEAD>
	<body bgColor="#FFFFFF" leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" 
		MS_POSITIONING="GridLayout">
		<div id="duo_div" style="display: none">
            <iframe id="duo_iframe" width="620" height="330" frameborder="0"></iframe>		
        </div>
		<FONT face="Tahoma"></FONT>
		<TABLE id="Table4" height="600" cellSpacing="0" cellPadding="0" width="100%" align="center"
			border="0">
			<TR>
			  <TD><p><FONT face="Tahoma">&nbsp;&nbsp;<img src="../images/SDTLogo_2016.jpg" /></FONT> </p>
<TABLE width="100%" border="0" align="center" cellPadding="0" cellSpacing="0"
							id="Table3" bgcolor="#FFCC66">
					  <TR>
						  <TD width="100%" height="200" vAlign="top" borderColor="lightgrey"><font face="Tahoma"><br>
						    <br>
						    </font>
						    <TABLE width="785" border="0" cellPadding="1" cellSpacing="1" id="Table2">
							    <TR>
								    <TD width="1356" align="right" borderColor="#ffffff">
									    <form id="Form1" method="post" runat="server">
										    <asp:label id="lblError" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
													   Visible="False"><font face="Tahoma">User ID or Password invalid,<br> please login again.</font></asp:label>
										    <font face="Tahoma"><BR>
										  </font>
										    <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" align="right" border="0">
											    <TR>
												    <TD style="WIDTH: 125px" align="right"><font face="Tahoma"><STRONG><FONT size="2">User ID :</FONT></STRONG></font></TD>
												    <TD><font face="Tahoma">
													    <asp:textbox id="txtUserId" runat="server" Font-Size="Smaller" ForeColor="#0000C0" BackColor="#C0C0FF"
																	Font-Names="Tahoma"></asp:textbox>
												    </font></TD>
											    </TR>
											    <TR>
												    <TD style="WIDTH: 125px" align="right"><font face="Tahoma"><STRONG><FONT size="2">Password :</FONT></STRONG></font></TD>
												    <TD><font face="Tahoma">
													    <asp:textbox id="txtPassword" runat="server" Font-Size="Smaller" 
                                                            ForeColor="#0000C0" BackColor="#C0C0FF"
															Font-Names="Tahoma" TextMode="Password">
														</asp:textbox>
												    </TD>
												 </TR>
												 <TR>
												    <TD style="WIDTH: 125px" align="left"></TD>
												    <TD>
												        <asp:CheckBox id="checkBoxPassword" runat="server" Height="16px" Font-Size="Smaller" 
                                                            ForeColor="#000000" Font-Names="Tahoma" text="Show Characters"  AutoPostBack="true" /> <%--onclick="forRentClicked(this)" --%> 
												    </TD>
												 </TR>    
											    <TR>
												    <TD style="WIDTH: 125px" align="left"></TD>
												    <TD vAlign="top"><font face="Tahoma">
													    <asp:button id="btnLogin" runat="server" Text=":: Login :: " Width="76px" 
                                                            style="height: 26px"></asp:button>                                        
                                                            <asp:HiddenField ID="hdResponse" runat="server" />
                                                        <div Style="display:none">
                                                            <asp:Button ID="btnLogin1" runat="server" Text="เข้าสู่ระบบ"  />
                                                        </div>
												    </font></TD>
											    </TR>
									        </TABLE>
									    </form>
								    </TD>
							    </TR>
						      </TABLE>
						  </TD>
					  </TR>
			      </TABLE>
				  <div align="right"><font face="Tahoma"><img src="../images/SDT.JPG" width="510" 
                          height="55"><br>
                  <br>
                  <br>
                  <br>
                        <font color="#FFFFFF">.
                </font></font> </div></TD>
			</TR>
		</TABLE>
	</body>
</HTML>