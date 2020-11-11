using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class DrinkCollection
    {
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
                ImageLink = drink.ImageLink
            };

            DrinkFactory.drinkConnectionHandler.CreateDrink(_dto);
        }

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


    }
}
