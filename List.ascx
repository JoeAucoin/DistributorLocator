<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="GIBS.Modules.DistributorLocator.List" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/DistributorLocator/css/Stylesheet.css?1=3" />

<style type="text/css">

    .box2 {
    display: inline-block;
    border-style: solid;
    border-width: 0px;
    width: 240px;
    height: 160px;
    margin: 1em;
}

</style>
<div>
<asp:Label ID="lblSearchSummary" runat="server" Text="0 Records Found"></asp:Label> | <asp:HyperLink
    ID="HyperLinkNewSearch" runat="server">New Search</asp:HyperLink>
</div>
<asp:DataList ID="DataList1" runat="server" datakeyfield="ItemID" OnItemDataBound="DataList1_ItemDataBound" RepeatLayout="Flow" RepeatDirection="Horizontal">
  <itemtemplate>
 
  
  <div class="box2">
  <div class="NormalBold"><asp:Label ID="lblDistributor" runat="server" /></div>
  <div class="Normal"><asp:Label ID="lblAddress" runat="server" /></div>
  <div class="Normal"><asp:Label ID="lblPhone" runat="server" /></div>
  <div class="Normal"><asp:Label ID="lblFax" runat="server" /></div>
  <div class="Normal"><asp:Label ID="lblContact" runat="server" Visible="false" /></div>
  <div style="padding-top:10px; padding-left:5px;"><asp:HyperLink ID="hyperlinkDetails" Text="Details" NavigateUrl="" runat="server" CssClass="btn btn-sm btn-primary" /> 
  <asp:HyperLink ID="HyperLinkEdit" runat="server" CssClass="btn btn-sm btn-primary">Edit</asp:HyperLink></div>
  </div>

  </itemtemplate>

</asp:DataList>

<dnn:PagingControl id="PagingControl1" runat="server" Visible="False" BackColor="#FFFFFF" BorderColor="#000000" CssClass="GridPager1" ></dnn:PagingControl>



<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"  
OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
 CssClass="dnnGrid" CellPadding="4" GridLines="None" HorizontalAlign="Center">
    <PagerSettings Position="Bottom" Mode="Numeric"  />
  <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />

 <HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Center" />
    <RowStyle CssClass="dnnGridItem" VerticalAlign="Top" />
    <AlternatingRowStyle CssClass="dnnGridAltItem" VerticalAlign="Top" />
    <EditRowStyle CssClass="dnnFormInput" />
    <SelectedRowStyle CssClass="dnnFormError" />
    <FooterStyle CssClass="dnnGridFooter" />
    <Columns>

        <asp:TemplateField HeaderText="" meta:resourcekey="TemplateFieldResource1">
         <ItemTemplate>
           <asp:LinkButton ID="LinkButtonEdit"    
             CommandArgument='<%# Eval("ItemID") %>' 
             CommandName="Edit" OnCommand="GridView1_lnkDetails" runat="server">View Details</asp:LinkButton>
         </ItemTemplate>
       </asp:TemplateField>
      
        <asp:BoundField HeaderText="Company" DataField="Distributor"></asp:BoundField>
        <asp:BoundField HeaderText="Address" DataField="FullAddress" HtmlEncode="false"></asp:BoundField>
        <asp:BoundField HeaderText="Contact" DataField="Contact"></asp:BoundField>
        <asp:BoundField HeaderText="Phone" DataField="Phone"></asp:BoundField>
        <asp:BoundField HeaderText="Fax" DataField="Fax"></asp:BoundField>
        <asp:BoundField HeaderText="Email" DataField="EmailLink" HtmlEncode="false" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Website" DataField="WebsiteLink" HtmlEncode="false" Visible="false"></asp:BoundField>

    </Columns>
</asp:GridView>
