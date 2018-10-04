<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="TrailerFinder.ascx.vb"
    Inherits="SDT.UserControls.TrailerFinder" %>
<style type="text/css">
    .style1
    {
        font-size: small;
    }
    .txt
    {
        text-align: left;
    }
</style>
<asp:TextBox ID="txtCode" runat="server" Width="25px" Font-Size="8pt"></asp:TextBox>
<img id="btnFind<%=this.ClientID%>" src="../images/search1.png"
    width="10px" style="cursor: hand; vertical-align: middle" onclick="btnFind<%=ClientID%>Click()" /><asp:TextBox
        ID="txtName" runat="server" ReadOnly="True" Width="70px" BackColor="LightGray"
        ForeColor="#666666" Font-Size="8pt" CssClass="txt"></asp:TextBox><%--display:none;--%>
<asp:Label ID="lblDataNotFound" runat="server" Text="<br />ไม่พบข้อมูล" ForeColor="Red"
    Font-Size="8pt"></asp:Label>
<div id="div<%=ClientID%>" style="display: none; width: 210px; position: absolute;
    border: solid 1px black; background-color: white; filter: progid:DXImageTransform.Microsoft.dropshadow(OffX=4, OffY=4, Color='gray', Positive='true');">
    <div style="background-color: RoyalBlue; text-align: center;">
        <table width="100%">
            <tr>
                <td align="center" style="color: White; font-family: Tahoma; font-size: 8pt;">
                    เลือกหนังตัวอย่าง
                </td>
                <td align="right" width="15" onclick="Hide<%=ClientID%>();">
                    <span style="color: red; cursor: hand; font-weight: bold; font-family: Arial; font-size: 10px;
                        filter: progid:DXImageTransform.Microsoft.dropshadow(OffX=1, OffY=1, Color='black', Positive='true');">
                        &nbsp;X&nbsp;</span>
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: Azure;">
        <table width="210">
            <tr>
                <td align="center">
                    <font face="Tahoma" color="rosybrown" size="1">
                        <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="movie_id" Font-Names="Tahoma" Font-Size="7pt" ForeColor="#333333"
                            GridLines="None" Width="210">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle ForeColor="Blue" HorizontalAlign="Center" Font-Size="7pt" Width="10px" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                            Text="เลือก" CommandArgument='<%# Bind("movie_id") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Movie_Id" HeaderText="รหัส" ItemStyle-Width="15px" SortExpression="Movie_Id"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="15px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="MovieName" HeaderText="เรื่อง" SortExpression="MovieName"
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Size="11"
                                Font-Bold="true" />
                            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </font>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnOnBlurCode" Style="display: none"></asp:Button>
    </div>
</div>
<asp:TextBox ID="txtDisplay" runat="server" Style="display: none" Text=""></asp:TextBox>
<asp:TextBox ID="txtEnabled" runat="server" Style="display: none"></asp:TextBox>

<script language="javascript" type="text/javascript">
function btnFind<%=ClientID%>Click() {
    if( document.getElementById("<%=ClientID%>_txtEnabled").value != "False" ) {
        var btnOffset = new ElementOffset(document.all["btnFind<%=ClientID%>"])
        div<%=ClientID%>.style.left = btnOffset.left;
        div<%=ClientID%>.style.top = btnOffset.bottom+5;
        div<%=ClientID%>.style.display = "";
        
        var divOffset = new ElementOffset(div<%=ClientID%>)
        
        div<%=ClientID%>.style.left = btnOffset.left - (divOffset.left - btnOffset.left);
        div<%=ClientID%>.style.top = (btnOffset.bottom+5) - (divOffset.top - btnOffset.bottom);
        
        divOffset = new ElementOffset(div<%=ClientID%>)
        
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

    this.ShowIntersecTag = function ( signalCode ) {
	    for( var i = 0; i < document.all.length ; i++ ) {
             var refObj = document.all(i)
	        if(  refObj.ElementOffsetSignalCode == signalCode  ) {
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
	
	this.left = 10//this.x
	this.right = 10 + this.width
	this.top = this.y
	this.bottom = this.y + this.height
	
}
</script>

