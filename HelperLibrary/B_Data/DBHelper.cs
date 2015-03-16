using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HelperLibrary.B_Entity;
using System.Data;

namespace HelperLibrary.B_Data
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

            SqlCommand cmd = new SqlCommand("GetUsers");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramMID = cmd.Parameters.Add
            ("@mid", System.Data.SqlDbType.VarChar, 11);
            paramMID.Direction = ParameterDirection.Input;
            paramMID.Value = userMID;

            SqlConnection sqlCon = dbCon.GetSQLConnection();
            sqlCon.Open();
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                int ra = reader.RecordsAffected;

                while (reader.Read())
                {
                    User dbuser = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        (reader.GetString(4).Equals("Y", StringComparison.CurrentCultureIgnoreCase) ? true : false),
                        (reader.GetString(5).Equals("Y", StringComparison.CurrentCultureIgnoreCase) ? true : false));

                    resultUsers.Add(dbuser);
                }
            }

            return resultUsers;
        }

        /// <summary>
        /// Get List for all VM Instance Sizes
        /// </summary>
        /// <returns>Set of all VM Instance Sizes</returns>
        public List<InstanceSize> GetVMInstanceSizes()
        {
            List<InstanceSize> vmSizes = new List<InstanceSize>();

            SqlCommand cmd = new SqlCommand("GetVMInstanceSizes");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlConnection sqlCon = dbCon.GetSQLConnection();
            sqlCon.Open();
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    InstanceSize vmSize = new InstanceSize(reader.GetSqlInt32(0).Value, reader.GetString(1),
                        reader.GetString(2), reader.GetString(3),
                        (reader.GetString(4).Equals("Y", StringComparison.CurrentCultureIgnoreCase) ? true : false));

                    vmSizes.Add(vmSize);
                }
            }
            return vmSizes;
        }

        /// <summary>
        /// Get List of all Status types for VM Request
        /// </summary>
        /// <returns>List of all Status types</returns>
        public List<VMRequestStatus> GetVMRequestStatus()
        {
            List<VMRequestStatus> statuses = new List<VMRequestStatus>();

            SqlCommand cmd = new SqlCommand("GetVMRequestStatusTypes");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlConnection sqlCon = dbCon.GetSQLConnection();
            sqlCon.Open();
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    VMRequestStatus status = new VMRequestStatus(reader.GetSqlInt32(0).Value, reader.GetString(1));

                    statuses.Add(status);
                }
            }
            return statuses;
        }

        /// <summary>
        /// Get all valid Locations
        /// </summary>
        /// <returns>List of Locations</returns>
        public List<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();

            SqlCommand cmd = new SqlCommand("GetLocations");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlConnection sqlCon = dbCon.GetSQLConnection();
            sqlCon.Open();
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Location location = new Location(((int)reader.GetInt32(0)), reader.GetString(1));

                    locations.Add(location);
                }
            }
            return locations;
        }

        /// <summary>
        /// Adds the VM Request in two tables: Details in one and Status in another.
        /// </summary>
        /// <param name="vmDetails">All Details/Configurations</param>
        /// <param name="user">Current User</param>
        /// <returns>TRUE if VM Request Added</returns>
        public bool AddVMRequest(VMDetails vmDetails)
        {
            SqlCommand cmd = new SqlCommand("AddVMRequest");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramMID = cmd.Parameters.Add("@mid", SqlDbType.VarChar, 11);
            paramMID.Direction = ParameterDirection.Input;
            paramMID.Value = vmDetails.MID;

            SqlParameter paramVmName = cmd.Parameters.Add("@vm_name", SqlDbType.VarChar, 20);
            paramVmName.Direction = ParameterDirection.Input;
            paramVmName.Value = vmDetails.VMName;

            SqlParameter paramVmInstanceSize = cmd.Parameters.Add("@vminstance_size_id", SqlDbType.Int);
            paramVmInstanceSize.Direction = ParameterDirection.Input;
            paramVmInstanceSize.Value = vmDetails.InstanceSize;

            SqlParameter paramImageName = cmd.Parameters.Add("@image_name", SqlDbType.VarChar, 500);
            paramImageName.Direction = ParameterDirection.Input;
            paramImageName.Value = vmDetails.ImageName;

            SqlParameter paramLocationID = cmd.Parameters.Add("@location_id", SqlDbType.Int);
            paramLocationID.Direction = ParameterDirection.Input;
            paramLocationID.Value = vmDetails.Location;

            SqlParameter paramVmRequestStatus = cmd.Parameters.Add("@vm_request_status", SqlDbType.VarChar, 10);
            paramVmRequestStatus.Direction = ParameterDirection.Input;
            paramVmRequestStatus.Value = vmDetails.Status.Status;

            SqlParameter paramVmRequestStatusID = cmd.Parameters.Add("@vm_request_status_id", SqlDbType.Int);
            paramVmRequestStatusID.Direction = ParameterDirection.Input;
            paramVmRequestStatusID.Value = vmDetails.Status.StatusID;

            SqlParameter paramResult = new SqlParameter("@result", SqlDbType.VarChar, 25);
            paramResult.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramResult);

            SqlConnection sqlCon = dbCon.GetSQLConnection();
            sqlCon.Open();
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();

            return paramResult.Value.ToString().Equals("Success");
        }

        /// <summary>
        /// Gets the VM Requests of given User and Of given Status Type
        /// </summary>
        /// <param name="userMID">User MID</param>
        /// <param name="statusType">Request Status Type</param>
        /// <returns>DataView of User Requests</returns>
        public DataView GetUserVMRequests(string userMID, string statusType)
        {
            DataView dvRequests = new DataView();
            try
            {
                string datasetName = "VMRequests";
                DataSet dsVMRequests = new DataSet(datasetName);

                SqlCommand cmd = new SqlCommand("GetVMRequestsOfUser");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramMID = cmd.Parameters.Add("@mid", SqlDbType.VarChar, 11);
                paramMID.Direction = ParameterDirection.Input;
                paramMID.Value = userMID;

                SqlParameter paramStatus = cmd.Parameters.Add("@status", SqlDbType.VarChar, 10);
                paramStatus.Direction = ParameterDirection.Input;
                paramStatus.Value = statusType;

                SqlConnection sqlCon = dbCon.GetSQLConnection();
                cmd.Connection = sqlCon;

                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                sqlCon.Open();

                da.Fill(dsVMRequests);

                dvRequests = dsVMRequests.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {

            }
            return dvRequests;
        }

        /// <summary>
        /// Cancels the VM Request by calling Stored Procedure 'CancelVMRequest'
        /// </summary>
        /// <param name="requestID">VM Request ID to Cancel</param>
        /// <param name="userID">Cancel by User</param>
        /// <param name="status">Cancel Status Object</param>
        /// <returns>TRUE if Cancelled successfully</returns>
        public bool CancelVMRequest(int requestID, string userID, VMRequestStatus status)
        {
            SqlCommand cmd = new SqlCommand("CancelVMRequest");
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramRequestID = cmd.Parameters.Add("@request_id", SqlDbType.Int);
            paramRequestID.Direction = ParameterDirection.Input;
            paramRequestID.Value = requestID;
            
            SqlParameter paramMID = cmd.Parameters.Add("@mid", SqlDbType.VarChar, 11);
            paramMID.Direction = ParameterDirection.Input;
            paramMID.Value = userID;

            SqlParameter paramVmRequestStatus = cmd.Parameters.Add("@vm_request_status", SqlDbType.VarChar, 10);
            paramVmRequestStatus.Direction = ParameterDirection.Input;
            paramVmRequestStatus.Value = status.Status;

            SqlParameter paramVmRequestStatusID = cmd.Parameters.Add("@vm_request_status_id", SqlDbType.Int);
            paramVmRequestStatusID.Direction = ParameterDirection.Input;
            paramVmRequestStatusID.Value = status.StatusID;

            SqlParameter paramResult = new SqlParameter("@result", SqlDbType.VarChar, 25);
            paramResult.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramResult);

            SqlConnection sqlCon = dbCon.GetSQLConnection();
            sqlCon.Open();
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();

            return paramResult.Value.ToString().Equals("Success");
        }
    }
}
