using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelperLibrary.B_Entity;
using HelperLibrary.B_Logic;

namespace WebRole.B_UI
{
    public partial class AdminVMDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.EmptyDataText = "NO Records Found";

        }

        protected void CreateVm_Click(object sender, EventArgs e)
        {
            GridViewRow grdRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            VMDetails vmDetails = new VMDetails();
            string newPassword = Membership.GeneratePassword(10, 2);

            vmDetails.UserName = grdRow.Cells[0].Text.ToString();
            vmDetails.ServiceName = grdRow.Cells[1].Text.ToString();
            vmDetails.VMName = grdRow.Cells[2].Text.ToString();
            vmDetails.ImageName = grdRow.Cells[3].Text.ToString();
            vmDetails.InstanceSize = grdRow.Cells[4].Text.ToString();

            vmDetails.Password = newPassword;
            vmDetails.Location = "East Asia";

            string msg = new VMRequestHelper().CreateVM(vmDetails);

            TextBox1.Text = msg + "\n\n" + grdRow.Cells[0].Text + "\n" + grdRow.Cells[1].Text + "\n" + grdRow.Cells[2].Text + "\n" + grdRow.Cells[3].Text + "\n" + grdRow.Cells[4].Text + "\n" + newPassword;
        }
    }
}