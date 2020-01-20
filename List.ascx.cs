using System;
using System.Collections.Generic;
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


namespace GIBS.Modules.DistributorLocator
{
    public partial class List : PortalModuleBase
    {
        public string _state;
        public string _radius;
        public string _zipCode;
        public int PageSize = 9;
        public int _CurrentPage = 1;
        public bool _ShowDataList = true;
        public bool _ShowDataGrid = true;

        public string _distributor = "";
        public string _city = "";

        public string _pageTitle = "";

        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            HyperLinkNewSearch.NavigateUrl = Globals.NavigateURL(TabId);
            
            LoadSettings();
            CheckQueryString();
            
        }


        public void CheckQueryString()
        {

            try
            {



                if (Request.QueryString["State"] != null)
                {
                    _state = Request.QueryString["State"].ToString();
                    SearchState();
                }

                if (Request.QueryString["Radius"] != null && Request.QueryString["ZipCode"] != null)
                {
                    _radius = Request.QueryString["Radius"].ToString();
                    _zipCode = Request.QueryString["ZipCode"].ToString();
                    SearchRadius();
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void SearchRadius()
        {

            try
            {

                DistributorLocatorController controller = new DistributorLocatorController();
                // LOOK UP THE LAT/LONG of the ZipCode
                DistributorLocatorInfo item = controller.Distributor_GetLatLongByZipCode(_zipCode.ToString());

                var iRadius = Int32.Parse(_radius.ToString());
                var istartlat = item.Latitude;
                var istartlong = item.Longitude;

                var LatRange = iRadius / 69.04545;      
                var LongRange = iRadius / (((System.Math.Cos(Convert.ToDouble(istartlat * 3.141592653589 / 180)) *6076) / 5280) * 60);

                var LowLatitude = istartlat - LatRange;
                var HighLatitude = istartlat + LatRange;
                var LowLongitude = istartlong - LongRange;
                var HighLongitude = istartlong + LongRange;

                List<DistributorLocatorInfo> items;
                DistributorLocatorController controller1 = new DistributorLocatorController();
                // Get all the ZipCodes with the radius
                items = controller1.Distributor_GetZipCodesByLatLong(LowLatitude, HighLatitude, LowLongitude, HighLongitude);

                var _ZipCodeString = "";
                foreach (DistributorLocatorInfo info in items)
                {
                    _ZipCodeString += info.ZipCode.ToString() + ",";
                }


                List<DistributorLocatorInfo> itemsResults;
                DistributorLocatorController controller2 = new DistributorLocatorController();
                // GET Grid Results
                itemsResults = controller2.Distributor_Search_Zips(_ZipCodeString.ToString());

                if (_ShowDataGrid == true)
                {
                    GridView1.DataSource = itemsResults;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.Visible = false;
                }

                // USED FOR TitleCase
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;


                ModuleConfiguration.ModuleTitle = "Results within " + _radius.ToString() + " miles of " + textInfo.ToTitleCase(item.City.ToString()) + ", " + item.State.ToString() + " " + _zipCode.ToString();

                //DotNetNuke.Framework.CDefault GIBSpage1 = (DotNetNuke.Framework.CDefault)this.Page;
                //// NEED lookup for the city & state of the zipcode entered
                //string _vState = ConvertState(_state.ToString());
                //GIBSpage1.Title = _pageTitle.ToString().Replace("[State]", _vState.ToString());

                if (_ShowDataList == true)
                {
                    if (Request.QueryString["currentpage"] != null)
                    {
                        _CurrentPage = Convert.ToInt32(Request.QueryString["currentpage"].ToString());
                    }
                    else
                    {
                        _CurrentPage = 1;
                    }


                    PagedDataSource objPagedDataSource = new PagedDataSource();
                    objPagedDataSource.DataSource = itemsResults;

                    if (objPagedDataSource.PageCount > 0)
                    {
                        objPagedDataSource.PageSize = PageSize;
                        objPagedDataSource.CurrentPageIndex = _CurrentPage - 1;
                        objPagedDataSource.AllowPaging = true;
                    }

                    DataList1.DataSource = objPagedDataSource;
                    DataList1.DataBind();


                    if (PageSize == 0 || itemsResults.Count <= PageSize)
                    {
                        PagingControl1.Visible = false;
                    }
                    else
                    {
                        PagingControl1.Visible = true;
                        PagingControl1.TotalRecords = itemsResults.Count;
                        PagingControl1.PageSize = PageSize;
                        PagingControl1.CurrentPage = _CurrentPage;
                        PagingControl1.TabID = TabId;
                        PagingControl1.QuerystringParams = GenerateQueryStringParameters(this.Request, "Radius", "ZipCode", "State", "pg");

                    }

                }
                else
                {
                    DataList1.Visible = false;
                    PagingControl1.Visible = false;
                }

                


                lblSearchSummary.Text = "Total Records Found: " + itemsResults.Count.ToString();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;

            if (Request.QueryString["State"] != null)
            {
                SearchState();
            }
            else

            {
                SearchRadius();
            }

            

        }


        public void SearchState()
        {
            try
            {

                List<DistributorLocatorInfo> items;
                DistributorLocatorController controller = new DistributorLocatorController();

                items = controller.Distributor_Search_State(_state.ToString());

                if (_ShowDataGrid == true)
                {
                    GridView1.DataSource = items;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.Visible = false;
                }

                // USED FOR TitleCase
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                if (_ShowDataList == true)
                {
                    if (Request.QueryString["currentpage"] != null)
                    {
                        _CurrentPage = Convert.ToInt32(Request.QueryString["currentpage"].ToString());
                    }
                    else
                    {
                        _CurrentPage = 1;
                    }


                    PagedDataSource objPagedDataSource = new PagedDataSource();
                    objPagedDataSource.DataSource = items;

                    if (objPagedDataSource.PageCount > 0)
                    {
                        objPagedDataSource.PageSize = PageSize;
                        objPagedDataSource.CurrentPageIndex = _CurrentPage - 1;
                        objPagedDataSource.AllowPaging = true;
                    }

                    DataList1.DataSource = objPagedDataSource;
                    DataList1.DataBind();


                    if (PageSize == 0 || items.Count <= PageSize)
                    {
                        PagingControl1.Visible = false;
                    }
                    else
                    {
                        PagingControl1.Visible = true;
                        PagingControl1.TotalRecords = items.Count;
                        PagingControl1.PageSize = PageSize;
                        PagingControl1.CurrentPage = _CurrentPage;
                        PagingControl1.TabID = TabId;
                        PagingControl1.QuerystringParams = GenerateQueryStringParameters(this.Request, "Radius", "ZipCode", "State", "pg");

                    }

                }
                else
                {
                    DataList1.Visible = false;
                    PagingControl1.Visible = false;
                }

                //DotNetNuke.Framework.CDefault GIBSpage = (DotNetNuke.Framework.CDefault)this.Page;
                string _vState = ConvertState(_state.ToString()).ToString();
                ////   string _VpageTitle = _pageTitle.ToString().Replace("[State]", _vState.ToString()).ToString();
                //GIBSpage.Title = _pageTitle.ToString();     //.Replace("[State]", _vState.ToString()).ToString();


                ModuleConfiguration.ModuleTitle = "Search Results for " + _vState.ToString();
                lblSearchSummary.Text = "Total Records Found: " + items.Count.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;

        }

        protected void GridView1_lnkDetails(Object sender, CommandEventArgs e)
        {
            string iStID = e.CommandArgument.ToString();
            Response.Redirect(GetDetailsLink(iStID.ToString()));
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int itemID = (int)GridView1.DataKeys[e.RowIndex].Value;
            e.Cancel = true;

        }


        // PRINT VIEW   
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int itemID = (int)GridView1.DataKeys[e.RowIndex].Value;
            //     Response.Redirect(Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "Edit", "SkinSrc=[G]" + Globals.QueryStringEncode(SkinController.RootSkin + "/" + Globals.glbHostSkinFolder + "/" + "No Skin") + "&mid=" + ModuleId.ToString() + "&ItemId=" + itemID), true);

            // string MyURL =  Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "Edit", "SkinSrc=[G]" + Globals.QueryStringEncode(SkinController.RootSkin + "/" + Globals.glbHostSkinFolder + "/" + "No Skin") + "&mid=" + ModuleId.ToString() + "&ItemId=" + itemID);

        }


        protected void linkButtonFavoritesAddListing_Click(object sender, EventArgs e)
        {
            try
            {
                int MLSnumber = 0;
                LinkButton myButton = sender as LinkButton;

                if (myButton != null)
                {
                    MLSnumber = Convert.ToInt32(myButton.CommandArgument);
                }

                //MlsConnectController controller = new MlsConnectController();
                //MlsConnectInfo item = new MlsConnectInfo();

                //item.Favorite = MLSnumber.ToString();
                //item.FavoriteType = "Listing";
                //item.ModuleId = Int32.Parse(_favoritesModule.ToString());
                //item.UserID = this.UserId;
                //item.EmailSearch = false;

                //controller.MlsConnect_Favorites_Add(item);

                //myButton.Text = "SAVED! - " + item.Favorite.ToString();




            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        protected static string GenerateQueryStringParameters(HttpRequest request, params string[] queryStringKeys)
        {
            StringBuilder queryString = new StringBuilder(64);
            foreach (string key in queryStringKeys)
            {
                if (request.QueryString[key] != null)
                {
                    if (queryString.Length > 0)
                    {
                        queryString.Append("&");
                    }

                    queryString.Append(key).Append("=").Append(request.QueryString[key]);
                }
            }

            return queryString.ToString();
        }

        private string GetAdditionalQueryStringParams()
        {
            throw new NotImplementedException();
        }


        protected void DataList1_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {

            try
            {




                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    StringBuilder queryString = new StringBuilder(64);

                    queryString.Append("pg").Append("/").Append("List");


                    string vLink = "";



                    vLink = Globals.NavigateURL(TabId, "View", queryString.ToString());
                    vLink = vLink.ToString().Replace("ctl/View/", "");

                    //Image GoogleMapImage = (Image)e.Item.FindControl("ImgGoogleStaticMap");
                    
                    //string _mapKey = "AIzaSyBzzsyt7eGq-PH2GH3XDsz1Evtmk1eYBRc";
                    //string _mapAddress = DataBinder.Eval(e.Item.DataItem, "Address").ToString().Replace(",", " ").Replace("#", "").ToString() + ", " + DataBinder.Eval(e.Item.DataItem, "City").ToString() + ", " + DataBinder.Eval(e.Item.DataItem, "State").ToString() + " " + DataBinder.Eval(e.Item.DataItem, "ZipCode").ToString();


                    ////ImgGoogleStaticMap
                    //GoogleMapImage.ImageUrl = "https://maps.googleapis.com/maps/api/staticmap?center=" + _mapAddress.ToString() + "&markers=color:red%7C" + _mapAddress.ToString() + "&zoom=14&size=440x160&key=" + _mapKey.ToString();
                    //GoogleMapImage.AlternateText = DataBinder.Eval(e.Item.DataItem, "Distributor").ToString();
                    //GoogleMapImage.ToolTip = DataBinder.Eval(e.Item.DataItem, "Distributor").ToString();
             
                    
                    // CompanyName  
                    Label _Distributor = (Label)e.Item.FindControl("lblDistributor");
                    _Distributor.Text = DataBinder.Eval(e.Item.DataItem, "Distributor").ToString();

                    // Address  
                    Label _Address = (Label)e.Item.FindControl("lblAddress");
                    _Address.Text = DataBinder.Eval(e.Item.DataItem, "FullAddress").ToString();
                    //+"<br />"
                    //    + DataBinder.Eval(e.Item.DataItem, "Address").ToString() + ""
                    //    + DataBinder.Eval(e.Item.DataItem, "Address").ToString();

                    // Phone  
                    Label _Phone = (Label)e.Item.FindControl("lblPhone");
                    _Phone.Text = "Phone: " + DataBinder.Eval(e.Item.DataItem, "Phone").ToString();

                    // FAX  
                    Label _Fax = (Label)e.Item.FindControl("lblFax");
                    _Fax.Text = "FAX: " + DataBinder.Eval(e.Item.DataItem, "Fax").ToString();

                    //lblContact
                    Label _Contact = (Label)e.Item.FindControl("lblContact");
                    _Contact.Text = "Contact: " + DataBinder.Eval(e.Item.DataItem, "Contact").ToString();
                    

                    // Link - DETAILS
                    HyperLink _WebSite = (HyperLink)e.Item.FindControl("hyperlinkDetails");
                    _WebSite.NavigateUrl = GetDetailsLink(DataBinder.Eval(e.Item.DataItem, "ItemID").ToString());

                    // Link - EDIT HyperLinkEdit
                    HyperLink _Edit = (HyperLink)e.Item.FindControl("HyperLinkEdit");
                    _Edit.NavigateUrl = Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "Edit", "mid=" + ModuleId.ToString() + "&rid=" + DataBinder.Eval(e.Item.DataItem, "ItemID").ToString());

                    if (UserInfo.IsInRole(this.PortalSettings.AdministratorRoleName))
                    {
                        _Edit.Visible = true;
                    }
                    else
                    {
                        _Edit.Visible = false;
                    }



                    //HyperLinkStaticMap
    //                HyperLink _MapLink = (HyperLink)e.Item.FindControl("HyperLinkStaticMap");
    //                _MapLink.NavigateUrl = _WebSite.NavigateUrl.ToString();

                    //// CHECK IF AUTHENTICATED
                    //if (HttpContext.Current.User.Identity.IsAuthenticated)
                    //{
                    //    // lblMarketingRemarks
                    //    Label MarketingRemarks = (Label)e.Item.FindControl("lblMarketingRemarks");
                    //    MarketingRemarks.Text = DataBinder.Eval(e.Item.DataItem, "PublicRemarks").ToString();
                    //}


                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public string GetDetailsLink(string itemID)
        {

            try
            {

                StringBuilder queryString = new StringBuilder(64);
                queryString.Append("pg").Append("/").Append("Details");
                queryString.Append("/Distributor/").Append(itemID.ToString());

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

        public void LoadSettings()
        {
            try
            {

                DistributorLocatorSettings settingsData = new DistributorLocatorSettings(this.TabModuleId);


                if (settingsData.NumPerPage != null)
                {
                    PageSize = Int32.Parse(settingsData.NumPerPage.ToString());
                }

                if (settingsData.ShowDataList != null)
                {
                    if (Convert.ToBoolean(settingsData.ShowDataList) == true)
                    {
                        _ShowDataList = true;
                    }
                    else
                    {
                        _ShowDataList = false;
                    }
                }

                if (settingsData.ShowDataGrid != null)
                {
                    if (Convert.ToBoolean(settingsData.ShowDataGrid) == true)
                    {
                        _ShowDataGrid = true;
                    }
                    else
                    {
                        _ShowDataGrid = false;
                    }
                }

                

                if (settingsData.PageTitleList != null)
                {
                    DotNetNuke.Framework.CDefault GIBSpage1 = (DotNetNuke.Framework.CDefault)this.Page;
                    _pageTitle = settingsData.PageTitleList.ToString();

                    if (Request.QueryString["State"] != null)
                    {
                        string _vState = ConvertState(Request.QueryString["State"].ToString());
                        GIBSpage1.Title = _pageTitle.ToString().Replace("[State]", _vState.ToString()).ToString();
                    }

                    if (Request.QueryString["Radius"] != null && Request.QueryString["ZipCode"] != null)
                    {
                        GIBSpage1.Title = _pageTitle.ToString().Replace("[State]", Request.QueryString["ZipCode"].ToString());
                    }

                }


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        public static string ConvertState(string state)
        {
            switch (state.ToUpper())
            {
                case "AL":
                    return "Alabama";
                case "AK":
                    return "Alaska";
                case "AR":
                    return "Arkansas";
                case "AZ":
                    return "Arizona";
                case "CA":
                    return "California";
                case "CO":
                    return "Colorado";
                case "CT":
                    return "Connecticut";
                case "DE":
                    return "Delaware";
                case "FL":
                    return "Florida";
                case "GA":
                    return "Georgia";
                case "HI":
                    return "Hawaii";
                case "ID":
                    return "Idaho";
                case "IL":
                    return "Illinois";
                case "IN":
                    return "Indiana";
                case "IA":
                    return "Iowa";
                case "KS":
                    return "Kansas";
                case "KY":
                    return "Kentucky";
                case "LA":
                    return "Louisiana";
                case "ME":
                    return "Manie";
                case "MD":
                    return "Maryland";
                case "MA":
                    return "Massachusetts";
                case "MI":
                    return "Michigan";
                case "MN":
                    return "Minnesota";
                case "MS":
                    return "Mississippi";
                case "MO":
                    return "Missouri";
                case "MT":
                    return "Montana";
                case "NE":
                    return "Nebraska";
                case "NV":
                    return "Nevada";
                case "NH":
                    return "New Hampshire";
                case "NJ":
                    return "New Jersey";
                case "NM":
                    return "New Mexico";
                case "NY":
                    return "New York";
                case "NC":
                    return "North Carolina";
                case "ND":
                    return "North Dakota";
                case "OH":
                    return "Ohio";
                case "OK":
                    return "Oklahoma";
                case "OR":
                    return "Oregon";
                case "PA":
                    return "Pennsylvania";
                case "RI":
                    return "Rhode Island";
                case "SC":
                    return "South Carolina";
                case "SD":
                    return "South Dakota";
                case "TN":
                    return "Tennessee";
                case "TX":
                    return "Texas";
                case "UT":
                    return "Utah";
                case "VT":
                    return "Vermont";
                case "VA":
                    return "Virginia";
                case "WA":
                    return "Washington";
                case "WV":
                    return "West Virginia";
                case "WI":
                    return "Wisconsin";
                case "WY":
                    return "Wyoming";

            // CANADA
                case "AB":
                    return "Alberta";
                case "BC":
                    return "British Columbia";
                case "MB":
                    return "Manitoba";
                case "NB":
                    return "New Brunswick";
                case "NL":
                    return "Newfoundland and Labrador";
                case "NS":
                    return "Nova Scotia";
                case "NT":
                    return "Northwest Territories";
                case "NU":
                    return "Nunavut";
                case "ON":
                    return "Ontario";
                case "PE":
                    return "Prince Edward Island";
                case "QC":
                    return "Quebec";
                case "SK":
                    return "Saskatchewan";
                case "YT":
                    return "Yukon";


                default:
                    return state;
            }
        }



    }
}