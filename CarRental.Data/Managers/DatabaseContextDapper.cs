using Microsoft.Data.SqlClient;

namespace CarRental.BussinessLayer.Managers
{
    public class DatabaseContextDapper
    {
        public SqlConnection OpenConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
        }

        public void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }
    }
}
