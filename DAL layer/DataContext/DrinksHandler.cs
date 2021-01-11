using DTO_layer.DTO_s;
using Interfaces.IHandlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_layer.DataContext
{
    public class DrinksHandler : IDrinksHandler
    {
        private DBConnectionHandler _dbCon;

        public DrinksHandler(DBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }

        public List<DTODrink> GetDrinks()
        {
            var drinks = new List<DTODrink>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [dbi431200].[dbo].[Drink]";
                //using, closes the connection at the end for you.
                // ||
                // \/
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DTODrink DrinkDTO = new DTODrink
                        {
                            DrinkID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Volume = reader.GetInt32(2),
                            AlcoholPercentage = reader.GetDecimal(3),
                            AmountStored = reader.GetInt32(4),
                            Price = reader.GetDecimal(5),
                            ImageLink = reader.GetString(6)

                        };

                        drinks.Add(DrinkDTO);
                    }
                }
            }
            return drinks;
        }

        public void CreateDrink(DTODrink D1)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO Drink (Name, Volume, AlcoholPercentage, AmountStored, Price, ImageLink) VALUES (@Name, @Volume, @AlcoholPercentage, @AmountStored, @Price, @ImageLink);";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@Name", D1.Name);
                    command.Parameters.AddWithValue("@Volume", D1.Volume);
                    command.Parameters.AddWithValue("@AlcoholPercentage", D1.AlcoholPercentage);
                    command.Parameters.AddWithValue("@AmountStored", D1.AmountStored);
                    command.Parameters.AddWithValue("@Price", D1.Price);
                    command.Parameters.AddWithValue("@ImageLink", D1.ImageLink);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDrink(DTODrink U1)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE Drink Set Name = @Name, Volume = @Volume, AlcoholPercentage = @AlcoholPercentage, AmountStored = @AmountStored, Price = @Price, ImageLink = @ImageLink WHERE DrinkID = @DrinkID;";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@DrinkID", U1.DrinkID);
                    command.Parameters.AddWithValue("@Name", U1.Name);
                    command.Parameters.AddWithValue("@Volume", U1.Volume);
                    command.Parameters.AddWithValue("@AlcoholPercentage", U1.AlcoholPercentage);
                    command.Parameters.AddWithValue("@AmountStored", U1.AmountStored);
                    command.Parameters.AddWithValue("@Price", U1.Price);
                    command.Parameters.AddWithValue("@ImageLink", U1.ImageLink);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDrink(int drinkID)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM Drink WHERE DrinkID=@DrinkID";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@DrinkID", drinkID);
                    _dbCon.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
