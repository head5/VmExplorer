using System;
using System.Collections.Generic;
using HelperLibrary.B_Entity;
using HelperLibrary.B_Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.B_Logic
{
    public class SignInHelper
    {
        /// <summary>
        /// Authenticating the User from given Credentials
        /// </summary>
        /// <param name="userCredentials">SignIN Credentials</param>
        /// <returns>Authentication Result</returns>
        public string AuthenticateUser(User userCredentials, out User authUser)
        {
            string result = Authentication_Result.Succeed.ToString();
            authUser = new User();

            DBHelper dbHelper = new DBHelper();
            List<User> users = dbHelper.AuthenticateUser(userCredentials.MID);

            if (users.Count == 0)
            {
                result = Authentication_Result.User_ID_Invalid.ToString();
            }
            else
            {
                authUser = users.FirstOrDefault(u => u.IsActive);

                if (authUser == null)
                {
                    result = Authentication_Result.Inactive_User.ToString();
                }
                else if (!(authUser.Password.Equals(userCredentials.Password, StringComparison.CurrentCulture)))
                {
                    result = Authentication_Result.Incorrect_Password.ToString();
                }
            }

            return result;
        }
    }
}
