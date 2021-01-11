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
        private DBConnectionHandler _dbCon;

        public CustomerHandler(DBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }
        public void CreateCustomer(DTOCustomer C1)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO Customer (CustomerID, Name, Adress, Email) VALUES (@CustomerID, @Name, @Adress, @Email);";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@CustomerID",C1.CustomerID);
                    command.Parameters.AddWithValue("@Name", C1.Name);
                    command.Parameters.AddWithValue("@Adress", C1.Adress);
                    command.Parameters.AddWithValue("@Email", C1.Email);


                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(string ID)
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

        public List<DTOCustomer> GetCustomers()
        {
            var customers = new List<DTOCustomer>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [dbi431200].[dbo].[Customer]";
                //using, closes the connection at the end for you.
                // ||
                // \/
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DTOCustomer customerDTO = new DTOCustomer
                        {
                            CustomerID = reader.GetString(0),
                            Name = reader.GetString(1),
                            Adress = reader.GetString(2),
                            Email = reader.GetString(3)
                        };

                        customers.Add(customerDTO);
                    }
                }
            }
            return customers;
        }
    }
}
