using System.Data.SqlClient;

namespace HelperLibrary.B_Data
{
    public class Connections
    {
        SqlConnection sqlCon;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Connections()
        {
        }

        /// <summary>
        /// Create connection to SQL DB in cloud using Configured Connection String
        /// </summary>
        private void CreateCloudSQLDBConnection()
        {
            //SQLDBConnection con = new SQLDBConnection();
            sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            sqlCon.Open();
        }

        /// <summary>
        /// Executes given query on database
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <returns>Result Set of Query Execution</returns>
        public SqlDataReader ExecuteSqlCommand(string sqlQuery)
        {
            string result = string.Empty;

            CreateCloudSQLDBConnection();

            SqlCommand command = new SqlCommand(sqlQuery, sqlCon);

            return command.ExecuteReader();
        }

        public string ExecuteSqlStoredProc(string sqlQuery)
	{
		return "";
	}

    }
}
