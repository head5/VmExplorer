using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelperLibrary.B_Entity;
using HelperLibrary.B_Logic;

namespace WebRole.B_UI
{
    public partial class VMConfiguration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VMRequestHelper vmReqHelper = new VMRequestHelper();
                PopulateVMInstanceSizes(vmReqHelper);
                PopulateVMOSImages(vmReqHelper);
                PopulateLocations(vmReqHelper);
                lblMessage.Text = "Set VM Configuration....";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Reset("Set VM Configuration....");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/B_UI/VMDashBoard.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateVMConfiguration())
            {
                VMDetails vmConfiguration = new VMDetails();
                vmConfiguration.MID = ((User)Session["USER"]).MID;
                vmConfiguration.ServiceName = ((User)Session["USER"]).Domain;
                vmConfiguration.ImageName = ddImageList.Text;
                vmConfiguration.InstanceSize = ddInstanceSizes.Text;
                vmConfiguration.VMName = txtVMName.Text;
                vmConfiguration.Location = ddLocation.SelectedValue;
                vmConfiguration.Status = GetDefaultVMRequestStatus();

                VMRequestHelper vmReqHelper = new VMRequestHelper();
                if (vmReqHelper.AddVMRequest(vmConfiguration))
                {
                    Response.Redirect("~/B_UI/VMDashBoard.aspx");
                }
                else
                {
                    Reset("VM Request Failed. Contact Administrator.");
                }
            }
        }

        /// <summary>
        /// Gets the list of Locations and populated the dropdown
        /// </summary>
        /// <param name="vmReqHelper">Object of helper</param>
        private void PopulateLocations(VMRequestHelper vmReqHelper)
        {
            List<Location> locations = vmReqHelper.GetLocations();

            ddLocation.Items.Add(new ListItem("--------- Select Location ----", "-1"));
            foreach (Location location in locations)
            {
                ddLocation.Items.Add(new ListItem(location.LocationName, location.ID.ToString()));
            }
        }

        /// <summary>
        /// Gets the list of Instance Sizes and populated the dropdown
        /// </summary>
        /// <param name="vmReqHelper">Object of helper</param>
        private void PopulateVMInstanceSizes(VMRequestHelper vmReqHelper)
        {
            List<InstanceSize> vmInstSizes = vmReqHelper.GetInstanceSizes();

            ddInstanceSizes.Items.Add(new ListItem("--------- Select Instance Size ----", "-1"));
            foreach (InstanceSize size in vmInstSizes)
            {
                if (size.IsActive)
                {
                    ddInstanceSizes.Items.Add(new ListItem(size.ToString(), size.ID.ToString()));
                }
            }
        }

        /// <summary>
        /// Runs the PowerShell script and gets the list of OS images
        /// </summary>
        /// <param name="vmReqHelper">List of OS(Win/Ubuntu) images</param>
        private void PopulateVMOSImages(VMRequestHelper vmReqHelper)
        {
            ddImageList.Items.Add(new ListItem("------ Select Image Name ---", "-1"));
            List<string> imagesList = vmReqHelper.GetVMImages();
            foreach (string image in imagesList.Where(img => (img.Contains("Windows-Server") || img.Contains("Ubuntu"))))
            {
                ddImageList.Items.Add(image);
            }
        }

        /// <summary>
        /// Validates the selected configuration
        /// </summary>
        /// <returns>TRUE if valid</returns>
        private bool ValidateVMConfiguration()
        {
            if (txtVMName.Text == null)
            {
                lblMessage.Text = " VM Name can not be blank.";
                return false;
            }
            else if (ddImageList.SelectedIndex == 0)
            {
                lblMessage.Text = "Please select OS ImageName.";
                return false;
            }
            else if (ddInstanceSizes.SelectedIndex == 0)
            {
                lblMessage.Text = "Please select VM InstanceSize";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Clears the data in controls
        /// </summary>
        /// <param name="lblMsg">Message to display in label</param>
        private void Reset(string lblMsg)
        {
            txtVMName.Text = string.Empty;
            ddInstanceSizes.SelectedIndex = -1;
            ddImageList.SelectedIndex = -1;
            ddLocation.SelectedIndex = -1;
            lblMessage.Text = lblMsg;
            txtVMName.Focus();
        }

        /// <summary>
        /// Returns Default VM Request Status
        /// </summary>
        /// <returns>vm request status id</returns>
        private VMRequestStatus GetDefaultVMRequestStatus()
        {
            List<VMRequestStatus> statuses = (List<VMRequestStatus>)Session["StatusTypes"];
            if (statuses.Equals(null))
            {
                statuses = new VMRequestHelper().GetStatusTypesForUser();
            }

            VMRequestStatus status = statuses.First(s => s.Status.Contains("Pending"));
            if (status.Equals(null))
            {
                return (new VMRequestStatus(1, "Pending"));
            }

            return status;
        }
    }
}