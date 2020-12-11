using DTO_layer.DTO_s;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_layer.DataContext
{
    public class ShoppingCartHandler : IShoppingCartHandler
    {

        private IDBConnectionHandler _dbCon;

        public ShoppingCartHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }

        public void CreateShoppingCart(DTOShoppingCart C1)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO ShoppingCart (CartID, CustomerID, TotalPrice, CreationTime) VALUES (@CartID, @CustomerID, @TotalPrice, @CreationTime);";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@CartID", C1.CartID);
                    command.Parameters.AddWithValue("@CustomerID", C1.CustomerID);
                    command.Parameters.AddWithValue("@TotalPrice", C1.TotalPrice);
                    command.Parameters.AddWithValue("@CreationTime", C1.CreationTime);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteShoppingCart(string cartID)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM ShoppingCart WHERE CartID=@CartID";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@CartID", cartID);
                    _dbCon.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<DTOShoppingCart> GetShoppingCarts()
        {
            var carts = new List<DTOShoppingCart>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [dbi431200].[dbo].[ShoppingCart]";
                //using, closes the connection at the end for you.
                // ||
                // \/
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DTOShoppingCart CartDTO = new DTOShoppingCart
                        {
                            CartID = reader.GetString(0),
                            CustomerID = reader.GetString(1),
                            TotalPrice = reader.GetDecimal(2),
                            CreationTime = reader.GetDateTime(3)
                        };

                        carts.Add(CartDTO);
                    }
                }
            }
            return carts;
        }

        public void UpdateShoppingCart(DTOShoppingCart UC1)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE ShoppingCart Set TotalPrice = @TotalPrice WHERE CartID = @CartID;";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@CartID", UC1.CartID);
                    command.Parameters.AddWithValue("@CustomerID", UC1.CustomerID);
                    command.Parameters.AddWithValue("@TotalPrice", UC1.TotalPrice);
                    command.Parameters.AddWithValue("@CreationTime", UC1.CreationTime);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
