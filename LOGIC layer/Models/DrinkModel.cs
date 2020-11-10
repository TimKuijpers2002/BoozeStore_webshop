using DAL_factory.Factories;
using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Models
{
    public class DrinkModel
    {
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public int TypeID { get; set; }
        public int Volume { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public int AmountStored { get; set; }
        public decimal Price { get; set; }
        public string ImageLink { get; set; }

        public List<DrinkModel> GetAllDrinks()
        {
            var result = DrinkFactory.drinkConnectionHandler.GetDrinks();
            var drink = new List<DrinkModel>();
            foreach (var dto in result)
            {
                drink.Add(new DrinkModel
                {
                    DrinkID = dto.DrinkID,
                    Name = dto.Name,
                    TypeID = dto.TypeID,
                    Volume = dto.Volume,
                    AlcoholPercentage = dto.AlcoholPercentage,
                    AmountStored = dto.AmountStored,
                    Price = dto.Price,
                    ImageLink = dto.ImageLink
                });
            }
            return drink;
        }

        public void Delete(int drinkID)
        {
            DrinkFactory.drinkConnectionHandler.DeleteDrink(drinkID);
        }
    }
}

