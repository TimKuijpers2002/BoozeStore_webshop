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
                    Price = dto.Price
                });
            }
            return drink;
        }

        public void Delete(int drinkID)
        {
            DrinkFactory.drinkConnectionHandler.DeleteDrink(drinkID);
        }

        public void Update(DrinkModel drink)
        {
            var _dto = new DTODrink()
            {
                DrinkID = drink.DrinkID,
                Name = drink.Name,
                TypeID = drink.TypeID,
                Volume = drink.Volume,
                AlcoholPercentage = drink.AlcoholPercentage,
                AmountStored = drink.AmountStored,
                Price = drink.Price,
            };

            DrinkFactory.drinkConnectionHandler.UpdateDrink(_dto);
        }

        public void Create(DrinkModel drink)
        {
            var _dto = new DTODrink()
            {
                DrinkID = drink.DrinkID,
                Name = drink.Name,
                TypeID = drink.TypeID,
                Volume = drink.Volume,
                AlcoholPercentage = drink.AlcoholPercentage,
                AmountStored = drink.AmountStored,
                Price = drink.Price,
            };

            DrinkFactory.drinkConnectionHandler.CreateDrink(_dto);
        }
    }
}

