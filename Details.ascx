<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Details.ascx.cs" Inherits="GIBS.Modules.DistributorLocator.Details" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>



<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/DistributorLocator/css/Stylesheet.css" />




<div class="row">
<div class="col-sm-3">
  <div class="NormalBold"><asp:Label ID="lblDistributor" runat="server" /></div>
  <div class="Normal"><asp:Label ID="lblAddress" runat="server" /></div>
  <div class="Normal"><asp:Label ID="lblPhone" runat="server" /></div>
  <div class="Normal"><asp:Label ID="lblFax" runat="server" /></div>
  <div class="Normal"><asp:Label ID="lblContact" runat="server" /></div>
 <div><asp:HyperLink ID="HyperLinkEmail" Text="E-Mail Distributor" runat="server"></asp:HyperLink></div>
  <div style="padding-top:10px; padding-left:10px;"><asp:HyperLink ID="hyperlinkWebSite" Text="Visit Website" NavigateUrl="" runat="server" CssClass="dnnPrimaryAction" /></div>
 

 <div style="padding-top:30px; padding-left:10px;"><asp:HyperLink ID="HyperLinkNewSearch" runat="server">New Search</asp:HyperLink></div>

  </div>
<div class="col-sm-9">



<div class="map-responsive">
	<iframe width="100%" height="500" frameborder="0" style="border:0"
  src="https://www.google.com/maps/embed/v1/search?key=<% = _GoogleMapKey %>&q=<% = _AddressToMap %>&zoom=18&maptype=satellite" allowfullscreen>
    </iframe>
</div>




<div><asp:Label ID="lblMessage" runat="server" Text="" /></div>
     </div>

</div>

<div style="display:none;">End Location: <asp:TextBox ID="tb_endPoint" runat="server"></asp:TextBox></div>
