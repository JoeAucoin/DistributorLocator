using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.DistributorLocator.Components
{
    public class DistributorLocatorController : IPortable
    {

        #region public method

        public DistributorLocatorInfo Distributor_GetLatLongByZipCode(string zipCode)
        {
            return (DistributorLocatorInfo)CBO.FillObject(DataProvider.Instance().Distributor_GetLatLongByZipCode(zipCode), typeof(DistributorLocatorInfo));
        }

        public List<DistributorLocatorInfo> Distributor_Search_State(string _state)
        {
            return CBO.FillCollection<DistributorLocatorInfo>(DataProvider.Instance().Distributor_Search_State(_state));
        }

        public List<DistributorLocatorInfo> Distributor_GetZipCodesByLatLong(double _LatitudeLow, double _LatitudeHigh, double _LongitudeLow, double _LongitudeHigh)
        {
            return CBO.FillCollection<DistributorLocatorInfo>(DataProvider.Instance().Distributor_GetZipCodesByLatLong(_LatitudeLow, _LatitudeHigh, _LongitudeLow, _LongitudeHigh));
        }

        public List<DistributorLocatorInfo> Distributor_Search_Zips(string _zipCodeCSV)
        {
            return CBO.FillCollection<DistributorLocatorInfo>(DataProvider.Instance().Distributor_Search_Zips(_zipCodeCSV));
        }

        public DistributorLocatorInfo Distributor_GetDistributor(int itemID)
        {
            return (DistributorLocatorInfo)CBO.FillObject(DataProvider.Instance().Distributor_GetDistributor(itemID), typeof(DistributorLocatorInfo));
        }

        public void Distributor_Update(DistributorLocatorInfo info)
        {
            //check we have some content to update
            if (info.Distributor != string.Empty)
            {
                DataProvider.Instance().Distributor_Update(info.ItemId, info.Distributor, info.Contact, info.Address, info.City, info.State, info.ZipCode, info.Phone, info.Fax, info.Email, info.Website, info.Email2, info.IsDistributor, info.DistributorTypeID, info.IsActive, info.Comments);
            }
        }

        public List<DistributorLocatorInfo> Distributor_Type_GetList()
        {
            return CBO.FillCollection<DistributorLocatorInfo>(DataProvider.Instance().Distributor_Type_GetList());
        }




        /// <summary>
        /// Gets all the DistributorLocatorInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        //public List<DistributorLocatorInfo> GetDistributorLocators(int moduleId)
        //{
        //    return CBO.FillCollection<DistributorLocatorInfo>(DataProvider.Instance().GetDistributorLocators(moduleId));
        //}

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        //public DistributorLocatorInfo GetDistributorLocator(int moduleId, int itemId)
        //{
        //    return (DistributorLocatorInfo)CBO.FillObject(DataProvider.Instance().GetDistributorLocator(moduleId, itemId), typeof(DistributorLocatorInfo));
        //}


        /// <summary>
        /// Adds a new DistributorLocatorInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        //public void AddDistributorLocator(DistributorLocatorInfo info)
        //{
        //    //check we have some content to store
        //    if (info.Content != string.Empty)
        //    {
        //        DataProvider.Instance().AddDistributorLocator(info.ModuleId, info.Content, info.CreatedByUser);
        //    }
        //}

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        //public void UpdateDistributorLocator(DistributorLocatorInfo info)
        //{
        //    //check we have some content to update
        //    if (info.Content != string.Empty)
        //    {
        //        DataProvider.Instance().UpdateDistributorLocator(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
        //    }
        //}


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        //public void DeleteDistributorLocator(int moduleId, int itemId)
        //{
        //    DataProvider.Instance().DeleteDistributorLocator(moduleId, itemId);
        //}


        #endregion

        #region ISearchable Members

        /// <summary>
        /// Implements the search interface required to allow DNN to index/search the content of your
        /// module
        /// </summary>
        /// <param name="modInfo"></param>
        /// <returns></returns>
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
        //{
        //    SearchItemInfoCollection searchItems = new SearchItemInfoCollection();

        //    List<DistributorLocatorInfo> infos = GetDistributorLocators(modInfo.ModuleID);

        //    foreach (DistributorLocatorInfo info in infos)
        //    {
        //        SearchItemInfo searchInfo = new SearchItemInfo(modInfo.ModuleTitle, info.Zip, info.CreatedByUser, info.CreatedDate,
        //                                            modInfo.ModuleID, info.ItemId.ToString(), info.Zip, "Item=" + info.ItemId.ToString());
        //        searchItems.Add(searchInfo);
        //    }

        //    return searchItems;
        //}

        #endregion

        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("nothing here");
            //List<DistributorLocatorInfo> infos = GetDistributorLocators(moduleID);

            //if (infos.Count > 0)
            //{
            //    sb.Append("<DistributorLocators>");
            //    foreach (DistributorLocatorInfo info in infos)
            //    {
            //        sb.Append("<DistributorLocator>");
            //        sb.Append("<content>");
            //        sb.Append(XmlUtils.XMLEncode(info.Zip));
            //        sb.Append("</content>");
            //        sb.Append("</DistributorLocator>");
            //    }
            //    sb.Append("</DistributorLocators>");
            //}

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "DistributorLocators");

            foreach (XmlNode info in infos.SelectNodes("DistributorLocator"))
            {
                DistributorLocatorInfo DistributorLocatorInfo = new DistributorLocatorInfo();
                DistributorLocatorInfo.ModuleId = ModuleID;
                DistributorLocatorInfo.ZipCode = info.SelectSingleNode("zip").InnerText;
                DistributorLocatorInfo.CreatedByUser = UserID;

              //  AddDistributorLocator(DistributorLocatorInfo);
            }
        }

        #endregion
    }
}
