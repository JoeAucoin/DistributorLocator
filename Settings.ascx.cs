using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.DistributorLocator.Components;

namespace GIBS.Modules.DistributorLocator
{
    public partial class Settings : ModuleSettingsBase
    {

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    DistributorLocatorSettings settingsData = new DistributorLocatorSettings(this.TabModuleId);

                    if (settingsData.NumPerPage != null)
                    {
                        ddlNumPerPage.SelectedValue = settingsData.NumPerPage;
                    }

                    if (settingsData.ShowDataList != null)
                    {
                        cbxShowDataList.Checked = Convert.ToBoolean(settingsData.ShowDataList);
                    }

                    if (settingsData.ShowDataGrid != null)
                    {
                        cbxShowDataGrid.Checked = Convert.ToBoolean(settingsData.ShowDataGrid);
                    }

                    if (settingsData.PageTitleDetails != null)
                    {
                        txtPageTitleDetails.Text = settingsData.PageTitleDetails;
                    }

                    if (settingsData.PageTitleList != null)
                    {
                        txtPageTitleList.Text = settingsData.PageTitleList;
                    }
                    
                    if (settingsData.GoogleMapAPIKey != null)
                    {
                        txtGoogleMapAPIKey.Text = settingsData.GoogleMapAPIKey;
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
                DistributorLocatorSettings settingsData = new DistributorLocatorSettings(this.TabModuleId);
                settingsData.NumPerPage = ddlNumPerPage.SelectedValue;
                settingsData.ShowDataList = cbxShowDataList.Checked.ToString();
                settingsData.ShowDataGrid = cbxShowDataGrid.Checked.ToString();
                settingsData.PageTitleDetails = txtPageTitleDetails.Text.ToString();
                settingsData.PageTitleList = txtPageTitleList.Text.ToString();
                settingsData.GoogleMapAPIKey = txtGoogleMapAPIKey.Text.ToString();
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}