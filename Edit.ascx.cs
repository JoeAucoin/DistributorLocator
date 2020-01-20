using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using GIBS.DistributorLocator.Components;
using DotNetNuke.Services.Exceptions;
using System.Globalization;
using System.Threading;
using System.Text;
using DotNetNuke.Common;
using DotNetNuke.Common.Lists;

namespace GIBS.Modules.DistributorLocator
{
    public partial class Edit : PortalModuleBase
    {

        static int _RecordID;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDropDownListStates();

                if (Request.QueryString["rid"] != null)
                {
                    _RecordID = Int32.Parse(Request.QueryString["rid"]);
                    GetRecord(_RecordID);
                }
            }
        }


        public void GetRecord(int _recordID)
        {
            try
            {


                DistributorLocatorController controller = new DistributorLocatorController();
                DistributorLocatorInfo item = controller.Distributor_GetDistributor(_recordID);

                if (item != null)
                {
                    txtDistributor.Text = item.Distributor;
                    txtAddress.Text = item.Address;
                    txtCity.Text = item.City;
                    txtComments.Text = item.Comments;
                    txtContact.Text = item.Contact;
                    txtEmail.Text = item.Email;
                    txtEmail2.Text = item.Email2;
                    txtFax.Text = item.Fax;
                    txtPhone.Text = item.Phone;
                    txtWebsite.Text = item.Website;
                    txtZipCode.Text = item.ZipCode;

                    ddlState.SelectedValue = item.State;
                    ddlDistributorType.SelectedValue = item.DistributorType;

                    if (item.IsDistributor == "y")
                    {
                        cbxIsDistributor.Checked = true;
                    }

                    if (item.IsActive == "y")
                    {
                        cbxIsActive.Checked = true;
                    }

                }



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        public void GetDropDownListStates()
        {

            try
            {
                // Get State Dropdown from DNN Lists
                ListController ctlList = new ListController();
                ListEntryInfoCollection vStates = ctlList.GetListEntryInfoCollection("Region", "Country.US", this.PortalId);
         //      ListEntryInfoCollection vStatesCanada = ctlList.GetListEntryInfoCollection("Region", "Country.CA", this.PortalId);
                
                
                
                //  State
                ddlState.DataTextField = "Value";
                ddlState.DataValueField = "Value";
                ddlState.DataSource = vStates;
            //    ddlState.DataSource = vStatesCanada;
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("--", ""));

                List<DistributorLocatorInfo> items;
                DistributorLocatorController controller = new DistributorLocatorController();

                items = controller.Distributor_Type_GetList();

                ddlDistributorType.DataTextField = "DistributorType";
                ddlDistributorType.DataValueField = "ItemID";
                ddlDistributorType.DataSource = items;
                ddlDistributorType.DataBind();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


  

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {


                DistributorLocatorController controller = new DistributorLocatorController();
                DistributorLocatorInfo item = new DistributorLocatorInfo();

                item.ItemId = _RecordID;
                item.Distributor = txtDistributor.Text.ToString();
                item.Contact = txtContact.Text.ToString();
                item.Address = txtAddress.Text.ToString();
                item.City = txtCity.Text.ToString();
                item.State = ddlState.SelectedValue.ToString();
                item.ZipCode = txtZipCode.Text.ToString();
                item.Phone = txtPhone.Text.ToString(); 
                item.Fax = txtFax.Text.ToString();
                item.Email = txtEmail.Text.ToString();
                item.Website = txtWebsite.Text.ToString();
                item.Email2 = txtEmail2.Text.ToString();
                if (cbxIsDistributor.Checked)
                {
                    item.IsDistributor = "y";
                }
                else
                {
                    item.IsDistributor = "n";
                }
                item.DistributorTypeID = Int32.Parse(ddlDistributorType.SelectedValue.ToString());
                if (cbxIsActive.Checked)
                {
                    item.IsActive = "y";
                }
                else
                {
                    item.IsActive = "n";
                }
                
                item.Comments = txtComments.Text.ToString();
                
                controller.Distributor_Update(item);

                Label1.Text = "UPDATE SUCCESSFUL";

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}