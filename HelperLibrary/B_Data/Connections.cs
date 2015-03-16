using System.Data.SqlClient;

namespace HelperLibrary.B_Data
{
    public class Connections
    {
        private string cloudsqlConnection = string.Empty;
        private string localSqllConnection = string.Empty;
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Connections()
        {
            localSqllConnection = "Data Source=(localdb)\\Projects;Initial Catalog=DBVMExplorer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            cloudsqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        }

        /// <summary>
        /// Return Connection Object to SQL DB (local/cloud)
        /// </summary>
        /// <returns>SQL Connection Object</returns>
        public SqlConnection GetSQLConnection()
        {
            return (new SqlConnection(localSqllConnection));
        }
    }

}
