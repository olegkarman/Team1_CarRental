using Microsoft.Data.SqlClient;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IDataContext
    {
        public SqlConnection OpenConnection(string connectionString);
        public void CloseConnection(SqlConnection connection);
    }
}
