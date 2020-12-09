using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_layer.DataContext
{
    public class DBConnectionHandler : IDBConnectionHandler
    {
        private static string connectionString = "";

        public static void SetConnectionString(string constring)
        {
            connectionString = constring;
        }
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
