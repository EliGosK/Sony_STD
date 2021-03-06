<%@ Page Title="เลือกข้อมูล" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerBase.Master"
    CodeBehind="PreCondition.aspx.vb" Inherits="SDT.Checker.PreCondition" EnableEventValidation="false" %>

<%@ Import Namespace="SDTCommon.Extensions" %>
<%@ Register TagPrefix="ucDatePicker" TagName="DatePicker" Src="~/UserControls/DatePicker.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function changeHeader() {
            //alert("Changed");

            var ddlDetail = document.getElementById('<%= ddlTheater.ClientID %>');
            for (var i = ddlDetail.options.length - 1; i >= 0; i--) {
                ddlDetail.remove(i);
            }

            var ddlHeader = document.getElementById('<%= ddlCircuit.ClientID %>');

            var data = '<%= GetHidenData() %>';
            var lines = data.split(/[;]/);
            for (var j = 0; j < lines.length; j++) {
                var fields = lines[j].split(/[,]/);
                if (fields[0] == ddlHeader.options[ddlHeader.selectedIndex].value) {
                    var newItem = document.createElement('OPTION');
                    newItem.value = fields[1];
                    newItem.text = fields[2].replace(/%2C/gi, ",");
                    ddlDetail.add(newItem);
                }
            }

            getDropDownValue();
        }
        function getDropDownValue() {
            var ddlDetail = document.getElementById('<%= ddlTheater.ClientID %>');
            var hiddenElementRef = document.getElementById('<%= hdfTheaterId.ClientID %>');
            hiddenElementRef.value = ddlDetail.options[ddlDetail.selectedIndex].value;
            //<%= ClientScript.GetPostBackEventReference(ddlTheater, string.Empty) %>;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplay">
        <tr>
            <td class="tdTitle" style="width: 100px">
                เครือ
            </td>
            <td class="tdInput">
                <asp:DropDownList ID="ddlCircuit" runat="server" CssClass="normalFont" Width="100%"
                    ForeColor="#FF9900">
                    <asp:ListItem> </asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 100px">
                โรงภาพยนตร์
            </td>
            <td class="tdInput">
                <asp:DropDownList ID="ddlTheater" runat="server" CssClass="normalFont" Width="100%"
                    OnChange="getDropDownValue()" ForeColor="#FF9900">
                    <asp:ListItem> </asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 100px">
                วันที่
            </td>
            <td class="tdInput">
                <ucDatePicker:DatePicker ID="dpkDate" runat="server" DateFormat="ddd dd/MM/yyyy" />
            </td>
        </tr>
    </table>
    <br />
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnOk" runat="server" Text="ตกลง" CssClass="ButtonDefualt" Width="70px" />
                &nbsp;
                <asp:Button ID="btnLogout" runat="server" Text="ออกจากระบบ" CssClass="ButtonDefualt" />
                <br />
                <asp:Button ID="btnTest" runat="server" Text="Test" CssClass="ButtonNewMsg" 
                    Visible="False" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdfTheaterId" runat="server" />
</asp:Content>
