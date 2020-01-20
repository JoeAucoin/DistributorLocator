using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Common.Controls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.ClientCapability;
using GIBS.DistributorLocator.Components;
using DotNetNuke.Common;
using System.Text;
using System.Web.Services;

using System.Collections.Specialized;
using System.Data;
using System.ComponentModel;
using DotNetNuke.Common.Lists;

namespace GIBS.Modules.DistributorLocator
{
    public partial class Search : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                GetStates();
                CreateStatePlaceholder();
                ModuleConfiguration.ModuleTitle = "Search Distributors";
            }

        }

        public void GetStates()
        {

            try
            {
                var _states = new ListController().GetListEntryInfoItems("Region", "Country.US", this.PortalId);

                ddlStates.DataTextField = "Text";
                ddlStates.DataValueField = "Value";
                ddlStates.DataSource = _states;
                ddlStates.DataBind();
                ddlStates.Items.Insert(0, new ListItem("--", ""));
                //      ddlStates.SelectedValue = "MA";


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void cmdSearchZipCode_Click(object sender, EventArgs e)
        {
            StringBuilder queryString = new StringBuilder(64);

            queryString.Append("pg").Append("/").Append("List");

            if (ddlStates.SelectedValue.ToString().Length > 0)
            {
                if (queryString.Length > 0)
                {
                    queryString.Append("/");
                }
                queryString.Append("State").Append("/").Append(ddlStates.SelectedValue.ToString());
            }

            else
            {
                if (txtZipCode.Text.ToString().Length > 0)
                {
                    if (queryString.Length > 0)
                    {
                        queryString.Append("/");
                    }
                    queryString.Append("ZipCode").Append("/").Append(txtZipCode.Text.ToString());
                    queryString.Append("/");
                    queryString.Append("Radius").Append("/").Append(ddlSearchRadius.SelectedValue.ToString());
                }

            }
            

            string vLink = "";



            vLink = Globals.NavigateURL(TabId, "View", queryString.ToString());
            vLink = vLink.ToString().Replace("ctl/View/", "");

            //// FOR DEBUGGING
            lblFormMessage.Visible = true;
            lblFormMessage.Text = queryString.ToString() + " <br />" + vLink.ToString() + " <br />tabID=" + TabId.ToString();

            Response.Redirect(vLink.ToString());
        }

        public void CreateStatePlaceholder()
        {

            try
            {

                var _states = new ListController().GetListEntryInfoItems("Region", "Country.US", this.PortalId);


                
                LiteralControl myHtml1 = new LiteralControl();
                myHtml1.Text = "<h5>United States</h5>";
                PlaceHolderStateLinks.Controls.Add(myHtml1);

                LiteralControl myHtml = new LiteralControl();
                myHtml.Text = "<div class=\"StateLinks\">";
                PlaceHolderStateLinks.Controls.Add(myHtml);
                foreach (DotNetNuke.Common.Lists.ListEntryInfo item in _states)
                {
                   
                    HyperLink hyp = new HyperLink();
                    hyp.ID = item.Text.ToString();
                    hyp.NavigateUrl = CreateStateLink(item.Value.ToString().Replace("US-", "").ToString());
                    hyp.Text = item.Text.ToString();

                    LiteralControl mySeperator = new LiteralControl();
                    mySeperator.Text = " | ";
                   
                    PlaceHolderStateLinks.Controls.Add(hyp);
                    PlaceHolderStateLinks.Controls.Add(mySeperator);
                    
                }
                LiteralControl myHtml2 = new LiteralControl();
                myHtml2.Text = "</div>";
                PlaceHolderStateLinks.Controls.Add(myHtml2);


                var _canada = new ListController().GetListEntryInfoItems("Region", "Country.CA", this.PortalId);
                
                LiteralControl myHtml3 = new LiteralControl();
                myHtml3.Text = "<h5>Canada</h5><div class=\"StateLinks\">";
                PlaceHolderStateLinks.Controls.Add(myHtml3);
                foreach (DotNetNuke.Common.Lists.ListEntryInfo item in _canada)
                {
                    HyperLink hyp = new HyperLink();
                    hyp.ID = item.Text.ToString();
                    hyp.NavigateUrl = CreateStateLink(item.Value.ToString().Replace("CA-", "").ToString());
                    hyp.Text = item.Text.ToString();

                    LiteralControl mySeperator = new LiteralControl();
                    mySeperator.Text = " | ";

                    PlaceHolderStateLinks.Controls.Add(hyp);
                    PlaceHolderStateLinks.Controls.Add(mySeperator);

                }
                LiteralControl myHtml4 = new LiteralControl();
                myHtml4.Text = "</div>";
                PlaceHolderStateLinks.Controls.Add(myHtml4);


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        //PlaceHolderStateLinks
        public string CreateStateLink(string _state)
        {

            try
            {

                StringBuilder queryString = new StringBuilder(64);
                queryString.Append("pg").Append("/").Append("List");
                queryString.Append("/State/").Append(_state.ToString());

                string vLink = "";

                vLink = Globals.NavigateURL(TabId, "View", queryString.ToString());
                vLink = vLink.ToString().Replace("ctl/View/", "");

                return vLink.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
                return "";
            }

        }


    }
}