using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRole.B_Data;
using WebRole.B_Entity;

namespace WebRole.B_Logic
{
    public class VMRequestHelper
    {
        /// <summary>
        /// Get all types of VM Instance Sizes
        /// </summary>
        /// <returns>All types of VM Instance Sizes</returns>
        public List<VMInstanceSize> GetInstanceSizes()
        {
            return (new DBHelper()).GetVMInstanceSizes();
        }

        public List<string> GetVMImages()
        {
           string errormsg;
           return (new PSHelper()).GetAzureImages(out errormsg);
        }

        public void AddVMRequest()
        { 

        }
    }
}