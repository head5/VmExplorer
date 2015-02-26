using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelperLibrary.B_Entity
{
    public enum Authentication_Result
    {
        Inactive_User,
        Incorrect_Password,
        Succeed,
        User_ID_Invalid
    }

    public class User
    {
        private string _mid;
        private string _username;
        private string _password;
        private bool _isadmin;
        private bool _isactive;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Fill User Details
        /// </summary>
        /// <param name="mid">User MID</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">User Password</param>
        /// <param name="isadmin">Is User Admin</param>
        /// <param name="isactive">Is User Active</param>
        public User(string mid, string userName, string password, bool isadmin, bool isactive)
        {
            MID = mid;
            UserName = userName;
            Password = password;
            IsAdmin = isadmin;
            IsActive = isactive;
        }

        public string MID
        {
            get { return _mid; }
            set { _mid = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool IsAdmin
        {
            get { return _isadmin; }
            set { _isadmin = value; }
        }

        public bool IsActive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
    }
}