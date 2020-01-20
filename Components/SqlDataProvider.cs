using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace GIBS.DistributorLocator.Components
{
    public class SqlDataProvider : DataProvider
    {


        #region vars

        private const string providerType = "data";
        private const string moduleQualifier = "GIBS_";

        private ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);
        private string connectionString;
        private string providerPath;
        private string objectQualifier;
        private string databaseOwner;

        #endregion

        #region cstor

        /// <summary>
        /// cstor used to create the sqlProvider with required parameters from the configuration
        /// section of web.config file
        /// </summary>
        public SqlDataProvider()
        {
            Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];
            connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

            if (connectionString == string.Empty)
                connectionString = provider.Attributes["connectionString"];

            providerPath = provider.Attributes["providerPath"];

            objectQualifier = provider.Attributes["objectQualifier"];
            if (objectQualifier != string.Empty && !objectQualifier.EndsWith("_"))
                objectQualifier += "_";

            databaseOwner = provider.Attributes["databaseOwner"];
            if (databaseOwner != string.Empty && !databaseOwner.EndsWith("."))
                databaseOwner += ".";
        }

        #endregion

        #region properties

        public string ConnectionString
        {
            get { return connectionString; }
        }


        public string ProviderPath
        {
            get { return providerPath; }
        }

        public string ObjectQualifier
        {
            get { return objectQualifier; }
        }


        public string DatabaseOwner
        {
            get { return databaseOwner; }
        }

        #endregion

        #region private methods

        private string GetFullyQualifiedName(string name)
        {
            return DatabaseOwner + ObjectQualifier + moduleQualifier + name;
        }

        private object GetNull(object field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(field, DBNull.Value);
        }

        #endregion

        #region override methods

        public override IDataReader Distributor_GetLatLongByZipCode(string zipCode)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Distributor_GetLatLongByZipCode"), zipCode);
        }	

        public override IDataReader Distributor_Search_State(string _state)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Distributor_Search_State"), _state);
        }

        public override IDataReader Distributor_GetZipCodesByLatLong(double _LatitudeLow, double _LatitudeHigh, double _LongitudeLow, double _LongitudeHigh)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Distributor_GetZipCodesByLatLong"), _LatitudeLow, _LatitudeHigh, _LongitudeLow, _LongitudeHigh);
        }

        public override IDataReader Distributor_Search_Zips(string _zipCodeCSV)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Distributor_Search_Zips"), _zipCodeCSV);
        }

        public override IDataReader Distributor_GetDistributor(int itemID)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Distributor_GetDistributor"), itemID);
        }

        public override void Distributor_Update(int itemId, string distributor, string contact, string address, string city, string state, string zipCode, string phone, string fax, string email, string website, string email2, string isDistributor, int distributorTypeID, string isActive, string comments)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("Distributor_Update"), itemId, distributor, contact, address, city, state, zipCode, phone, fax, email, website, email2, isDistributor, distributorTypeID, isActive, comments);
        }


        public override IDataReader Distributor_Type_GetList()
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Distributor_Type_GetList"));
        }	

        //public override IDataReader GetDistributorLocators(int moduleId)
        //{
        //    return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("GetDistributorLocators"), moduleId);
        //}

        //public override IDataReader GetDistributorLocator(int moduleId, int itemId)
        //{
        //    return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("GetDistributorLocator"), moduleId, itemId);
        //}

        //public override void AddDistributorLocator(int moduleId, string content, int userId)
        //{
        //    SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("AddDistributorLocator"), moduleId, content, userId);
        //}

        //public override void UpdateDistributorLocator(int moduleId, int itemId, string content, int userId)
        //{
        //    SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("UpdateDistributorLocator"), moduleId, itemId, content, userId);
        //}

        //public override void DeleteDistributorLocator(int moduleId, int itemId)
        //{
        //    SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("DeleteDistributorLocator"), moduleId, itemId);
        //}

        #endregion
    }
}
