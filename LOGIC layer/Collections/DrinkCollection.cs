using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using LOGIC_layer.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class DrinkCollection
    {
        private DrinkValidation drinkValidation;
        private List<DrinkModel> drinks;

        public DrinkCollection()
        {
            drinkValidation = new DrinkValidation();
        }
        public void Create(DrinkModel drink)
        {

                var _dto = new DTODrink()
                {
                    DrinkID = drink.DrinkID,
                    Name = drink.Name,
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
            drinks = new List<DrinkModel>();
            foreach (var dto in result)
            {
                drinks.Add(new DrinkModel(dto.DrinkID,dto.Name,dto.Volume,dto.AlcoholPercentage,dto.AmountStored,dto.Price,dto.ImageLink));
            }
            return drinks;
        }

        public List<DrinkModel> SearchForDrinks(string searchText)
        {
            var all = GetAllDrinks();
            drinks = new List<DrinkModel>();

            if (!string.IsNullOrEmpty(searchText))
            {
                var result = all.Where(d => d.Name.Contains(searchText));
                foreach (var unconvertedArticle in result)
                {
                    DrinkModel model = new DrinkModel(unconvertedArticle.DrinkID, unconvertedArticle.Name, unconvertedArticle.Volume, unconvertedArticle.AlcoholPercentage, unconvertedArticle.AmountStored, unconvertedArticle.Price, unconvertedArticle.ImageLink);
                    drinks.Add(model);
                }
                return drinks;
            }
            else
            {
                return all;
            }
        }

        public List<DrinkModel> GetDrinkByID(int ID)
        {
            var result = GetAllDrinks();
            return result.Where(d => d.DrinkID == ID).ToList();
        } 
    }
}
