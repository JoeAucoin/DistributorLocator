using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using GIBS.DistributorLocator.Components;
using DotNetNuke.Common.Lists;

namespace GIBS.Modules.DistributorLocator
{
    public partial class ViewDistributorLocator : PortalModuleBase, IActionable
    {
        public string mControlToLoad = "";
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        public void ReadQueryString()
        {

            try
            {


                    if (Request.QueryString["pg"] != null)
                {

                    switch (Request.QueryString["pg"].ToString().ToLower())
                    {

                        case "list":
                            mControlToLoad = "List.ascx";
                            break;

                        case "details":
                            mControlToLoad = "Details.ascx";
                            break;

                        //case "contact":

                        //    mControlToLoad = "Contact.ascx";
                        //    break;

                        ////TellAFriend
                        //case "tellafriend":

                        //    mControlToLoad = "TellAFriend.ascx";
                        //    break;

                        //case "default":

                        //    mControlToLoad = "yourfrontpage.ascx";
                        //    break;

                    }

                }
                else
                {

                    mControlToLoad = "Search.ascx";
                }



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }



        public void LoadControlType()
        {

            try
            {

                PortalModuleBase pmb = (PortalModuleBase)this.LoadControl(mControlToLoad);

                if (pmb != null)
                {

                    pmb.ModuleConfiguration = this.ModuleConfiguration;
                    pmb.ID = System.IO.Path.GetFileNameWithoutExtension(mControlToLoad);
                    PlaceHolder1.Controls.Add(pmb);

                }



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }




        protected void Page_Init(object sender, EventArgs e)
        {

            ReadQueryString();

            LoadControlType();


        }



        #region IActionable Members

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                //create a new action to add an item, this will be added to the controls
                //dropdown menu
                ModuleActionCollection actions = new ModuleActionCollection();
                //actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                //    ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                //     true, false);

                return actions;
            }
        }

        #endregion




        /// <summary>
        /// Handles the items being bound to the datalist control. In this method we merge the data with the
        /// template defined for this control to produce the result to display to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>





    }
}