using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace GIBS.DistributorLocator.Components
{
    public class DistributorLocatorInfo
    {
        //private vars exposed thro the
        //properties
        private int moduleId;
        private int itemId;
        private string distributor;
        private string contact;
        private string fullAddress;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        private string phone;
        private string fax;
        private string email;
        private string emailLink;
        private string email2;
        private string isDistributor;
        private string isActive;
        private string website;
        private string websiteLink;
        private string distributorType;
        private int distributorTypeID;
        private string comments;

        private float latitude;
        private float longitude;


        private int createdByUser;
        private DateTime createdDate;
        private string createdByUserName = null;


        /// <summary>
        /// empty cstor
        /// </summary>
        public DistributorLocatorInfo()
        {
        }


        #region properties
        //distributorTypeID


        public int DistributorTypeID
        {
            get { return distributorTypeID; }
            set { distributorTypeID = value; }
        }


        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string Distributor
        {
            get { return distributor; }
            set { distributor = value; }
        }

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        public string FullAddress
        {
            get { return fullAddress; }
            set { fullAddress = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string EmailLink
        {
            get
            {

                if (email.Length > 6)
                {
                    emailLink = "<a href='mailto:" + email.ToString() + "?Subject=Alvin%20Products' target='_blank' >E-Mail</a>";
                }
                return emailLink;
            }

        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        //isDistributor
        public string IsDistributor
        {
            get { return isDistributor; }
            set { isDistributor = value; }
        }

        public string IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public string Website
        {
            get {  return website; }
            set { website = value; }
        }

        public string WebsiteLink
        {
            get
            {

                if (website.Length > 6)
                {
                    websiteLink = "<a href='http://" + website.ToString() + "' target='_blank' >Website</a>";
                }
                return websiteLink;
            }

        }
        public string DistributorType
        {
            get { return distributorType; }
            set { distributorType = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public float Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public float Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }	

        public int CreatedByUser
        {
            get { return createdByUser; }
            set { createdByUser = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public string CreatedByUserName
        {
            get
            {
                if (createdByUserName == null)
                {
                    //int portalId = PortalController.GetCurrentPortalSettings().PortalId;
                    //UserInfo user = UserController.GetUser(portalId, createdByUser, false);
                    createdByUserName = "";
                }

                return createdByUserName;
            }
        }

        #endregion
    }
}
