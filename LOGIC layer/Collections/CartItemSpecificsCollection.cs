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
        public List<CartSpecificsModel> GetAllSpecifics(List<string> keyIDs, List<DrinkModel> drinks)
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
    }
}
