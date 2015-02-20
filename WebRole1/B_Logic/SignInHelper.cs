using System;
using System.Collections.Generic;
using WebRole.B_Entity;
using WebRole.B_Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRole.B_Logic
{
    public class SignInHelper
    {
        /// <summary>
        /// Authenticating the User from given Credentials
        /// </summary>
        /// <param name="userCredentials">SignIN Credentials</param>
        /// <returns>Authentication Result</returns>
        public string AuthenticateUser(User userCredentials)
        {
            string result = Authentication_Result.Succeed.ToString();

            DBHelper dbHelper = new DBHelper();
            List<User> users = dbHelper.AuthenticateUser(userCredentials.MID);

            if (users.Count == 0)
            {
                result = Authentication_Result.User_ID_Invalid.ToString();
            }
            else
            {
                User foundUser = users.FirstOrDefault(u => u.IsActive);
                if (foundUser == null)
                {
                    result = Authentication_Result.Inactive_User.ToString();
                }
                else if (!(foundUser.Password.Equals(userCredentials.Password, StringComparison.CurrentCulture)))
                {
                    result = Authentication_Result.Incorrect_Password.ToString();
                }
            }
            return result;
        }
    }
}
