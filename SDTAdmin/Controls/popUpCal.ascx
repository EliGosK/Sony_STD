<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="popUpCal.ascx.vb" Inherits=".popUpCal" %>
<asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
    ForeColor="Black" Height="152px" NextPrevFormat="ShortMonth" Width="216px" 
    Font-Bold="False">
    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
    <TodayDayStyle BackColor="#CCCCCC" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
        VerticalAlign="Bottom" />
    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
        Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
</asp:Calendar>
