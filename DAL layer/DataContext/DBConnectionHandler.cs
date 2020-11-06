using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_layer.DataContext
{
    public class DBConnectionHandler : IDBConnectionHandler
    {
        private protected string connectionString = "Server=mssql.fhict.local;Database=dbi431200;User Id=dbi431200;Password=TimK2002;";
        public SqlConnection connection { get; private set; }
        public SqlConnection Open()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
