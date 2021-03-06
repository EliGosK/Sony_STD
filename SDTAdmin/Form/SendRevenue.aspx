<%@ Page Title="แจ้งรายได้ภาพยนตร์" Language="vb" AutoEventWireup="false" MasterPageFile="CheckerTransaction.Master"
    CodeBehind="SendRevenue.aspx.vb" Inherits="Form.SendRevenue" %>

<%@ Import Namespace="SDTCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfRevenueDate" runat="server" />
    <asp:HiddenField ID="hdfTheaterId" runat="server" />
    <asp:HiddenField ID="hdfMovieId" runat="server" />
    <asp:HiddenField ID="hdfUserId" runat="server" />
    <br />
    <asp:Panel ID="pnlOwner" runat="server">
        <table class="tableDisplay" style="width: 60%">
            <% 
                If GetRequest(ParamList.MovieTypeId) = 1 Then
            %>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    จอที่
                </td>
                <td class="labelTitle">
                    <asp:DropDownList ID="ddlScreen" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    รอบ/เวลา
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlHour" runat="server">
                        <asp:ListItem Selected="True" Value="1">10</asp:ListItem>
                        <asp:ListItem Value="2">11</asp:ListItem>
                        <asp:ListItem Value="3">12</asp:ListItem>
                        <asp:ListItem Value="4">13</asp:ListItem>
                        <asp:ListItem Value="5">14</asp:ListItem>
                        <asp:ListItem Value="6">15</asp:ListItem>
                        <asp:ListItem Value="7">16</asp:ListItem>
                        <asp:ListItem Value="8">17</asp:ListItem>
                        <asp:ListItem Value="9">18</asp:ListItem>
                        <asp:ListItem Value="10">19</asp:ListItem>
                        <asp:ListItem Value="11">20</asp:ListItem>
                        <asp:ListItem Value="12">21</asp:ListItem>
                        <asp:ListItem Value="13">22</asp:ListItem>
                        <asp:ListItem Value="14">23</asp:ListItem>
                        <asp:ListItem Value="15">00</asp:ListItem>
                        <asp:ListItem Value="16">01</asp:ListItem>
                        <asp:ListItem Value="17">02</asp:ListItem>
                        <asp:ListItem Value="18">03</asp:ListItem>
                        <asp:ListItem Value="19">04</asp:ListItem>
                        <asp:ListItem Value="120">05</asp:ListItem>
                        <asp:ListItem Value="21">06</asp:ListItem>
                        <asp:ListItem Value="22">07</asp:ListItem>
                        <asp:ListItem Value="23">08</asp:ListItem>
                        <asp:ListItem Value="24">09</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;:
                    <asp:DropDownList ID="ddlMinute" runat="server">
                        <asp:ListItem Value="1">00</asp:ListItem>
                        <asp:ListItem Value="2">05</asp:ListItem>
                        <asp:ListItem Value="3">10</asp:ListItem>
                        <asp:ListItem Value="4">15</asp:ListItem>
                        <asp:ListItem Value="5">20</asp:ListItem>
                        <asp:ListItem Value="6">25</asp:ListItem>
                        <asp:ListItem Value="7">30</asp:ListItem>
                        <asp:ListItem Value="8">35</asp:ListItem>
                        <asp:ListItem Value="9">40</asp:ListItem>
                        <asp:ListItem Value="10">45</asp:ListItem>
                        <asp:ListItem Value="11">50</asp:ListItem>
                        <asp:ListItem Value="12">55</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    ประเภทการฉาย
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Value="ปกติ">ปกติ</asp:ListItem>
                        <asp:ListItem Value="รอบพิเศษ">รอบพิเศษ</asp:ListItem>
                        <asp:ListItem Value="รอบเหมา">รอบเหมา</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle">
                </td>
                <td class="tdInput">
                </td>
            </tr>
            <%
            End If
            %>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlDetail" runat="server">
        <table class="tableDisplay" style="width: 60%">
            <tr>
                <td class="tdTitle" style="width: 100px">
                    สถานะ
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="3">ยอดเบื้องต้น</asp:ListItem>
                        <asp:ListItem Value="2">ยอดจริง</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    ระบบฟิล์ม/เสียง
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlFilmTypeSound" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    รายได้<br />
                    (บาท)
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtRevenue" runat="server" MaxLength="9">0</asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    ผู้ชม<br />
                    (คน)
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtViewer" runat="server" MaxLength="4">0</asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlDetailCompetitor" runat="server">
            <table class="tableDisplay" style="width: 60%">
                <tr>
                    <td class="tdTitle" style="width: 100px">
                        จำนวนจอ<br />
                    </td>
                    <td class="tdInput">
                        <asp:TextBox ID="txtCountScreen" runat="server" MaxLength="6">0</asp:TextBox>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="tdTitle" style="width: 100px">
                        จำนวนรอบ<br />
                    </td>
                    <td class="tdInput">
                        <asp:TextBox ID="txtCountSession" runat="server" MaxLength="6">0</asp:TextBox>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="pnlCompetitorPreData" runat="server">
        <table class="tableDisplay" style="width: 60%">
            <tr>
                <td class="tdTitle" style="width: 100px">
                    รายได้<br />
                    ทั้งหมด<br />
                    (บาท)
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtAllRevenue" runat="server" MaxLength="9">0</asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    ผู้ชม<br />
                    ทั้งหมด<br />
                    (คน)
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtAllViewer" runat="server" MaxLength="4">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    จำนวนจอ<br />
                    ทั้งหมด<br />
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtAllScreen" runat="server" MaxLength="6">0</asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 100px">
                    จำนวนรอบ<br />
                    ทั้งหมด<br />
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtAllSession" runat="server" MaxLength="6">0</asp:TextBox>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Label ID="lblErrorDuplicate" runat="server" CssClass="labelError" Visible="False"
        Text="โรงและรอบ หรือ ระบบฟิล์มที่เลือก มีข้อมูลแล้ว<br />กรุณาตรวจสอบ !"></asp:Label>
    <asp:Label ID="lblErrorRevenue" runat="server" CssClass="labelError" Visible="False"
        Text="ยอดรายได้ไม่สัมพันธ์กับจำนวนคน<br />กรุณาตรวจสอบ !"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnSend" runat="server" Text="Update" CssClass="ButtonDefualt" />&nbsp;
    <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="ButtonDefualt" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ButtonDefualt" />
</asp:Content>
