using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebRole.B_Entity;
using WebRole.B_Logic;

namespace WebRole.B_UI
{
    public partial class VMConfiguration : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!(Session["USER"] == null))
                //{
                //    signInUser = (User)Session["USER"];
                //}

                User authUser = new User("M1015156", "Anand", "P@ssw0rd1", true, true);
                PopulateVMInstanceSizes();
                PopulateVMOSImages();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtVMName.Text = string.Empty;            
            ddInstanceSizes.SelectedIndex = -1;
            txtVMName.Focus();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/B_UI/VMDashBoard.aspx.cs");
        }

        private void PopulateVMInstanceSizes()
        {
            VMRequestHelper vmReqHelper = new VMRequestHelper();

            List<VMInstanceSize> vmInstSizes = vmReqHelper.GetInstanceSizes();

            ddInstanceSizes.Items.Add(new ListItem("Select Instance Size", "-1"));
            foreach (VMInstanceSize size in vmInstSizes)
            {
                if (size.IsActive)
                {
                    ddInstanceSizes.Items.Add(new ListItem(size.ToString(), size.ID.ToString()));
                }
            }
        }
        private void PopulateVMOSImages()
        {
            VMRequestHelper vmReqHelper = new VMRequestHelper();

            List<string> imagesList = vmReqHelper.GetVMImages();
            foreach (String image in imagesList)
            {
                if(image.Contains("Windows-Server")||image.Contains("Ubuntu"))
                ddImageList.Items.Add(image);
            }

        }
    }
}