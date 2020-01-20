using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

namespace GIBS.DistributorLocator.Components
{
    /// <summary>
    /// Provides strong typed access to settings used by module
    /// </summary>
    public class DistributorLocatorSettings
    {
        ModuleController controller;
        int tabModuleId;

        public DistributorLocatorSettings(int tabModuleId)
        {
            controller = new ModuleController();
            this.tabModuleId = tabModuleId;
        }

        protected T ReadSetting<T>(string settingName, T defaultValue)
        {
            Hashtable settings = controller.GetTabModuleSettings(this.tabModuleId);

            T ret = default(T);

            if (settings.ContainsKey(settingName))
            {
                System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                try
                {
                    ret = (T)tc.ConvertFrom(settings[settingName]);
                }
                catch
                {
                    ret = defaultValue;
                }
            }
            else
                ret = defaultValue;

            return ret;
        }

        protected void WriteSetting(string settingName, string value)
        {
            controller.UpdateTabModuleSetting(this.tabModuleId, settingName, value);
        }

        #region public properties

        /// <summary>
        /// get/set template used to render the module content
        /// to the user
        /// </summary>
        public string NumPerPage
        {
            get { return ReadSetting<string>("numPerPage", null); }
            set { WriteSetting("numPerPage", value); }
        }

        public string ShowDataList
        {
            get { return ReadSetting<string>("showDataList", null); }
            set { WriteSetting("showDataList", value); }
        }

        public string ShowDataGrid
        {
            get { return ReadSetting<string>("showDataGrid", null); }
            set { WriteSetting("showDataGrid", value); }
        }

        public string PageTitleList
        {
            get { return ReadSetting<string>("pageTitleList", null); }
            set { WriteSetting("pageTitleList", value); }
        }


        public string PageTitleDetails
        {
            get { return ReadSetting<string>("pageTitleDetails", null); }
            set { WriteSetting("pageTitleDetails", value); }
        }

        public string GoogleMapAPIKey
        {
            get { return ReadSetting<string>("googleMapAPIKey", null); }
            set { WriteSetting("googleMapAPIKey", value); }
        }

        #endregion
    }
}
