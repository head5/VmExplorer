using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebRole.B_Entity;

namespace WebRole.B_Data
{
    public class DBHelper
    {
        Connections dbCon;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DBHelper()
        {
            dbCon = new Connections();
        }

        /// <summary>
        /// Querying the database for users matching with given MID
        /// </summary>
        /// <param name="userMID">User MID from credentials</param>
        /// <returns>The set of matching record for the given user MID</returns>
        public List<User> AuthenticateUser(string userMID)
        {
            List<User> resultUsers = new List<User>();
            string query = string.Format("SELECT MId, UserName, Password, Admin, Active FROM Users WHERE MId='{0}'", userMID);
            SqlDataReader reader = dbCon.ExecuteSqlCommand(query);

            if (reader.HasRows)
            {
                int ra = reader.RecordsAffected;

                while (reader.Read())
                {
                    User dbuser = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        (reader.GetString(3).Equals("Y", StringComparison.CurrentCultureIgnoreCase) ? true : false),
                        (reader.GetString(4).Equals("Y", StringComparison.CurrentCultureIgnoreCase) ? true : false));

                    resultUsers.Add(dbuser);
                }
            }

            return resultUsers;
        }

        /// <summary>
        /// Querying the database for all VM Instance Sizes
        /// </summary>
        /// <returns>Set of all VM Instance Sizes</returns>
        public List<VMInstanceSize> GetVMInstanceSizes()
        {
            List<VMInstanceSize> vmSizes = new List<VMInstanceSize>();
            string query = "SELECT ID, Name, Memory, Core, Active FROM VM_Instance_Size";

            SqlDataReader reader = dbCon.ExecuteSqlCommand(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    VMInstanceSize vmSize = new VMInstanceSize(reader.GetSqlInt32(0).Value, reader.GetString(1),
                        reader.GetString(2), reader.GetString(3),
                        (reader.GetString(4).Equals("Y", StringComparison.CurrentCultureIgnoreCase) ? true : false));
                    
                    vmSizes.Add(vmSize);
                }
            }
            return vmSizes;
        }

        /// <summary>
        /// Querying the database for all Status types for VM Request
        /// </summary>
        /// <returns>Set of all Status types</returns>
        public List<VMRequestStatus> GetVMRequestStatus()
        {
            List<VMRequestStatus> statuses = new List<VMRequestStatus>();
            string query = "SELECT Id, Status FROM VM_Request_Status";

            SqlDataReader reader = dbCon.ExecuteSqlCommand(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    VMRequestStatus status = new VMRequestStatus(((int)reader.GetInt64(0)), reader.GetString(1));

                    statuses.Add(status);
                }
            }
            return statuses;
        }
    }
}
