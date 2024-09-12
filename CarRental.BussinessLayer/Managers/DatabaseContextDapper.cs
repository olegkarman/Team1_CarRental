using Microsoft.Data.SqlClient;
using CarRental.BussinessLayer.Interfaces;

namespace CarRental.BussinessLayer.Managers
{
    public class DatabaseContextDapper : IDataContext
    {
        public string ShowConnectionInfo(SqlConnection connection)
        {
            string info;

            info = $"ID WORKSTATION: {connection.WorkstationId}\nSERVER VERSION: {connection.ServerVersion}\nPACKET SIZE: {connection.PacketSize}";

            return info;
        }

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
