<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DatePicker.ascx.vb"
    Inherits="SDT.UserControls.DatePicker" %>
<link rel="stylesheet" type="text/css" href="../js/tigra_calendar/tcal.css" />

<script language="javascript" type="text/javascript" src="../js/tigra_calendar/tcal.js"></script>

<asp:TextBox ID="txtDate" runat="server" class="tcal" Columns="0" BackColor="#FFFFFF"
    ForeColor="#FF9900" Font-Names="Tahoma" Font-Bold="True" ReadOnly="True" Width="100px">
</asp:TextBox>