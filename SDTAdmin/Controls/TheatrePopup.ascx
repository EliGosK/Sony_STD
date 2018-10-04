<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="TheatrePopup.ascx.vb"
    Inherits=".TheatrePopup" %>
<style type="text/css">
    .style1
    {
        height: 25px;
    }
</style>

<asp:TextBox ID="txtCode" runat="server"  Width="75px" Font-Size="12px" Font-Names="Tahoma" ></asp:TextBox>
<img id="btnFind<%=this.ClientID%>" src="../Images/search1.png" style="cursor: hand;
    vertical-align: middle" onclick="btnFind<%=this.ClientID%>Click()" />
<asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="160px" BackColor="LightGray"
    ForeColor="#666666" Font-Size="12px" Font-Names="Tahoma"></asp:TextBox>
<%--display:none;--%>
<asp:Label ID="lblDataNotFound" Font-Names="Tahoma" runat="server" Text="Data not found."
    ForeColor="Red" Font-Size="10pt"></asp:Label>


<div id="div<%=this.ClientID%>" style="display:none; width: 400px; position: absolute;
    border: solid 1px black; background-color: white; filter: progid:DXImageTransform.Microsoft.dropshadow(OffX=4, OffY=4, Color='gray', Positive='true');">
    <div style="background-color: #405d89; border-color: Gray; text-align: center;">
        <table width="400">
            <tr>
                <td align="center" style="background-color: #405d89; border-color: Gray; color: White;
                    font-family: tahoma; font-weight: bold; font-size: small;">
                    Theatre
                </td>
                <td align="right" width="15" onclick="Hide<%=this.ClientID%>();">
                    <span style="background-color: #405d89; border-color: Gray; color: red; cursor: hand;
                        font-weight: bold; font-family: Tahoma; font-size: x-small; filter: progid:DXImageTransform.Microsoft.dropshadow(OffX=1, OffY=1, Color='black', Positive='true');">
                        &nbsp;X&nbsp;</span>
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: Azure;">
        <table width="400">
            <tr>
                <td align="left">
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" DataKeyNames="theater_id"
                        DataSourceID="sqlMovies" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma"
                        Font-Size="Small" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemStyle ForeColor="Blue" Font-Names="Tahoma" Font-Size="9pt" HorizontalAlign="Center"
                                    Width="70px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="true" CausesValidation="False"
                                        CommandName="Select" Text="Select" CommandArgument='<%# Bind("theater_id") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="theater_id"  HeaderText="Theatre I.D." ItemStyle-HorizontalAlign="Center"
                                ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" SortExpression="theater_id"
                                ItemStyle-Font-Names="Tahoma" ItemStyle-Font-Size="12px" />
                            <asp:HyperLinkField DataTextField="theater_code"  Visible="false" DataTextFormatString="{0:ddd dd-MMM-yyyy}"    
                                HeaderText="Theatre Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                SortExpression="theater_code" ItemStyle-Width="130px" ItemStyle-Font-Names="Tahoma"
                                ItemStyle-Font-Size="12px" />
                            <asp:HyperLinkField DataTextField="theater_name" DataTextFormatString="{0:ddd dd-MMM-yyyy}"  
                                HeaderText="Theatre" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"
                                SortExpression="theater_name"  ItemStyle-Font-Names="Tahoma"
                                ItemStyle-Font-Size="12px" />
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Bold="True"
                            Font-Size="14pt" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                            Font-Size="Small" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                            Font-Size="10" HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" Font-Names="Tahoma" Font-Size="Small" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Names="Tahoma" Font-Size="Small" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="sqlMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>">
                    </asp:SqlDataSource>
                    <asp:HiddenField ID="txtCode1" runat="server" />
                </td>
            </tr>
        </table>
        <asp:Button runat="server" id="onBlurCode" style=" display:none"></asp:Button>
    </div>
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="353px" OnRowCommand="GridView1_RowCommand" 
BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
GridLines="None" Font-Names="tahoma" Font-Size="10pt" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemStyle ForeColor="Blue" HorizontalAlign="Center" />
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                    Text="select" CommandArgument='<%# Bind("CusId") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="CusCode" DataFormatString="{0}" HeaderText="รหัส" >
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="CusName" DataFormatString="{0}" HeaderText="ชื่อ" >
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>

    </Columns>
    <FooterStyle BackColor="Tan" />
    
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" />
    <AlternatingRowStyle BackColor="PaleGoldenrod" />
</asp:GridView>--%>

</div>
<asp:TextBox ID="txtDisplay" runat="server" Style="display: none" Text=""></asp:TextBox>
<asp:TextBox ID="txtEnabled" runat="server" Style="display: none"></asp:TextBox>
<asp:HiddenField ID="txtStartDate" runat="server" />
<asp:HiddenField ID="txtEndDate" runat="server" />

<script language="javascript" type="text/javascript">
function btnFind<%=this.ClientID%>Click() {
    if( document.getElementById("<%=this.ClientID%>_txtEnabled").value != "False" ) {
        var btn_offset = new ElementOffset(document.all["btnFind<%=this.ClientID%>"])
        div<%=this.ClientID%>.style.left = btn_offset.left;
        div<%=this.ClientID%>.style.top = btn_offset.bottom+5;
        div<%=this.ClientID%>.style.display = "";
        
        var div_offset = new ElementOffset(div<%=this.ClientID%>)
        
        div<%=this.ClientID%>.style.left = btn_offset.left - (div_offset.left - btn_offset.left);
        div<%=this.ClientID%>.style.top = (btn_offset.bottom+5) - (div_offset.top - btn_offset.bottom);
        
        div_offset = new ElementOffset(div<%=this.ClientID%>)
        
        //div_offset.HideIntersecTag("SELECT","<%=this.ClientID%>");
    
        document.getElementById("<%=this.ClientID%>_txtDisplay").value = "display";
    }
}
function Hide<%=this.ClientID%>() {
    div<%=this.ClientID%>.style.display = "none";
    var div_offset = new ElementOffset(div<%=this.ClientID%>)
    div_offset.ShowIntersecTag("<%=this.ClientID%>");
    document.getElementById("<%=this.ClientID%>_txtDisplay").value = "";
}
function <%=this.ClientID%>CodeChange() {
    var txt = document.getElementById("<%=this.ClientID%>_txtCode");
    <%=this.ClientID%>Callback( txt.value, null);
}
function <%=this.ClientID%>ChangeResponse(args,context) {
    var txt = document.getElementById("<%=this.ClientID%>_txtName");
    txt.value = args
    if( args == "" )
    {
        document.getElementById("<%=this.ClientID%>_txtCode").value = "";
    }
}
function <%=this.ClientID%>Restore() {
    if( document.getElementById("<%=this.ClientID%>_txtDisplay").value != "" ) 
    {
        if( document.readyState == "complete" )
           btnFind<%=this.ClientID%>Click();
        else
            setTimeout("<%=this.ClientID%>Restore();",1);
    }
}

<%=this.ClientID%>Restore();



function ElementOffset( srcObj ) {
    this.IsPointInBox = function ( cx, cy ) {
        return( cx >= this.left && cx <= this.right &&  cy >= this.top && cy <= this.bottom )
    }
    
    this.IsIntersec = function ( obj ) {
        if( this.IsPointInBox(obj.left,obj.top) ) return true
        if( this.IsPointInBox(obj.left,obj.bottom) ) return true
        if( this.IsPointInBox(obj.right,obj.top) ) return true
        if( this.IsPointInBox(obj.right,obj.bottom) ) return true
        
        if( obj.IsPointInBox(this.left,this.top) ) return true
        if( obj.IsPointInBox(this.left,this.bottom) ) return true
        if( obj.IsPointInBox(this.right,this.top) ) return true
        if( obj.IsPointInBox(this.right,this.bottom) ) return true
        
        return false
    }
    
    this.HideIntersecTag = function ( tag, SignalCode ) {
		for( var i = 0; i < document.all.length ; i++ ) {
		    var refObj = document.all(i)
		    if( refObj.tagName == tag ) {
		        var refOffset = new ElementOffset( refObj )
//		        alert( refObj.id + "--" + refOffset.ToString() + "==" + this.ToString() )
		        if( this.IsIntersec(refOffset) ) {
		            refObj.style.display = "none"
		            refObj.ElementOffsetSignalCode = SignalCode;
		        }
		    }
		}
    }

    this.ShowIntersecTag = function ( SignalCode ) {
	    for( var i = 0; i < document.all.length ; i++ ) {
             var refObj = document.all(i)
	        if(  refObj.ElementOffsetSignalCode == SignalCode  ) {
	            refObj.style.display = ""
	            refObj.ElementOffsetSignalCode = null;
	        }
	    }
    }
    
    this.ToString = function(){
        return "(" + this.left + "," + this.top + "," + this.right + "," + this.bottom + ")";
    }

	this.x = 0
	this.y = 0
	var refObj = srcObj
	this.width = refObj.offsetWidth
	this.height = refObj.offsetHeight
	while( refObj ) {
        this.x += refObj.offsetLeft
        this.y += refObj.offsetTop
        refObj = refObj.offsetParent
	}
	
	this.left = this.x
	this.right = this.x + this.width
	this.top = this.y
	this.bottom = this.y + this.height
	
}
</script>

