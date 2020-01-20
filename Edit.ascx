<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="GIBS.Modules.DistributorLocator.Edit" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<div>
    <asp:Label ID="Label1" runat="server" Text="" CssClass="NormalRed"></asp:Label> </div>

<div class="dnnForm" id="form-distributor">
        <div style="float:right;"> <asp:LinkButton ID="cmdUpdate" resourcekey="cmdSave" runat="server" OnClick="cmdSave_Click"
                CssClass="btn btn-sm btn-primary" />
                <a href='javascript:history.go(-1)' class="btn btn-sm btn-primary">Cancel</a>
                
                </div>
        
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtDistributor" ResourceKey="lblDistributor" />
            <asp:TextBox runat="server" ID="txtDistributor" />
            
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtContact" ResourceKey="lblContact" />
            <asp:TextBox runat="server" ID="txtContact" />
            
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtAddress" ResourceKey="lblAddress" />
            <asp:TextBox runat="server" ID="txtAddress" />
            
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtCity" ResourceKey="lblCity" />
            <asp:TextBox runat="server" ID="txtCity" />
            
        </div>		
		
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="ddlState" ResourceKey="lblState" />
            <asp:DropDownList runat="server" ID="ddlState">
            </asp:DropDownList>
        </div>
		
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtZipCode" ResourceKey="lblZipCode" />
            <asp:TextBox runat="server" ID="txtZipCode" />
            
        </div>	
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtPhone" ResourceKey="lblPhone" />
            <asp:TextBox runat="server" ID="txtPhone" />
            
        </div>	
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtFax" ResourceKey="lblFax" />
            <asp:TextBox runat="server" ID="txtFax" />
        </div>

		
		
		
		<div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtEmail" ResourceKey="lblEmail" />
            <asp:TextBox runat="server" ID="txtEmail" />
        </div>		

		<div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtWebsite" ResourceKey="lblWebsite" />
            <asp:TextBox runat="server" ID="txtWebsite" />
        </div>	

		<div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtEmail2" ResourceKey="lblEmail2" />
            <asp:TextBox runat="server" ID="txtEmail2" />
        </div>			
		
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="cbxIsDistributor" ResourceKey="lblIsDistributor" />
            <asp:CheckBox runat="server" ID="cbxIsDistributor" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="cbxIsActive" ResourceKey="lblIsActive" />
            <asp:CheckBox runat="server" ID="cbxIsActive" />
        </div>
		
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="ddlDistributorType" ResourceKey="lblDistributorType" />
            <asp:DropDownList runat="server" ID="ddlDistributorType">
            </asp:DropDownList>
        </div>		
		
		<div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtComments" ResourceKey="lblComments" />
            <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" />
        </div>			
				
		
    </fieldset>
    

    
</div>
