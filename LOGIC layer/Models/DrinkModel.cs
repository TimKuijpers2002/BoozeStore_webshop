using DAL_factory.Factories;
using DTO_layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC_layer.Models
{
    public class DrinkModel
    {
        public int DrinkID { get; }
        public string Name { get; }
        public int TypeID { get; }
        public int Volume { get; }
        public decimal AlcoholPercentage { get; }
        public int AmountStored { get; }
        public decimal Price { get; }
        public string ImageLink { get; }

        public DrinkModel(int drinkID, string name, int typeID, int volume, decimal alcoholpercentage, int amountstored, decimal price, string imagelink)
        {
            DrinkID = drinkID;
            Name = name;
            TypeID = typeID;
            Volume = volume;
            AlcoholPercentage = alcoholpercentage;
            AmountStored = amountstored;
            Price = price;
            ImageLink = imagelink;
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
                ImageLink = drink.ImageLink
            };

            DrinkFactory.drinkConnectionHandler.UpdateDrink(_dto);
        }
    }
}

