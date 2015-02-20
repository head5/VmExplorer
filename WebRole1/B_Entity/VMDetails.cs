using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole.B_Entity
{
    public class VMDetails
    {

        private string _VMName;
        private string _ImageName;
        private string _ServiceName;
        private string _InstanceSize;
        private string _Datadisk;
        private string _UserName;
        private string _Passowrd;
        private string _Location;

        public string VMName
        {
            get { return _VMName; }
            set { _VMName = value; }
        }

        public string ImageName
        {
            get { return _ImageName; }
            set { _ImageName = value; }
        }

        public string ServiceName
        {
            get { return _ServiceName; }
            set { _ServiceName = value; }
        }

        public string InstanceSize
        {
            get { return _InstanceSize; }
            set { _InstanceSize = value; }
        }

        public string Datadisk
        {
            get { return _Datadisk; }
            set { _Datadisk = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Passowrd
        {
            get { return _Passowrd; }
            set { _Passowrd = value; }
        }


        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
    }
}