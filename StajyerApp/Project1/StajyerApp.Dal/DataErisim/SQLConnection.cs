using System.Data;
using System.Data.SqlClient;

namespace StajyerApp.Dal.DataErisim
{
    public class SQLConnection
    {
        
        public static string ConnectionString;
        public static SqlConnection GetConnection()
        {
            ConnectionString = "Data Source=193.1.1.17\\TVS_MSSQLSERVER;Initial Catalog=db_kutuphane ;User ID=ebim; Password=11";
            SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;     
        }
        public static void ConnectionClose(SqlConnection cnn)
        {
            if (cnn == null)
            {
                return;
            }

            if (cnn.State != ConnectionState.Closed && cnn.State != ConnectionState.Broken)
            {
                cnn.Dispose();
            }
        }
        public void setDB(string db)
        {
            
            
        }
    }
}
