﻿<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="MoviePopupSN.ascx.vb" Inherits=".MoviePopupSN" %>

<asp:TextBox ID="txtCode" runat="server" Width="75px" > </asp:TextBox>
<img id="btnFind<%=this.ClientID%>" src="../Images/search1.png"  style="cursor:hand;vertical-align:middle" onclick="btnFind<%=this.ClientID%>Click()" /><asp:TextBox 
    ID="txtName" runat="server" ReadOnly="True" Width="320px" 
    BackColor="LightGray"  ForeColor="#666666" ></asp:TextBox>
    <asp:Label ID="lblDataNotFound" runat="server" Text="Data not found." 
    ForeColor="Red" style="font-size:10pt; font-family:Tahoma; "></asp:Label>
    
    <%--display:none--%>
<div id="div<%=this.ClientID%>" style="display:none;position:absolute;border:solid 1px black;background-color:white;
                    filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=4, OffY=4, Color='gray', Positive='true');"
                    >
<div style="background-color:#405d89;text-align:center; border-color:Gray;">
<table width="500">
<tr>
<td align=center  style="font-size:10pt;color:White;font-weight:bold;font-family:Tahoma;" >Movie Data</td>
<td align=right  width="15" onclick="Hide<%=this.ClientID%>();" 
         ><span style="color:red;cursor:hand;font-weight:bold;font-family:Arial;font-size:10pt;
            filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=1, OffY=1, Color='black', Positive='true');">&nbsp;X&nbsp;</span>
            </td>
</tr>
</table>
</div>
<div style="background-color:#c5dff9; color:Black;">
    <table width="500">
    <tr>
        <td><b>
        
            <asp:Label ID="Label4" Font-Bold="true" Font-Names="Tahoma" Font-Size="10pt" runat="server"  
                Text=":: Search criteria ::"></asp:Label>
            </b>                                            
                    </td>
    </tr>
    <tr>
        <td valign="top">
        
            <asp:Label ID="Label1" Font-Names="Tahoma" Font-Bold="true" Font-Size="9pt" runat="server"  
                Text="Title:"></asp:Label>
            <asp:TextBox ID="txtMovies" runat="server" Width="181px" ></asp:TextBox>&nbsp;<asp:ImageButton ID="btnFind" runat="server" ImageUrl="~/Images/Search.gif" 
                OnClick="btnFind_Click" ImageAlign="AbsBottom" Height="20px" 
                Width="21px" />        
        
        <span style="display:none">
            <asp:Label ID="Label2" Font-Bold="true"  Font-Names="Tahoma" Font-Size="9pt" runat="server"  Text="Distibutor:"></asp:Label>
                                                    <asp:DropDownList ID="ddlDistibutor" runat="server" 
                                                         EnableTheming="True" Font-Size="9pt"
                                                         Font-Names="Tahoma" 
                                                        ForeColor="Black" 
                AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="Label3" 
                Font-Names="Tahoma" Font-Size="9pt" runat="server"  
                Text="&amp;nbsp;&amp;nbsp;Studio:"></asp:Label>
            <asp:DropDownList ID="ddlStudio" runat="server" 
                                                       Font-Size="9pt"
                                                        Font-Names="Tahoma" 
                ForeColor="Black" AutoPostBack="True">
                                                    </asp:DropDownList>
            
            <asp:Label ID="Label5" Font-Names="Tahoma" Font-Size="9pt" runat="server" Font-Bold="true"   
                Text="&amp;nbsp;&amp;nbsp;Movie Type:"></asp:Label>
            <asp:DropDownList ID="ddlMovieType" runat="server" 
                Font-Names="Tahoma" ForeColor="Black" AutoPostBack="true" Font-Size="9pt">
                
            </asp:DropDownList>    
                     </span>                               
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: center">
        
            &nbsp;<b>Result : </b>            
            <asp:Label ID="lblResult"  Font-Bold="true"  runat="server" ForeColor="#009900" 
                style="font-weight: 700"></asp:Label>
            &nbsp;<b>record.</b></td>
    </tr>
    <tr>
    <td align="center">
     <FONT face="Tahoma" color="rosybrown" size="1">
    <asp:GridView ID="GridView1" 
        runat="server" AllowSorting="True" 
                                                  AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="movie_id" 
                                                
        Font-Names="Tahoma" Font-Size="9pt" 
                                                  ForeColor="#333333" 
        GridLines="None" Width="500" AllowPaging="True">
                                                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"   />
                                                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                  <Columns>
                                                          <asp:TemplateField ShowHeader="False">
            <ItemStyle ForeColor="Blue" HorizontalAlign="Center"/>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"  Font-Bold="true" CommandName="Select"
                    Text="Select" CommandArgument='<%# Bind("movie_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                                                     <%-- <asp:HyperLinkField DataNavigateUrlFields="movie_id" 
                                                          DataNavigateUrlFormatString="frmctbv_mmd_movie_add.aspx?titleId={0}" 
                                                          DataTextField="MoviesName" HeaderText="Title" 
                                                          SortExpression="MoviesName" />--%>
                                                          
                                                           <asp:BoundField DataField="Movie_Id" HeaderText="Title I.D." ItemStyle-Width="60px" 
                                                          SortExpression="Movie_Id" ItemStyle-HorizontalAlign="Center"  />
                                                          
                                                           <asp:BoundField DataField="MoviesName" HeaderText="Title" ItemStyle-HorizontalAlign="Left" 
                                                          SortExpression="MoviesName" />
                                                          
                                                          <asp:BoundField DataField="studio_name" HeaderText="Studio" ItemStyle-HorizontalAlign="Left" 
                                                          SortExpression="studio_name" />
                                                      <asp:BoundField DataField="distributor_name" HeaderText="Distributor" ItemStyle-HorizontalAlign="Left" 
                                                          SortExpression="distributor_name" />
                                                          
                                                      <%--<asp:BoundField DataField="MovieType_Des" HeaderText="Type" ItemStyle-HorizontalAlign="Left" 
                                                          SortExpression="MovieType_Des" />
                                                      
                                                      <asp:BoundField DataField="movie_statusCode" HeaderText="Status"  ItemStyle-Width="50px" 
                                                          SortExpression="movie_statusCode"  ItemStyle-HorizontalAlign="Center"/>--%>
                                                  </Columns>
                                                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" 
                                                      Font-Bold="True" Font-Size="13pt" />
                                                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"    Font-Size="10" 
                                                      HorizontalAlign="Left" />
                                                  <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                              </asp:GridView>

   </FONT>
        <%-- <asp:HyperLinkField DataNavigateUrlFields="movie_id" 
                                                          DataNavigateUrlFormatString="frmctbv_mmd_movie_add.aspx?titleId={0}" 
                                                          DataTextField="MoviesName" HeaderText="Title" 
                                                          SortExpression="MoviesName" />--%>

<%--<asp:SqlDataSource ID="sqlMovies" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                                >
                </asp:SqlDataSource>--%>
                

                
    </td>
    
    </tr>
    </table>
    <asp:Button runat="server" id="onBlurCode" style=" display:none"></asp:Button>
</div>

<%--                <asp:SqlDataSource ID="sqlDistibutor" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    SelectCommand="SELECT [distributor_name], [distributor_id] FROM [tblDistributor]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlStudio" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    SelectCommand="SELECT studio_id, studio_name FROM tblStudio">
                </asp:SqlDataSource>--%>
</div>
<asp:TextBox ID="txtDisplay" runat="server" style="display:none" Text=""></asp:TextBox>
<asp:TextBox ID="txtEnabled" runat="server" style="display:none"></asp:TextBox>

<asp:HiddenField ID="txtAppearOn" runat="server" />
<asp:HiddenField ID="txtInStatus" runat="server" />
<asp:HiddenField ID="txtSetupNo" runat="server" />

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


