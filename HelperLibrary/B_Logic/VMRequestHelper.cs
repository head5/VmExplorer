using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelperLibrary.B_Data;
using HelperLibrary.B_Entity;

namespace HelperLibrary.B_Logic
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

        public void AddVMRequestToDatabase(VMDetails vmdetails)
        {
            vmdetails.Location = "East Asia";           
            vmdetails.Passowrd = "achiever12!@";
            vmdetails.ServiceName = "MINDTREE";

            new DBHelper().AddVMCreateRequest(vmdetails);
        }

        public void SetupAzureAccount()
        {
            new PSHelper().SetupAzure();
        }

        public void GetPendingRequests()
        {

        }

        public string CreateVM(VMDetails vmDetails) 
        {
            return new PSHelper().createVM(vmDetails);
        }
    }
}