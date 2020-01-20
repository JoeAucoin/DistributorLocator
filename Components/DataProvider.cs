using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace GIBS.DistributorLocator.Components
{
    public abstract class DataProvider
    {

        #region common methods

        /// <summary>
        /// var that is returned in the this singleton
        /// pattern
        /// </summary>
        private static DataProvider instance = null;

        /// <summary>
        /// private static cstor that is used to init an
        /// instance of this class as a singleton
        /// </summary>
        static DataProvider()
        {
            instance = (DataProvider)Reflection.CreateObject("data", "GIBS.DistributorLocator.Components", "");
        }

        /// <summary>
        /// Exposes the singleton object used to access the database with
        /// the conrete dataprovider
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {
            return instance;
        }

        #endregion


        #region Abstract methods

        /* implement the methods that the dataprovider should */

        public abstract IDataReader Distributor_GetLatLongByZipCode(string zipCode);

        public abstract IDataReader Distributor_Search_State(string _state);

        public abstract IDataReader Distributor_GetZipCodesByLatLong(double _LatitudeLow, double _LatitudeHigh, double _LongitudeLow, double _LongitudeHigh);

        public abstract IDataReader Distributor_Search_Zips(string _zipCodeCSV);

        public abstract IDataReader Distributor_GetDistributor(int itemID);

        public abstract void Distributor_Update(int itemId, string distributor, string contact, string address, string city, string state, string zipCode, string phone, string fax, string email, string website, string email2, string isDistributor, int distributorTypeID, string isActive, string comments);

        public abstract IDataReader Distributor_Type_GetList();


        //public abstract IDataReader GetDistributorLocators(int moduleId);
        //public abstract IDataReader GetDistributorLocator(int moduleId, int itemId);
        //public abstract void AddDistributorLocator(int moduleId, string content, int userId);
        //public abstract void UpdateDistributorLocator(int moduleId, int itemId, string content, int userId);
        //public abstract void DeleteDistributorLocator(int moduleId, int itemId);

        #endregion

    }



}
