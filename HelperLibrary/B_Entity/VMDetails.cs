﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelperLibrary.B_Entity
{
    public class VMDetails
    {

        private string _VMName;
        private string _ImageName;
        private string _ServiceName;
        private int _InstanceSize;
        private string _Datadisk;
        private string _UserName;
        private string _Passowrd;
        private string _Location;
        private string _MID;
        private string _VMSize;

          
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

        public int InstanceSize
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
        public string MID
        {
            get { return _MID; }
            set { _MID = value; }
        }
        public string VMSize
        {
            get { return _VMSize; }
            set { _VMSize = value; }
        }
            

    }
}