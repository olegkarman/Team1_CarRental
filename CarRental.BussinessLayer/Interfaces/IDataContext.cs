using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IDataContext
    {
        public SqlConnection OpenConnection(string connectionString);
        public void CloseConnection(SqlConnection connection);
    }
}
