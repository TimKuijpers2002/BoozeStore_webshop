using DTO_layer.DTO_s;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_layer.DataContext
{
    public class CartItemsHandler : ICartItemsHandler
    {
        private DBConnectionHandler _dbCon;

        public CartItemsHandler(DBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }

        public void CreateOrder(DTOOrder O1)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO CartItems (CartID, DrinkID, Quantity) VALUES (@CartID, @DrinkID, @Quantity);";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@CartID", O1.CartID);
                    command.Parameters.AddWithValue("@DrinkID", O1.DrinkID);
                    command.Parameters.AddWithValue("@Quantity", O1.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(string ID)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM CartItems WHERE CartID=@CartID";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@CartID", ID);
                    _dbCon.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<DTOOrder> GetOrders()
        {
            var orders = new List<DTOOrder>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [dbi431200].[dbo].[CartItems]";
                //using, closes the connection at the end for you.
                // ||
                // \/
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DTOOrder OrderDTO = new DTOOrder
                        {
                            CartID = reader.GetString(0),
                            DrinkID = reader.GetInt32(1),
                            Quantity = reader.GetInt32(2),

                        };

                        orders.Add(OrderDTO);
                    }
                }
            }
            return orders;
        }

        public void UpdateOrder(DTOOrder UO1)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE CartItems Set DrinkID = @DrinkID, Quantity = @Quantity WHERE CartID = @CartID;";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@CartID", UO1.CartID);
                    command.Parameters.AddWithValue("@DrinkID", UO1.DrinkID);
                    command.Parameters.AddWithValue("@Quantity", UO1.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
