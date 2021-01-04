using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                drink.Add(new DrinkModel(dto.DrinkID,dto.Name,dto.TypeID,dto.Volume,dto.AlcoholPercentage,dto.AmountStored,dto.Price,dto.ImageLink));
            }
            return drink;
        }

        public List<DrinkModel> SearchForDrinks(string searchText)
        {
            var all = GetAllDrinks();
            var drinkResult = new List<DrinkModel>();

            if (!string.IsNullOrEmpty(searchText))
            {
                var result = all.Where(d => d.Name.Contains(searchText));
                foreach (var unconvertedArticle in result)
                {
                    DrinkModel model = new DrinkModel(unconvertedArticle.DrinkID, unconvertedArticle.Name, unconvertedArticle.TypeID, unconvertedArticle.Volume, unconvertedArticle.AlcoholPercentage, unconvertedArticle.AmountStored, unconvertedArticle.Price, unconvertedArticle.ImageLink);
                    drinkResult.Add(model);
                }
                return drinkResult;
            }
            else
            {
                return all;
            }
        }
    }
}
