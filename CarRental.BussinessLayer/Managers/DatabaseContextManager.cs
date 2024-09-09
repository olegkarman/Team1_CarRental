using CarRental.BussinessLayer.Interfaces;
using Microsoft.Data.SqlClient;

namespace CarRental.BussinessLayer.Managers
{
    public class DatabaseContextManager : DatabaseContextDapper, IDataContext
    {
        public string ShowConnectionInfo(SqlConnection connection)
        {
            string info;

            info = $"ID WORKSTATION: {connection.WorkstationId}\nSERVER VERSION: {connection.ServerVersion}\nPACKET SIZE: {connection.PacketSize}";

            return info;
        }
    }
}
