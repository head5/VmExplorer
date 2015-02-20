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
    public partial class VMDashBoard : System.Web.UI.Page
    {
        User authUser = null;
        VMRequestHelper vmReqHelper = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!(Session["USER"] == null))
                //{
                //    signInUser = (User)Session["USER"];
                //}

                authUser = new User("M1015156", "Anand", "P@ssw0rd", true, true);
                vmReqHelper = new VMRequestHelper();
            }
        }
    }
}