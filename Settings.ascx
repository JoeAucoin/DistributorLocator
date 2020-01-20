<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.DistributorLocator.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>

<div class="dnnForm" id="form-settings">

    <fieldset>

<dnn:sectionhead id="sectGeneralSettings" cssclass="Head" runat="server" text="General Settings" section="GeneralSection"
	includerule="False" isexpanded="True"></dnn:sectionhead>

<div id="GeneralSection" runat="server">   
            
                    
                    		
	<div class="dnnFormItem">					
	<dnn:label id="lblNumPerPage" runat="server" controlname="ddlNumPerPage" suffix=":"></dnn:label>
	<asp:DropDownList ID="ddlNumPerPage" runat="server">
		<asp:ListItem Text="2" Value="2"></asp:ListItem>
		<asp:ListItem Text="5" Value="5"></asp:ListItem>
		<asp:ListItem Text="10" Value="10"></asp:ListItem>
        <asp:ListItem Text="12" Value="12"></asp:ListItem>
		<asp:ListItem Text="20" Value="20"></asp:ListItem>
			<asp:ListItem Text="30" Value="30"></asp:ListItem>
		<asp:ListItem Text="40" Value="40"></asp:ListItem>
		<asp:ListItem Text="50" Value="50"></asp:ListItem>
		<asp:ListItem Text="100" Value="100"></asp:ListItem>

		</asp:DropDownList>			
				
	</div>	



    <div class="dnnFormItem">					
        <dnn:label id="lblShowDataList" runat="server" controlname="cbxShowDataList" suffix=":"></dnn:label>
        <asp:CheckBox ID="cbxShowDataList" runat="server" />
    </div>


	<div class="dnnFormItem">					
        <dnn:label id="lblShowDataGrid" runat="server" controlname="cbxShowDataGrid" suffix=":"></dnn:label>
        <asp:CheckBox ID="cbxShowDataGrid" runat="server" />
    </div>

	<div class="dnnFormItem">					
        <dnn:label id="lblPageTitleList" runat="server" controlname="txtPageTitleList" suffix=":"></dnn:label>
        <asp:TextBox ID="txtPageTitleList" runat="server" />
    </div>		
	
	<div class="dnnFormItem">					
        <dnn:label id="lblPageTitleDetails" runat="server" controlname="txtPageTitleDetails" suffix=":"></dnn:label>
        <asp:TextBox ID="txtPageTitleDetails" runat="server" />
    </div>	

    <div class="dnnFormItem">
        <dnn:label id="lblGoogleMapAPIKey" runat="server" controlname="txtGoogleMapAPIKey" suffix=":"></dnn:label>
            <asp:textbox id="txtGoogleMapAPIKey" cssclass="NormalTextBox" runat="server" />		
    </div>


 </div>
        			


    </fieldset>

</div>
