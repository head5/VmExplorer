using System;
using System.Web.UI;
using WebRole.B_Entity;
using WebRole.B_Logic;

namespace WebRole
{
    public partial class _Default : Page
    {
        /// <summary>
        /// Page Load
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["USER"] = null;
            new VMRequestHelper().SetupAzureAccount();

            // Code to run only once at a time of first load.
            if (!IsPostBack)
            {
                
                lblMessage.Text = "Enter credentials to Sign IN.";
            }
        }

        /// <summary>
        /// Authenticate the given Credentials
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                lblMessage.Text = "Authenticating....";

                User logInUser = new User();
                logInUser.MID = txtUserID.Text;
                logInUser.Password = txtPassword.Text;

                SignInHelper signInHelper = new SignInHelper();
                string authResult = signInHelper.AuthenticateUser(logInUser);


                if (authResult.Equals(Authentication_Result.Succeed.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    Session["USER"] = logInUser;

                    // Redirect to VM Creation Page
                    Response.Redirect("~/B_UI/VMConfiguration.aspx");
                }
                else
                {
                    lblMessage.Text = authResult.Replace("_", " ");
                }
            }
        }

        /// <summary>
        /// Clear the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtUserID.Text = string.Empty;
            txtPassword.Text = string.Empty;
            lblMessage.Text = "Enter credentials to Sign IN.";
            txtUserID.Focus();
        }

        /// <summary>
        /// Validates the fields
        /// </summary>
        /// <returns>True/False</returns>
        private bool Validator()
        {
            if (txtUserID.Text.Equals(string.Empty))
            {
                lblMessage.Text = "Please provide User ID.";
            }
            else if (txtPassword.Text.Equals(string.Empty))
            {
                lblMessage.Text = "Please provide password.";
            }
            else
            {
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(txtPassword.Text,
                    @"(?=^.{8,12}$)((?=.*\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*");

                if (match.Success && match.Index == 0 && match.Length == txtPassword.Text.Length)
                {
                    return true;
                }
                lblMessage.Text = "Password length should be more that 7 characters and Password must contain at least one Capital alphabet, Numeric Value and a Special Character.";
            }
            return false;
        }
    }
}