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
        DBHelper dbHelper;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public VMRequestHelper()
        {
            dbHelper = new DBHelper();
        }

        /// <summary>
        /// Get all types of VM Instance Sizes
        /// </summary>
        /// <returns>All types of VM Instance Sizes</returns>
        public List<InstanceSize> GetInstanceSizes()
        {
            return (new DBHelper()).GetVMInstanceSizes();
        }

        /// <summary>
        /// Get the list of OS Images
        /// </summary>
        /// <returns>list of OS Images</returns>
        public List<string> GetVMImages()
        {
            return (new PSHelper()).GetAzureImages();
        }

        /// <summary>
        /// Get list of VM Request Status Types For User
        /// </summary>
        /// <returns>list of expected VM Request Status Type Objects</returns>
        public List<VMRequestStatus> GetStatusTypesForUser()
        {
            List<VMRequestStatus> vmRequestStatus = new List<VMRequestStatus>();

            string[] expectedStatusTypes = { "Pending", "Approved", "Denied" };

            foreach (VMRequestStatus status in vmRequestStatus)
            {
                if (!expectedStatusTypes.Contains(status.Status))
                {
                    vmRequestStatus.Remove(status);
                }
            }
            return vmRequestStatus;
        }

        /// <summary>
        /// Get list of VM Request Status Types For Admin
        /// </summary>
        /// <returns>list of expected VM Request Status Type Objects</returns>
        public List<VMRequestStatus> GetStatusTypesForAdmin()
        {
            List<VMRequestStatus> vmRequestStatus = new List<VMRequestStatus>();

            string[] expectedStatusTypes = { "Pending", "Approved", "Denied" };

            foreach (VMRequestStatus status in vmRequestStatus)
            {
                if (status.Status.Equals("Cancelled"))
                {
                    vmRequestStatus.Remove(status);
                }
            }
            return vmRequestStatus;
        }

        /// <summary>
        /// Get list of expected VM locations
        /// </summary>
        /// <returns>list of Location</returns>
        public List<Location> GetLocations()
        {
            return dbHelper.GetLocations();
        }

        /// <summary>
        /// Adds a Create VM Request
        /// </summary>
        /// <param name="vmDetails">VM Configuration Details</param>
        /// <returns>TRUE if VM request is added</returns>
        public bool AddVMRequest(VMDetails vmDetails)
        {
            return dbHelper.AddVMRequest(vmDetails);
        }

        /// <summary>
        /// Sets Up the Azure Account
        /// </summary>
        public void SetupAzureAccount()
        {
            new PSHelper().SetupAzureUsingRunspace();
        }

        /// <summary>
        /// Creates VM using PowerShell Script
        /// </summary>
        /// <param name="vmDetails">VM Details</param>
        /// <returns>Result of VM Creation attempt</returns>
        public string CreateVM(VMDetails vmDetails)
        {
            return new PSHelper().CreateVM(vmDetails);
        }

        /// <summary>
        /// Get all the VM Request of Current User
        /// </summary>
        /// <param name="userMID">Current Users MID</param>
        /// <param name="statusType">Stats Type</param>
        /// <returns>DataView Populated with Result Data</returns>
        public System.Data.DataView GetUserVMRequests(string userMID, string statusType)
        {
            return (new DBHelper().GetUserVMRequests(userMID, statusType));
        }

        /// <summary>
        /// Cancels the VM Request
        /// </summary>
        /// <param name="requestID">Request ID</param>
        /// <param name="userID">Cancelled by User</param>
        /// <param name="status">Cancelled status object</param>
        /// <returns>TRUE if VM Request is Cancelled</returns>
        public bool CancelVMRequest(int requestID, string userID, VMRequestStatus status)
        {
            return (new DBHelper()).CancelVMRequest(requestID, userID, status);
        }
    }
}