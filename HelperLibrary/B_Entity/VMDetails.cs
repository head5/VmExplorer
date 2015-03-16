using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelperLibrary.B_Entity
{
    public class VMDetails
    {
        private string _mid;
        private string _vmname;
        private string _imagename;
        private string _servicename;
        private string _instancesize;
        private string _datadisk;
        private string _username;
        private string _passowrd;
        private string _location;
        private VMRequestStatus _status;

        public VMDetails()
        {
        }

        public VMDetails(string mid, string vmName, string vmInstanceSizeId, string imageName, string locationId)
        {
            _mid = mid;
            _vmname = vmName;
            _instancesize = vmInstanceSizeId;
            _imagename = imageName;
            _location = locationId;
        }
               
        public string VMName
        {
            get { return _vmname; }
            set { _vmname = value; }
        }

        public string ImageName
        {
            get { return _imagename; }
            set { _imagename = value; }
        }

        public string ServiceName
        {
            get { return _servicename; }
            set { _servicename = value; }
        }

        public string InstanceSize
        {
            get { return _instancesize; }
            set { _instancesize = value; }
        }

        public string DataDisk
        {
            get { return _datadisk; }
            set { _datadisk = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _passowrd; }
            set { _passowrd = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string MID
        {
            get { return _mid; }
            set { _mid = value; }
        }

        public VMRequestStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}