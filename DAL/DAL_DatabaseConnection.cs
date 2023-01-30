using Microsoft.Data.SqlClient;

namespace EksamenFinish.DAL
{
    // Handles the connection to the Database
    
    public class DAL_DatabaseConnection
    {
        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "10.56.8.37",
                UserID = "STUDENT26",
                Password = "OPENDB_26",
                InitialCatalog = "DB26",
                TrustServerCertificate = true
            };
            return builder.ConnectionString;
        }
    }
}