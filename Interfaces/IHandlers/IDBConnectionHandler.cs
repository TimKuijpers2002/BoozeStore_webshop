using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Interfaces.IHandlers
{
    public interface IDBConnectionHandler
    {
        SqlConnection connection { get; }
        SqlConnection Open();
        void Close();
    }
}
