using System;
using DotNetNuke.Entities.Modules;
using GIBS.DistributorLocator.Components;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Common;

namespace GIBS.Modules.DistributorLocator
{
    public partial class Details : PortalModuleBase
    {

        public string _distributor = "";
        public string _city = "";
        public string _state;
        public string _zipCode;
        public string _GoogleMapKey;        //GET FROM MODULE SETTINGS
        public string _AddressToMap = "";

        public string _pageTitle = "";


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);



        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLinkNewSearch.NavigateUrl = Globals.NavigateURL(TabId);
            

            LoadSettings();
            GetDistributor();
        }


        public void GetDistributor()
        {
            try
            {

                DistributorLocatorController controller = new DistributorLocatorController();
                DistributorLocatorInfo item = controller.Distributor_GetDistributor(Int32.Parse(Request.QueryString["Distributor"].ToString()));

                lblDistributor.Text = item.Distributor.ToString();
                lblAddress.Text = item.FullAddress.ToString();
                lblPhone.Text = "Phone: " + item.Phone.ToString();
                lblFax.Text = "Fax: " + item.Fax.ToString();
                if (item.Contact.ToString().Length > 3)
                {
                    lblContact.Text = "Contact: " + item.Contact.ToString();
                }

                //WebSite Link
                
                if (item.Website.ToString().Length > 6)
                {
                    hyperlinkWebSite.NavigateUrl = "http://" + item.Website.ToString();
                    hyperlinkWebSite.Target = "_blank";
                }
                else
                {
                    hyperlinkWebSite.Visible = false;
                }

                // EMAIL LINK
                if (item.Email.ToString().Length > 6)
                {
                    HyperLinkEmail.NavigateUrl = "mailto:" + item.Email.ToString() + "?subject=Product%20Inquiry";
                }
                else
                {
                    HyperLinkEmail.Visible = false;
                }

                ModuleConfiguration.ModuleTitle = item.Distributor.ToString() + " in " + item.City.ToString() + ", " + item.State.ToString();
                DotNetNuke.Framework.CDefault GIBSpage = (DotNetNuke.Framework.CDefault)this.Page;
                GIBSpage.Title = _pageTitle.ToString().Replace("[Distributor]", item.Distributor.ToString()).Replace("[City]", item.City.ToString()).Replace("[State]", item.State.ToString()).ToString();
                
           //    GIBSpage.Title = "Lab-metal Distributor " + item.Distributor.ToString() + " in " + item.City.ToString() + ", " + item.State.ToString();


                string _Address = item.Address.ToString() + ", " + item.City.ToString() + ", " + item.State.ToString() + " " + item.ZipCode.ToString();

                _AddressToMap = _Address.ToString().Replace(" ", "+").Replace("&", "%26").ToString();
                //BuildGoogleMap(_Address.ToString());

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        public void LoadSettings()
        {
            try
            {

                DistributorLocatorSettings settingsData = new DistributorLocatorSettings(this.TabModuleId);


                if (settingsData.PageTitleDetails != null)
                {
                    _pageTitle = settingsData.PageTitleDetails.ToString();
                }
                
                if (settingsData.GoogleMapAPIKey != null)
                {
                    _GoogleMapKey = settingsData.GoogleMapAPIKey.ToString();
                }


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


   

    }
}