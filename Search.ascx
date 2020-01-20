<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="GIBS.Modules.DistributorLocator.Search" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/DistributorLocator/css/Stylesheet.css" />

<asp:Label ID="lblFormMessage" runat="server" Text=""></asp:Label>


<div class="dnnForm" id="form-settings">
    <fieldset>

    <div class="Head">Search by Zip Code Radius</div>

         <div style="float:right;">
          <asp:LinkButton ID="cmdSearchZipCode" resourcekey="cmdSearchZipCode" runat="server" OnClick="cmdSearchZipCode_Click"
                CssClass="dnnPrimaryAction" />
         </div>
            <div class="dnnFormItem">
                <dnn:Label ID="lblZipCode" runat="server" ControlName="txtZipCode" Suffix=":" />
                <asp:TextBox ID="txtZipCode" runat="server" />
            </div>
            <div class="dnnFormItem">
                <dnn:Label ID="lblSearchRadius" runat="server" ControlName="ddlSearchRadius" Suffix=":" />
                <asp:DropDownList ID="ddlSearchRadius" runat="server">
                    <asp:ListItem Text="5 Mile Radius" Value="5"></asp:ListItem>
                    <asp:ListItem Text="10 Mile Radius" Value="10"></asp:ListItem>
                    <asp:ListItem Text="20 Mile Radius" Value="20" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="30 Mile Radius" Value="30"></asp:ListItem>
                    <asp:ListItem Text="40 Mile Radius" Value="40"></asp:ListItem>
                    <asp:ListItem Text="50 Mile Radius" Value="50"></asp:ListItem>
                    <asp:ListItem Text="100 Mile Radius" Value="100"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="Head">or Search by State/Province</div>
            <div class="dnnFormItem" style="display:none;">
                <dnn:Label ID="lblStateDropdown" runat="server" ControlName="ddlStates" Suffix=":" />
                <asp:DropDownList ID="ddlStates" runat="server">
                </asp:DropDownList>
            </div>


            
                <asp:PlaceHolder ID="PlaceHolderStateLinks" runat="server"></asp:PlaceHolder>





    </fieldset>
</div>

