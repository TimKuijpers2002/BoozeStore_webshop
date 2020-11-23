using DTO_layer.DTO_s;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_layer.DataContext
{
    public class CustomerHandler : ICustomerHandler
    {
        private IDBConnectionHandler _dbCon;

        public CustomerHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }
        public void CreateCustomer(DTOCustomer C1)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO Customer (Name, Adress, Email) VALUES (@Name, @Adress, @Email);";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@Name", C1.Name);
                    command.Parameters.AddWithValue("@Adress", C1.Adress);
                    command.Parameters.AddWithValue("@Email", C1.Email);


                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int ID)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID;";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                        command.Parameters.AddWithValue("@CustomerID", ID);
                        _dbCon.Open();
                        command.ExecuteNonQuery();  
                }
            }
        }
    }
}
