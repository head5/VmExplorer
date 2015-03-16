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
    public partial class VMDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USER"] = new User("M1015156", "Mindtree", "Anand", "P@ssw0rd1", true, true);
                //Session["StatusTypes"] = new VMRequestHelper().GetStatusTypesForUser();

                gvRequests.AllowSorting = true;
                ViewState["SortExpression"] = "VMName ASC";

                gvRequests.AllowPaging = true;
                gvRequests.PageSize = 2;

                PopulateStatusTypes();
                BindVMRequestGrid();
            }
        }

        protected void btnCreateVM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/B_UI/VMConfiguration.aspx");
        }

        protected void gvRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Check if current row is not Header Row
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the background color of alternate Rows
                if ((e.Row.RowIndex % 2) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }


                // If request is cancelled then Disable the Cancel LinkButton
                if (e.Row.Cells[5].Text.Equals("Cancelled"))
                {
                    ((LinkButton)e.Row.Cells[6].Controls[0]).Enabled = false;
                }
                else
                {
                    //Provide JavaScript confirm box before Cancelling VM Request.
                    // Make sure the current GridViewRow is either in the normal state or an alternate row. 
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes["onclick"] = "if(!confirm('Are you sure you want to cancel this VM Request ?')) return false;";
                    }
                }
            }

            // Set Border to All Columns with Color and Width
            string colStyle = "border-left:1px Double SteelBlue;";

            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Attributes.Add("style", colStyle);
            }
        }

        protected void gvRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            gvRequests.PageIndex = e.NewPageIndex;


            // Rebind the GridView control to  
            // show data in the new page. 
            BindVMRequestGrid();
        }

        protected void gvRequests_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] strSortExpression = ViewState["SortExpression"].ToString().Split(' ');


            // If the sorting column is the same as the previous one,  
            // then change the sort order. 
            if (strSortExpression[0] == e.SortExpression)
            {
                if (strSortExpression[1] == "ASC")
                {
                    ViewState["SortExpression"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
                }
            }
            // If sorting column is another column,   
            // then specify the sort order to "Ascending". 
            else
            {
                ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
            }


            // Rebind the GridView control to show sorted data. 
            BindVMRequestGrid(); 

        }

        protected void gvRequests_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int vmReqID = (int)gvRequests.DataKeys[e.RowIndex].Value;
            VMRequestStatus cancelledStatus = GetVMRequestStatus("Cancelled");


            if (new VMRequestHelper().CancelVMRequest(vmReqID,((User)Session["USER"]).MID, cancelledStatus))
            {
                BindVMRequestGrid();
            }
        }

        protected void ddStatusTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVMRequestGrid();
        }

        /// <summary>
        /// Populates VM Request Statuses in dropdown
        /// </summary>
        private void PopulateStatusTypes()
        {
            ddStatusTypes.Items.Add(new ListItem("ALL", "-1"));

            foreach (VMRequestStatus status in ((List<VMRequestStatus>)Session["StatusTypes"]))
            {
                ddStatusTypes.Items.Add(new ListItem(status.Status, status.StatusID.ToString()));
            }
        }

        /// <summary>
        /// Populates the VM Requests of Current User
        /// </summary>
        private void BindVMRequestGrid()
        {
            System.Data.DataView dvRequests = new VMRequestHelper().GetUserVMRequests(((User)Session["USER"]).MID, ddStatusTypes.SelectedItem.Text);
            dvRequests.Sort = ViewState["SortExpression"].ToString();

            gvRequests.DataSource = dvRequests;
            gvRequests.DataBind();
        }

        /// <summary>
        /// Returns VM Request Status object
        /// </summary>
        /// <param name="statusType">Expected Status Type</param>
        /// <returns>vm request status object</returns>
        private VMRequestStatus GetVMRequestStatus(string statusType)
        {
            List<VMRequestStatus> statuses = (List<VMRequestStatus>)Session["StatusTypes"];
            if (statuses.Equals(null))
            {
                statuses = new VMRequestHelper().GetStatusTypesForUser();
            }

            VMRequestStatus status = statuses.First(s => s.Status.Contains(statusType));
           
            return status;
        }

    }
}