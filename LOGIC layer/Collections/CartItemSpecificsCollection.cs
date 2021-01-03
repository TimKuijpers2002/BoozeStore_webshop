using DAL_factory.Factories;
using LOGIC_layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class CartItemSpecificsCollection
    {
        private readonly CartItemCollection itemColl;
        private readonly DrinkCollection drinkColl;
        public CartItemSpecificsCollection()
        {
            itemColl = new CartItemCollection();
            drinkColl = new DrinkCollection();
        }
        public List<CartSpecificsModel> GetAllSpecificsWithDrinkID(List<string> keyIDs, List<DrinkModel> drinks)
        {
            var specifics = new List<CartSpecificsModel>();

            List<int> _DrinkIDs = keyIDs.Select(int.Parse).ToList();

            if (drinks != null)
            {
                for (int j = 0; j < _DrinkIDs.Count; j++)
                {

                    for (int i = 0; i < drinks.Count; i++)
                    {
                        if (_DrinkIDs[j] == drinks[i].DrinkID)
                        {
                            int Key = drinks[i].DrinkID;
                            var model = new CartSpecificsModel(drinks[i].Name, drinks[i].Price, drinks[i].ImageLink, "0", drinks[i].DrinkID, 0);
                            specifics.Add(model);
                        }
                    }
                }
            }
            else
            {

            }
            return specifics;
        }

        public List<CartSpecificsModel> GetAllSpecificsWithCartID(string CartID)
        {
            var specifics = new List<CartSpecificsModel>();
            var drinks = drinkColl.GetAllDrinks();
            var orders = itemColl.GetAllOrders();

            var results = orders.Where(o => o.CartID.Contains(CartID)).ToList();
            for (int i = 0; i < results.Count; i++)
            {
                for(int j = 0; j < drinks.Count; j++)
                {
                    if (results[i].DrinkID == drinks[j].DrinkID)
                    {
                        var model = new CartSpecificsModel(drinks[i].Name, drinks[i].Price, drinks[i].ImageLink, results[i].CartID, drinks[i].DrinkID, results[i].Quantity);
                        specifics.Add(model);
                    }
                }
            }
            return specifics;
        }
    }
}
