using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole.B_UI
{
    public partial class Detail : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["USER"] == null)
            //{
            //    Response.Write("<script>alert('Your session is expired. Please SignIn again.');</script>");
            //    Response.Redirect("~/SignIn.aspx");
            //}
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //if (Session["USER"] == null)
            //{
            //    Response.Write("<script>alert('Your session is expired. Please SignIn again.');</script>");
            //    Response.Redirect("~/SignIn.aspx");
            //}

            //if (!IsPostBack)
            //{
 
            //}
        }
    }
}