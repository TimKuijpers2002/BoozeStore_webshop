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
                ImageLink = drink.ImageLink
            };

            DrinkFactory.drinkConnectionHandler.UpdateDrink(_dto);
        }
    }
}
