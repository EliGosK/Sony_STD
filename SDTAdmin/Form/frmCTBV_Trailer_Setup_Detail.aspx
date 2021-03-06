<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_Trailer_Setup_Detail.aspx.vb"
    Inherits=".frmCTBV_Trailer_Setup_Detail" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>SDT Management Information System - Manage Master Data Movie</title>
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
 
        .style2
        {
            font-weight: bold;
            font-size: 14px;
            color: #999999;
            font-family: "Tahoma";
        }
        .style10
        {
            font-weight: bold;
            font-size: 12px;
            color: #ff0000;
            font-family: "Tahoma";
        }
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style28
        {
            font-weight: normal;
        }
        .style25
        {
            width: 15%;
        }
        .style29
        {
            width: 807px;
        }
         .style26
        {
            width: 270px;
        }
        .style27
        {
            width: 79px;
        }
        </style>

    <script language="JavaScript" type="text/JavaScript">
<!--
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
//-->
    </script>

    <meta http-equiv="Content-Type" content="text/html; charset=windows-874">

    <script language="Javascript" src="../js/ColorPicker2.js"></script>

</head>
<body ms_positioning="GridLayout" leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#d3d3d3"
        bgcolor="#cccccc" id="Table2">
        <tr>
            <td width="53%" align="left" bgcolor="#ffffff" style="height: 23px">
                <font color="#000099" face="Tahoma" size="2"><strong>
                    <uc1:ctbvCtlTop ID="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop>
                </strong></font>
            </td>
            <td width="47%" align="right" bgcolor="#ffffff" style="height: 23px">
                <table width="58" border="0">
                    <tr>
                        <td width="52">
                            <a href="frmCTBV_Login.aspx">
                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/images/Exit.png" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            Log Out
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr background="../images/BG7.jpg">
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg" 
                class="style16">
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&nbsp;&gt; <a href="frmCTBV_Menu_Trailer.aspx">
                    Trailer Menu </a>&nbsp;&gt; </b><strong>Trailer Setup Details</strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff" >
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style2">
                                Trailer Setup Details</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="78" align="center" bgcolor="#E2E2E2">
                                        <table border="0" cellspacing="0" bgcolor="#DADADA">
                                            <tr bgcolor="#CCCCCC">
                                                <td width="10%" bordercolor="#DADADA" bgcolor="#DADADA">
                                                   <div align="center" class="style28">
                                                      <a href="frmCTBV_Trailer_Setup.aspx">
                                                        <img src="../images/NewCCC.png" border="0"></a></div> 
                                                </td>
                                                <td bordercolor="#DADADA" bgcolor="#DADADA" class="style25">
                                                   
                                                 
                                                    
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style29">
                                                    &nbsp;</td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style26" valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td bordercolor="#E9E9E9" bgcolor="#DADADA" class="style27" valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td width="50px" bordercolor="#E9E9E9" bgcolor="#DADADA" valign="bottom" class="style25">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <table width="560px">
                                            <tr>
                                                <td style="text-align: left">
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td>
                                                    </td>
                                                            <td style="text-align: right">
     
            <asp:Label ID="Label2" Font-Names="Tahoma" Font-Size="9pt" runat="server"  
            Text="Month:" style="font-weight: 700"></asp:Label>
                                                    <asp:DropDownList ID="ddlMonth" runat="server" 
                                                         EnableTheming="true" Font-Size="9pt"
                                                         Font-Names="Tahoma" 
                                                        ForeColor="Black" Width="50px">
                                                        <asp:ListItem Selected="True"> </asp:ListItem>
                                                        <asp:ListItem >01</asp:ListItem>
                                                        <asp:ListItem>02</asp:ListItem>
                                                        <asp:ListItem>03</asp:ListItem>
                                                        <asp:ListItem>04</asp:ListItem>
                                                        <asp:ListItem>05</asp:ListItem>
                                                        <asp:ListItem>06</asp:ListItem>
                                                        <asp:ListItem>07</asp:ListItem>
                                                        <asp:ListItem>08</asp:ListItem>
                                                        <asp:ListItem>09</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                        <asp:ListItem>11</asp:ListItem>
                                                        <asp:ListItem>12</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblMonth" 
                Font-Names="Tahoma" Font-Size="9pt" runat="server"  
                Text="&amp;nbsp;Year:" style="font-weight: 700"></asp:Label>
            <asp:TextBox ID="txtYear" runat="server" MaxLength="4" Width="61px"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" Width="59px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:GridView ID="grdTrailer" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CellPadding="4" DataKeyNames="setup_no" DataSourceID="sqlTrailer" Font-Names="Tahoma"
                                                        Font-Size="Small" ForeColor="#333333" GridLines="None" Width="550px" 
                                                        PageSize="25" BorderStyle="None">
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <Columns>
                                                            <asp:HyperLinkField DataNavigateUrlFields="setup_no" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-HorizontalAlign="Center" DataNavigateUrlFormatString="frmCTBV_Trailer_Setup.aspx?setup_no={0}"
                                                                DataTextField="setup_no1" HeaderText="Setup No." SortExpression="setup_no1">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:HyperLinkField>
                                                            <asp:BoundField DataField="setup_start_date" HeaderText="Start Date"  HTMLEncode="False"  HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-HorizontalAlign="Center" SortExpression="setup_start_date" DataFormatString="{0:ddd dd-MMM-yyyy}" >
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="setup_end_date" HeaderText="End Date"  HTMLEncode="False"  HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-HorizontalAlign="Center" SortExpression="setup_end_date" DataFormatString="{0:ddd dd-MMM-yyyy}" >
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField ShowHeader="False" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton111" runat="server" CausesValidation="False" CommandName="Del"
                                                                        Text="Delete" OnClientClick="return confirm('Do you want to delete this Trailer Setup?')"
                                                                        CommandArgument='<%# Bind("setup_no") %>' ForeColor="#FF6600"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                                                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"  Font-Size="10"  />
                                                        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    </asp:GridView>
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <%@ register src="../Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="uc1" %>
                            <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                            <asp:SqlDataSource ID="sqlTrailer" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                SelectCommand="Select *,substring(setup_no,7,2)+'-'+substring(setup_no,5,2)+'-'+substring(setup_no,1,4) setup_no1  FROM tblTrailer_Setup_Hdr ORDER BY setup_no DESC"></asp:SqlDataSource>
                            <center>
                                <%--<font color="rosybrown" face="Tahoma" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font></center>--%>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>