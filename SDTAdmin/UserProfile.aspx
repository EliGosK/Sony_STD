<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UserProfile.aspx.vb" Inherits="UserProfile"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Controls/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Controls/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Defult</title>
    <script language="javascript" type="text/javascript" src="js/Common.js"></script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#ff9966" leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
		<form id="Form1" method="post" runat="server">
			<FONT face="Tahoma">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
					</TR>
					<TR>
						<TD>UserName<asp:textbox id="txtUser" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>Password<asp:textbox id="txtPass" runat="server" TextMode="Password"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>ReKey Password
							<asp:TextBox id="txtRepass" runat="server" TextMode="Password"></asp:TextBox>
							<asp:CompareValidator id="CompareValidator1" runat="server" ControlToValidate="txtRepass" ErrorMessage="Please ReKey Password"
								ControlToCompare="txtPass"></asp:CompareValidator></TD>
					</TR>
					<TR>
						<TD>FirstName<asp:textbox id="txtFName" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">SurName<asp:textbox id="txtSName" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">E-Mail<asp:textbox id="txtEmail" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Button id="Button1" runat="server" Text="Register"></asp:Button>
							<asp:Button id="Button5" runat="server" Text="Cancel"></asp:Button></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="Msg" runat="server" EnableViewState="False"></asp:Label></TD>
					</TR>
					<TR>
						<TD>
							<uc1:Footer id="Footer1" runat="server"></uc1:Footer></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
