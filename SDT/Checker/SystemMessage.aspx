<%@ Page Title="ข้อความ" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerBase.Master"
    CodeBehind="SystemMessage.aspx.vb" Inherits="SDT.Checker.SystemMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    ForeColor="#0000CC"></asp:Label>
                <br />
                ---------------------------------------
                <br />
                <asp:Label ID="lblTime" runat="server" Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt"
                    ForeColor="#0033CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="tdOneCenter">
                <asp:RadioButton ID="RadioButton1" runat="server" Text=" 1" Font-Bold="True" GroupName="Ans"
                    BackColor="White" BorderColor="#FFCC99" BorderStyle="Solid" BorderWidth="1px"
                    AutoPostBack="True" />
                &nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Text=" 2" Font-Bold="True"
                    GroupName="Ans" BackColor="White" BorderColor="#FFCC99" BorderStyle="Solid" BorderWidth="1px"
                    AutoPostBack="True" />
                &nbsp;<asp:RadioButton ID="RadioButton3" runat="server" Text=" 3" Font-Bold="True"
                    GroupName="Ans" BackColor="White" BorderColor="#FFCC99" BorderStyle="Solid" BorderWidth="1px"
                    AutoPostBack="True" />
                &nbsp;<asp:RadioButton ID="RadioButton4" runat="server" Text=" 4" Font-Bold="True"
                    GroupName="Ans" BackColor="White" BorderColor="#FFCC99" BorderStyle="Solid" BorderWidth="1px"
                    AutoPostBack="True" />
                &nbsp;<asp:RadioButton ID="RadioButton5" runat="server" Text=" 5" Font-Bold="True"
                    GroupName="Ans" BackColor="White" BorderColor="#FFCC99" BorderStyle="Solid" BorderWidth="1px"
                    AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="ButtonDefualt" Width="90px" />&nbsp;
                <asp:Button ID="btnMainMenu" runat="server" Text="กลับเมนูหลัก" CssClass="ButtonDefualt"
                    Width="90px" />
            </td>
        </tr>
    </table>
</asp:Content>
